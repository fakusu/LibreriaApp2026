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
        public List<int> AutoresIds { get; set; } = new();
        public List<int> TemasIds { get; set; } = new();
        public int PesoEnGramos { get; set; }
        public int CantidadPaginas { get; set; }
        public bool Activo { get; set; }
        public byte[] RowVersion { get; set; } = null!;
    }
}
