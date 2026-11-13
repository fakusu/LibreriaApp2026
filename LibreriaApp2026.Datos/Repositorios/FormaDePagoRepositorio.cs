using LibreriaApp2026.Datos.Interfaces;
using LibreriaApp2026.Entidades;

namespace LibreriaApp2026.Datos.Repositorios
{
    public class FormaDePagoRepositorio : RepositorioConcurrente<FormaDePago>, IFormaDePagoRepositorio
    {
        public FormaDePagoRepositorio(LibreriaDbContext context) : base(context)
        {
        }

        public bool EstaRelacionado(FormaDePago formaDePago)
        {
            return _context.Ventas.Any(v => v.FormaDePagoId == formaDePago.FormaDePagoId);
        }

        public bool Existe(FormaDePago formaDePago)
        {
            return _context.FormasDePago
                .Any(f => f.Nombre == formaDePago.Nombre &&
                f.FormaDePagoId != formaDePago.FormaDePagoId);
        }
    }
}
