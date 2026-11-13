using LibreriaApp2026.Servicios.DTOs.Cliente;
using FluentValidation;

namespace LibreriaApp2026.Servicios.Validators
{
    public class ClienteCreateDtoValidator : AbstractValidator<ClienteCreateDto>
    {
        public ClienteCreateDtoValidator()
        {
            ClienteReglas.Aplicar(this);
        }
    }
}
