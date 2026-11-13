using LibreriaApp2026.Entidades.Enums;
using LibreriaApp2026.Servicios.Common;
using LibreriaApp2026.Servicios.DTOs.Venta;

namespace LibreriaApp2026.Servicios.Interfaces
{
    public interface IVentaServicio
    {
        Result<ResultadoPaginacionDto<VentaListDto>> ObtenerPaginado(int paginaActual,
            int cantidadPorPagina, string campoOrdenar, bool esAscendente, EstadoVenta? filtroEstado,
            string? textoBuscar = null);
        Result<VentaDetailDto> ObtenerDetalle(int id);
        Result<List<ProductoVentaDto>> ObtenerProductosParaVenta(string? textoBuscar = null);
        //devuelve el número de la venta registrada
        Result<int> Agregar(VentaCreateDto ventaDto);
        Result Facturar(VentaCambioEstadoDto ventaDto);
        Result Anular(VentaCambioEstadoDto ventaDto);
    }
}
