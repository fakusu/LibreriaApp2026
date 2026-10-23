using LibreriaApp2026.Servicios.Common;
using LibreriaApp2026.Servicios.DTOs.Autor;

namespace LibreriaApp2026.Servicios.Interfaces
{
    public interface IAutorServicio
    {
        Result<List<AutorListDto>> ObtenerTodos();
        Result<AutorListDto> ObtenerPorId(int id);
        Result<AutorUpdateDto> ObtenerParaEditar(int id);
        Result<AutorDeleteDto> ObtenerParaBorrar(int id);
        Result Agregar(AutorCreateDto autorDto);
        Result Editar(AutorUpdateDto autorDto);
        Result Borrar(AutorDeleteDto autorDto);
        Result<List<AutorListDto>> FiltrarPorActivo(bool activo);
        Result<ResultadoPaginacionDto<AutorListDto>> ObtenerPaginado(int paginaActual,
            int cantidadPorPagina, string campoOrdenar, bool esAscendente, bool? filtroActivo,
            string? textoBuscar = null);
    }
}
