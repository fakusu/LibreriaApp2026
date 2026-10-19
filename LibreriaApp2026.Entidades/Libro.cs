namespace LibreriaApp2026.Entidades
{
    public abstract class Libro : Producto
    {
        public const int AnioMinimo = 1450;

        private string _isbn = null!;
        private int _anioPublicacion;
        private int _stock;
        private decimal _precio;
        private int _editorialId;

        public string ISBN
        {
            get => _isbn;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("El ISBN no puede estar vacío ni ser nulo.", nameof(value));
                }

                if (value.Trim().Length > 13)
                {
                    throw new ArgumentException("El ISBN no puede superar los 13 caracteres.", nameof(value));
                }

                _isbn = value.Trim();
            }
        }

        public int AnioPublicacion
        {
            get => _anioPublicacion;
            set
            {
                if (value < AnioMinimo || value > DateTime.Today.Year)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), $"El año de publicación debe estar entre {AnioMinimo} y {DateTime.Today.Year}.");
                }

                _anioPublicacion = value;
            }
        }

        public int Stock
        {
            get => _stock;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "El stock no puede ser negativo.");
                }

                _stock = value;
            }
        }

        public decimal Precio
        {
            get => _precio;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "El precio no puede ser negativo.");
                }

                _precio = value;
            }
        }

        public int EditorialId
        {
            get => _editorialId;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Debe indicar una editorial válida.");
                }

                _editorialId = value;
            }
        }

        // Propiedad de navegación
        public Editorial Editorial { get; set; } = null!;

        protected Libro() { }

        protected Libro(string titulo, string? descripcion, string isbn, int anioPublicacion,
            int stock, decimal precio, int editorialId) : base(titulo, descripcion)
        {
            ISBN = isbn;
            AnioPublicacion = anioPublicacion;
            Stock = stock;
            Precio = precio;
            EditorialId = editorialId;
        }

        // Datos comunes a todos los libros; las clases hijas los completan con base.MostrarDatos()
        public override string MostrarDatos()
        {
            return $"{Nombre} (ISBN {ISBN}) - Año: {AnioPublicacion} - Precio: {Precio:C2} - Stock: {Stock}";
        }
    }
}
