using LibreriaApp2026.Datos.Interfaces;
using LibreriaApp2026.Entidades;

namespace LibreriaApp2026.Datos.Repositorios
{
    public class EditorialRepositorio : RepositorioGenerico<Editorial>, IEditorialRepositorio
    {
        public EditorialRepositorio(LibreriaDbContext context) : base(context)
        {
        }

        public bool EstaRelacionado(Editorial editorial)
        {
            //luego relacionar con Libros:
            //return _context.Libros.Any(l => l.EditorialId == editorial.EditorialId);
            return false;
        }

        public bool Existe(Editorial editorial)
        {
            return _context.Editoriales
                .Any(e => e.Nombre == editorial.Nombre &&
                e.EditorialId != editorial.EditorialId);
        }
    }
}
