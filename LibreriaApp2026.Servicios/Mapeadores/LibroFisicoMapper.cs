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
                //la editorial, los autores y los temas solo vienen cargados si se hizo el Include
                Editorial = libro.Editorial?.Nombre ?? string.Empty,
                Autores = string.Join("; ", libro.LibrosAutores
                    .Where(la => la.Autor is not null)
                    .Select(la => $"{la.Autor.Apellido}, {la.Autor.Nombre}")
                    .Order()),
                Temas = string.Join("; ", libro.LibrosTemas
                    .Where(lt => lt.Tema is not null)
                    .Select(lt => lt.Tema.Nombre)
                    .Order()),
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
            var libro = new LibroFisico
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
            libro.AsignarAutores(libroDto.AutoresIds);
            libro.AsignarTemas(libroDto.TemasIds);
            return libro;
        }

        public static LibroFisico ToEntidad(LibroFisicoUpdateDto libroDto)
        {
            var libro = new LibroFisico
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
                RowVersion = libroDto.RowVersion,
            };
            libro.AsignarAutores(libroDto.AutoresIds);
            libro.AsignarTemas(libroDto.TemasIds);
            return libro;
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
                AutoresIds = libro.LibrosAutores.Select(la => la.AutorId).ToList(),
                TemasIds = libro.LibrosTemas.Select(lt => lt.TemaId).ToList(),
                PesoEnGramos = libro.PesoEnGramos,
                CantidadPaginas = libro.CantidadPaginas,
                Activo = libro.Activo,
                RowVersion = libro.RowVersion,
            };
        }

        public static LibroFisicoDeleteDto ToDeleteDto(LibroFisico libro)
        {
            return new LibroFisicoDeleteDto
            {
                ProductoId = libro.ProductoId,
                RowVersion = libro.RowVersion,
            };
        }
    }
}
