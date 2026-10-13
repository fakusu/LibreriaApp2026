namespace LibreriaApp2026.Servicios.DTOs.Tema
{
    public class TemaUpdateDto
    {
        public int TemaId { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Descripcion { get; set; }
        public bool Activo { get; set; }
    }
}
