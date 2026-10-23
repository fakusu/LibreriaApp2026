using LibreriaApp2026.Entidades;
using LibreriaApp2026.Servicios.DTOs.Autor;

namespace LibreriaApp2026.Servicios.Mapeadores
{
    public static class AutorMapper
    {
        public static AutorListDto ToListDto(Autor autor)
        {
            return new AutorListDto
            {
                AutorId = autor.AutorId,
                NombreCompleto = $"{autor.Apellido}, {autor.Nombre}",
                FechaNacimiento = autor.FechaNacimiento,
                Nacionalidad = autor.Nacionalidad,
                Activo = autor.Activo,
            };
        }

        public static Autor ToEntidad(AutorCreateDto autorDto)
        {
            return new Autor
            {
                Nombre = autorDto.Nombre,
                Apellido = autorDto.Apellido,
                FechaNacimiento = autorDto.FechaNacimiento,
                Nacionalidad = autorDto.Nacionalidad,
                Activo = autorDto.Activo
            };
        }

        public static Autor ToEntidad(AutorUpdateDto autorDto)
        {
            return new Autor
            {
                AutorId = autorDto.AutorId,
                Nombre = autorDto.Nombre,
                Apellido = autorDto.Apellido,
                FechaNacimiento = autorDto.FechaNacimiento,
                Nacionalidad = autorDto.Nacionalidad,
                Activo = autorDto.Activo,
                RowVersion = autorDto.RowVersion,
            };
        }

        public static AutorUpdateDto ToUpdateDto(Autor autor)
        {
            return new AutorUpdateDto
            {
                AutorId = autor.AutorId,
                Nombre = autor.Nombre,
                Apellido = autor.Apellido,
                FechaNacimiento = autor.FechaNacimiento,
                Nacionalidad = autor.Nacionalidad,
                Activo = autor.Activo,
                RowVersion = autor.RowVersion,
            };
        }

        public static AutorDeleteDto ToDeleteDto(Autor autor)
        {
            return new AutorDeleteDto
            {
                AutorId = autor.AutorId,
                RowVersion = autor.RowVersion,
            };
        }
    }
}
