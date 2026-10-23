using LibreriaApp2026.Servicios.Common;
using LibreriaApp2026.Servicios.DTOs.LibroDigital;

namespace LibreriaApp2026.Servicios.Interfaces
{
    public interface ILibroDigitalServicio
    {
        Result<List<LibroDigitalListDto>> ObtenerTodos();
        Result<LibroDigitalListDto> ObtenerPorId(int id);
        Result<LibroDigitalUpdateDto> ObtenerParaEditar(int id);
        Result<LibroDigitalDeleteDto> ObtenerParaBorrar(int id);
        Result Agregar(LibroDigitalCreateDto libroDto);
        Result Editar(LibroDigitalUpdateDto libroDto);
        Result Borrar(LibroDigitalDeleteDto libroDto);
        Result<List<LibroDigitalListDto>> FiltrarPorActivo(bool activo);
        Result<ResultadoPaginacionDto<LibroDigitalListDto>> ObtenerPaginado(int paginaActual,
            int cantidadPorPagina, string campoOrdenar, bool esAscendente, bool? filtroActivo,
            string? textoBuscar = null);
    }
}
