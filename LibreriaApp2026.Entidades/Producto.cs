namespace LibreriaApp2026.Entidades
{
    public abstract class Producto
    {
        private string _nombre = null!;
        private string? _descripcion;

        public int ProductoId { get; set; }

        public string Nombre
        {
            get => _nombre;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("El nombre del producto no puede estar vacío ni ser nulo.", nameof(value));
                }

                if (value.Trim().Length > 150)
                {
                    throw new ArgumentException("El nombre del producto no puede superar los 150 caracteres.", nameof(value));
                }

                _nombre = value.Trim();
            }
        }

        //La descripción no es obligatoria
        public string? Descripcion
        {
            get => _descripcion;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    _descripcion = null;
                    return;
                }

                if (value.Trim().Length > 500)
                {
                    throw new ArgumentException("La descripción del producto no puede superar los 500 caracteres.", nameof(value));
                }

                _descripcion = value.Trim();
            }
        }

        public bool Activo { get; set; } = true;

        protected Producto() { }

        protected Producto(string nombre, string? descripcion)
        {
            // Las asignaciones invocan los 'setters' correspondientes y sus validaciones
            Nombre = nombre;
            Descripcion = descripcion;
        }

        public abstract string MostrarDatos();
    }
}
