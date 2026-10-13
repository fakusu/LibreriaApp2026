using LibreriaApp2026.Servicios.Common;
using LibreriaApp2026.Servicios.DTOs.Tema;

namespace LibreriaApp2026.Servicios.Interfaces
{
    public interface ITemaServicio
    {
        Result<List<TemaListDto>> ObtenerTodos();
        Result<TemaListDto> ObtenerPorId(int id);
        Result<TemaUpdateDto> ObtenerParaEditar(int id);
        Result Agregar(TemaCreateDto temaDto);
        Result Editar(TemaUpdateDto temaDto);
        Result Borrar(int id);
        Result<List<TemaListDto>> FiltrarPorActivo(bool activo);
        Result<ResultadoPaginacionDto<TemaListDto>> ObtenerPaginado(int paginaActual,
            int cantidadPorPagina, string campoOrdenar, bool esAscendente, bool? filtroActivo,
            string? textoBuscar = null);
    }
}
