using LibreriaApp2026.Servicios.DTOs.Venta;

namespace LibreriaApp2026.Windows.Helpers
{
    /// <summary>
    /// Carrito de la venta que se está armando en pantalla.
    /// Controla las cantidades antes de mandar la venta al servicio
    /// (el servicio vuelve a controlar todo contra la base de datos al guardar).
    /// </summary>
    public class EditorVenta
    {
        private readonly List<DetalleVentaDto> _detalles = new();

        public IReadOnlyList<DetalleVentaDto> Detalles => _detalles.AsReadOnly();

        public decimal Total => _detalles.Sum(d => d.Subtotal);

        public bool EstaVacia => _detalles.Count == 0;

        // Si el libro ya está en la venta se suma la cantidad
        public void AgregarProducto(DetalleVentaDto nuevo)
        {
            var existente = _detalles.FirstOrDefault(d => d.ProductoId == nuevo.ProductoId);
            if (existente is null)
            {
                ValidarCantidad(nuevo, nuevo.Cantidad);
                _detalles.Add(nuevo);
                return;
            }

            if (existente.Stock is null)
            {
                throw new InvalidOperationException($"El libro digital {existente.Producto} ya está en la venta (se vende de a una unidad).");
            }

            var cantidadTotal = existente.Cantidad + nuevo.Cantidad;
            ValidarCantidad(existente, cantidadTotal);
            existente.Cantidad = cantidadTotal;
        }

        public void ModificarCantidad(int productoId, int cantidad)
        {
            var detalle = Buscar(productoId);
            ValidarCantidad(detalle, cantidad);
            detalle.Cantidad = cantidad;
        }

        public void QuitarProducto(int productoId)
        {
            _detalles.Remove(Buscar(productoId));
        }

        public List<DetalleVentaCreateDto> ObtenerDetallesParaGuardar()
        {
            return _detalles
                .Select(d => new DetalleVentaCreateDto { ProductoId = d.ProductoId, Cantidad = d.Cantidad })
                .ToList();
        }

        private DetalleVentaDto Buscar(int productoId)
        {
            return _detalles.FirstOrDefault(d => d.ProductoId == productoId)
                ?? throw new InvalidOperationException("El producto no está en la venta.");
        }

        private static void ValidarCantidad(DetalleVentaDto detalle, int cantidad)
        {
            if (cantidad <= 0)
            {
                throw new InvalidOperationException("La cantidad debe ser mayor a cero.");
            }

            // Los digitales no tienen stock: se vende una licencia por venta
            if (detalle.Stock is null && cantidad != 1)
            {
                throw new InvalidOperationException($"El libro digital {detalle.Producto} se vende de a una unidad.");
            }

            if (detalle.Stock is not null && cantidad > detalle.Stock)
            {
                throw new InvalidOperationException($"Stock insuficiente de {detalle.Producto}. Disponible: {detalle.Stock}, solicitado: {cantidad}.");
            }
        }
    }
}
