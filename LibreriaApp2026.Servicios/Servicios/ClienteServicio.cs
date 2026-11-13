using LibreriaApp2026.Datos;
using LibreriaApp2026.Entidades;
using LibreriaApp2026.Servicios.Common;
using LibreriaApp2026.Servicios.DTOs.Cliente;
using LibreriaApp2026.Servicios.Interfaces;
using LibreriaApp2026.Servicios.Mapeadores;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LibreriaApp2026.Servicios.Servicios
{
    public class ClienteServicio : IClienteServicio
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<ClienteCreateDto> _createValidator;
        private readonly IValidator<ClienteUpdateDto> _updateValidator;

        public ClienteServicio(
            IUnitOfWork unitOfWork,
            IValidator<ClienteCreateDto> createValidator,
            IValidator<ClienteUpdateDto> updateValidator)
        {
            _unitOfWork = unitOfWork;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public Result Agregar(ClienteCreateDto clienteDto)
        {
            // 1. Validar DTO antes del mapeo
            var result = _createValidator.Validate(clienteDto);
            if (!result.IsValid)
            {
                return Result.Failure(result.Errors.Select(e => e.ErrorMessage).ToList());
            }

            // 2. Mapear a Entidad
            var cliente = ClienteMapper.ToEntidad(clienteDto);

            // 3. Regla de negocio: el documento no se puede repetir
            if (_unitOfWork.Clientes.Existe(cliente))
            {
                return Result.Failure($"Ya existe un cliente con el documento {cliente.Documento}.");
            }

            try
            {
                _unitOfWork.Clientes.Agregar(cliente);
                _unitOfWork.Save();
                return Result.Success();
            }
            catch (Exception ex)
            {
                _unitOfWork.RollBack();
                return Result.Failure($"Error al intentar agregar el cliente: {ex.Message}");
            }
        }

        public Result Editar(ClienteUpdateDto clienteDto)
        {
            var result = _updateValidator.Validate(clienteDto);
            if (!result.IsValid)
            {
                return Result.Failure(result.Errors.Select(e => e.ErrorMessage).ToList());
            }

            var cliente = _unitOfWork.Clientes.ObtenerPorId(clienteDto.ClienteId);
            if (cliente == null)
            {
                return Result.Failure("Cliente no encontrado.");
            }

            cliente.Nombre = clienteDto.Nombre;
            cliente.Apellido = clienteDto.Apellido;
            cliente.Documento = clienteDto.Documento;
            cliente.Email = clienteDto.Email;
            cliente.Telefono = clienteDto.Telefono;
            cliente.Calle = clienteDto.Calle;
            cliente.Numero = clienteDto.Numero;
            cliente.Localidad = clienteDto.Localidad;
            cliente.Provincia = clienteDto.Provincia;
            cliente.CodigoPostal = clienteDto.CodigoPostal;
            cliente.Activo = clienteDto.Activo;

            if (_unitOfWork.Clientes.Existe(cliente))
            {
                var mensaje = $"Ya existe otro cliente con el documento {cliente.Documento}.";
                _unitOfWork.RollBack();
                return Result.Failure(mensaje);
            }

            try
            {
                _unitOfWork.Clientes.Editar(cliente, cliente.ClienteId, clienteDto.RowVersion);
                _unitOfWork.Save();
                return Result.Success();
            }
            catch (DbUpdateConcurrencyException)
            {
                _unitOfWork.RollBack();
                return Result.ConcurrencyFailure("Otro usuario modificó el registro.\nLa grilla se recargará automáticamente");
            }
            catch (Exception ex)
            {
                _unitOfWork.RollBack();
                return Result.Failure($"Error al intentar editar el cliente: {ex.Message}");
            }
        }

        public Result Borrar(ClienteDeleteDto clienteDto)
        {
            var cliente = _unitOfWork.Clientes.ObtenerPorId(clienteDto.ClienteId);
            if (cliente == null)
            {
                return Result.Failure("Cliente no encontrado.");
            }

            // Regla de negocio: no se puede eliminar un cliente con ventas
            if (_unitOfWork.Clientes.EstaRelacionado(cliente))
            {
                return Result.Failure($"No se puede borrar el cliente {cliente.NombreCompleto} porque tiene ventas registradas.");
            }

            try
            {
                _unitOfWork.Clientes.Borrar(cliente.ClienteId, clienteDto.RowVersion);
                _unitOfWork.Save();
                return Result.Success();
            }
            catch (DbUpdateConcurrencyException)
            {
                _unitOfWork.RollBack();
                return Result.ConcurrencyFailure("Otro usuario modificó el registro.\nLa grilla se recargará automáticamente");
            }
            catch (Exception ex)
            {
                _unitOfWork.RollBack();
                return Result.Failure($"Error al intentar borrar el cliente: {ex.Message}");
            }
        }

        public Result<ClienteUpdateDto> ObtenerParaEditar(int id)
        {
            try
            {
                var cliente = _unitOfWork.Clientes.ObtenerPorId(id);
                if (cliente != null)
                {
                    return Result<ClienteUpdateDto>.Success(ClienteMapper.ToUpdateDto(cliente));
                }

                return Result<ClienteUpdateDto>.Failure("Cliente no encontrado.");
            }
            catch (Exception ex)
            {
                return Result<ClienteUpdateDto>.Failure(ex.Message);
            }
        }

        public Result<ClienteDeleteDto> ObtenerParaBorrar(int id)
        {
            try
            {
                var cliente = _unitOfWork.Clientes.ObtenerPorId(id);
                if (cliente != null)
                {
                    return Result<ClienteDeleteDto>.Success(ClienteMapper.ToDeleteDto(cliente));
                }

                return Result<ClienteDeleteDto>.Failure("Cliente no encontrado.");
            }
            catch (Exception ex)
            {
                return Result<ClienteDeleteDto>.Failure(ex.Message);
            }
        }

        public Result<List<ClienteListDto>> FiltrarPorActivo(bool activo)
        {
            try
            {
                var lista = _unitOfWork.Clientes.Query()
                    .Where(c => c.Activo == activo)
                    .OrderBy(c => c.Apellido).ThenBy(c => c.Nombre)
                    .ToList();
                var listaDto = lista.Select(ClienteMapper.ToListDto).ToList();
                return Result<List<ClienteListDto>>.Success(listaDto);
            }
            catch (Exception ex)
            {
                return Result<List<ClienteListDto>>.Failure($"Error al intentar filtrar los clientes: {ex.Message}");
            }
        }

        public Result<ResultadoPaginacionDto<ClienteListDto>> ObtenerPaginado(
            int pagina,
            int registros,
            string campoOrden,
            bool esAscendente,
            bool? filtroActivo = null,
            string? textoBuscar = null)
        {
            try
            {
                Expression<Func<Cliente, bool>>? filtro = c =>
                        (!filtroActivo.HasValue || c.Activo == filtroActivo.Value) &&
                        (string.IsNullOrWhiteSpace(textoBuscar) || c.Apellido.Contains(textoBuscar) ||
                            c.Nombre.Contains(textoBuscar) || c.Documento.Contains(textoBuscar));

                Func<IQueryable<Cliente>, IOrderedQueryable<Cliente>>? ordenarPor = campoOrden switch
                {
                    "ClienteId" => q => esAscendente ? q.OrderBy(c => c.ClienteId) : q.OrderByDescending(c => c.ClienteId),
                    "Documento" => q => esAscendente ? q.OrderBy(c => c.Documento) : q.OrderByDescending(c => c.Documento),
                    "Email" => q => esAscendente ? q.OrderBy(c => c.Email) : q.OrderByDescending(c => c.Email),
                    _ => q => esAscendente ? q.OrderBy(c => c.Apellido).ThenBy(c => c.Nombre) : q.OrderByDescending(c => c.Apellido).ThenByDescending(c => c.Nombre)
                };

                var resultado = _unitOfWork.Clientes.ObtenerPagina(pagina, registros, ordenarPor, filtro);
                var listaDto = resultado.lista.Select(ClienteMapper.ToListDto).ToList();

                var resultadoPaginacion = new ResultadoPaginacionDto<ClienteListDto>
                {
                    Items = listaDto,
                    CantidadRegistros = resultado.totalRegistros,
                    CantidadPorPagina = registros,
                    PaginaActual = pagina
                };

                return Result<ResultadoPaginacionDto<ClienteListDto>>.Success(resultadoPaginacion);
            }
            catch (Exception ex)
            {
                return Result<ResultadoPaginacionDto<ClienteListDto>>.Failure(ex.Message);
            }
        }
    }
}
