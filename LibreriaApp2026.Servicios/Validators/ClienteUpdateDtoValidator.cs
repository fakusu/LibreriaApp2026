using LibreriaApp2026.Servicios.DTOs.Cliente;
using FluentValidation;

namespace LibreriaApp2026.Servicios.Validators
{
    public class ClienteUpdateDtoValidator : AbstractValidator<ClienteUpdateDto>
    {
        public ClienteUpdateDtoValidator()
        {
            RuleFor(x => x.ClienteId)
                .GreaterThan(0).WithMessage("El identificador del cliente debe ser mayor a cero.");

            ClienteReglas.Aplicar(this);

            RuleFor(x => x.RowVersion)
                .NotNull().WithMessage("El campo de concurrencia es obligatorio.");
        }
    }
}
