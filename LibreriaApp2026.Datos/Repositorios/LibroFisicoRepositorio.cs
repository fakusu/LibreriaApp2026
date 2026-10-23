using LibreriaApp2026.Datos.Interfaces;
using LibreriaApp2026.Entidades;
using Microsoft.EntityFrameworkCore;

namespace LibreriaApp2026.Datos.Repositorios
{
    public class LibroFisicoRepositorio : RepositorioConcurrente<LibroFisico>, ILibroFisicoRepositorio
    {
        public LibroFisicoRepositorio(LibreriaDbContext context) : base(context)
        {
        }

        public bool EstaRelacionado(LibroFisico libroFisico)
        {
            //luego relacionar con Packs (tabla DetallesPacks)
            return false;
        }

        public bool Existe(LibroFisico libroFisico)
        {
            //el ISBN no se puede repetir entre ningún tipo de libro
            return _context.Libros
                .Any(l => l.ISBN == libroFisico.ISBN &&
                l.ProductoId != libroFisico.ProductoId);
        }

        //con seguimiento de cambios, para poder editar los autores y temas del libro
        public LibroFisico? ObtenerConAutoresYTemas(int id)
        {
            return _context.LibrosFisicos
                .Include(l => l.LibrosAutores)
                .Include(l => l.LibrosTemas)
                .FirstOrDefault(l => l.ProductoId == id);
        }

        public override List<LibroFisico> ObtenerTodos()
        {
            return _context.LibrosFisicos
                .Include(l => l.Editorial)
                .Include(l => l.LibrosAutores).ThenInclude(la => la.Autor)
                .Include(l => l.LibrosTemas).ThenInclude(lt => lt.Tema)
                .AsNoTracking()
                .ToList();
        }
    }
}
