using LibreriaApp2026.Entidades;
using LibreriaApp2026.Servicios.DTOs.Venta;

namespace LibreriaApp2026.Servicios.Mapeadores
{
    public static class VentaMapper
    {
        public static VentaListDto ToListDto(Venta venta)
        {
            return new VentaListDto
            {
                VentaId = venta.VentaId,
                FechaVenta = venta.FechaVenta,
                Cliente = venta.Cliente.NombreCompleto,
                FormaDePago = venta.FormaDePago.Nombre,
                ImporteTotal = venta.ImporteTotal,
                Estado = venta.EstadoVenta.ToString(),
                RowVersion = venta.RowVersion,
            };
        }

        public static VentaDetailDto ToDetailDto(Venta venta)
        {
            var cliente = venta.Cliente;
            var domicilio = string.Join(", ", new[]
            {
                $"{cliente.Calle} {cliente.Numero}".Trim(),
                cliente.Localidad,
                cliente.Provincia,
                string.IsNullOrWhiteSpace(cliente.CodigoPostal) ? null : $"CP {cliente.CodigoPostal}"
            }.Where(s => !string.IsNullOrWhiteSpace(s)));

            return new VentaDetailDto
            {
                VentaId = venta.VentaId,
                FechaVenta = venta.FechaVenta,
                Cliente = cliente.NombreCompleto,
                Documento = cliente.Documento,
                Domicilio = string.IsNullOrWhiteSpace(domicilio) ? null : domicilio,
                FormaDePago = venta.FormaDePago.Nombre,
                Estado = venta.EstadoVenta.ToString(),
                ImporteTotal = venta.ImporteTotal,
                Detalles = venta.Detalles.Select(ToDetalleDto).ToList(),
            };
        }

        public static DetalleVentaDto ToDetalleDto(DetalleVenta detalle)
        {
            return new DetalleVentaDto
            {
                ProductoId = detalle.ProductoId,
                Producto = detalle.Producto.Nombre,
                Tipo = TipoDeProducto(detalle.Producto),
                Cantidad = detalle.Cantidad,
                PrecioUnitario = detalle.PrecioUnitario,
            };
        }

        public static ProductoVentaDto ToProductoVentaDto(Libro libro)
        {
            return new ProductoVentaDto
            {
                ProductoId = libro.ProductoId,
                Titulo = libro.Nombre,
                Tipo = TipoDeProducto(libro),
                Editorial = libro.Editorial.Nombre,
                Precio = libro.Precio,
                Stock = libro is LibroFisico fisico ? fisico.Stock : null,
            };
        }

        private static string TipoDeProducto(Producto producto)
        {
            return producto switch
            {
                LibroFisico => "Libro físico",
                LibroDigital => "Libro digital",
                _ => "Producto"
            };
        }
    }
}
