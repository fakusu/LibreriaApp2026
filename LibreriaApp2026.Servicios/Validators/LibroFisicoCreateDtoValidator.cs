using LibreriaApp2026.Entidades;
using LibreriaApp2026.Servicios.DTOs.LibroFisico;
using FluentValidation;

namespace LibreriaApp2026.Servicios.Validators
{
    public class LibroFisicoCreateDtoValidator : AbstractValidator<LibroFisicoCreateDto>
    {
        public LibroFisicoCreateDtoValidator()
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

            RuleFor(x => x.Stock)
                .GreaterThanOrEqualTo(0).WithMessage("El stock no puede ser negativo.");

            RuleFor(x => x.Precio)
                .GreaterThanOrEqualTo(0).WithMessage("El precio no puede ser negativo.");

            RuleFor(x => x.EditorialId)
                .GreaterThan(0).WithMessage("Debe seleccionar una editorial.");

            RuleFor(x => x.PesoEnGramos)
                .GreaterThan(0).WithMessage("El peso debe ser mayor a cero.");

            RuleFor(x => x.CantidadPaginas)
                .GreaterThan(0).WithMessage("La cantidad de páginas debe ser mayor a cero.");
        }
    }
}
