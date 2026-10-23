using LibreriaApp2026.Datos;
using LibreriaApp2026.Entidades;
using LibreriaApp2026.Servicios.Common;
using LibreriaApp2026.Servicios.DTOs.Autor;
using LibreriaApp2026.Servicios.Interfaces;
using LibreriaApp2026.Servicios.Mapeadores;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LibreriaApp2026.Servicios.Servicios
{
    public class AutorServicio : IAutorServicio
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<AutorCreateDto> _createValidator;
        private readonly IValidator<AutorUpdateDto> _updateValidator;

        public AutorServicio(
            IUnitOfWork unitOfWork,
            IValidator<AutorCreateDto> createValidator,
            IValidator<AutorUpdateDto> updateValidator)
        {
            _unitOfWork = unitOfWork;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public Result Agregar(AutorCreateDto autorDto)
        {
            // 1. Validar DTO antes del mapeo
            var result = _createValidator.Validate(autorDto);
            if (!result.IsValid)
            {
                return Result.Failure(result.Errors.Select(e => e.ErrorMessage).ToList());
            }

            // 2. Mapear a Entidad
            var autor = AutorMapper.ToEntidad(autorDto);

            // 3. Regla de negocio: Duplicados
            if (_unitOfWork.Autores.Existe(autor))
            {
                return Result.Failure($"Ya existe el autor {autor.Apellido}, {autor.Nombre}.");
            }

            try
            {
                _unitOfWork.Autores.Agregar(autor);
                _unitOfWork.Save();
                return Result.Success();
            }
            catch (Exception ex)
            {
                _unitOfWork.RollBack();
                return Result.Failure($"Error al intentar agregar el autor: {ex.Message}");
            }
        }

        public Result Editar(AutorUpdateDto autorDto)
        {
            // 1. Validar DTO antes de tocar la BD o mapear
            var result = _updateValidator.Validate(autorDto);
            if (!result.IsValid)
            {
                return Result.Failure(result.Errors.Select(e => e.ErrorMessage).ToList());
            }

            // 2. Obtener entidad existente
            var autor = _unitOfWork.Autores.ObtenerPorId(autorDto.AutorId);
            if (autor == null)
            {
                return Result.Failure("Autor no encontrado.");
            }

            // 3. Modificar propiedades
            autor.Nombre = autorDto.Nombre;
            autor.Apellido = autorDto.Apellido;
            autor.FechaNacimiento = autorDto.FechaNacimiento;
            autor.Nacionalidad = autorDto.Nacionalidad;
            autor.Activo = autorDto.Activo;

            // 4. Regla de negocio: Duplicados (excluyendo el propio registro)
            if (_unitOfWork.Autores.Existe(autor))
            {
                var mensaje = $"Ya existe otro autor {autor.Apellido}, {autor.Nombre}.";
                _unitOfWork.RollBack();
                return Result.Failure(mensaje);
            }

            try
            {
                _unitOfWork.Autores.Editar(autor, autor.AutorId, autorDto.RowVersion);
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
                return Result.Failure($"Error al intentar editar el autor: {ex.Message}");
            }
        }

        public Result Borrar(AutorDeleteDto autorDto)
        {
            var autor = _unitOfWork.Autores.ObtenerPorId(autorDto.AutorId);
            if (autor == null)
            {
                return Result.Failure("Autor no encontrado.");
            }

            // Regla de negocio: no se puede eliminar un autor con libros asociados
            if (_unitOfWork.Autores.EstaRelacionado(autor))
            {
                return Result.Failure($"No se puede borrar el autor {autor.Apellido}, {autor.Nombre} porque tiene libros asociados.");
            }

            try
            {
                _unitOfWork.Autores.Borrar(autor.AutorId, autorDto.RowVersion);
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
                return Result.Failure($"Error al intentar borrar el autor: {ex.Message}");
            }
        }

        public Result<List<AutorListDto>> ObtenerTodos()
        {
            try
            {
                var lista = _unitOfWork.Autores.ObtenerTodos();
                var listaDto = lista.Select(AutorMapper.ToListDto).ToList();
                return Result<List<AutorListDto>>.Success(listaDto);
            }
            catch (Exception ex)
            {
                return Result<List<AutorListDto>>.Failure(ex.Message);
            }
        }

        public Result<AutorListDto> ObtenerPorId(int id)
        {
            try
            {
                var autor = _unitOfWork.Autores.ObtenerPorId(id);
                if (autor == null)
                {
                    return Result<AutorListDto>.Failure("Autor no encontrado.");
                }

                var autorDto = AutorMapper.ToListDto(autor);
                return Result<AutorListDto>.Success(autorDto);
            }
            catch (Exception ex)
            {
                return Result<AutorListDto>.Failure(ex.Message);
            }
        }

        public Result<AutorUpdateDto> ObtenerParaEditar(int id)
        {
            try
            {
                var autor = _unitOfWork.Autores.ObtenerPorId(id);
                if (autor != null)
                {
                    var autorDto = AutorMapper.ToUpdateDto(autor);
                    return Result<AutorUpdateDto>.Success(autorDto);
                }

                return Result<AutorUpdateDto>.Failure("Autor no encontrado.");
            }
            catch (Exception ex)
            {
                return Result<AutorUpdateDto>.Failure(ex.Message);
            }
        }

        public Result<AutorDeleteDto> ObtenerParaBorrar(int id)
        {
            try
            {
                var autor = _unitOfWork.Autores.ObtenerPorId(id);
                if (autor != null)
                {
                    var autorDto = AutorMapper.ToDeleteDto(autor);
                    return Result<AutorDeleteDto>.Success(autorDto);
                }

                return Result<AutorDeleteDto>.Failure("Autor no encontrado.");
            }
            catch (Exception ex)
            {
                return Result<AutorDeleteDto>.Failure(ex.Message);
            }
        }

        public Result<List<AutorListDto>> FiltrarPorActivo(bool activo)
        {
            try
            {
                var query = _unitOfWork.Autores.Query();
                var lista = query.Where(a => a.Activo == activo);
                var listaDto = lista.Select(AutorMapper.ToListDto).ToList();
                return Result<List<AutorListDto>>.Success(listaDto);
            }
            catch (Exception ex)
            {
                return Result<List<AutorListDto>>.Failure($"Error al intentar filtrar los autores: {ex.Message}");
            }
        }

        public Result<ResultadoPaginacionDto<AutorListDto>> ObtenerPaginado(
            int pagina,
            int registros,
            string campoOrden,
            bool esAscendente,
            bool? filtroActivo = null,
            string? textoBuscar = null)
        {
            try
            {
                Expression<Func<Autor, bool>>? filtro = a =>
                        (!filtroActivo.HasValue || a.Activo == filtroActivo.Value) &&
                        (string.IsNullOrWhiteSpace(textoBuscar) || a.Nombre.Contains(textoBuscar) ||
                            a.Apellido.Contains(textoBuscar) || a.Nacionalidad.Contains(textoBuscar));

                Func<IQueryable<Autor>, IOrderedQueryable<Autor>>? ordenarPor = campoOrden switch
                {
                    "AutorId" => q => esAscendente ? q.OrderBy(a => a.AutorId) : q.OrderByDescending(a => a.AutorId),
                    "FechaNacimiento" => q => esAscendente ? q.OrderBy(a => a.FechaNacimiento) : q.OrderByDescending(a => a.FechaNacimiento),
                    "Nacionalidad" => q => esAscendente ? q.OrderBy(a => a.Nacionalidad).ThenBy(a => a.Apellido) : q.OrderByDescending(a => a.Nacionalidad).ThenBy(a => a.Apellido),
                    _ => q => esAscendente ? q.OrderBy(a => a.Apellido).ThenBy(a => a.Nombre) : q.OrderByDescending(a => a.Apellido).ThenByDescending(a => a.Nombre)
                };

                var resultado = _unitOfWork.Autores.ObtenerPagina(pagina, registros, ordenarPor, filtro);
                var listaDto = resultado.lista.Select(AutorMapper.ToListDto).ToList();

                var resultadoPaginacion = new ResultadoPaginacionDto<AutorListDto>
                {
                    Items = listaDto,
                    CantidadRegistros = resultado.totalRegistros,
                    CantidadPorPagina = registros,
                    PaginaActual = pagina
                };

                return Result<ResultadoPaginacionDto<AutorListDto>>.Success(resultadoPaginacion);
            }
            catch (Exception ex)
            {
                return Result<ResultadoPaginacionDto<AutorListDto>>.Failure(ex.Message);
            }
        }
    }
}
