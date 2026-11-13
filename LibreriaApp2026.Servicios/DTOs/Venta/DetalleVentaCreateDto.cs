namespace LibreriaApp2026.Servicios.DTOs.Venta
{
    // El precio no viaja desde la pantalla: el servicio lo toma de la base de datos
    public class DetalleVentaCreateDto
    {
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
    }
}
