namespace LibreriaApp2026.Entidades
{
    public class DetalleVenta
    {
        public int VentaId { get; private set; }
        public Venta Venta { get; private set; } = null!;
        public int ProductoId { get; private set; }
        public Producto Producto { get; private set; } = null!;
        public int Cantidad { get; private set; }

        // Precio del producto al momento de la venta (si después cambia el precio, la venta no se altera)
        public decimal PrecioUnitario { get; private set; }

        public decimal Subtotal => PrecioUnitario * Cantidad;

        private DetalleVenta() { } // para EF

        public DetalleVenta(int productoId, int cantidad, decimal precioUnitario)
        {
            if (productoId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(productoId), "Debe indicar un producto válido.");
            }

            if (cantidad <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(cantidad), "La cantidad debe ser mayor a cero.");
            }

            if (precioUnitario < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(precioUnitario), "El precio no puede ser negativo.");
            }

            ProductoId = productoId;
            Cantidad = cantidad;
            PrecioUnitario = precioUnitario;
        }
    }
}
