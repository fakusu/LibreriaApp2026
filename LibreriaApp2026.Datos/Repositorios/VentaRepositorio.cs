using LibreriaApp2026.Datos.Interfaces;
using LibreriaApp2026.Entidades;
using Microsoft.EntityFrameworkCore;

namespace LibreriaApp2026.Datos.Repositorios
{
    public class VentaRepositorio : RepositorioConcurrente<Venta>, IVentaRepositorio
    {
        public VentaRepositorio(LibreriaDbContext context) : base(context)
        {
        }

        public Venta? ObtenerConDetalles(int id)
        {
            return _context.Ventas
                .Include(v => v.Detalles)
                .FirstOrDefault(v => v.VentaId == id);
        }

        public Venta? ObtenerParaConsulta(int id)
        {
            return _context.Ventas
                .Include(v => v.Cliente)
                .Include(v => v.FormaDePago)
                .Include(v => v.Detalles).ThenInclude(d => d.Producto)
                .AsNoTracking()
                .FirstOrDefault(v => v.VentaId == id);
        }

        public List<Libro> ObtenerLibros(IEnumerable<int> ids)
        {
            var lista = ids.Distinct().ToList();
            return _context.Libros
                .Include(l => l.Editorial)
                .Where(l => lista.Contains(l.ProductoId))
                .ToList();
        }

        public List<Libro> ObtenerLibrosParaVenta(string? textoBuscar)
        {
            //solo se pueden vender libros activos de editoriales activas
            var query = _context.Libros
                .Include(l => l.Editorial)
                .Where(l => l.Activo && l.Editorial.Activo);

            if (!string.IsNullOrWhiteSpace(textoBuscar))
            {
                query = query.Where(l => l.Nombre.Contains(textoBuscar) || l.ISBN.Contains(textoBuscar));
            }

            return query
                .OrderBy(l => l.Nombre)
                .AsNoTracking()
                .ToList();
        }
    }
}
