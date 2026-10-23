namespace LibreriaApp2026.Entidades
{
    public class LibroDigital : Libro
    {
        private string _formato = null!;
        private decimal _tamanioMB;
        private string _urlDescarga = null!;

        public string Formato
        {
            get => _formato;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("El formato no puede estar vacío ni ser nulo.", nameof(value));
                }

                if (value.Trim().Length > 10)
                {
                    throw new ArgumentException("El formato no puede superar los 10 caracteres.", nameof(value));
                }

                _formato = value.Trim().ToUpper();
            }
        }

        public decimal TamanioMB
        {
            get => _tamanioMB;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "El tamaño debe ser mayor a cero.");
                }

                _tamanioMB = value;
            }
        }

        public string UrlDescarga
        {
            get => _urlDescarga;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("La URL de descarga no puede estar vacía ni ser nula.", nameof(value));
                }

                if (value.Trim().Length > 300)
                {
                    throw new ArgumentException("La URL de descarga no puede superar los 300 caracteres.", nameof(value));
                }

                _urlDescarga = value.Trim();
            }
        }

        public LibroDigital() { }

        public LibroDigital(string titulo, string? descripcion, string isbn, int anioPublicacion,
            decimal precio, int editorialId, IEnumerable<int> autoresIds, IEnumerable<int> temasIds,
            string formato, decimal tamanioMB, string urlDescarga)
            : base(titulo, descripcion, isbn, anioPublicacion, precio, editorialId, autoresIds, temasIds)
        {
            Formato = formato;
            TamanioMB = tamanioMB;
            UrlDescarga = urlDescarga;
        }

        public override string MostrarDatos()
        {
            return $"Libro digital: {base.MostrarDatos()} - {Formato} ({TamanioMB} MB)";
        }
    }
}
