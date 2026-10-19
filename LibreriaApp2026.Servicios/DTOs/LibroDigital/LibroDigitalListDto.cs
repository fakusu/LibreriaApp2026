namespace LibreriaApp2026.Servicios.DTOs.LibroDigital
{
    public class LibroDigitalListDto
    {
        public int ProductoId { get; set; }
        public string Titulo { get; set; } = null!;
        public string ISBN { get; set; } = null!;
        public string Editorial { get; set; } = null!;
        public int AnioPublicacion { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public string Formato { get; set; } = null!;
        public decimal TamanioMB { get; set; }
        public bool Activo { get; set; }
    }
}
