using LibreriaApp2026.Entidades;

namespace LibreriaApp2026.Datos.Interfaces
{
    public interface ILibroFisicoRepositorio : IRepositorioConcurrente<LibroFisico>
    {
        bool Existe(LibroFisico libroFisico);
        bool EstaRelacionado(LibroFisico libroFisico);
        LibroFisico? ObtenerConAutoresYTemas(int id);
    }
}
