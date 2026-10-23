namespace LibreriaApp2026.Entidades
{
    public class LibroFisico : Libro
    {
        private int _stock;
        private int _pesoEnGramos;
        private int _cantidadPaginas;

        // Solo los libros físicos manejan stock
        public int Stock
        {
            get => _stock;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "El stock no puede ser negativo.");
                }

                _stock = value;
            }
        }

        public int PesoEnGramos
        {
            get => _pesoEnGramos;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "El peso debe ser mayor a cero.");
                }

                _pesoEnGramos = value;
            }
        }

        public int CantidadPaginas
        {
            get => _cantidadPaginas;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "La cantidad de páginas debe ser mayor a cero.");
                }

                _cantidadPaginas = value;
            }
        }

        public LibroFisico() { }

        public LibroFisico(string titulo, string? descripcion, string isbn, int anioPublicacion,
            decimal precio, int editorialId, IEnumerable<int> autoresIds, IEnumerable<int> temasIds,
            int stock, int pesoEnGramos, int cantidadPaginas)
            : base(titulo, descripcion, isbn, anioPublicacion, precio, editorialId, autoresIds, temasIds)
        {
            Stock = stock;
            PesoEnGramos = pesoEnGramos;
            CantidadPaginas = cantidadPaginas;
        }

        public override string MostrarDatos()
        {
            return $"Libro físico: {base.MostrarDatos()} - Stock: {Stock} - {CantidadPaginas} págs. - {PesoEnGramos} grs";
        }
    }
}
