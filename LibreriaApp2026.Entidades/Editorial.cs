using LibreriaApp2026.Entidades.Interfaces;

namespace LibreriaApp2026.Entidades
{
    public class Editorial : IConcurrencyEntity
    {
        private string _nombre = null!;
        private string _paisOrigen = null!;

        public int EditorialId { get; set; }

        public string Nombre
        {
            get => _nombre;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("El nombre de la editorial no puede estar vacío ni ser nulo.", nameof(value));
                }

                if (value.Trim().Length > 100)
                {
                    throw new ArgumentException("El nombre de la editorial no puede superar los 100 caracteres.", nameof(value));
                }

                _nombre = value.Trim();
            }
        }

        public string PaisOrigen
        {
            get => _paisOrigen;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("El país de origen no puede estar vacío ni ser nulo.", nameof(value));
                }

                if (value.Trim().Length > 50)
                {
                    throw new ArgumentException("El país de origen no puede superar los 50 caracteres.", nameof(value));
                }

                _paisOrigen = value.Trim();
            }
        }

        public bool Activo { get; set; } = true;

        public byte[] RowVersion { get; set; } = null!;
    }
}
