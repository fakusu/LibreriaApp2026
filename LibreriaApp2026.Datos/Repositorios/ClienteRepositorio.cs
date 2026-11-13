using LibreriaApp2026.Datos.Interfaces;
using LibreriaApp2026.Entidades;

namespace LibreriaApp2026.Datos.Repositorios
{
    public class ClienteRepositorio : RepositorioConcurrente<Cliente>, IClienteRepositorio
    {
        public ClienteRepositorio(LibreriaDbContext context) : base(context)
        {
        }

        public bool EstaRelacionado(Cliente cliente)
        {
            return _context.Ventas.Any(v => v.ClienteId == cliente.ClienteId);
        }

        public bool Existe(Cliente cliente)
        {
            //el documento no se puede repetir
            return _context.Clientes
                .Any(c => c.Documento == cliente.Documento &&
                c.ClienteId != cliente.ClienteId);
        }
    }
}
