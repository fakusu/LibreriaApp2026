using LibreriaApp2026.Datos.Interfaces;

namespace LibreriaApp2026.Datos
{
    public interface IUnitOfWork : IDisposable
    {
        IEditorialRepositorio Editoriales { get; }
        IAutorRepositorio Autores { get; }
        ITemaRepositorio Temas { get; }
        ILibroFisicoRepositorio LibrosFisicos { get; }
        ILibroDigitalRepositorio LibrosDigitales { get; }
        void Save();
        void RollBack();
    }
}
