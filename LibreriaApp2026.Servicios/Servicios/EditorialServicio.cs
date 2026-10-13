using LibreriaApp2026.Datos;
using LibreriaApp2026.Entidades;
using LibreriaApp2026.Servicios.Common;
using LibreriaApp2026.Servicios.DTOs.Editorial;
using LibreriaApp2026.Servicios.Interfaces;
using LibreriaApp2026.Servicios.Mapeadores;
using FluentValidation;
using System.Linq.Expressions;

namespace LibreriaApp2026.Servicios.Servicios
{
    public class EditorialServicio : IEditorialServicio
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<EditorialCreateDto> _createValidator;
        private readonly IValidator<EditorialUpdateDto> _updateValidator;

        public EditorialServicio(
            IUnitOfWork unitOfWork,
            IValidator<EditorialCreateDto> createValidator,
            IValidator<EditorialUpdateDto> updateValidator)
        {
            _unitOfWork = unitOfWork;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public Result Agregar(EditorialCreateDto editorialDto)
        {
            // 1. Validar DTO antes del mapeo
            var result = _createValidator.Validate(editorialDto);
            if (!result.IsValid)
            {
                return Result.Failure(result.Errors.Select(e => e.ErrorMessage).ToList());
            }

            // 2. Mapear a Entidad
            var editorial = EditorialMapper.ToEntidad(editorialDto);

            // 3. Regla de negocio: Duplicados
            if (_unitOfWork.Editoriales.Existe(editorial))
            {
                return Result.Failure($"Ya existe una editorial con el nombre {editorial.Nombre}.");
            }

            try
            {
                _unitOfWork.Editoriales.Agregar(editorial);
                _unitOfWork.Save();
                return Result.Success();
            }
            catch (Exception ex)
            {
                _unitOfWork.RollBack();
                return Result.Failure($"Error al intentar agregar la editorial: {ex.Message}");
            }
        }

        public Result Editar(EditorialUpdateDto editorialDto)
        {
            // 1. Validar DTO antes de tocar la BD o mapear
            var result = _updateValidator.Validate(editorialDto);
            if (!result.IsValid)
            {
                return Result.Failure(result.Errors.Select(e => e.ErrorMessage).ToList());
            }

            // 2. Obtener entidad existente
            var editorial = _unitOfWork.Editoriales.ObtenerPorId(editorialDto.EditorialId);
            if (editorial == null)
            {
                return Result.Failure("Editorial no encontrada.");
            }

            // 3. Modificar propiedades
            editorial.Nombre = editorialDto.Nombre;
            editorial.PaisOrigen = editorialDto.PaisOrigen;
            editorial.Activo = editorialDto.Activo;

            // 4. Regla de negocio: Duplicados (excluyendo el propio registro)
            if (_unitOfWork.Editoriales.Existe(editorial))
            {
                var mensaje = $"Ya existe otra editorial con el nombre {editorial.Nombre}.";
                _unitOfWork.RollBack();
                return Result.Failure(mensaje);
            }

            try
            {
                _unitOfWork.Editoriales.Editar(editorial, editorial.EditorialId);
                _unitOfWork.Save();
                return Result.Success();
            }
            catch (Exception ex)
            {
                _unitOfWork.RollBack();
                return Result.Failure($"Error al intentar editar la editorial: {ex.Message}");
            }
        }

        public Result Borrar(int id)
        {
            var editorial = _unitOfWork.Editoriales.ObtenerPorId(id);
            if (editorial == null)
            {
                return Result.Failure("Editorial no encontrada.");
            }

            // Regla de negocio: no se puede eliminar una editorial con libros asociados
            if (_unitOfWork.Editoriales.EstaRelacionado(editorial))
            {
                return Result.Failure($"No se puede borrar la editorial {editorial.Nombre} porque tiene libros asociados.");
            }

            try
            {
                _unitOfWork.Editoriales.Borrar(editorial.EditorialId);
                _unitOfWork.Save();
                return Result.Success();
            }
            catch (Exception ex)
            {
                _unitOfWork.RollBack();
                return Result.Failure($"Error al intentar borrar la editorial: {ex.Message}");
            }
        }

        public Result<List<EditorialListDto>> ObtenerTodos()
        {
            try
            {
                var lista = _unitOfWork.Editoriales.ObtenerTodos();
                var listaDto = lista.Select(EditorialMapper.ToListDto).ToList();
                return Result<List<EditorialListDto>>.Success(listaDto);
            }
            catch (Exception ex)
            {
                return Result<List<EditorialListDto>>.Failure(ex.Message);
            }
        }

        public Result<EditorialListDto> ObtenerPorId(int id)
        {
            try
            {
                var editorial = _unitOfWork.Editoriales.ObtenerPorId(id);
                if (editorial == null)
                {
                    return Result<EditorialListDto>.Failure("Editorial no encontrada.");
                }

                var editorialDto = EditorialMapper.ToListDto(editorial);
                return Result<EditorialListDto>.Success(editorialDto);
            }
            catch (Exception ex)
            {
                return Result<EditorialListDto>.Failure(ex.Message);
            }
        }

        public Result<EditorialUpdateDto> ObtenerParaEditar(int id)
        {
            try
            {
                var editorial = _unitOfWork.Editoriales.ObtenerPorId(id);
                if (editorial != null)
                {
                    var editorialDto = EditorialMapper.ToUpdateDto(editorial);
                    return Result<EditorialUpdateDto>.Success(editorialDto);
                }

                return Result<EditorialUpdateDto>.Failure("Editorial no encontrada.");
            }
            catch (Exception ex)
            {
                return Result<EditorialUpdateDto>.Failure(ex.Message);
            }
        }

        public Result<List<EditorialListDto>> FiltrarPorActivo(bool activo)
        {
            try
            {
                var query = _unitOfWork.Editoriales.Query();
                var lista = query.Where(e => e.Activo == activo);
                var listaDto = lista.Select(EditorialMapper.ToListDto).ToList();
                return Result<List<EditorialListDto>>.Success(listaDto);
            }
            catch (Exception ex)
            {
                return Result<List<EditorialListDto>>.Failure($"Error al intentar filtrar las editoriales: {ex.Message}");
            }
        }

        public Result<ResultadoPaginacionDto<EditorialListDto>> ObtenerPaginado(
            int pagina,
            int registros,
            string campoOrden,
            bool esAscendente,
            bool? filtroActivo = null,
            string? textoBuscar = null)
        {
            try
            {
                Expression<Func<Editorial, bool>>? filtro = e =>
                        (!filtroActivo.HasValue || e.Activo == filtroActivo.Value) &&
                        (string.IsNullOrWhiteSpace(textoBuscar) || e.Nombre.Contains(textoBuscar) ||
                            e.PaisOrigen.Contains(textoBuscar));

                Func<IQueryable<Editorial>, IOrderedQueryable<Editorial>>? ordenarPor = campoOrden switch
                {
                    "EditorialId" => q => esAscendente ? q.OrderBy(e => e.EditorialId) : q.OrderByDescending(e => e.EditorialId),
                    "PaisOrigen" => q => esAscendente ? q.OrderBy(e => e.PaisOrigen).ThenBy(e => e.Nombre) : q.OrderByDescending(e => e.PaisOrigen).ThenBy(e => e.Nombre),
                    _ => q => esAscendente ? q.OrderBy(e => e.Nombre) : q.OrderByDescending(e => e.Nombre)
                };

                var resultado = _unitOfWork.Editoriales.ObtenerPagina(pagina, registros, ordenarPor, filtro);
                var listaDto = resultado.lista.Select(EditorialMapper.ToListDto).ToList();

                var resultadoPaginacion = new ResultadoPaginacionDto<EditorialListDto>
                {
                    Items = listaDto,
                    CantidadRegistros = resultado.totalRegistros,
                    CantidadPorPagina = registros,
                    PaginaActual = pagina
                };

                return Result<ResultadoPaginacionDto<EditorialListDto>>.Success(resultadoPaginacion);
            }
            catch (Exception ex)
            {
                return Result<ResultadoPaginacionDto<EditorialListDto>>.Failure(ex.Message);
            }
        }
    }
}
