using LibreriaApp2026.Datos.Interfaces;
using LibreriaApp2026.Entidades;
using Microsoft.EntityFrameworkCore;

namespace LibreriaApp2026.Datos.Repositorios
{
    public class LibroFisicoRepositorio : RepositorioGenerico<LibroFisico>, ILibroFisicoRepositorio
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

        public override List<LibroFisico> ObtenerTodos()
        {
            return _context.LibrosFisicos
                .Include(l => l.Editorial)
                .AsNoTracking()
                .ToList();
        }
    }
}
