using System.ComponentModel;

namespace LibreriaApp2026.Servicios.DTOs.Venta
{
    // Libro que se puede elegir al armar una venta
    public class ProductoVentaDto
    {
        public int ProductoId { get; set; }
        public string Titulo { get; set; } = null!;
        public string Tipo { get; set; } = null!;
        public string Editorial { get; set; } = null!;
        public decimal Precio { get; set; }

        //null en los libros digitales (no manejan stock)
        public int? Stock { get; set; }

        [Browsable(false)]
        public bool EsDigital => Stock is null;
    }
}
