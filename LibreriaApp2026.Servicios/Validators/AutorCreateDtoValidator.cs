using LibreriaApp2026.Servicios.DTOs.Autor;
using FluentValidation;

namespace LibreriaApp2026.Servicios.Validators
{
    public class AutorCreateDtoValidator : AbstractValidator<AutorCreateDto>
    {
        public const int EdadMinima = 16;

        public AutorCreateDtoValidator()
        {
            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre del autor es obligatorio.")
                .MaximumLength(50).WithMessage("El nombre no puede superar los 50 caracteres.");

            RuleFor(x => x.Apellido)
                .NotEmpty().WithMessage("El apellido del autor es obligatorio.")
                .MaximumLength(50).WithMessage("El apellido no puede superar los 50 caracteres.");

            RuleFor(x => x.FechaNacimiento)
                .LessThanOrEqualTo(_ => DateTime.Today.AddYears(-EdadMinima))
                .WithMessage($"El autor debe tener al menos {EdadMinima} años.");

            RuleFor(x => x.Nacionalidad)
                .NotEmpty().WithMessage("La nacionalidad es obligatoria.")
                .MaximumLength(50).WithMessage("La nacionalidad no puede superar los 50 caracteres.");
        }
    }
}
