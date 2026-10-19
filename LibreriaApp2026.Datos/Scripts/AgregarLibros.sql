-- Etapa 2: herencia Producto -> Libro -> LibroFisico / LibroDigital (mapeo TPT: una tabla por clase)
-- Ejecutar sobre la base LibreriaIo2026 (ya tiene Editoriales, Autores y Temas)
USE LibreriaIo2026;
GO

CREATE TABLE Productos
(
    ProductoId  INT IDENTITY(1,1) NOT NULL,
    Nombre      NVARCHAR(150) NOT NULL,
    Descripcion NVARCHAR(500) NULL,
    Activo      BIT NOT NULL CONSTRAINT DF_Productos_Activo DEFAULT (1),
    CONSTRAINT PK_Productos PRIMARY KEY (ProductoId)
);
GO

CREATE TABLE Libros
(
    ProductoId      INT NOT NULL,
    ISBN            NVARCHAR(13) NOT NULL,
    AnioPublicacion INT NOT NULL,
    Stock           INT NOT NULL,
    Precio          DECIMAL(18,2) NOT NULL,
    EditorialId     INT NOT NULL,
    CONSTRAINT PK_Libros PRIMARY KEY (ProductoId),
    CONSTRAINT FK_Libros_Productos_ProductoId FOREIGN KEY (ProductoId)
        REFERENCES Productos (ProductoId) ON DELETE CASCADE,
    CONSTRAINT FK_Libros_Editoriales_EditorialId FOREIGN KEY (EditorialId)
        REFERENCES Editoriales (EditorialId),
    CONSTRAINT CK_Libros_Stock CHECK (Stock >= 0),
    CONSTRAINT CK_Libros_Precio CHECK (Precio >= 0)
);
GO

CREATE UNIQUE INDEX IX_Libros_ISBN ON Libros (ISBN);
CREATE INDEX IX_Libros_EditorialId ON Libros (EditorialId);
GO

CREATE TABLE LibrosFisicos
(
    ProductoId      INT NOT NULL,
    PesoEnGramos    INT NOT NULL,
    CantidadPaginas INT NOT NULL,
    CONSTRAINT PK_LibrosFisicos PRIMARY KEY (ProductoId),
    CONSTRAINT FK_LibrosFisicos_Libros_ProductoId FOREIGN KEY (ProductoId)
        REFERENCES Libros (ProductoId) ON DELETE CASCADE,
    CONSTRAINT CK_LibrosFisicos_PesoEnGramos CHECK (PesoEnGramos > 0),
    CONSTRAINT CK_LibrosFisicos_CantidadPaginas CHECK (CantidadPaginas > 0)
);
GO

CREATE TABLE LibrosDigitales
(
    ProductoId  INT NOT NULL,
    Formato     NVARCHAR(10) NOT NULL,
    TamanioMB   DECIMAL(10,2) NOT NULL,
    UrlDescarga NVARCHAR(300) NOT NULL,
    CONSTRAINT PK_LibrosDigitales PRIMARY KEY (ProductoId),
    CONSTRAINT FK_LibrosDigitales_Libros_ProductoId FOREIGN KEY (ProductoId)
        REFERENCES Libros (ProductoId) ON DELETE CASCADE,
    CONSTRAINT CK_LibrosDigitales_TamanioMB CHECK (TamanioMB > 0)
);
GO
