-- Corrección etapa 2: el stock pasa a LibrosFisicos (los digitales no manejan stock)
-- y cada libro tiene un autor (FK AutorId en Libros)
-- Ejecutar una sola vez sobre la base LibreriaIo2026
USE LibreriaIo2026;
GO

-- Stock: de Libros a LibrosFisicos, conservando lo cargado
ALTER TABLE LibrosFisicos ADD Stock INT NOT NULL CONSTRAINT DF_LibrosFisicos_Stock DEFAULT (0);
GO

UPDATE lf
SET lf.Stock = l.Stock
FROM LibrosFisicos lf
INNER JOIN Libros l ON l.ProductoId = lf.ProductoId;
GO

ALTER TABLE LibrosFisicos ADD CONSTRAINT CK_LibrosFisicos_Stock CHECK (Stock >= 0);
ALTER TABLE Libros DROP CONSTRAINT CK_Libros_Stock;
ALTER TABLE Libros DROP COLUMN Stock;
GO

-- Autor: a los libros ya cargados se les asigna el primer autor (corregirlos después desde la app)
ALTER TABLE Libros ADD AutorId INT NULL;
GO

UPDATE Libros SET AutorId = (SELECT MIN(AutorId) FROM Autores);
GO

ALTER TABLE Libros ALTER COLUMN AutorId INT NOT NULL;
ALTER TABLE Libros ADD CONSTRAINT FK_Libros_Autores_AutorId FOREIGN KEY (AutorId)
    REFERENCES Autores (AutorId);
CREATE INDEX IX_Libros_AutorId ON Libros (AutorId);
GO
