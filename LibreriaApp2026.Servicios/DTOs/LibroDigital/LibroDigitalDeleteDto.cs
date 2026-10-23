namespace LibreriaApp2026.Servicios.DTOs.LibroDigital
{
    public class LibroDigitalDeleteDto
    {
        public int ProductoId { get; set; }
        public byte[] RowVersion { get; set; } = null!;
    }
}
