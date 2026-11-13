using LibreriaApp2026.Entidades.Enums;
using LibreriaApp2026.Entidades.Interfaces;

namespace LibreriaApp2026.Entidades
{
    public class Venta : IConcurrencyEntity
    {
        private readonly List<DetalleVenta> _detalles = new();

        public int VentaId { get; private set; }
        public int ClienteId { get; private set; }
        public Cliente Cliente { get; private set; } = null!;
        public int FormaDePagoId { get; private set; }
        public FormaDePago FormaDePago { get; private set; } = null!;
        public DateTime FechaVenta { get; private set; }
        public EstadoVenta EstadoVenta { get; private set; }
        public decimal ImporteTotal { get; private set; }
        public byte[] RowVersion { get; set; } = null!;

        // Los detalles solo se agregan con AgregarDetalle, así el total siempre queda bien calculado
        public IReadOnlyCollection<DetalleVenta> Detalles => _detalles.AsReadOnly();

        private Venta() { } // para EF

        public Venta(int clienteId, int formaDePagoId)
        {
            if (clienteId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(clienteId), "Debe indicar un cliente válido.");
            }

            if (formaDePagoId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(formaDePagoId), "Debe indicar una forma de pago válida.");
            }

            ClienteId = clienteId;
            FormaDePagoId = formaDePagoId;
            FechaVenta = DateTime.Now;
            EstadoVenta = EstadoVenta.Pendiente;
        }

        public void AgregarDetalle(int productoId, int cantidad, decimal precioUnitario)
        {
            if (EstadoVenta != EstadoVenta.Pendiente)
            {
                throw new InvalidOperationException("Solo se pueden agregar productos a una venta pendiente.");
            }

            if (_detalles.Any(d => d.ProductoId == productoId))
            {
                throw new InvalidOperationException("El producto ya está incluido en la venta.");
            }

            _detalles.Add(new DetalleVenta(productoId, cantidad, precioUnitario));
            ImporteTotal = _detalles.Sum(d => d.Subtotal);
        }

        public void Facturar()
        {
            if (EstadoVenta != EstadoVenta.Pendiente)
            {
                throw new InvalidOperationException("Solo se puede facturar una venta pendiente.");
            }

            if (_detalles.Count == 0)
            {
                throw new InvalidOperationException("No se puede facturar una venta sin productos.");
            }

            EstadoVenta = EstadoVenta.Facturada;
        }

        public void Anular()
        {
            if (EstadoVenta != EstadoVenta.Pendiente)
            {
                throw new InvalidOperationException("Solo se puede anular una venta pendiente.");
            }

            EstadoVenta = EstadoVenta.Anulada;
        }
    }
}
