-- Relaciones N:M de Libros con Autores y Temas (tablas intermedias LibrosAutores y LibrosTemas)
-- Reemplaza la columna AutorId que agregó StockYAutorLibros.sql
-- Ejecutar una sola vez sobre la base LibreriaIo2026
USE LibreriaIo2026;
GO

CREATE TABLE LibrosAutores
(
    ProductoId INT NOT NULL,
    AutorId    INT NOT NULL,
    CONSTRAINT PK_LibrosAutores PRIMARY KEY (ProductoId, AutorId),
    CONSTRAINT FK_LibrosAutores_Libros_ProductoId FOREIGN KEY (ProductoId)
        REFERENCES Libros (ProductoId) ON DELETE CASCADE,
    CONSTRAINT FK_LibrosAutores_Autores_AutorId FOREIGN KEY (AutorId)
        REFERENCES Autores (AutorId)
);
GO

CREATE INDEX IX_LibrosAutores_AutorId ON LibrosAutores (AutorId);
GO

-- el autor que ya tenía cada libro pasa a la tabla intermedia
INSERT INTO LibrosAutores (ProductoId, AutorId)
SELECT ProductoId, AutorId FROM Libros;
GO

DROP INDEX IX_Libros_AutorId ON Libros;
ALTER TABLE Libros DROP CONSTRAINT FK_Libros_Autores_AutorId;
ALTER TABLE Libros DROP COLUMN AutorId;
GO

CREATE TABLE LibrosTemas
(
    ProductoId INT NOT NULL,
    TemaId     INT NOT NULL,
    CONSTRAINT PK_LibrosTemas PRIMARY KEY (ProductoId, TemaId),
    CONSTRAINT FK_LibrosTemas_Libros_ProductoId FOREIGN KEY (ProductoId)
        REFERENCES Libros (ProductoId) ON DELETE CASCADE,
    CONSTRAINT FK_LibrosTemas_Temas_TemaId FOREIGN KEY (TemaId)
        REFERENCES Temas (TemaId)
);
GO

CREATE INDEX IX_LibrosTemas_TemaId ON LibrosTemas (TemaId);
GO
