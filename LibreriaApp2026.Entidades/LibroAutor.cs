namespace LibreriaApp2026.Entidades
{
    // Tabla intermedia de la relación N:M entre Libros y Autores
    public class LibroAutor
    {
        public int ProductoId { get; set; }
        public int AutorId { get; set; }

        // Propiedades de navegación
        public Libro Libro { get; set; } = null!;
        public Autor Autor { get; set; } = null!;
    }
}
