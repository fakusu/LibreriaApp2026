using LibreriaApp2026.Servicios.Common;
using LibreriaApp2026.Servicios.DTOs.LibroFisico;

namespace LibreriaApp2026.Servicios.Interfaces
{
    public interface ILibroFisicoServicio
    {
        Result<List<LibroFisicoListDto>> ObtenerTodos();
        Result<LibroFisicoListDto> ObtenerPorId(int id);
        Result<LibroFisicoUpdateDto> ObtenerParaEditar(int id);
        Result Agregar(LibroFisicoCreateDto libroDto);
        Result Editar(LibroFisicoUpdateDto libroDto);
        Result Borrar(int id);
        Result<List<LibroFisicoListDto>> FiltrarPorActivo(bool activo);
        Result<ResultadoPaginacionDto<LibroFisicoListDto>> ObtenerPaginado(int paginaActual,
            int cantidadPorPagina, string campoOrdenar, bool esAscendente, bool? filtroActivo,
            string? textoBuscar = null);
    }
}
