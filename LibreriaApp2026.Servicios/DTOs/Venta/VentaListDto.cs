using System.ComponentModel;

namespace LibreriaApp2026.Servicios.DTOs.Venta
{
    public class VentaListDto
    {
        public int VentaId { get; set; }
        public DateTime FechaVenta { get; set; }
        public string Cliente { get; set; } = null!;
        public string FormaDePago { get; set; } = null!;
        public decimal ImporteTotal { get; set; }
        public string Estado { get; set; } = null!;

        //para controlar la concurrencia al facturar o anular
        [Browsable(false)]
        public byte[] RowVersion { get; set; } = null!;
    }
}
