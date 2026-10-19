using LibreriaApp2026.Entidades;
using LibreriaApp2026.Servicios.DTOs.LibroFisico;

namespace LibreriaApp2026.Servicios.Mapeadores
{
    public static class LibroFisicoMapper
    {
        public static LibroFisicoListDto ToListDto(LibroFisico libro)
        {
            return new LibroFisicoListDto
            {
                ProductoId = libro.ProductoId,
                Titulo = libro.Nombre,
                ISBN = libro.ISBN,
                //la editorial solo viene cargada si se hizo el Include
                Editorial = libro.Editorial?.Nombre ?? string.Empty,
                AnioPublicacion = libro.AnioPublicacion,
                Precio = libro.Precio,
                Stock = libro.Stock,
                CantidadPaginas = libro.CantidadPaginas,
                PesoEnGramos = libro.PesoEnGramos,
                Activo = libro.Activo,
            };
        }

        public static LibroFisico ToEntidad(LibroFisicoCreateDto libroDto)
        {
            return new LibroFisico
            {
                Nombre = libroDto.Titulo,
                Descripcion = libroDto.Descripcion,
                ISBN = libroDto.ISBN,
                AnioPublicacion = libroDto.AnioPublicacion,
                Stock = libroDto.Stock,
                Precio = libroDto.Precio,
                EditorialId = libroDto.EditorialId,
                PesoEnGramos = libroDto.PesoEnGramos,
                CantidadPaginas = libroDto.CantidadPaginas,
                Activo = libroDto.Activo
            };
        }

        public static LibroFisico ToEntidad(LibroFisicoUpdateDto libroDto)
        {
            return new LibroFisico
            {
                ProductoId = libroDto.ProductoId,
                Nombre = libroDto.Titulo,
                Descripcion = libroDto.Descripcion,
                ISBN = libroDto.ISBN,
                AnioPublicacion = libroDto.AnioPublicacion,
                Stock = libroDto.Stock,
                Precio = libroDto.Precio,
                EditorialId = libroDto.EditorialId,
                PesoEnGramos = libroDto.PesoEnGramos,
                CantidadPaginas = libroDto.CantidadPaginas,
                Activo = libroDto.Activo,
            };
        }

        public static LibroFisicoUpdateDto ToUpdateDto(LibroFisico libro)
        {
            return new LibroFisicoUpdateDto
            {
                ProductoId = libro.ProductoId,
                Titulo = libro.Nombre,
                Descripcion = libro.Descripcion,
                ISBN = libro.ISBN,
                AnioPublicacion = libro.AnioPublicacion,
                Stock = libro.Stock,
                Precio = libro.Precio,
                EditorialId = libro.EditorialId,
                PesoEnGramos = libro.PesoEnGramos,
                CantidadPaginas = libro.CantidadPaginas,
                Activo = libro.Activo,
            };
        }
    }
}
