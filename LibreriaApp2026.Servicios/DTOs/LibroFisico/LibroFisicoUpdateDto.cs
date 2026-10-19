namespace LibreriaApp2026.Servicios.DTOs.LibroFisico
{
    public class LibroFisicoUpdateDto
    {
        public int ProductoId { get; set; }
        public string Titulo { get; set; } = null!;
        public string? Descripcion { get; set; }
        public string ISBN { get; set; } = null!;
        public int AnioPublicacion { get; set; }
        public int Stock { get; set; }
        public decimal Precio { get; set; }
        public int EditorialId { get; set; }
        public int PesoEnGramos { get; set; }
        public int CantidadPaginas { get; set; }
        public bool Activo { get; set; }
    }
}
