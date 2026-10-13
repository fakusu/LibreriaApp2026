using LibreriaApp2026.Datos.Interfaces;
using LibreriaApp2026.Entidades;

namespace LibreriaApp2026.Datos.Repositorios
{
    public class AutorRepositorio : RepositorioGenerico<Autor>, IAutorRepositorio
    {
        public AutorRepositorio(LibreriaDbContext context) : base(context)
        {
        }

        public bool EstaRelacionado(Autor autor)
        {
            //luego relacionar con Libros (tabla intermedia LibrosAutores)
            return false;
        }

        public bool Existe(Autor autor)
        {
            return _context.Autores
                .Any(a => a.Nombre == autor.Nombre &&
                a.Apellido == autor.Apellido &&
                a.AutorId != autor.AutorId);
        }
    }
}
