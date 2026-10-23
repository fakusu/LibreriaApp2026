namespace LibreriaApp2026.Servicios.DTOs.LibroDigital
{
    public class LibroDigitalCreateDto
    {
        public string Titulo { get; set; } = null!;
        public string? Descripcion { get; set; }
        public string ISBN { get; set; } = null!;
        public int AnioPublicacion { get; set; }
        public decimal Precio { get; set; }
        public int EditorialId { get; set; }
        public List<int> AutoresIds { get; set; } = new();
        public List<int> TemasIds { get; set; } = new();
        public string Formato { get; set; } = null!;
        public decimal TamanioMB { get; set; }
        public string UrlDescarga { get; set; } = null!;
        public bool Activo { get; set; }
    }
}
