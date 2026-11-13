namespace LibreriaApp2026.Servicios.DTOs.Venta
{
    // Para facturar o anular una venta, con el RowVersion que tenía cuando el usuario la leyó
    public class VentaCambioEstadoDto
    {
        public int VentaId { get; set; }
        public byte[] RowVersion { get; set; } = null!;
    }
}
