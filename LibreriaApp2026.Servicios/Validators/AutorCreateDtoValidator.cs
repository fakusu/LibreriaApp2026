using LibreriaApp2026.Entidades.Validaciones;
using LibreriaApp2026.Servicios.DTOs.Autor;
using FluentValidation;

namespace LibreriaApp2026.Servicios.Validators
{
    public class AutorCreateDtoValidator : AbstractValidator<AutorCreateDto>
    {
        public const int EdadMinima = 16;

        public AutorCreateDtoValidator()
        {
            RuleFor(x => x.Nombre).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("El nombre del autor es obligatorio.")
                .MaximumLength(50).WithMessage("El nombre no puede superar los 50 caracteres.")
                .Must(Formatos.EsNombrePersona).WithMessage("El nombre solo puede tener letras, espacios, apóstrofos, guiones y puntos.");

            RuleFor(x => x.Apellido).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("El apellido del autor es obligatorio.")
                .MaximumLength(50).WithMessage("El apellido no puede superar los 50 caracteres.")
                .Must(Formatos.EsNombrePersona).WithMessage("El apellido solo puede tener letras, espacios, apóstrofos, guiones y puntos.");

            RuleFor(x => x.FechaNacimiento)
                .LessThanOrEqualTo(_ => DateTime.Today.AddYears(-EdadMinima))
                .WithMessage($"El autor debe tener al menos {EdadMinima} años.");

            RuleFor(x => x.Nacionalidad).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("La nacionalidad es obligatoria.")
                .MaximumLength(50).WithMessage("La nacionalidad no puede superar los 50 caracteres.")
                .Must(Formatos.EsSoloLetras).WithMessage("La nacionalidad solo puede tener letras, espacios, puntos y guiones.");
        }
    }
}
