using LibreriaApp2026.Entidades.Interfaces;

namespace LibreriaApp2026.Entidades
{
    // Tipo de venta: Efectivo, Débito, Crédito, Transferencia...
    public class FormaDePago : IConcurrencyEntity
    {
        private string _nombre = null!;

        public int FormaDePagoId { get; set; }

        public string Nombre
        {
            get => _nombre;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("El nombre de la forma de pago no puede estar vacío ni ser nulo.", nameof(value));
                }

                if (value.Trim().Length > 50)
                {
                    throw new ArgumentException("El nombre de la forma de pago no puede superar los 50 caracteres.", nameof(value));
                }

                _nombre = value.Trim();
            }
        }

        public bool Activo { get; set; } = true;

        public byte[] RowVersion { get; set; } = null!;

        public ICollection<Venta> Ventas { get; set; } = new List<Venta>();
    }
}
