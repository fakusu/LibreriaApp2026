using LibreriaApp2026.Datos.Interfaces;
using LibreriaApp2026.Entidades.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibreriaApp2026.Datos.Repositorios
{
    public class RepositorioConcurrente<T> : RepositorioGenerico<T>,
        IRepositorioConcurrente<T> where T : class, IConcurrencyEntity
    {
        public RepositorioConcurrente(LibreriaDbContext context) : base(context)
        {
        }

        public override void Borrar(int id)
        {
            throw new NotImplementedException("Debe utilizar la versión de concurrencia");
        }

        public void Borrar(int id, byte[] rowVersion)
        {
            var entidadEnDb = _dbSet.Find(id);
            if (entidadEnDb is null)
            {
                throw new KeyNotFoundException($"No se pudo borrar la entidad ID: {id} de la tabla {typeof(T).Name}");
            }

            //se compara contra el RowVersion que tenía el registro cuando el usuario lo leyó
            var entry = _context.Entry(entidadEnDb);
            entry.OriginalValues["RowVersion"] = rowVersion;
            _dbSet.Remove(entidadEnDb);
        }

        public void Editar(T entidad, int id, byte[] rowVersion)
        {
            var entidadEnDb = _dbSet.Find(id);
            if (entidadEnDb is null)
            {
                throw new KeyNotFoundException($"No se pudo editar la entidad ID: {id} de la tabla {typeof(T).Name}");
            }

            var entry = _context.Entry(entidadEnDb);
            entry.OriginalValues["RowVersion"] = rowVersion;
            entry.CurrentValues.SetValues(entidad);
            //con herencia (TPT) el RowVersion está en la tabla Productos: marcando toda la entidad
            //como modificada EF actualiza siempre esa tabla y controla la concurrencia,
            //aunque solo haya cambiado un campo de la tabla hija
            entry.State = EntityState.Modified;
        }
    }
}
