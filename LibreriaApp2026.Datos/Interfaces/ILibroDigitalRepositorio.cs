using LibreriaApp2026.Entidades;

namespace LibreriaApp2026.Datos.Interfaces
{
    public interface ILibroDigitalRepositorio : IRepositorioConcurrente<LibroDigital>
    {
        bool Existe(LibroDigital libroDigital);
        bool EstaRelacionado(LibroDigital libroDigital);
        LibroDigital? ObtenerConAutoresYTemas(int id);
    }
}
