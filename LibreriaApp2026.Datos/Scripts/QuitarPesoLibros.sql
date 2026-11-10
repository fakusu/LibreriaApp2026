-- Se elimina el peso en gramos de los libros físicos (ya no se usa)
-- Ejecutar una sola vez sobre la base LibreriaIo2026
USE LibreriaIo2026;
GO

ALTER TABLE LibrosFisicos DROP CONSTRAINT CK_LibrosFisicos_PesoEnGramos;
ALTER TABLE LibrosFisicos DROP COLUMN PesoEnGramos;
GO
