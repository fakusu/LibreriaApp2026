using LibreriaApp2026.Servicios.Common;
using LibreriaApp2026.Servicios.DTOs.Cliente;

namespace LibreriaApp2026.Servicios.Interfaces
{
    public interface IClienteServicio
    {
        Result<ClienteUpdateDto> ObtenerParaEditar(int id);
        Result<ClienteDeleteDto> ObtenerParaBorrar(int id);
        Result Agregar(ClienteCreateDto clienteDto);
        Result Editar(ClienteUpdateDto clienteDto);
        Result Borrar(ClienteDeleteDto clienteDto);
        Result<List<ClienteListDto>> FiltrarPorActivo(bool activo);
        Result<ResultadoPaginacionDto<ClienteListDto>> ObtenerPaginado(int paginaActual,
            int cantidadPorPagina, string campoOrdenar, bool esAscendente, bool? filtroActivo,
            string? textoBuscar = null);
    }
}
