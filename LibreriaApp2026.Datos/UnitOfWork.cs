using LibreriaApp2026.Datos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibreriaApp2026.Datos
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LibreriaDbContext _context;
        public IEditorialRepositorio Editoriales { get; }
        public IAutorRepositorio Autores { get; }
        public ITemaRepositorio Temas { get; }
        public ILibroFisicoRepositorio LibrosFisicos { get; }
        public ILibroDigitalRepositorio LibrosDigitales { get; }
        public IClienteRepositorio Clientes { get; }
        public IFormaDePagoRepositorio FormasDePago { get; }
        public IVentaRepositorio Ventas { get; }

        public UnitOfWork(IEditorialRepositorio editorialRepositorio,
            IAutorRepositorio autorRepositorio,
            ITemaRepositorio temaRepositorio,
            ILibroFisicoRepositorio libroFisicoRepositorio,
            ILibroDigitalRepositorio libroDigitalRepositorio,
            IClienteRepositorio clienteRepositorio,
            IFormaDePagoRepositorio formaDePagoRepositorio,
            IVentaRepositorio ventaRepositorio,
            LibreriaDbContext context)
        {
            Editoriales = editorialRepositorio;
            Autores = autorRepositorio;
            Temas = temaRepositorio;
            LibrosFisicos = libroFisicoRepositorio;
            LibrosDigitales = libroDigitalRepositorio;
            Clientes = clienteRepositorio;
            FormasDePago = formaDePagoRepositorio;
            Ventas = ventaRepositorio;
            _context = context;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void RollBack()
        {
            foreach (var item in _context.ChangeTracker.Entries())
            {
                switch (item.State)
                {
                    case EntityState.Modified:
                        item.State = EntityState.Unchanged;
                        item.CurrentValues.SetValues(item.OriginalValues);
                        break;
                    case EntityState.Added:
                        item.State = EntityState.Detached;
                        break;
                    case EntityState.Deleted:
                        item.State = EntityState.Unchanged;
                        break;
                }
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
