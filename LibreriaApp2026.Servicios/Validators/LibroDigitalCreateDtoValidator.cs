using LibreriaApp2026.Entidades;
using LibreriaApp2026.Servicios.DTOs.LibroDigital;
using FluentValidation;

namespace LibreriaApp2026.Servicios.Validators
{
    public class LibroDigitalCreateDtoValidator : AbstractValidator<LibroDigitalCreateDto>
    {
        public LibroDigitalCreateDtoValidator()
        {
            RuleFor(x => x.Titulo)
                .NotEmpty().WithMessage("El título del libro es obligatorio.")
                .MaximumLength(150).WithMessage("El título no puede superar los 150 caracteres.");

            RuleFor(x => x.Descripcion)
                .MaximumLength(500).WithMessage("La descripción no puede superar los 500 caracteres.");

            RuleFor(x => x.ISBN)
                .NotEmpty().WithMessage("El ISBN es obligatorio.")
                .MaximumLength(13).WithMessage("El ISBN no puede superar los 13 caracteres.");

            RuleFor(x => x.AnioPublicacion)
                .InclusiveBetween(Libro.AnioMinimo, DateTime.Today.Year)
                .WithMessage($"El año de publicación debe estar entre {Libro.AnioMinimo} y {DateTime.Today.Year}.");

            RuleFor(x => x.Precio)
                .GreaterThanOrEqualTo(0).WithMessage("El precio no puede ser negativo.");

            RuleFor(x => x.EditorialId)
                .GreaterThan(0).WithMessage("Debe seleccionar una editorial.");

            RuleFor(x => x.AutoresIds)
                .NotEmpty().WithMessage("Debe seleccionar al menos un autor.");

            RuleFor(x => x.TemasIds)
                .NotEmpty().WithMessage("Debe seleccionar al menos un tema.");

            RuleFor(x => x.Formato)
                .NotEmpty().WithMessage("El formato es obligatorio.")
                .MaximumLength(10).WithMessage("El formato no puede superar los 10 caracteres.");

            RuleFor(x => x.TamanioMB)
                .GreaterThan(0).WithMessage("El tamaño debe ser mayor a cero.");

            RuleFor(x => x.UrlDescarga)
                .NotEmpty().WithMessage("La URL de descarga es obligatoria.")
                .MaximumLength(300).WithMessage("La URL de descarga no puede superar los 300 caracteres.");
        }
    }
}
