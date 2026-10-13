using LibreriaApp2026.Datos.Interfaces;
using LibreriaApp2026.Entidades;

namespace LibreriaApp2026.Datos.Repositorios
{
    public class TemaRepositorio : RepositorioGenerico<Tema>, ITemaRepositorio
    {
        public TemaRepositorio(LibreriaDbContext context) : base(context)
        {
        }

        public bool EstaRelacionado(Tema tema)
        {
            //luego relacionar con Libros (tabla intermedia LibrosTemas)
            return false;
        }

        public bool Existe(Tema tema)
        {
            return _context.Temas
                .Any(t => t.Nombre == tema.Nombre &&
                t.TemaId != tema.TemaId);
        }
    }
}
