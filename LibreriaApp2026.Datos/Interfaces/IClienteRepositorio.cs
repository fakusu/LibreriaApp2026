using LibreriaApp2026.Entidades;

namespace LibreriaApp2026.Datos.Interfaces
{
    public interface IClienteRepositorio : IRepositorioConcurrente<Cliente>
    {
        bool Existe(Cliente cliente);
        bool EstaRelacionado(Cliente cliente);
    }
}
