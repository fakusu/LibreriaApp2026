namespace LibreriaApp2026.Servicios.DTOs.LibroDigital
{
    public class LibroDigitalDetailDto
    {
        public int ProductoId { get; set; }
        public string Titulo { get; set; } = null!;
        public string? Descripcion { get; set; }
        public string ISBN { get; set; } = null!;
        public string Editorial { get; set; } = null!;
        public List<string> Autores { get; set; } = new();
        public List<string> Temas { get; set; } = new();
        public int AnioPublicacion { get; set; }
        public decimal Precio { get; set; }
        public string Formato { get; set; } = null!;
        public decimal TamanioMB { get; set; }
        public string UrlDescarga { get; set; } = null!;
        public bool Activo { get; set; }
    }
}
