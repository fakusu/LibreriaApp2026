namespace LibreriaApp2026.Entidades
{
    public class LibroFisico : Libro
    {
        private int _pesoEnGramos;
        private int _cantidadPaginas;

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
            int stock, decimal precio, int editorialId, int pesoEnGramos, int cantidadPaginas)
            : base(titulo, descripcion, isbn, anioPublicacion, stock, precio, editorialId)
        {
            PesoEnGramos = pesoEnGramos;
            CantidadPaginas = cantidadPaginas;
        }

        public override string MostrarDatos()
        {
            return $"Libro físico: {base.MostrarDatos()} - {CantidadPaginas} págs. - {PesoEnGramos} grs";
        }
    }
}
