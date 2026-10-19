using LibreriaApp2026.Servicios.DTOs.Autor;
using FluentValidation;

namespace LibreriaApp2026.Servicios.Validators
{
    public class AutorUpdateDtoValidator : AbstractValidator<AutorUpdateDto>
    {
        public AutorUpdateDtoValidator()
        {
            RuleFor(x => x.AutorId)
                .GreaterThan(0).WithMessage("El identificador del autor debe ser mayor a cero.");

            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre del autor es obligatorio.")
                .MaximumLength(50).WithMessage("El nombre no puede superar los 50 caracteres.");

            RuleFor(x => x.Apellido)
                .NotEmpty().WithMessage("El apellido del autor es obligatorio.")
                .MaximumLength(50).WithMessage("El apellido no puede superar los 50 caracteres.");

            RuleFor(x => x.FechaNacimiento)
                .LessThanOrEqualTo(_ => DateTime.Today.AddYears(-AutorCreateDtoValidator.EdadMinima))
                .WithMessage($"El autor debe tener al menos {AutorCreateDtoValidator.EdadMinima} años.");

            RuleFor(x => x.Nacionalidad)
                .NotEmpty().WithMessage("La nacionalidad es obligatoria.")
                .MaximumLength(50).WithMessage("La nacionalidad no puede superar los 50 caracteres.");
        }
    }
}
