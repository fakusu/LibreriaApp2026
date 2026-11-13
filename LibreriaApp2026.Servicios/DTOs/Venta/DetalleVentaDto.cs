using System.ComponentModel;

namespace LibreriaApp2026.Servicios.DTOs.Venta
{
    // Un renglón de la venta: se usa en el carrito de la nueva venta y en el detalle de una venta
    public class DetalleVentaDto
    {
        public int ProductoId { get; set; }
        public string Producto { get; set; } = null!;
        public string Tipo { get; set; } = null!;
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal => PrecioUnitario * Cantidad;

        //stock disponible (null en los libros digitales), para controlar la cantidad en el carrito
        [Browsable(false)]
        public int? Stock { get; set; }
    }
}
