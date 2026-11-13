namespace LibreriaApp2026.Servicios.DTOs.Venta
{
    public class VentaCreateDto
    {
        public int ClienteId { get; set; }
        public int FormaDePagoId { get; set; }
        public List<DetalleVentaCreateDto> Detalles { get; set; } = new();
    }
}
