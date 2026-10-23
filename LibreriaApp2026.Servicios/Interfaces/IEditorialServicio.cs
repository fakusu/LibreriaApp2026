using LibreriaApp2026.Servicios.Common;
using LibreriaApp2026.Servicios.DTOs.Editorial;

namespace LibreriaApp2026.Servicios.Interfaces
{
    public interface IEditorialServicio
    {
        Result<List<EditorialListDto>> ObtenerTodos();
        Result<EditorialListDto> ObtenerPorId(int id);
        Result<EditorialUpdateDto> ObtenerParaEditar(int id);
        Result<EditorialDeleteDto> ObtenerParaBorrar(int id);
        Result Agregar(EditorialCreateDto editorialDto);
        Result Editar(EditorialUpdateDto editorialDto);
        Result Borrar(EditorialDeleteDto editorialDto);
        Result<List<EditorialListDto>> FiltrarPorActivo(bool activo);
        Result<ResultadoPaginacionDto<EditorialListDto>> ObtenerPaginado(int paginaActual,
            int cantidadPorPagina, string campoOrdenar, bool esAscendente, bool? filtroActivo,
            string? textoBuscar = null);
    }
}
