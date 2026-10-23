using LibreriaApp2026.Servicios.DTOs.Tema;
using FluentValidation;

namespace LibreriaApp2026.Servicios.Validators
{
    public class TemaUpdateDtoValidator : AbstractValidator<TemaUpdateDto>
    {
        public TemaUpdateDtoValidator()
        {
            RuleFor(x => x.TemaId)
                .GreaterThan(0).WithMessage("El identificador del tema debe ser mayor a cero.");

            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre del tema es obligatorio.")
                .MaximumLength(50).WithMessage("El nombre no puede superar los 50 caracteres.");

            //La descripción no es obligatoria
            RuleFor(x => x.Descripcion)
                .MaximumLength(200).WithMessage("La descripción no puede superar los 200 caracteres.");

            RuleFor(x => x.RowVersion)
                .NotNull().WithMessage("El campo de concurrencia es obligatorio.");
        }
    }
}
