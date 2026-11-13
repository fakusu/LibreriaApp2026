using LibreriaApp2026.Entidades;

namespace LibreriaApp2026.Datos.Interfaces
{
    public interface IFormaDePagoRepositorio : IRepositorioConcurrente<FormaDePago>
    {
        bool Existe(FormaDePago formaDePago);
        bool EstaRelacionado(FormaDePago formaDePago);
    }
}
