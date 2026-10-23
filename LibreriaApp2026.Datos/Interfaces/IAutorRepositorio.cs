using LibreriaApp2026.Entidades;

namespace LibreriaApp2026.Datos.Interfaces
{
    public interface IAutorRepositorio : IRepositorioConcurrente<Autor>
    {
        bool Existe(Autor autor);
        bool EstaRelacionado(Autor autor);
    }
}
