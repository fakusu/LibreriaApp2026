using LibreriaApp2026.Entidades.Interfaces;
using LibreriaApp2026.Entidades.Validaciones;
using System.Diagnostics.CodeAnalysis;

namespace LibreriaApp2026.Entidades
{
    public class Cliente : IConcurrencyEntity
    {
        private string _nombre = null!;
        private string _apellido = null!;
        private string _documento = null!;
        private string? _email;
        private string? _telefono;
        private string? _calle;
        private string? _numero;
        private string? _localidad;
        private string? _provincia;
        private string? _codigoPostal;

        public int ClienteId { get; set; }

        public string Nombre
        {
            get => _nombre;
            set => _nombre = ConFormato(Obligatorio(value, 50, "El nombre del cliente"), Formatos.EsNombrePersona,
                "El nombre del cliente solo puede tener letras, espacios, apóstrofos, guiones y puntos.");
        }

        public string Apellido
        {
            get => _apellido;
            set => _apellido = ConFormato(Obligatorio(value, 50, "El apellido del cliente"), Formatos.EsNombrePersona,
                "El apellido del cliente solo puede tener letras, espacios, apóstrofos, guiones y puntos.");
        }

        // El documento (DNI) identifica al cliente: no se puede repetir
        public string Documento
        {
            get => _documento;
            set => _documento = ConFormato(Obligatorio(value, 8, "El documento"), Formatos.EsDni,
                "El documento debe ser un DNI de 7 u 8 dígitos, sin puntos.");
        }

        public string? Email
        {
            get => _email;
            set
            {
                _email = ConFormato(Opcional(value, 100, "El email"), Formatos.EsEmail,
                    "El email no tiene un formato válido.");
            }
        }

        public string? Telefono
        {
            get => _telefono;
            set => _telefono = ConFormato(Opcional(value, 30, "El teléfono"), Formatos.EsTelefono,
                $"El teléfono solo puede tener números, espacios, +, - y paréntesis, con al menos {Formatos.MinimoDigitosTelefono} dígitos.");
        }

        // Domicilio (opcional; se usa para los envíos a domicilio)
        public string? Calle
        {
            get => _calle;
            set => _calle = Opcional(value, 100, "La calle");
        }

        public string? Numero
        {
            get => _numero;
            set => _numero = ConFormato(Opcional(value, 20, "El número"), Formatos.EsNumeroCalle,
                "El número de la calle debe ser numérico (puede llevar una letra, ej: 930 B) o S/N.");
        }

        public string? Localidad
        {
            get => _localidad;
            set => _localidad = ConFormato(Opcional(value, 100, "La localidad"), Formatos.EsLocalidad,
                "La localidad solo puede tener letras, números, espacios, puntos y guiones.");
        }

        public string? Provincia
        {
            get => _provincia;
            set => _provincia = ConFormato(Opcional(value, 100, "La provincia"), Formatos.EsSoloLetras,
                "La provincia solo puede tener letras, espacios, puntos y guiones.");
        }

        public string? CodigoPostal
        {
            get => _codigoPostal;
            set => _codigoPostal = ConFormato(Opcional(value, 10, "El código postal"), Formatos.EsCodigoPostal,
                "El código postal debe tener 4 dígitos (ej: 1042) o el formato CPA (ej: C1042AAB).")?.ToUpperInvariant();
        }

        public bool Activo { get; set; } = true;

        public byte[] RowVersion { get; set; } = null!;

        public ICollection<Venta> Ventas { get; set; } = new List<Venta>();

        public string NombreCompleto => $"{Apellido}, {Nombre}";

        private static string Obligatorio(string value, int maximo, string campo)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException($"{campo} no puede estar vacío ni ser nulo.", nameof(value));
            }

            if (value.Trim().Length > maximo)
            {
                throw new ArgumentException($"{campo} no puede superar los {maximo} caracteres.", nameof(value));
            }

            return value.Trim();
        }

        //controla el formato; los opcionales vacíos (null) no se controlan
        [return: NotNullIfNotNull(nameof(value))]
        private static string? ConFormato(string? value, Func<string, bool> esValido, string mensaje)
        {
            if (value is not null && !esValido(value))
            {
                throw new ArgumentException(mensaje, nameof(value));
            }

            return value;
        }

        //los datos opcionales vacíos se guardan como null
        private static string? Opcional(string? value, int maximo, string campo)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return null;
            }

            if (value.Trim().Length > maximo)
            {
                throw new ArgumentException($"{campo} no puede superar los {maximo} caracteres.", nameof(value));
            }

            return value.Trim();
        }
    }
}
