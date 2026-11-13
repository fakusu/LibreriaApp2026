using LibreriaApp2026.Entidades.Validaciones;
using LibreriaApp2026.Entidades.Interfaces;

namespace LibreriaApp2026.Entidades
{
    public class Autor : IConcurrencyEntity
    {
        private string _nombre = null!;
        private string _apellido = null!;
        private DateTime _fechaNacimiento;
        private string _nacionalidad = null!;

        public int AutorId { get; set; }

        public string Nombre
        {
            get => _nombre;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("El nombre del autor no puede estar vacío ni ser nulo.", nameof(value));
                }

                if (value.Trim().Length > 50)
                {
                    throw new ArgumentException("El nombre del autor no puede superar los 50 caracteres.", nameof(value));
                }

                if (!Formatos.EsNombrePersona(value))
                {
                    throw new ArgumentException("El nombre del autor solo puede tener letras, espacios, apóstrofos, guiones y puntos.", nameof(value));
                }

                _nombre = value.Trim();
            }
        }

        public string Apellido
        {
            get => _apellido;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("El apellido del autor no puede estar vacío ni ser nulo.", nameof(value));
                }

                if (value.Trim().Length > 50)
                {
                    throw new ArgumentException("El apellido del autor no puede superar los 50 caracteres.", nameof(value));
                }

                if (!Formatos.EsNombrePersona(value))
                {
                    throw new ArgumentException("El apellido del autor solo puede tener letras, espacios, apóstrofos, guiones y puntos.", nameof(value));
                }

                _apellido = value.Trim();
            }
        }

        public DateTime FechaNacimiento
        {
            get => _fechaNacimiento;
            set
            {
                if (value.Date > DateTime.Today)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "La fecha de nacimiento no puede ser futura.");
                }

                _fechaNacimiento = value.Date;
            }
        }

        public string Nacionalidad
        {
            get => _nacionalidad;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("La nacionalidad no puede estar vacía ni ser nula.", nameof(value));
                }

                if (value.Trim().Length > 50)
                {
                    throw new ArgumentException("La nacionalidad no puede superar los 50 caracteres.", nameof(value));
                }

                if (!Formatos.EsSoloLetras(value))
                {
                    throw new ArgumentException("La nacionalidad solo puede tener letras, espacios, puntos y guiones.", nameof(value));
                }

                _nacionalidad = value.Trim();
            }
        }

        public bool Activo { get; set; } = true;

        public byte[] RowVersion { get; set; } = null!;
    }
}
