using LibreriaApp2026.Entidades;
using LibreriaApp2026.Servicios.DTOs.Cliente;

namespace LibreriaApp2026.Servicios.Mapeadores
{
    public static class ClienteMapper
    {
        public static ClienteListDto ToListDto(Cliente cliente)
        {
            return new ClienteListDto
            {
                ClienteId = cliente.ClienteId,
                NombreCompleto = $"{cliente.Apellido}, {cliente.Nombre}",
                Documento = cliente.Documento,
                Telefono = cliente.Telefono,
                Email = cliente.Email,
                Activo = cliente.Activo,
                Direccion = $"{cliente.Calle} {cliente.Numero}".Trim(),
                Localidad = cliente.Localidad,
                Provincia = cliente.Provincia,
                CodigoPostal = cliente.CodigoPostal,
            };
        }

        public static Cliente ToEntidad(ClienteCreateDto clienteDto)
        {
            return new Cliente
            {
                Nombre = clienteDto.Nombre,
                Apellido = clienteDto.Apellido,
                Documento = clienteDto.Documento,
                Email = clienteDto.Email,
                Telefono = clienteDto.Telefono,
                Calle = clienteDto.Calle,
                Numero = clienteDto.Numero,
                Localidad = clienteDto.Localidad,
                Provincia = clienteDto.Provincia,
                CodigoPostal = clienteDto.CodigoPostal,
                Activo = clienteDto.Activo
            };
        }

        public static ClienteUpdateDto ToUpdateDto(Cliente cliente)
        {
            return new ClienteUpdateDto
            {
                ClienteId = cliente.ClienteId,
                Nombre = cliente.Nombre,
                Apellido = cliente.Apellido,
                Documento = cliente.Documento,
                Email = cliente.Email,
                Telefono = cliente.Telefono,
                Calle = cliente.Calle,
                Numero = cliente.Numero,
                Localidad = cliente.Localidad,
                Provincia = cliente.Provincia,
                CodigoPostal = cliente.CodigoPostal,
                Activo = cliente.Activo,
                RowVersion = cliente.RowVersion,
            };
        }

        public static ClienteDeleteDto ToDeleteDto(Cliente cliente)
        {
            return new ClienteDeleteDto
            {
                ClienteId = cliente.ClienteId,
                RowVersion = cliente.RowVersion,
            };
        }
    }
}
