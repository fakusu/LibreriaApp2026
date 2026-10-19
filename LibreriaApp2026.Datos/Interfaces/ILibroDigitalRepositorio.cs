using LibreriaApp2026.Entidades;

namespace LibreriaApp2026.Datos.Interfaces
{
    public interface ILibroDigitalRepositorio : IRepositorioGenerico<LibroDigital>
    {
        bool Existe(LibroDigital libroDigital);
        bool EstaRelacionado(LibroDigital libroDigital);
    }
}
