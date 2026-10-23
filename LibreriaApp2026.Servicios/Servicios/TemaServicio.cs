using LibreriaApp2026.Datos;
using LibreriaApp2026.Entidades;
using LibreriaApp2026.Servicios.Common;
using LibreriaApp2026.Servicios.DTOs.Tema;
using LibreriaApp2026.Servicios.Interfaces;
using LibreriaApp2026.Servicios.Mapeadores;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LibreriaApp2026.Servicios.Servicios
{
    public class TemaServicio : ITemaServicio
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<TemaCreateDto> _createValidator;
        private readonly IValidator<TemaUpdateDto> _updateValidator;

        public TemaServicio(
            IUnitOfWork unitOfWork,
            IValidator<TemaCreateDto> createValidator,
            IValidator<TemaUpdateDto> updateValidator)
        {
            _unitOfWork = unitOfWork;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public Result Agregar(TemaCreateDto temaDto)
        {
            // 1. Validar DTO antes del mapeo
            var result = _createValidator.Validate(temaDto);
            if (!result.IsValid)
            {
                return Result.Failure(result.Errors.Select(e => e.ErrorMessage).ToList());
            }

            // 2. Mapear a Entidad
            var tema = TemaMapper.ToEntidad(temaDto);

            // 3. Regla de negocio: Duplicados
            if (_unitOfWork.Temas.Existe(tema))
            {
                return Result.Failure($"Ya existe un tema con el nombre {tema.Nombre}.");
            }

            try
            {
                _unitOfWork.Temas.Agregar(tema);
                _unitOfWork.Save();
                return Result.Success();
            }
            catch (Exception ex)
            {
                _unitOfWork.RollBack();
                return Result.Failure($"Error al intentar agregar el tema: {ex.Message}");
            }
        }

        public Result Editar(TemaUpdateDto temaDto)
        {
            // 1. Validar DTO antes de tocar la BD o mapear
            var result = _updateValidator.Validate(temaDto);
            if (!result.IsValid)
            {
                return Result.Failure(result.Errors.Select(e => e.ErrorMessage).ToList());
            }

            // 2. Obtener entidad existente
            var tema = _unitOfWork.Temas.ObtenerPorId(temaDto.TemaId);
            if (tema == null)
            {
                return Result.Failure("Tema no encontrado.");
            }

            // 3. Modificar propiedades
            tema.Nombre = temaDto.Nombre;
            tema.Descripcion = temaDto.Descripcion;
            tema.Activo = temaDto.Activo;

            // 4. Regla de negocio: Duplicados (excluyendo el propio registro)
            if (_unitOfWork.Temas.Existe(tema))
            {
                var mensaje = $"Ya existe otro tema con el nombre {tema.Nombre}.";
                _unitOfWork.RollBack();
                return Result.Failure(mensaje);
            }

            try
            {
                _unitOfWork.Temas.Editar(tema, tema.TemaId, temaDto.RowVersion);
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
                return Result.Failure($"Error al intentar editar el tema: {ex.Message}");
            }
        }

        public Result Borrar(TemaDeleteDto temaDto)
        {
            var tema = _unitOfWork.Temas.ObtenerPorId(temaDto.TemaId);
            if (tema == null)
            {
                return Result.Failure("Tema no encontrado.");
            }

            // Regla de negocio: no se puede eliminar un tema con libros asociados
            if (_unitOfWork.Temas.EstaRelacionado(tema))
            {
                return Result.Failure($"No se puede borrar el tema {tema.Nombre} porque tiene libros asociados.");
            }

            try
            {
                _unitOfWork.Temas.Borrar(tema.TemaId, temaDto.RowVersion);
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
                return Result.Failure($"Error al intentar borrar el tema: {ex.Message}");
            }
        }

        public Result<List<TemaListDto>> ObtenerTodos()
        {
            try
            {
                var lista = _unitOfWork.Temas.ObtenerTodos();
                var listaDto = lista.Select(TemaMapper.ToListDto).ToList();
                return Result<List<TemaListDto>>.Success(listaDto);
            }
            catch (Exception ex)
            {
                return Result<List<TemaListDto>>.Failure(ex.Message);
            }
        }

        public Result<TemaListDto> ObtenerPorId(int id)
        {
            try
            {
                var tema = _unitOfWork.Temas.ObtenerPorId(id);
                if (tema == null)
                {
                    return Result<TemaListDto>.Failure("Tema no encontrado.");
                }

                var temaDto = TemaMapper.ToListDto(tema);
                return Result<TemaListDto>.Success(temaDto);
            }
            catch (Exception ex)
            {
                return Result<TemaListDto>.Failure(ex.Message);
            }
        }

        public Result<TemaUpdateDto> ObtenerParaEditar(int id)
        {
            try
            {
                var tema = _unitOfWork.Temas.ObtenerPorId(id);
                if (tema != null)
                {
                    var temaDto = TemaMapper.ToUpdateDto(tema);
                    return Result<TemaUpdateDto>.Success(temaDto);
                }

                return Result<TemaUpdateDto>.Failure("Tema no encontrado.");
            }
            catch (Exception ex)
            {
                return Result<TemaUpdateDto>.Failure(ex.Message);
            }
        }

        public Result<TemaDeleteDto> ObtenerParaBorrar(int id)
        {
            try
            {
                var tema = _unitOfWork.Temas.ObtenerPorId(id);
                if (tema != null)
                {
                    var temaDto = TemaMapper.ToDeleteDto(tema);
                    return Result<TemaDeleteDto>.Success(temaDto);
                }

                return Result<TemaDeleteDto>.Failure("Tema no encontrado.");
            }
            catch (Exception ex)
            {
                return Result<TemaDeleteDto>.Failure(ex.Message);
            }
        }

        public Result<List<TemaListDto>> FiltrarPorActivo(bool activo)
        {
            try
            {
                var query = _unitOfWork.Temas.Query();
                var lista = query.Where(t => t.Activo == activo);
                var listaDto = lista.Select(TemaMapper.ToListDto).ToList();
                return Result<List<TemaListDto>>.Success(listaDto);
            }
            catch (Exception ex)
            {
                return Result<List<TemaListDto>>.Failure($"Error al intentar filtrar los temas: {ex.Message}");
            }
        }

        public Result<ResultadoPaginacionDto<TemaListDto>> ObtenerPaginado(
            int pagina,
            int registros,
            string campoOrden,
            bool esAscendente,
            bool? filtroActivo = null,
            string? textoBuscar = null)
        {
            try
            {
                Expression<Func<Tema, bool>>? filtro = t =>
                        (!filtroActivo.HasValue || t.Activo == filtroActivo.Value) &&
                        (string.IsNullOrWhiteSpace(textoBuscar) || t.Nombre.Contains(textoBuscar) ||
                            (t.Descripcion != null && t.Descripcion.Contains(textoBuscar)));

                Func<IQueryable<Tema>, IOrderedQueryable<Tema>>? ordenarPor = campoOrden switch
                {
                    "TemaId" => q => esAscendente ? q.OrderBy(t => t.TemaId) : q.OrderByDescending(t => t.TemaId),
                    _ => q => esAscendente ? q.OrderBy(t => t.Nombre) : q.OrderByDescending(t => t.Nombre)
                };

                var resultado = _unitOfWork.Temas.ObtenerPagina(pagina, registros, ordenarPor, filtro);
                var listaDto = resultado.lista.Select(TemaMapper.ToListDto).ToList();

                var resultadoPaginacion = new ResultadoPaginacionDto<TemaListDto>
                {
                    Items = listaDto,
                    CantidadRegistros = resultado.totalRegistros,
                    CantidadPorPagina = registros,
                    PaginaActual = pagina
                };

                return Result<ResultadoPaginacionDto<TemaListDto>>.Success(resultadoPaginacion);
            }
            catch (Exception ex)
            {
                return Result<ResultadoPaginacionDto<TemaListDto>>.Failure(ex.Message);
            }
        }
    }
}
