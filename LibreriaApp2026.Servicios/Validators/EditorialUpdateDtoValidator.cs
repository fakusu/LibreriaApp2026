using LibreriaApp2026.Servicios.DTOs.Editorial;
using FluentValidation;

namespace LibreriaApp2026.Servicios.Validators
{
    public class EditorialUpdateDtoValidator : AbstractValidator<EditorialUpdateDto>
    {
        public EditorialUpdateDtoValidator()
        {
            RuleFor(x => x.EditorialId)
                .GreaterThan(0).WithMessage("El identificador de la editorial debe ser mayor a cero.");

            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre de la editorial es obligatorio.")
                .MaximumLength(100).WithMessage("El nombre no puede superar los 100 caracteres.");

            RuleFor(x => x.PaisOrigen)
                .NotEmpty().WithMessage("El país de origen es obligatorio.")
                .MaximumLength(50).WithMessage("El país de origen no puede superar los 50 caracteres.");

            RuleFor(x => x.RowVersion)
                .NotNull().WithMessage("El campo de concurrencia es obligatorio.");
        }
    }
}
