namespace LibreriaApp2026.Entidades
{
    // Tabla intermedia de la relación N:M entre Libros y Temas
    public class LibroTema
    {
        public int ProductoId { get; set; }
        public int TemaId { get; set; }

        // Propiedades de navegación
        public Libro Libro { get; set; } = null!;
        public Tema Tema { get; set; } = null!;
    }
}
