using LibreriaApp2026.Servicios.Common;
using LibreriaApp2026.Servicios.DTOs.FormaDePago;

namespace LibreriaApp2026.Servicios.Interfaces
{
    public interface IFormaDePagoServicio
    {
        Result<FormaDePagoUpdateDto> ObtenerParaEditar(int id);
        Result<FormaDePagoDeleteDto> ObtenerParaBorrar(int id);
        Result Agregar(FormaDePagoCreateDto formaDePagoDto);
        Result Editar(FormaDePagoUpdateDto formaDePagoDto);
        Result Borrar(FormaDePagoDeleteDto formaDePagoDto);
        Result<List<FormaDePagoListDto>> FiltrarPorActivo(bool activo);
        Result<ResultadoPaginacionDto<FormaDePagoListDto>> ObtenerPaginado(int paginaActual,
            int cantidadPorPagina, string campoOrdenar, bool esAscendente, bool? filtroActivo,
            string? textoBuscar = null);
    }
}
