using LibreriaApp2026.Servicios.DTOs.Venta;
using FluentValidation;

namespace LibreriaApp2026.Servicios.Validators
{
    public class VentaCreateDtoValidator : AbstractValidator<VentaCreateDto>
    {
        public VentaCreateDtoValidator()
        {
            RuleFor(x => x.ClienteId)
                .GreaterThan(0).WithMessage("Debe seleccionar un cliente.");

            RuleFor(x => x.FormaDePagoId)
                .GreaterThan(0).WithMessage("Debe seleccionar una forma de pago.");

            RuleFor(x => x.Detalles)
                .NotEmpty().WithMessage("La venta debe tener al menos un producto.")
                .Must(d => d.Select(i => i.ProductoId).Distinct().Count() == d.Count)
                    .WithMessage("No se puede repetir un producto en la venta.");

            RuleForEach(x => x.Detalles).ChildRules(detalle =>
            {
                detalle.RuleFor(d => d.ProductoId)
                    .GreaterThan(0).WithMessage("Hay un producto inválido en la venta.");
                detalle.RuleFor(d => d.Cantidad)
                    .GreaterThan(0).WithMessage("La cantidad de cada producto debe ser mayor a cero.");
            });
        }
    }
}
