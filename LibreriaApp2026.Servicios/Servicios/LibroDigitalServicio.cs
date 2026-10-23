using LibreriaApp2026.Datos;
using LibreriaApp2026.Entidades;
using LibreriaApp2026.Servicios.Common;
using LibreriaApp2026.Servicios.DTOs.LibroDigital;
using LibreriaApp2026.Servicios.Interfaces;
using LibreriaApp2026.Servicios.Mapeadores;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LibreriaApp2026.Servicios.Servicios
{
    public class LibroDigitalServicio : ILibroDigitalServicio
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<LibroDigitalCreateDto> _createValidator;
        private readonly IValidator<LibroDigitalUpdateDto> _updateValidator;

        public LibroDigitalServicio(
            IUnitOfWork unitOfWork,
            IValidator<LibroDigitalCreateDto> createValidator,
            IValidator<LibroDigitalUpdateDto> updateValidator)
        {
            _unitOfWork = unitOfWork;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public Result Agregar(LibroDigitalCreateDto libroDto)
        {
            // 1. Validar DTO antes del mapeo
            var result = _createValidator.Validate(libroDto);
            if (!result.IsValid)
            {
                return Result.Failure(result.Errors.Select(e => e.ErrorMessage).ToList());
            }

            // 2. Mapear a Entidad
            var libro = LibroDigitalMapper.ToEntidad(libroDto);

            // 3. Regla de negocio: Duplicados (el ISBN es único entre todos los libros)
            if (_unitOfWork.LibrosDigitales.Existe(libro))
            {
                return Result.Failure($"Ya existe un libro con el ISBN {libro.ISBN}.");
            }

            try
            {
                _unitOfWork.LibrosDigitales.Agregar(libro);
                _unitOfWork.Save();
                return Result.Success();
            }
            catch (Exception ex)
            {
                _unitOfWork.RollBack();
                return Result.Failure($"Error al intentar agregar el libro: {ex.Message}");
            }
        }

        public Result Editar(LibroDigitalUpdateDto libroDto)
        {
            // 1. Validar DTO antes de tocar la BD o mapear
            var result = _updateValidator.Validate(libroDto);
            if (!result.IsValid)
            {
                return Result.Failure(result.Errors.Select(e => e.ErrorMessage).ToList());
            }

            // 2. Obtener entidad existente (con sus autores y temas)
            var libro = _unitOfWork.LibrosDigitales.ObtenerConAutoresYTemas(libroDto.ProductoId);
            if (libro == null)
            {
                return Result.Failure("Libro no encontrado.");
            }

            // 3. Modificar propiedades
            libro.Nombre = libroDto.Titulo;
            libro.Descripcion = libroDto.Descripcion;
            libro.ISBN = libroDto.ISBN;
            libro.AnioPublicacion = libroDto.AnioPublicacion;
            libro.Precio = libroDto.Precio;
            libro.EditorialId = libroDto.EditorialId;
            libro.AsignarAutores(libroDto.AutoresIds);
            libro.AsignarTemas(libroDto.TemasIds);
            libro.Formato = libroDto.Formato;
            libro.TamanioMB = libroDto.TamanioMB;
            libro.UrlDescarga = libroDto.UrlDescarga;
            libro.Activo = libroDto.Activo;

            // 4. Regla de negocio: Duplicados (excluyendo el propio registro)
            if (_unitOfWork.LibrosDigitales.Existe(libro))
            {
                var mensaje = $"Ya existe otro libro con el ISBN {libro.ISBN}.";
                _unitOfWork.RollBack();
                return Result.Failure(mensaje);
            }

            try
            {
                _unitOfWork.LibrosDigitales.Editar(libro, libro.ProductoId, libroDto.RowVersion);
                _unitOfWork.Save();
                return Result.Success();
            }
            catch (DbUpdateConcurrencyException)
            {
                _unitOfWork.RollBack();
                return Result.ConcurrencyFailure("Otro usuario modificó el registro.\nLa grilla se recargará automáticamente");
            }
            catch (Exception ex)
            {
                _unitOfWork.RollBack();
                return Result.Failure($"Error al intentar editar el libro: {ex.Message}");
            }
        }

        public Result Borrar(LibroDigitalDeleteDto libroDto)
        {
            var libro = _unitOfWork.LibrosDigitales.ObtenerPorId(libroDto.ProductoId);
            if (libro == null)
            {
                return Result.Failure("Libro no encontrado.");
            }

            // Regla de negocio: no se puede eliminar un libro que forma parte de un pack
            if (_unitOfWork.LibrosDigitales.EstaRelacionado(libro))
            {
                return Result.Failure($"No se puede borrar el libro {libro.Nombre} porque forma parte de un pack.");
            }

            try
            {
                _unitOfWork.LibrosDigitales.Borrar(libro.ProductoId, libroDto.RowVersion);
                _unitOfWork.Save();
                return Result.Success();
            }
            catch (DbUpdateConcurrencyException)
            {
                _unitOfWork.RollBack();
                return Result.ConcurrencyFailure("Otro usuario modificó el registro.\nLa grilla se recargará automáticamente");
            }
            catch (Exception ex)
            {
                _unitOfWork.RollBack();
                return Result.Failure($"Error al intentar borrar el libro: {ex.Message}");
            }
        }

        public Result<List<LibroDigitalListDto>> ObtenerTodos()
        {
            try
            {
                var lista = _unitOfWork.LibrosDigitales.ObtenerTodos();
                var listaDto = lista.Select(LibroDigitalMapper.ToListDto).ToList();
                return Result<List<LibroDigitalListDto>>.Success(listaDto);
            }
            catch (Exception ex)
            {
                return Result<List<LibroDigitalListDto>>.Failure(ex.Message);
            }
        }

        public Result<LibroDigitalListDto> ObtenerPorId(int id)
        {
            try
            {
                var libro = _unitOfWork.LibrosDigitales.Query()
                    .Include(l => l.Editorial)
                    .Include(l => l.LibrosAutores).ThenInclude(la => la.Autor)
                    .Include(l => l.LibrosTemas).ThenInclude(lt => lt.Tema)
                    .FirstOrDefault(l => l.ProductoId == id);
                if (libro == null)
                {
                    return Result<LibroDigitalListDto>.Failure("Libro no encontrado.");
                }

                var libroDto = LibroDigitalMapper.ToListDto(libro);
                return Result<LibroDigitalListDto>.Success(libroDto);
            }
            catch (Exception ex)
            {
                return Result<LibroDigitalListDto>.Failure(ex.Message);
            }
        }

        public Result<LibroDigitalUpdateDto> ObtenerParaEditar(int id)
        {
            try
            {
                var libro = _unitOfWork.LibrosDigitales.ObtenerConAutoresYTemas(id);
                if (libro != null)
                {
                    var libroDto = LibroDigitalMapper.ToUpdateDto(libro);
                    return Result<LibroDigitalUpdateDto>.Success(libroDto);
                }

                return Result<LibroDigitalUpdateDto>.Failure("Libro no encontrado.");
            }
            catch (Exception ex)
            {
                return Result<LibroDigitalUpdateDto>.Failure(ex.Message);
            }
        }

        public Result<LibroDigitalDeleteDto> ObtenerParaBorrar(int id)
        {
            try
            {
                var libro = _unitOfWork.LibrosDigitales.ObtenerPorId(id);
                if (libro != null)
                {
                    var libroDto = LibroDigitalMapper.ToDeleteDto(libro);
                    return Result<LibroDigitalDeleteDto>.Success(libroDto);
                }

                return Result<LibroDigitalDeleteDto>.Failure("Libro no encontrado.");
            }
            catch (Exception ex)
            {
                return Result<LibroDigitalDeleteDto>.Failure(ex.Message);
            }
        }

        public Result<List<LibroDigitalListDto>> FiltrarPorActivo(bool activo)
        {
            try
            {
                var query = _unitOfWork.LibrosDigitales.Query()
                    .Include(l => l.Editorial)
                    .Include(l => l.LibrosAutores).ThenInclude(la => la.Autor)
                    .Include(l => l.LibrosTemas).ThenInclude(lt => lt.Tema);
                var lista = query.Where(l => l.Activo == activo);
                var listaDto = lista.Select(LibroDigitalMapper.ToListDto).ToList();
                return Result<List<LibroDigitalListDto>>.Success(listaDto);
            }
            catch (Exception ex)
            {
                return Result<List<LibroDigitalListDto>>.Failure($"Error al intentar filtrar los libros: {ex.Message}");
            }
        }

        public Result<ResultadoPaginacionDto<LibroDigitalListDto>> ObtenerPaginado(
            int pagina,
            int registros,
            string campoOrden,
            bool esAscendente,
            bool? filtroActivo = null,
            string? textoBuscar = null)
        {
            try
            {
                Expression<Func<LibroDigital, bool>>? filtro = l =>
                        (!filtroActivo.HasValue || l.Activo == filtroActivo.Value) &&
                        (string.IsNullOrWhiteSpace(textoBuscar) || l.Nombre.Contains(textoBuscar) ||
                            l.ISBN.Contains(textoBuscar) || l.Editorial.Nombre.Contains(textoBuscar) ||
                            l.LibrosAutores.Any(la => la.Autor.Apellido.Contains(textoBuscar) || la.Autor.Nombre.Contains(textoBuscar)) ||
                            l.LibrosTemas.Any(lt => lt.Tema.Nombre.Contains(textoBuscar)) ||
                            l.Formato.Contains(textoBuscar));

                Func<IQueryable<LibroDigital>, IOrderedQueryable<LibroDigital>>? ordenarPor = campoOrden switch
                {
                    "ProductoId" => q => esAscendente ? q.OrderBy(l => l.ProductoId) : q.OrderByDescending(l => l.ProductoId),
                    "ISBN" => q => esAscendente ? q.OrderBy(l => l.ISBN) : q.OrderByDescending(l => l.ISBN),
                    "Editorial" => q => esAscendente ? q.OrderBy(l => l.Editorial.Nombre).ThenBy(l => l.Nombre) : q.OrderByDescending(l => l.Editorial.Nombre).ThenBy(l => l.Nombre),
                    //se ordena por el primer autor / tema (alfabéticamente) de cada libro
                    "Autores" => q => esAscendente ? q.OrderBy(l => l.LibrosAutores.Select(la => la.Autor.Apellido + ", " + la.Autor.Nombre).OrderBy(n => n).FirstOrDefault()).ThenBy(l => l.Nombre) : q.OrderByDescending(l => l.LibrosAutores.Select(la => la.Autor.Apellido + ", " + la.Autor.Nombre).OrderBy(n => n).FirstOrDefault()).ThenBy(l => l.Nombre),
                    "Temas" => q => esAscendente ? q.OrderBy(l => l.LibrosTemas.Select(lt => lt.Tema.Nombre).OrderBy(n => n).FirstOrDefault()).ThenBy(l => l.Nombre) : q.OrderByDescending(l => l.LibrosTemas.Select(lt => lt.Tema.Nombre).OrderBy(n => n).FirstOrDefault()).ThenBy(l => l.Nombre),
                    "AnioPublicacion" => q => esAscendente ? q.OrderBy(l => l.AnioPublicacion).ThenBy(l => l.Nombre) : q.OrderByDescending(l => l.AnioPublicacion).ThenBy(l => l.Nombre),
                    "Precio" => q => esAscendente ? q.OrderBy(l => l.Precio) : q.OrderByDescending(l => l.Precio),
                    "Formato" => q => esAscendente ? q.OrderBy(l => l.Formato).ThenBy(l => l.Nombre) : q.OrderByDescending(l => l.Formato).ThenBy(l => l.Nombre),
                    "TamanioMB" => q => esAscendente ? q.OrderBy(l => l.TamanioMB) : q.OrderByDescending(l => l.TamanioMB),
                    _ => q => esAscendente ? q.OrderBy(l => l.Nombre) : q.OrderByDescending(l => l.Nombre)
                };

                Func<IQueryable<LibroDigital>, IQueryable<LibroDigital>>? incluir = q => q.Include(l => l.Editorial)
                    .Include(l => l.LibrosAutores).ThenInclude(la => la.Autor)
                    .Include(l => l.LibrosTemas).ThenInclude(lt => lt.Tema);

                var resultado = _unitOfWork.LibrosDigitales.ObtenerPagina(pagina, registros, ordenarPor, filtro, incluir);
                var listaDto = resultado.lista.Select(LibroDigitalMapper.ToListDto).ToList();

                var resultadoPaginacion = new ResultadoPaginacionDto<LibroDigitalListDto>
                {
                    Items = listaDto,
                    CantidadRegistros = resultado.totalRegistros,
                    CantidadPorPagina = registros,
                    PaginaActual = pagina
                };

                return Result<ResultadoPaginacionDto<LibroDigitalListDto>>.Success(resultadoPaginacion);
            }
            catch (Exception ex)
            {
                return Result<ResultadoPaginacionDto<LibroDigitalListDto>>.Failure(ex.Message);
            }
        }
    }
}
