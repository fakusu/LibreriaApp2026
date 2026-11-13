using System.Text.RegularExpressions;

namespace LibreriaApp2026.Entidades.Validaciones
{
    /// <summary>
    /// Reglas de formato de los datos. Se usan en las tres capas:
    /// entidades (setters), validadores FluentValidation y formularios,
    /// así cada regla está definida en un solo lugar.
    /// Todas reciben el texto ya recortado (Trim) y devuelven false si es null o vacío.
    /// </summary>
    public static class Formatos
    {
        // Nombres y apellidos: letras (con acentos y ñ), espacios, apóstrofo, guion y punto ("J. R. R.", "O'Brien")
        private static readonly Regex NombrePersonaRegex = new(@"^\p{L}[\p{L} '.\-]*$");
        // Nacionalidad, país, provincia: letras, espacios, punto y guion
        private static readonly Regex SoloLetrasRegex = new(@"^\p{L}[\p{L} .\-]*$");
        // Localidad: como el anterior pero admite números ("9 de Julio", "25 de Mayo")
        private static readonly Regex LocalidadRegex = new(@"^[\p{L}\d][\p{L}\d .\-]*$");
        // Teléfono: dígitos, espacios, +, -, ( )
        private static readonly Regex TelefonoRegex = new(@"^\+?[\d ()\-]+$");
        // DNI: 7 u 8 dígitos
        private static readonly Regex DniRegex = new(@"^\d{7,8}$");
        // Código postal: 4 dígitos (1042) o CPA (C1042AAB)
        private static readonly Regex CodigoPostalRegex = new(@"^(\d{4}|[A-Za-z]\d{4}[A-Za-z]{3})$");
        // Número de calle: dígitos con una letra opcional ("1520", "930 B") o "S/N"
        private static readonly Regex NumeroCalleRegex = new(@"^(\d{1,6}( ?[A-Za-z])?|[Ss]/[Nn])$");
        // ISBN (ya normalizado): 10 dígitos (el último puede ser X) o 13 dígitos
        private static readonly Regex IsbnRegex = new(@"^(\d{9}[\dX]|\d{13})$");
        private static readonly Regex EmailRegex = new(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");

        public const int MinimoDigitosTelefono = 6;

        public static bool EsNombrePersona(string? valor) => Coincide(NombrePersonaRegex, valor);

        public static bool EsSoloLetras(string? valor) => Coincide(SoloLetrasRegex, valor);

        public static bool EsLocalidad(string? valor) => Coincide(LocalidadRegex, valor);

        public static bool EsDni(string? valor) => Coincide(DniRegex, valor);

        public static bool EsCodigoPostal(string? valor) => Coincide(CodigoPostalRegex, valor);

        public static bool EsNumeroCalle(string? valor) => Coincide(NumeroCalleRegex, valor);

        public static bool EsEmail(string? valor) => Coincide(EmailRegex, valor);

        public static bool EsTelefono(string? valor)
        {
            return Coincide(TelefonoRegex, valor) &&
                valor!.Count(char.IsDigit) >= MinimoDigitosTelefono;
        }

        // Saca guiones y espacios y pasa la x final a mayúscula: "978-950-49-0001-1" -> "9789504900011"
        public static string NormalizarIsbn(string? valor)
        {
            if (string.IsNullOrWhiteSpace(valor)) return string.Empty;
            return new string(valor.Where(c => c != '-' && !char.IsWhiteSpace(c)).ToArray()).ToUpperInvariant();
        }

        public static bool EsIsbn(string? valor) => Coincide(IsbnRegex, NormalizarIsbn(valor));

        // El http:// o https:// es opcional ("berserk.com" es válida); si se escribe, solo se aceptan esos dos
        public static bool EsUrl(string? valor)
        {
            if (string.IsNullOrWhiteSpace(valor)) return false;
            var url = valor.Trim();
            if (url.Any(char.IsWhiteSpace)) return false;
            if (!url.Contains("://")) url = "https://" + url;

            return Uri.TryCreate(url, UriKind.Absolute, out var uri)
                && (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps)
                && uri.Host.Contains('.')
                && !uri.Host.StartsWith('.') && !uri.Host.EndsWith('.');
        }

        private static bool Coincide(Regex regex, string? valor)
        {
            return !string.IsNullOrWhiteSpace(valor) && regex.IsMatch(valor.Trim());
        }
    }
}
