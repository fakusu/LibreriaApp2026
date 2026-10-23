-- Concurrencia optimista: columna RowVersion en las tablas principales
-- (en Productos alcanza para LibrosFisicos y LibrosDigitales por la herencia TPT)
-- Ejecutar una sola vez sobre la base LibreriaIo2026
USE LibreriaIo2026;
GO

ALTER TABLE Editoriales ADD RowVersion ROWVERSION NOT NULL;
ALTER TABLE Autores ADD RowVersion ROWVERSION NOT NULL;
ALTER TABLE Temas ADD RowVersion ROWVERSION NOT NULL;
ALTER TABLE Productos ADD RowVersion ROWVERSION NOT NULL;
GO
