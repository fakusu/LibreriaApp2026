using LibreriaApp2026.Entidades;
using LibreriaApp2026.Servicios.DTOs.LibroDigital;

namespace LibreriaApp2026.Servicios.Mapeadores
{
    public static class LibroDigitalMapper
    {
        public static LibroDigitalListDto ToListDto(LibroDigital libro)
        {
            return new LibroDigitalListDto
            {
                ProductoId = libro.ProductoId,
                Titulo = libro.Nombre,
                ISBN = libro.ISBN,
                //la editorial solo viene cargada si se hizo el Include
                Editorial = libro.Editorial?.Nombre ?? string.Empty,
                AnioPublicacion = libro.AnioPublicacion,
                Precio = libro.Precio,
                Stock = libro.Stock,
                Formato = libro.Formato,
                TamanioMB = libro.TamanioMB,
                Activo = libro.Activo,
            };
        }

        public static LibroDigital ToEntidad(LibroDigitalCreateDto libroDto)
        {
            return new LibroDigital
            {
                Nombre = libroDto.Titulo,
                Descripcion = libroDto.Descripcion,
                ISBN = libroDto.ISBN,
                AnioPublicacion = libroDto.AnioPublicacion,
                Stock = libroDto.Stock,
                Precio = libroDto.Precio,
                EditorialId = libroDto.EditorialId,
                Formato = libroDto.Formato,
                TamanioMB = libroDto.TamanioMB,
                UrlDescarga = libroDto.UrlDescarga,
                Activo = libroDto.Activo
            };
        }

        public static LibroDigital ToEntidad(LibroDigitalUpdateDto libroDto)
        {
            return new LibroDigital
            {
                ProductoId = libroDto.ProductoId,
                Nombre = libroDto.Titulo,
                Descripcion = libroDto.Descripcion,
                ISBN = libroDto.ISBN,
                AnioPublicacion = libroDto.AnioPublicacion,
                Stock = libroDto.Stock,
                Precio = libroDto.Precio,
                EditorialId = libroDto.EditorialId,
                Formato = libroDto.Formato,
                TamanioMB = libroDto.TamanioMB,
                UrlDescarga = libroDto.UrlDescarga,
                Activo = libroDto.Activo,
            };
        }

        public static LibroDigitalUpdateDto ToUpdateDto(LibroDigital libro)
        {
            return new LibroDigitalUpdateDto
            {
                ProductoId = libro.ProductoId,
                Titulo = libro.Nombre,
                Descripcion = libro.Descripcion,
                ISBN = libro.ISBN,
                AnioPublicacion = libro.AnioPublicacion,
                Stock = libro.Stock,
                Precio = libro.Precio,
                EditorialId = libro.EditorialId,
                Formato = libro.Formato,
                TamanioMB = libro.TamanioMB,
                UrlDescarga = libro.UrlDescarga,
                Activo = libro.Activo,
            };
        }
    }
}
