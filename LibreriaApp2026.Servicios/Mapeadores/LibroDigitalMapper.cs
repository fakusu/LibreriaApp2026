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
                Formato = libro.Formato,
                TamanioMB = libro.TamanioMB,
                Activo = libro.Activo,
            };
        }

        public static LibroDigital ToEntidad(LibroDigitalCreateDto libroDto)
        {
            var libro = new LibroDigital
            {
                Nombre = libroDto.Titulo,
                Descripcion = libroDto.Descripcion,
                ISBN = libroDto.ISBN,
                AnioPublicacion = libroDto.AnioPublicacion,
                Precio = libroDto.Precio,
                EditorialId = libroDto.EditorialId,
                Formato = libroDto.Formato,
                TamanioMB = libroDto.TamanioMB,
                UrlDescarga = libroDto.UrlDescarga,
                Activo = libroDto.Activo
            };
            libro.AsignarAutores(libroDto.AutoresIds);
            libro.AsignarTemas(libroDto.TemasIds);
            return libro;
        }

        public static LibroDigital ToEntidad(LibroDigitalUpdateDto libroDto)
        {
            var libro = new LibroDigital
            {
                ProductoId = libroDto.ProductoId,
                Nombre = libroDto.Titulo,
                Descripcion = libroDto.Descripcion,
                ISBN = libroDto.ISBN,
                AnioPublicacion = libroDto.AnioPublicacion,
                Precio = libroDto.Precio,
                EditorialId = libroDto.EditorialId,
                Formato = libroDto.Formato,
                TamanioMB = libroDto.TamanioMB,
                UrlDescarga = libroDto.UrlDescarga,
                Activo = libroDto.Activo,
                RowVersion = libroDto.RowVersion,
            };
            libro.AsignarAutores(libroDto.AutoresIds);
            libro.AsignarTemas(libroDto.TemasIds);
            return libro;
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
                Precio = libro.Precio,
                EditorialId = libro.EditorialId,
                AutoresIds = libro.LibrosAutores.Select(la => la.AutorId).ToList(),
                TemasIds = libro.LibrosTemas.Select(lt => lt.TemaId).ToList(),
                Formato = libro.Formato,
                TamanioMB = libro.TamanioMB,
                UrlDescarga = libro.UrlDescarga,
                Activo = libro.Activo,
                RowVersion = libro.RowVersion,
            };
        }

        public static LibroDigitalDeleteDto ToDeleteDto(LibroDigital libro)
        {
            return new LibroDigitalDeleteDto
            {
                ProductoId = libro.ProductoId,
                RowVersion = libro.RowVersion,
            };
        }
    }
}
