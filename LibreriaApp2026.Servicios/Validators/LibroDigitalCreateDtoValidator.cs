using LibreriaApp2026.Entidades.Validaciones;
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

            RuleFor(x => x.ISBN).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("El ISBN es obligatorio.")
                .Must(Formatos.EsIsbn).WithMessage("El ISBN debe tener 10 dígitos (el último puede ser X) o 13 dígitos.");

            RuleFor(x => x.AnioPublicacion)
                .InclusiveBetween(Libro.AnioMinimo, DateTime.Today.Year)
                .WithMessage($"El año de publicación debe estar entre {Libro.AnioMinimo} y {DateTime.Today.Year}.");

            RuleFor(x => x.Precio)
                .GreaterThan(0).WithMessage("El precio debe ser mayor a cero.");

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

            RuleFor(x => x.UrlDescarga).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("La URL de descarga es obligatoria.")
                .MaximumLength(300).WithMessage("La URL de descarga no puede superar los 300 caracteres.")
                .Must(Formatos.EsUrl).WithMessage("La URL de descarga no es válida (ej: ejemplo.com/libro.pdf).");
        }
    }
}
