using LibreriaApp2026.Entidades.Interfaces;

namespace LibreriaApp2026.Datos.Interfaces
{
    public interface IRepositorioConcurrente<T> : IRepositorioGenerico<T> where T : class, IConcurrencyEntity
    {
        void Borrar(int id, byte[] rowVersion);
        void Editar(T entidad, int id, byte[] rowVersion);
    }
}
