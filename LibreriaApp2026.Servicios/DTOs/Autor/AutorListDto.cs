namespace LibreriaApp2026.Servicios.DTOs.Autor
{
    public class AutorListDto
    {
        public int AutorId { get; set; }
        public string NombreCompleto { get; set; } = null!;
        public DateTime FechaNacimiento { get; set; }
        public string Nacionalidad { get; set; } = null!;
        public bool Activo { get; set; }
    }
}
