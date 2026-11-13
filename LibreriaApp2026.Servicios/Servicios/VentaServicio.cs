using LibreriaApp2026.Datos;
using LibreriaApp2026.Entidades;
using LibreriaApp2026.Entidades.Enums;
using LibreriaApp2026.Servicios.Common;
using LibreriaApp2026.Servicios.DTOs.Venta;
using LibreriaApp2026.Servicios.Interfaces;
using LibreriaApp2026.Servicios.Mapeadores;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LibreriaApp2026.Servicios.Servicios
{
    public class VentaServicio : IVentaServicio
    {
        private const string MensajeConcurrencia = "Otro usuario modificó la venta.\nLa grilla se recargará automáticamente";

        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<VentaCreateDto> _createValidator;

        public VentaServicio(IUnitOfWork unitOfWork, IValidator<VentaCreateDto> createValidator)
        {
            _unitOfWork = unitOfWork;
            _createValidator = createValidator;
        }

        public Result<int> Agregar(VentaCreateDto ventaDto)
        {
            // 1. Validar el DTO (cliente, forma de pago, al menos un producto, cantidades)
            var result = _createValidator.Validate(ventaDto);
            if (!result.IsValid)
            {
                return Result<int>.Failure(result.Errors.Select(e => e.ErrorMessage).ToList());
            }

            // 2. Reglas de negocio contra la base de datos (se juntan todos los errores)
            var errores = new List<string>();

            var cliente = _unitOfWork.Clientes.ObtenerPorId(ventaDto.ClienteId);
            if (cliente is null)
            {
                errores.Add("El cliente seleccionado no existe.");
            }
            else if (!cliente.Activo)
            {
                errores.Add($"El cliente {cliente.NombreCompleto} no está activo.");
            }

            var formaDePago = _unitOfWork.FormasDePago.ObtenerPorId(ventaDto.FormaDePagoId);
            if (formaDePago is null)
            {
                errores.Add("La forma de pago seleccionada no existe.");
            }
            else if (!formaDePago.Activo)
            {
                errores.Add($"La forma de pago {formaDePago.Nombre} no está activa.");
            }

            //con seguimiento de cambios: a los libros físicos se les descuenta el stock
            var libros = _unitOfWork.Ventas.ObtenerLibros(ventaDto.Detalles.Select(d => d.ProductoId));
            foreach (var item in ventaDto.Detalles)
            {
                var libro = libros.FirstOrDefault(l => l.ProductoId == item.ProductoId);
                if (libro is null)
                {
                    errores.Add($"El producto {item.ProductoId} no existe.");
                    continue;
                }

                // No se puede vender un producto inactivo o cuya editorial esté inactiva
                if (!libro.Activo)
                {
                    errores.Add($"El libro {libro.Nombre} no está activo.");
                }
                if (!libro.Editorial.Activo)
                {
                    errores.Add($"El libro {libro.Nombre} pertenece a una editorial inactiva ({libro.Editorial.Nombre}).");
                }

                switch (libro)
                {
                    // Los físicos tienen stock
                    case LibroFisico fisico when fisico.Stock < item.Cantidad:
                        errores.Add($"Stock insuficiente de {libro.Nombre}. Disponible: {fisico.Stock}, solicitado: {item.Cantidad}.");
                        break;
                    // Los digitales no tienen stock: se vende una licencia por venta
                    case LibroDigital when item.Cantidad != 1:
                        errores.Add($"El libro digital {libro.Nombre} se vende de a una unidad.");
                        break;
                }
            }

            if (errores.Count > 0)
            {
                _unitOfWork.RollBack();
                return Result<int>.Failure(errores);
            }

            try
            {
                // 3. Armar la venta: el precio se toma del libro (no de la pantalla)
                var venta = new Venta(ventaDto.ClienteId, ventaDto.FormaDePagoId);
                foreach (var item in ventaDto.Detalles)
                {
                    var libro = libros.First(l => l.ProductoId == item.ProductoId);
                    venta.AgregarDetalle(libro.ProductoId, item.Cantidad, libro.Precio);

                    if (libro is LibroFisico fisico)
                    {
                        fisico.Stock -= item.Cantidad;
                    }
                }

                // 4. Un solo SaveChanges: la venta, sus detalles y el stock se guardan todos juntos o ninguno
                _unitOfWork.Ventas.Agregar(venta);
                _unitOfWork.Save();
                return Result<int>.Success(venta.VentaId);
            }
            catch (DbUpdateConcurrencyException)
            {
                _unitOfWork.RollBack();
                return Result<int>.Failure("Otro usuario modificó el stock de algún libro mientras se cargaba la venta. Vuelva a intentarlo.");
            }
            catch (Exception ex)
            {
                _unitOfWork.RollBack();
                return Result<int>.Failure($"Error al intentar registrar la venta: {ex.InnerException?.Message ?? ex.Message}");
            }
        }

        public Result Facturar(VentaCambioEstadoDto ventaDto)
        {
            var venta = _unitOfWork.Ventas.ObtenerConDetalles(ventaDto.VentaId);
            if (venta is null)
            {
                return Result.Failure("Venta no encontrada.");
            }

            if (venta.EstadoVenta != EstadoVenta.Pendiente)
            {
                return Result.Failure($"La venta N° {venta.VentaId} ya está {venta.EstadoVenta.ToString().ToLower()}; solo se pueden facturar ventas pendientes.");
            }

            try
            {
                venta.Facturar();
                _unitOfWork.Ventas.Editar(venta, venta.VentaId, ventaDto.RowVersion);
                _unitOfWork.Save();
                return Result.Success();
            }
            catch (DbUpdateConcurrencyException)
            {
                _unitOfWork.RollBack();
                return Result.ConcurrencyFailure(MensajeConcurrencia);
            }
            catch (Exception ex)
            {
                _unitOfWork.RollBack();
                return Result.Failure($"Error al intentar facturar la venta: {ex.Message}");
            }
        }

        public Result Anular(VentaCambioEstadoDto ventaDto)
        {
            var venta = _unitOfWork.Ventas.ObtenerConDetalles(ventaDto.VentaId);
            if (venta is null)
            {
                return Result.Failure("Venta no encontrada.");
            }

            if (venta.EstadoVenta != EstadoVenta.Pendiente)
            {
                return Result.Failure($"La venta N° {venta.VentaId} ya está {venta.EstadoVenta.ToString().ToLower()}; solo se pueden anular ventas pendientes.");
            }

            try
            {
                venta.Anular();

                // Se devuelve el stock de los libros físicos
                var libros = _unitOfWork.Ventas.ObtenerLibros(venta.Detalles.Select(d => d.ProductoId));
                foreach (var detalle in venta.Detalles)
                {
                    if (libros.FirstOrDefault(l => l.ProductoId == detalle.ProductoId) is LibroFisico fisico)
                    {
                        fisico.Stock += detalle.Cantidad;
                    }
                }

                _unitOfWork.Ventas.Editar(venta, venta.VentaId, ventaDto.RowVersion);
                _unitOfWork.Save();
                return Result.Success();
            }
            catch (DbUpdateConcurrencyException)
            {
                _unitOfWork.RollBack();
                return Result.ConcurrencyFailure(MensajeConcurrencia);
            }
            catch (Exception ex)
            {
                _unitOfWork.RollBack();
                return Result.Failure($"Error al intentar anular la venta: {ex.Message}");
            }
        }

        public Result<VentaDetailDto> ObtenerDetalle(int id)
        {
            try
            {
                var venta = _unitOfWork.Ventas.ObtenerParaConsulta(id);
                if (venta is null)
                {
                    return Result<VentaDetailDto>.Failure("Venta no encontrada.");
                }

                return Result<VentaDetailDto>.Success(VentaMapper.ToDetailDto(venta));
            }
            catch (Exception ex)
            {
                return Result<VentaDetailDto>.Failure(ex.Message);
            }
        }

        public Result<List<ProductoVentaDto>> ObtenerProductosParaVenta(string? textoBuscar = null)
        {
            try
            {
                var libros = _unitOfWork.Ventas.ObtenerLibrosParaVenta(textoBuscar);
                var listaDto = libros.Select(VentaMapper.ToProductoVentaDto).ToList();
                return Result<List<ProductoVentaDto>>.Success(listaDto);
            }
            catch (Exception ex)
            {
                return Result<List<ProductoVentaDto>>.Failure(ex.Message);
            }
        }

        public Result<ResultadoPaginacionDto<VentaListDto>> ObtenerPaginado(
            int pagina,
            int registros,
            string campoOrden,
            bool esAscendente,
            EstadoVenta? filtroEstado = null,
            string? textoBuscar = null)
        {
            try
            {
                Expression<Func<Venta, bool>>? filtro = v =>
                        (!filtroEstado.HasValue || v.EstadoVenta == filtroEstado.Value) &&
                        (string.IsNullOrWhiteSpace(textoBuscar) || v.Cliente.Apellido.Contains(textoBuscar) ||
                            v.Cliente.Nombre.Contains(textoBuscar) || v.Cliente.Documento.Contains(textoBuscar));

                Func<IQueryable<Venta>, IOrderedQueryable<Venta>>? ordenarPor = campoOrden switch
                {
                    "VentaId" => q => esAscendente ? q.OrderBy(v => v.VentaId) : q.OrderByDescending(v => v.VentaId),
                    "Cliente" => q => esAscendente ? q.OrderBy(v => v.Cliente.Apellido).ThenBy(v => v.Cliente.Nombre) : q.OrderByDescending(v => v.Cliente.Apellido).ThenByDescending(v => v.Cliente.Nombre),
                    "FormaDePago" => q => esAscendente ? q.OrderBy(v => v.FormaDePago.Nombre) : q.OrderByDescending(v => v.FormaDePago.Nombre),
                    "ImporteTotal" => q => esAscendente ? q.OrderBy(v => v.ImporteTotal) : q.OrderByDescending(v => v.ImporteTotal),
                    "Estado" => q => esAscendente ? q.OrderBy(v => v.EstadoVenta) : q.OrderByDescending(v => v.EstadoVenta),
                    _ => q => esAscendente ? q.OrderBy(v => v.FechaVenta) : q.OrderByDescending(v => v.FechaVenta)
                };

                var resultado = _unitOfWork.Ventas.ObtenerPagina(pagina, registros, ordenarPor, filtro,
                    q => q.Include(v => v.Cliente).Include(v => v.FormaDePago));
                var listaDto = resultado.lista.Select(VentaMapper.ToListDto).ToList();

                var resultadoPaginacion = new ResultadoPaginacionDto<VentaListDto>
                {
                    Items = listaDto,
                    CantidadRegistros = resultado.totalRegistros,
                    CantidadPorPagina = registros,
                    PaginaActual = pagina
                };

                return Result<ResultadoPaginacionDto<VentaListDto>>.Success(resultadoPaginacion);
            }
            catch (Exception ex)
            {
                return Result<ResultadoPaginacionDto<VentaListDto>>.Failure(ex.Message);
            }
        }
    }
}
