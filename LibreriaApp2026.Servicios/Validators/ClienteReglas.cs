using LibreriaApp2026.Entidades.Validaciones;
using FluentValidation;

namespace LibreriaApp2026.Servicios.Validators
{
    /// <summary>
    /// Reglas comunes al alta y a la edición de un cliente
    /// (los dos DTOs tienen los mismos campos, se describen con esta interfaz).
    /// </summary>
    public interface IDatosCliente
    {
        string Nombre { get; }
        string Apellido { get; }
        string Documento { get; }
        string? Email { get; }
        string? Telefono { get; }
        string? Calle { get; }
        string? Numero { get; }
        string? Localidad { get; }
        string? Provincia { get; }
        string? CodigoPostal { get; }
    }

    public static class ClienteReglas
    {
        public static void Aplicar<T>(AbstractValidator<T> v) where T : IDatosCliente
        {
            v.RuleFor(x => x.Nombre).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("El nombre del cliente es obligatorio.")
                .MaximumLength(50).WithMessage("El nombre no puede superar los 50 caracteres.")
                .Must(Formatos.EsNombrePersona).WithMessage("El nombre solo puede tener letras, espacios, apóstrofos, guiones y puntos.");

            v.RuleFor(x => x.Apellido).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("El apellido del cliente es obligatorio.")
                .MaximumLength(50).WithMessage("El apellido no puede superar los 50 caracteres.")
                .Must(Formatos.EsNombrePersona).WithMessage("El apellido solo puede tener letras, espacios, apóstrofos, guiones y puntos.");

            v.RuleFor(x => x.Documento).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("El documento es obligatorio.")
                .Must(Formatos.EsDni).WithMessage("El documento debe ser un DNI de 7 u 8 dígitos, sin puntos.");

            v.RuleFor(x => x.Email).Cascade(CascadeMode.Stop)
                .MaximumLength(100).WithMessage("El email no puede superar los 100 caracteres.")
                .Must(Formatos.EsEmail).WithMessage("El email no tiene un formato válido.")
                .When(x => !string.IsNullOrWhiteSpace(x.Email));

            v.RuleFor(x => x.Telefono).Cascade(CascadeMode.Stop)
                .MaximumLength(30).WithMessage("El teléfono no puede superar los 30 caracteres.")
                .Must(Formatos.EsTelefono).WithMessage($"El teléfono solo puede tener números, espacios, +, - y paréntesis, con al menos {Formatos.MinimoDigitosTelefono} dígitos.")
                .When(x => !string.IsNullOrWhiteSpace(x.Telefono));

            // Domicilio: es opcional, pero si se carga tiene que estar completo (para el envío a domicilio)
            v.RuleFor(x => x).Must(x => DomicilioCompletoOVacio(x))
                .WithName("Domicilio")
                .WithMessage("Si carga el domicilio debe completar calle, número, localidad y provincia.");

            v.RuleFor(x => x.Calle)
                .MaximumLength(100).WithMessage("La calle no puede superar los 100 caracteres.");

            v.RuleFor(x => x.Numero).Cascade(CascadeMode.Stop)
                .MaximumLength(20).WithMessage("El número no puede superar los 20 caracteres.")
                .Must(Formatos.EsNumeroCalle).WithMessage("El número de la calle debe ser numérico (puede llevar una letra, ej: 930 B) o S/N.")
                .When(x => !string.IsNullOrWhiteSpace(x.Numero));

            v.RuleFor(x => x.Localidad).Cascade(CascadeMode.Stop)
                .MaximumLength(100).WithMessage("La localidad no puede superar los 100 caracteres.")
                .Must(Formatos.EsLocalidad).WithMessage("La localidad solo puede tener letras, números, espacios, puntos y guiones.")
                .When(x => !string.IsNullOrWhiteSpace(x.Localidad));

            v.RuleFor(x => x.Provincia).Cascade(CascadeMode.Stop)
                .MaximumLength(100).WithMessage("La provincia no puede superar los 100 caracteres.")
                .Must(Formatos.EsSoloLetras).WithMessage("La provincia solo puede tener letras, espacios, puntos y guiones.")
                .When(x => !string.IsNullOrWhiteSpace(x.Provincia));

            v.RuleFor(x => x.CodigoPostal)
                .Must(Formatos.EsCodigoPostal).WithMessage("El código postal debe tener 4 dígitos (ej: 1042) o el formato CPA (ej: C1042AAB).")
                .When(x => !string.IsNullOrWhiteSpace(x.CodigoPostal));
        }

        public static bool DomicilioCompletoOVacio(IDatosCliente c)
        {
            var obligatorios = new[] { c.Calle, c.Numero, c.Localidad, c.Provincia };
            bool algunoCargado = obligatorios.Append(c.CodigoPostal).Any(d => !string.IsNullOrWhiteSpace(d));
            return !algunoCargado || obligatorios.All(d => !string.IsNullOrWhiteSpace(d));
        }
    }
}
