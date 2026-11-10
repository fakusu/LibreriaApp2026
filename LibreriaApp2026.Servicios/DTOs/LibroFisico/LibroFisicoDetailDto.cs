namespace LibreriaApp2026.Servicios.DTOs.LibroFisico
{
    public class LibroFisicoDetailDto
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
        public int Stock { get; set; }
        public int CantidadPaginas { get; set; }
        public bool Activo { get; set; }
    }
}
