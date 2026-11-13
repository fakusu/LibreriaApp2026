using LibreriaApp2026.Servicios.DTOs.FormaDePago;
using FluentValidation;

namespace LibreriaApp2026.Servicios.Validators
{
    public class FormaDePagoCreateDtoValidator : AbstractValidator<FormaDePagoCreateDto>
    {
        public FormaDePagoCreateDtoValidator()
        {
            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre de la forma de pago es obligatorio.")
                .MaximumLength(50).WithMessage("El nombre no puede superar los 50 caracteres.");
        }
    }
}
