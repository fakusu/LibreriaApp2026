-- Etapa 3: Clientes, Formas de pago (tipo de venta), Ventas y Detalle de ventas
-- Ejecutar una sola vez sobre la base LibreriaIo2026 (ya tiene Editoriales, Autores, Temas y Libros)
-- Ejecutar con codificación UTF-8:  sqlcmd -S . -E -C -f 65001 -i AgregarVentas.sql
USE LibreriaIo2026;
GO

CREATE TABLE FormasDePago
(
    FormaDePagoId INT IDENTITY(1,1) NOT NULL,
    Nombre        NVARCHAR(50) NOT NULL,
    Activo        BIT NOT NULL CONSTRAINT DF_FormasDePago_Activo DEFAULT (1),
    RowVersion    ROWVERSION NOT NULL,
    CONSTRAINT PK_FormasDePago PRIMARY KEY (FormaDePagoId)
);
GO

CREATE UNIQUE INDEX IX_FormasDePago_Nombre ON FormasDePago (Nombre);
GO

CREATE TABLE Clientes
(
    ClienteId    INT IDENTITY(1,1) NOT NULL,
    Nombre       NVARCHAR(50) NOT NULL,
    Apellido     NVARCHAR(50) NOT NULL,
    Documento    NVARCHAR(20) NOT NULL,
    Email        NVARCHAR(100) NULL,
    Telefono     NVARCHAR(30) NULL,
    Calle        NVARCHAR(100) NULL,
    Numero       NVARCHAR(20) NULL,
    Localidad    NVARCHAR(100) NULL,
    Provincia    NVARCHAR(100) NULL,
    CodigoPostal NVARCHAR(10) NULL,
    Activo       BIT NOT NULL CONSTRAINT DF_Clientes_Activo DEFAULT (1),
    RowVersion   ROWVERSION NOT NULL,
    CONSTRAINT PK_Clientes PRIMARY KEY (ClienteId),
    CONSTRAINT CK_Clientes_Documento CHECK (LEN(Documento) >= 7)
);
GO

CREATE UNIQUE INDEX IX_Clientes_Documento ON Clientes (Documento);
GO

-- EstadoVenta: 1 = Pendiente, 2 = Facturada, 3 = Anulada
CREATE TABLE Ventas
(
    VentaId       INT IDENTITY(1,1) NOT NULL,
    ClienteId     INT NOT NULL,
    FormaDePagoId INT NOT NULL,
    FechaVenta    DATETIME2 NOT NULL,
    EstadoVenta   TINYINT NOT NULL CONSTRAINT DF_Ventas_EstadoVenta DEFAULT (1),
    ImporteTotal  DECIMAL(18,2) NOT NULL,
    RowVersion    ROWVERSION NOT NULL,
    CONSTRAINT PK_Ventas PRIMARY KEY (VentaId),
    CONSTRAINT FK_Ventas_Clientes_ClienteId FOREIGN KEY (ClienteId)
        REFERENCES Clientes (ClienteId),
    CONSTRAINT FK_Ventas_FormasDePago_FormaDePagoId FOREIGN KEY (FormaDePagoId)
        REFERENCES FormasDePago (FormaDePagoId),
    CONSTRAINT CK_Ventas_EstadoVenta CHECK (EstadoVenta BETWEEN 1 AND 3),
    CONSTRAINT CK_Ventas_ImporteTotal CHECK (ImporteTotal >= 0)
);
GO

CREATE INDEX IX_Ventas_ClienteId ON Ventas (ClienteId);
CREATE INDEX IX_Ventas_FormaDePagoId ON Ventas (FormaDePagoId);
GO

CREATE TABLE DetallesVentas
(
    VentaId        INT NOT NULL,
    ProductoId     INT NOT NULL,
    Cantidad       INT NOT NULL,
    PrecioUnitario DECIMAL(18,2) NOT NULL,
    CONSTRAINT PK_DetallesVentas PRIMARY KEY (VentaId, ProductoId),
    CONSTRAINT FK_DetallesVentas_Ventas_VentaId FOREIGN KEY (VentaId)
        REFERENCES Ventas (VentaId),
    CONSTRAINT FK_DetallesVentas_Productos_ProductoId FOREIGN KEY (ProductoId)
        REFERENCES Productos (ProductoId),
    CONSTRAINT CK_DetallesVentas_Cantidad CHECK (Cantidad > 0),
    CONSTRAINT CK_DetallesVentas_PrecioUnitario CHECK (PrecioUnitario >= 0)
);
GO

CREATE INDEX IX_DetallesVentas_ProductoId ON DetallesVentas (ProductoId);
GO

-- Formas de pago iniciales
INSERT INTO FormasDePago (Nombre, Activo)
VALUES (N'Efectivo', 1), (N'Tarjeta de débito', 1), (N'Tarjeta de crédito', 1), (N'Transferencia', 1);
GO
