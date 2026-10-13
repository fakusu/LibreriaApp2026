using LibreriaApp2026.Servicios.DTOs.Tema;
using FluentValidation;

namespace LibreriaApp2026.Servicios.Validators
{
    public class TemaCreateDtoValidator : AbstractValidator<TemaCreateDto>
    {
        public TemaCreateDtoValidator()
        {
            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre del tema es obligatorio.")
                .MaximumLength(50).WithMessage("El nombre no puede superar los 50 caracteres.");

            //La descripción no es obligatoria
            RuleFor(x => x.Descripcion)
                .MaximumLength(200).WithMessage("La descripción no puede superar los 200 caracteres.");
        }
    }
}
