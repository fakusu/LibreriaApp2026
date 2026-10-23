using LibreriaApp2026.Entidades;

namespace LibreriaApp2026.Datos.Interfaces
{
    public interface ITemaRepositorio : IRepositorioConcurrente<Tema>
    {
        bool Existe(Tema tema);
        bool EstaRelacionado(Tema tema);
    }
}
