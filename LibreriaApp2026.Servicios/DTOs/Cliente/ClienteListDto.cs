using System.ComponentModel;

namespace LibreriaApp2026.Servicios.DTOs.Cliente
{
    public class ClienteListDto
    {
        public int ClienteId { get; set; }
        public string NombreCompleto { get; set; } = null!;
        public string Documento { get; set; } = null!;
        public string? Telefono { get; set; }
        public string? Email { get; set; }
        public bool Activo { get; set; }

        //el domicilio no se muestra en la grilla; se usa en la venta (envío a domicilio)
        [Browsable(false)]
        public string? Direccion { get; set; }
        [Browsable(false)]
        public string? Localidad { get; set; }
        [Browsable(false)]
        public string? Provincia { get; set; }
        [Browsable(false)]
        public string? CodigoPostal { get; set; }
    }
}
