using LibreriaApp2026.Entidades;

namespace LibreriaApp2026.Datos.Interfaces
{
    public interface IEditorialRepositorio : IRepositorioConcurrente<Editorial>
    {
        bool Existe(Editorial editorial);
        bool EstaRelacionado(Editorial editorial);
    }
}
