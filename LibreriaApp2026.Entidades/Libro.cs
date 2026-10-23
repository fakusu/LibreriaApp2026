namespace LibreriaApp2026.Entidades
{
    public abstract class Libro : Producto
    {
        public const int AnioMinimo = 1450;

        private string _isbn = null!;
        private int _anioPublicacion;
        private decimal _precio;
        private int _editorialId;

        public string ISBN
        {
            get => _isbn;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("El ISBN no puede estar vacío ni ser nulo.", nameof(value));
                }

                if (value.Trim().Length > 13)
                {
                    throw new ArgumentException("El ISBN no puede superar los 13 caracteres.", nameof(value));
                }

                _isbn = value.Trim();
            }
        }

        public int AnioPublicacion
        {
            get => _anioPublicacion;
            set
            {
                if (value < AnioMinimo || value > DateTime.Today.Year)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), $"El año de publicación debe estar entre {AnioMinimo} y {DateTime.Today.Year}.");
                }

                _anioPublicacion = value;
            }
        }

        public decimal Precio
        {
            get => _precio;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "El precio no puede ser negativo.");
                }

                _precio = value;
            }
        }

        public int EditorialId
        {
            get => _editorialId;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Debe indicar una editorial válida.");
                }

                _editorialId = value;
            }
        }

        // Propiedades de navegación
        public Editorial Editorial { get; set; } = null!;
        public ICollection<LibroAutor> LibrosAutores { get; set; } = new List<LibroAutor>();
        public ICollection<LibroTema> LibrosTemas { get; set; } = new List<LibroTema>();

        protected Libro() { }

        protected Libro(string titulo, string? descripcion, string isbn, int anioPublicacion,
            decimal precio, int editorialId, IEnumerable<int> autoresIds, IEnumerable<int> temasIds)
            : base(titulo, descripcion)
        {
            ISBN = isbn;
            AnioPublicacion = anioPublicacion;
            Precio = precio;
            EditorialId = editorialId;
            AsignarAutores(autoresIds);
            AsignarTemas(temasIds);
        }

        // Deja en la tabla intermedia exactamente los autores indicados:
        // quita los que ya no están y agrega los nuevos (los que siguen no se tocan)
        public void AsignarAutores(IEnumerable<int> autoresIds)
        {
            var ids = autoresIds.Distinct().ToList();
            if (ids.Count == 0)
            {
                throw new ArgumentException("El libro debe tener al menos un autor.", nameof(autoresIds));
            }

            foreach (var libroAutor in LibrosAutores.Where(la => !ids.Contains(la.AutorId)).ToList())
            {
                LibrosAutores.Remove(libroAutor);
            }

            foreach (var autorId in ids.Where(id => !LibrosAutores.Any(la => la.AutorId == id)).ToList())
            {
                LibrosAutores.Add(new LibroAutor { AutorId = autorId });
            }
        }

        // Igual que AsignarAutores, para los temas
        public void AsignarTemas(IEnumerable<int> temasIds)
        {
            var ids = temasIds.Distinct().ToList();
            if (ids.Count == 0)
            {
                throw new ArgumentException("El libro debe tener al menos un tema.", nameof(temasIds));
            }

            foreach (var libroTema in LibrosTemas.Where(lt => !ids.Contains(lt.TemaId)).ToList())
            {
                LibrosTemas.Remove(libroTema);
            }

            foreach (var temaId in ids.Where(id => !LibrosTemas.Any(lt => lt.TemaId == id)).ToList())
            {
                LibrosTemas.Add(new LibroTema { TemaId = temaId });
            }
        }

        // Datos comunes a todos los libros; las clases hijas los completan con base.MostrarDatos()
        public override string MostrarDatos()
        {
            return $"{Nombre} (ISBN {ISBN}) - Año: {AnioPublicacion} - Precio: {Precio:C2}";
        }
    }
}
