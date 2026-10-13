namespace LibreriaApp2026.Entidades
{
    public class Tema
    {
        private string _nombre = null!;
        private string? _descripcion;

        public int TemaId { get; set; }

        public string Nombre
        {
            get => _nombre;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("El nombre del tema no puede estar vacío ni ser nulo.", nameof(value));
                }

                if (value.Trim().Length > 50)
                {
                    throw new ArgumentException("El nombre del tema no puede superar los 50 caracteres.", nameof(value));
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

                if (value.Trim().Length > 200)
                {
                    throw new ArgumentException("La descripción del tema no puede superar los 200 caracteres.", nameof(value));
                }

                _descripcion = value.Trim();
            }
        }

        public bool Activo { get; set; } = true;
    }
}
