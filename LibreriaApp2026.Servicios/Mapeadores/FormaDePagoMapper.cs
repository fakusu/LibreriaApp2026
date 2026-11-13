using LibreriaApp2026.Entidades;
using LibreriaApp2026.Servicios.DTOs.FormaDePago;

namespace LibreriaApp2026.Servicios.Mapeadores
{
    public static class FormaDePagoMapper
    {
        public static FormaDePagoListDto ToListDto(FormaDePago formaDePago)
        {
            return new FormaDePagoListDto
            {
                FormaDePagoId = formaDePago.FormaDePagoId,
                Nombre = formaDePago.Nombre,
                Activo = formaDePago.Activo,
            };
        }

        public static FormaDePago ToEntidad(FormaDePagoCreateDto formaDePagoDto)
        {
            return new FormaDePago
            {
                Nombre = formaDePagoDto.Nombre,
                Activo = formaDePagoDto.Activo
            };
        }

        public static FormaDePagoUpdateDto ToUpdateDto(FormaDePago formaDePago)
        {
            return new FormaDePagoUpdateDto
            {
                FormaDePagoId = formaDePago.FormaDePagoId,
                Nombre = formaDePago.Nombre,
                Activo = formaDePago.Activo,
                RowVersion = formaDePago.RowVersion,
            };
        }

        public static FormaDePagoDeleteDto ToDeleteDto(FormaDePago formaDePago)
        {
            return new FormaDePagoDeleteDto
            {
                FormaDePagoId = formaDePago.FormaDePagoId,
                RowVersion = formaDePago.RowVersion,
            };
        }
    }
}
