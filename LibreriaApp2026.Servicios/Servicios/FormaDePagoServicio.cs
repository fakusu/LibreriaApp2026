using LibreriaApp2026.Datos;
using LibreriaApp2026.Entidades;
using LibreriaApp2026.Servicios.Common;
using LibreriaApp2026.Servicios.DTOs.FormaDePago;
using LibreriaApp2026.Servicios.Interfaces;
using LibreriaApp2026.Servicios.Mapeadores;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LibreriaApp2026.Servicios.Servicios
{
    public class FormaDePagoServicio : IFormaDePagoServicio
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<FormaDePagoCreateDto> _createValidator;
        private readonly IValidator<FormaDePagoUpdateDto> _updateValidator;

        public FormaDePagoServicio(
            IUnitOfWork unitOfWork,
            IValidator<FormaDePagoCreateDto> createValidator,
            IValidator<FormaDePagoUpdateDto> updateValidator)
        {
            _unitOfWork = unitOfWork;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public Result Agregar(FormaDePagoCreateDto formaDePagoDto)
        {
            var result = _createValidator.Validate(formaDePagoDto);
            if (!result.IsValid)
            {
                return Result.Failure(result.Errors.Select(e => e.ErrorMessage).ToList());
            }

            var formaDePago = FormaDePagoMapper.ToEntidad(formaDePagoDto);

            if (_unitOfWork.FormasDePago.Existe(formaDePago))
            {
                return Result.Failure($"Ya existe una forma de pago con el nombre {formaDePago.Nombre}.");
            }

            try
            {
                _unitOfWork.FormasDePago.Agregar(formaDePago);
                _unitOfWork.Save();
                return Result.Success();
            }
            catch (Exception ex)
            {
                _unitOfWork.RollBack();
                return Result.Failure($"Error al intentar agregar la forma de pago: {ex.Message}");
            }
        }

        public Result Editar(FormaDePagoUpdateDto formaDePagoDto)
        {
            var result = _updateValidator.Validate(formaDePagoDto);
            if (!result.IsValid)
            {
                return Result.Failure(result.Errors.Select(e => e.ErrorMessage).ToList());
            }

            var formaDePago = _unitOfWork.FormasDePago.ObtenerPorId(formaDePagoDto.FormaDePagoId);
            if (formaDePago == null)
            {
                return Result.Failure("Forma de pago no encontrada.");
            }

            formaDePago.Nombre = formaDePagoDto.Nombre;
            formaDePago.Activo = formaDePagoDto.Activo;

            if (_unitOfWork.FormasDePago.Existe(formaDePago))
            {
                var mensaje = $"Ya existe otra forma de pago con el nombre {formaDePago.Nombre}.";
                _unitOfWork.RollBack();
                return Result.Failure(mensaje);
            }

            try
            {
                _unitOfWork.FormasDePago.Editar(formaDePago, formaDePago.FormaDePagoId, formaDePagoDto.RowVersion);
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
                return Result.Failure($"Error al intentar editar la forma de pago: {ex.Message}");
            }
        }

        public Result Borrar(FormaDePagoDeleteDto formaDePagoDto)
        {
            var formaDePago = _unitOfWork.FormasDePago.ObtenerPorId(formaDePagoDto.FormaDePagoId);
            if (formaDePago == null)
            {
                return Result.Failure("Forma de pago no encontrada.");
            }

            // Regla de negocio: no se puede eliminar una forma de pago usada en ventas
            if (_unitOfWork.FormasDePago.EstaRelacionado(formaDePago))
            {
                return Result.Failure($"No se puede borrar la forma de pago {formaDePago.Nombre} porque tiene ventas asociadas.");
            }

            try
            {
                _unitOfWork.FormasDePago.Borrar(formaDePago.FormaDePagoId, formaDePagoDto.RowVersion);
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
                return Result.Failure($"Error al intentar borrar la forma de pago: {ex.Message}");
            }
        }

        public Result<FormaDePagoUpdateDto> ObtenerParaEditar(int id)
        {
            try
            {
                var formaDePago = _unitOfWork.FormasDePago.ObtenerPorId(id);
                if (formaDePago != null)
                {
                    return Result<FormaDePagoUpdateDto>.Success(FormaDePagoMapper.ToUpdateDto(formaDePago));
                }

                return Result<FormaDePagoUpdateDto>.Failure("Forma de pago no encontrada.");
            }
            catch (Exception ex)
            {
                return Result<FormaDePagoUpdateDto>.Failure(ex.Message);
            }
        }

        public Result<FormaDePagoDeleteDto> ObtenerParaBorrar(int id)
        {
            try
            {
                var formaDePago = _unitOfWork.FormasDePago.ObtenerPorId(id);
                if (formaDePago != null)
                {
                    return Result<FormaDePagoDeleteDto>.Success(FormaDePagoMapper.ToDeleteDto(formaDePago));
                }

                return Result<FormaDePagoDeleteDto>.Failure("Forma de pago no encontrada.");
            }
            catch (Exception ex)
            {
                return Result<FormaDePagoDeleteDto>.Failure(ex.Message);
            }
        }

        public Result<List<FormaDePagoListDto>> FiltrarPorActivo(bool activo)
        {
            try
            {
                var lista = _unitOfWork.FormasDePago.Query()
                    .Where(f => f.Activo == activo)
                    .OrderBy(f => f.Nombre);
                var listaDto = lista.Select(FormaDePagoMapper.ToListDto).ToList();
                return Result<List<FormaDePagoListDto>>.Success(listaDto);
            }
            catch (Exception ex)
            {
                return Result<List<FormaDePagoListDto>>.Failure($"Error al intentar filtrar las formas de pago: {ex.Message}");
            }
        }

        public Result<ResultadoPaginacionDto<FormaDePagoListDto>> ObtenerPaginado(
            int pagina,
            int registros,
            string campoOrden,
            bool esAscendente,
            bool? filtroActivo = null,
            string? textoBuscar = null)
        {
            try
            {
                Expression<Func<FormaDePago, bool>>? filtro = f =>
                        (!filtroActivo.HasValue || f.Activo == filtroActivo.Value) &&
                        (string.IsNullOrWhiteSpace(textoBuscar) || f.Nombre.Contains(textoBuscar));

                Func<IQueryable<FormaDePago>, IOrderedQueryable<FormaDePago>>? ordenarPor = campoOrden switch
                {
                    "FormaDePagoId" => q => esAscendente ? q.OrderBy(f => f.FormaDePagoId) : q.OrderByDescending(f => f.FormaDePagoId),
                    _ => q => esAscendente ? q.OrderBy(f => f.Nombre) : q.OrderByDescending(f => f.Nombre)
                };

                var resultado = _unitOfWork.FormasDePago.ObtenerPagina(pagina, registros, ordenarPor, filtro);
                var listaDto = resultado.lista.Select(FormaDePagoMapper.ToListDto).ToList();

                var resultadoPaginacion = new ResultadoPaginacionDto<FormaDePagoListDto>
                {
                    Items = listaDto,
                    CantidadRegistros = resultado.totalRegistros,
                    CantidadPorPagina = registros,
                    PaginaActual = pagina
                };

                return Result<ResultadoPaginacionDto<FormaDePagoListDto>>.Success(resultadoPaginacion);
            }
            catch (Exception ex)
            {
                return Result<ResultadoPaginacionDto<FormaDePagoListDto>>.Failure(ex.Message);
            }
        }
    }
}
