namespace LibreriaApp2026.Servicios.DTOs.LibroFisico
{
    public class LibroFisicoListDto
    {
        public int ProductoId { get; set; }
        public string Titulo { get; set; } = null!;
        public string ISBN { get; set; } = null!;
        public string Editorial { get; set; } = null!;
        public string Autores { get; set; } = null!;
        public string Temas { get; set; } = null!;
        public int AnioPublicacion { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public int CantidadPaginas { get; set; }
        public int PesoEnGramos { get; set; }
        public bool Activo { get; set; }
    }
}
