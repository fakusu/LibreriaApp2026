using LibreriaApp2026.Datos.Interfaces;
using LibreriaApp2026.Entidades;
using Microsoft.EntityFrameworkCore;

namespace LibreriaApp2026.Datos.Repositorios
{
    public class LibroDigitalRepositorio : RepositorioConcurrente<LibroDigital>, ILibroDigitalRepositorio
    {
        public LibroDigitalRepositorio(LibreriaDbContext context) : base(context)
        {
        }

        public bool EstaRelacionado(LibroDigital libroDigital)
        {
            //luego relacionar con Packs (tabla DetallesPacks)
            return false;
        }

        public bool Existe(LibroDigital libroDigital)
        {
            //el ISBN no se puede repetir entre ningún tipo de libro
            return _context.Libros
                .Any(l => l.ISBN == libroDigital.ISBN &&
                l.ProductoId != libroDigital.ProductoId);
        }

        //con seguimiento de cambios, para poder editar los autores y temas del libro
        public LibroDigital? ObtenerConAutoresYTemas(int id)
        {
            return _context.LibrosDigitales
                .Include(l => l.LibrosAutores)
                .Include(l => l.LibrosTemas)
                .FirstOrDefault(l => l.ProductoId == id);
        }

        public override List<LibroDigital> ObtenerTodos()
        {
            return _context.LibrosDigitales
                .Include(l => l.Editorial)
                .Include(l => l.LibrosAutores).ThenInclude(la => la.Autor)
                .Include(l => l.LibrosTemas).ThenInclude(lt => lt.Tema)
                .AsNoTracking()
                .ToList();
        }
    }
}
