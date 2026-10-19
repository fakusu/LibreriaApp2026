using LibreriaApp2026.Datos;
using LibreriaApp2026.Entidades;
using LibreriaApp2026.Servicios.Common;
using LibreriaApp2026.Servicios.DTOs.LibroFisico;
using LibreriaApp2026.Servicios.Interfaces;
using LibreriaApp2026.Servicios.Mapeadores;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LibreriaApp2026.Servicios.Servicios
{
    public class LibroFisicoServicio : ILibroFisicoServicio
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<LibroFisicoCreateDto> _createValidator;
        private readonly IValidator<LibroFisicoUpdateDto> _updateValidator;

        public LibroFisicoServicio(
            IUnitOfWork unitOfWork,
            IValidator<LibroFisicoCreateDto> createValidator,
            IValidator<LibroFisicoUpdateDto> updateValidator)
        {
            _unitOfWork = unitOfWork;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public Result Agregar(LibroFisicoCreateDto libroDto)
        {
            // 1. Validar DTO antes del mapeo
            var result = _createValidator.Validate(libroDto);
            if (!result.IsValid)
            {
                return Result.Failure(result.Errors.Select(e => e.ErrorMessage).ToList());
            }

            // 2. Mapear a Entidad
            var libro = LibroFisicoMapper.ToEntidad(libroDto);

            // 3. Regla de negocio: Duplicados (el ISBN es único entre todos los libros)
            if (_unitOfWork.LibrosFisicos.Existe(libro))
            {
                return Result.Failure($"Ya existe un libro con el ISBN {libro.ISBN}.");
            }

            try
            {
                _unitOfWork.LibrosFisicos.Agregar(libro);
                _unitOfWork.Save();
                return Result.Success();
            }
            catch (Exception ex)
            {
                _unitOfWork.RollBack();
                return Result.Failure($"Error al intentar agregar el libro: {ex.Message}");
            }
        }

        public Result Editar(LibroFisicoUpdateDto libroDto)
        {
            // 1. Validar DTO antes de tocar la BD o mapear
            var result = _updateValidator.Validate(libroDto);
            if (!result.IsValid)
            {
                return Result.Failure(result.Errors.Select(e => e.ErrorMessage).ToList());
            }

            // 2. Obtener entidad existente
            var libro = _unitOfWork.LibrosFisicos.ObtenerPorId(libroDto.ProductoId);
            if (libro == null)
            {
                return Result.Failure("Libro no encontrado.");
            }

            // 3. Modificar propiedades
            libro.Nombre = libroDto.Titulo;
            libro.Descripcion = libroDto.Descripcion;
            libro.ISBN = libroDto.ISBN;
            libro.AnioPublicacion = libroDto.AnioPublicacion;
            libro.Stock = libroDto.Stock;
            libro.Precio = libroDto.Precio;
            libro.EditorialId = libroDto.EditorialId;
            libro.PesoEnGramos = libroDto.PesoEnGramos;
            libro.CantidadPaginas = libroDto.CantidadPaginas;
            libro.Activo = libroDto.Activo;

            // 4. Regla de negocio: Duplicados (excluyendo el propio registro)
            if (_unitOfWork.LibrosFisicos.Existe(libro))
            {
                var mensaje = $"Ya existe otro libro con el ISBN {libro.ISBN}.";
                _unitOfWork.RollBack();
                return Result.Failure(mensaje);
            }

            try
            {
                _unitOfWork.LibrosFisicos.Editar(libro, libro.ProductoId);
                _unitOfWork.Save();
                return Result.Success();
            }
            catch (Exception ex)
            {
                _unitOfWork.RollBack();
                return Result.Failure($"Error al intentar editar el libro: {ex.Message}");
            }
        }

        public Result Borrar(int id)
        {
            var libro = _unitOfWork.LibrosFisicos.ObtenerPorId(id);
            if (libro == null)
            {
                return Result.Failure("Libro no encontrado.");
            }

            // Regla de negocio: no se puede eliminar un libro que forma parte de un pack
            if (_unitOfWork.LibrosFisicos.EstaRelacionado(libro))
            {
                return Result.Failure($"No se puede borrar el libro {libro.Nombre} porque forma parte de un pack.");
            }

            try
            {
                _unitOfWork.LibrosFisicos.Borrar(libro.ProductoId);
                _unitOfWork.Save();
                return Result.Success();
            }
            catch (Exception ex)
            {
                _unitOfWork.RollBack();
                return Result.Failure($"Error al intentar borrar el libro: {ex.Message}");
            }
        }

        public Result<List<LibroFisicoListDto>> ObtenerTodos()
        {
            try
            {
                var lista = _unitOfWork.LibrosFisicos.ObtenerTodos();
                var listaDto = lista.Select(LibroFisicoMapper.ToListDto).ToList();
                return Result<List<LibroFisicoListDto>>.Success(listaDto);
            }
            catch (Exception ex)
            {
                return Result<List<LibroFisicoListDto>>.Failure(ex.Message);
            }
        }

        public Result<LibroFisicoListDto> ObtenerPorId(int id)
        {
            try
            {
                var libro = _unitOfWork.LibrosFisicos.Query()
                    .Include(l => l.Editorial)
                    .FirstOrDefault(l => l.ProductoId == id);
                if (libro == null)
                {
                    return Result<LibroFisicoListDto>.Failure("Libro no encontrado.");
                }

                var libroDto = LibroFisicoMapper.ToListDto(libro);
                return Result<LibroFisicoListDto>.Success(libroDto);
            }
            catch (Exception ex)
            {
                return Result<LibroFisicoListDto>.Failure(ex.Message);
            }
        }

        public Result<LibroFisicoUpdateDto> ObtenerParaEditar(int id)
        {
            try
            {
                var libro = _unitOfWork.LibrosFisicos.ObtenerPorId(id);
                if (libro != null)
                {
                    var libroDto = LibroFisicoMapper.ToUpdateDto(libro);
                    return Result<LibroFisicoUpdateDto>.Success(libroDto);
                }

                return Result<LibroFisicoUpdateDto>.Failure("Libro no encontrado.");
            }
            catch (Exception ex)
            {
                return Result<LibroFisicoUpdateDto>.Failure(ex.Message);
            }
        }

        public Result<List<LibroFisicoListDto>> FiltrarPorActivo(bool activo)
        {
            try
            {
                var query = _unitOfWork.LibrosFisicos.Query().Include(l => l.Editorial);
                var lista = query.Where(l => l.Activo == activo);
                var listaDto = lista.Select(LibroFisicoMapper.ToListDto).ToList();
                return Result<List<LibroFisicoListDto>>.Success(listaDto);
            }
            catch (Exception ex)
            {
                return Result<List<LibroFisicoListDto>>.Failure($"Error al intentar filtrar los libros: {ex.Message}");
            }
        }

        public Result<ResultadoPaginacionDto<LibroFisicoListDto>> ObtenerPaginado(
            int pagina,
            int registros,
            string campoOrden,
            bool esAscendente,
            bool? filtroActivo = null,
            string? textoBuscar = null)
        {
            try
            {
                Expression<Func<LibroFisico, bool>>? filtro = l =>
                        (!filtroActivo.HasValue || l.Activo == filtroActivo.Value) &&
                        (string.IsNullOrWhiteSpace(textoBuscar) || l.Nombre.Contains(textoBuscar) ||
                            l.ISBN.Contains(textoBuscar) || l.Editorial.Nombre.Contains(textoBuscar));

                Func<IQueryable<LibroFisico>, IOrderedQueryable<LibroFisico>>? ordenarPor = campoOrden switch
                {
                    "ProductoId" => q => esAscendente ? q.OrderBy(l => l.ProductoId) : q.OrderByDescending(l => l.ProductoId),
                    "ISBN" => q => esAscendente ? q.OrderBy(l => l.ISBN) : q.OrderByDescending(l => l.ISBN),
                    "Editorial" => q => esAscendente ? q.OrderBy(l => l.Editorial.Nombre).ThenBy(l => l.Nombre) : q.OrderByDescending(l => l.Editorial.Nombre).ThenBy(l => l.Nombre),
                    "AnioPublicacion" => q => esAscendente ? q.OrderBy(l => l.AnioPublicacion).ThenBy(l => l.Nombre) : q.OrderByDescending(l => l.AnioPublicacion).ThenBy(l => l.Nombre),
                    "Precio" => q => esAscendente ? q.OrderBy(l => l.Precio) : q.OrderByDescending(l => l.Precio),
                    "Stock" => q => esAscendente ? q.OrderBy(l => l.Stock) : q.OrderByDescending(l => l.Stock),
                    "CantidadPaginas" => q => esAscendente ? q.OrderBy(l => l.CantidadPaginas) : q.OrderByDescending(l => l.CantidadPaginas),
                    "PesoEnGramos" => q => esAscendente ? q.OrderBy(l => l.PesoEnGramos) : q.OrderByDescending(l => l.PesoEnGramos),
                    _ => q => esAscendente ? q.OrderBy(l => l.Nombre) : q.OrderByDescending(l => l.Nombre)
                };

                Func<IQueryable<LibroFisico>, IQueryable<LibroFisico>>? incluir = q => q.Include(l => l.Editorial);

                var resultado = _unitOfWork.LibrosFisicos.ObtenerPagina(pagina, registros, ordenarPor, filtro, incluir);
                var listaDto = resultado.lista.Select(LibroFisicoMapper.ToListDto).ToList();

                var resultadoPaginacion = new ResultadoPaginacionDto<LibroFisicoListDto>
                {
                    Items = listaDto,
                    CantidadRegistros = resultado.totalRegistros,
                    CantidadPorPagina = registros,
                    PaginaActual = pagina
                };

                return Result<ResultadoPaginacionDto<LibroFisicoListDto>>.Success(resultadoPaginacion);
            }
            catch (Exception ex)
            {
                return Result<ResultadoPaginacionDto<LibroFisicoListDto>>.Failure(ex.Message);
            }
        }
    }
}
