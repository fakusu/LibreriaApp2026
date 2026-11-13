namespace LibreriaApp2026.Servicios.DTOs.Venta
{
    public class VentaDetailDto
    {
        public int VentaId { get; set; }
        public DateTime FechaVenta { get; set; }
        public string Cliente { get; set; } = null!;
        public string Documento { get; set; } = null!;
        public string? Domicilio { get; set; }
        public string FormaDePago { get; set; } = null!;
        public string Estado { get; set; } = null!;
        public decimal ImporteTotal { get; set; }
        public List<DetalleVentaDto> Detalles { get; set; } = new();
    }
}
