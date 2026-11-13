-- Validación de formatos: el documento del cliente pasa a ser un DNI (7 u 8 dígitos)
-- y el precio de los libros tiene que ser mayor a cero.
-- Al final lista los datos ya cargados que no cumplen las reglas nuevas, para corregirlos desde la aplicación.
-- Ejecutar una sola vez sobre la base LibreriaIo2026 (después de AgregarVentas.sql)
-- Ejecutar con codificación UTF-8:  sqlcmd -S . -E -C -f 65001 -i ValidacionFormatos.sql
USE LibreriaIo2026;
GO

-- Clientes.Documento: NVARCHAR(20) -> NVARCHAR(8), solo dígitos
DROP INDEX IX_Clientes_Documento ON Clientes;
ALTER TABLE Clientes DROP CONSTRAINT CK_Clientes_Documento;
GO
ALTER TABLE Clientes ALTER COLUMN Documento NVARCHAR(8) NOT NULL;
GO
CREATE UNIQUE INDEX IX_Clientes_Documento ON Clientes (Documento);
ALTER TABLE Clientes ADD CONSTRAINT CK_Clientes_Documento
    CHECK (LEN(Documento) BETWEEN 7 AND 8 AND Documento NOT LIKE '%[^0-9]%');
GO

-- Libros.Precio: mayor a cero
ALTER TABLE Libros DROP CONSTRAINT CK_Libros_Precio;
ALTER TABLE Libros ADD CONSTRAINT CK_Libros_Precio CHECK (Precio > 0);
GO

-- Datos existentes que no cumplen las reglas nuevas (no se modifican: al editarlos la aplicación pide corregirlos)
SET NOCOUNT ON;

SELECT 'Libro' AS Tabla, p.ProductoId AS Id, p.Nombre AS Registro, 'ISBN' AS Campo, l.ISBN AS Valor
FROM Libros l JOIN Productos p ON p.ProductoId = l.ProductoId
WHERE NOT (
    (LEN(l.ISBN) = 13 AND l.ISBN NOT LIKE '%[^0-9]%') OR
    (LEN(l.ISBN) = 10 AND LEFT(l.ISBN, 9) NOT LIKE '%[^0-9]%' AND RIGHT(l.ISBN, 1) LIKE '[0-9X]')
)
UNION ALL
SELECT 'Libro digital', d.ProductoId, p.Nombre, 'UrlDescarga', d.UrlDescarga
FROM LibrosDigitales d JOIN Productos p ON p.ProductoId = d.ProductoId
WHERE d.UrlDescarga LIKE '% %' OR d.UrlDescarga NOT LIKE '%_.__%'
UNION ALL
SELECT 'Autor', AutorId, Apellido + ', ' + Nombre, 'Nombre/Apellido', Nombre + ' ' + Apellido
FROM Autores
WHERE Nombre LIKE '%[0-9]%' OR Apellido LIKE '%[0-9]%'
UNION ALL
SELECT 'Autor', AutorId, Apellido + ', ' + Nombre, 'Nacionalidad', Nacionalidad
FROM Autores
WHERE Nacionalidad LIKE '%[0-9]%'
UNION ALL
SELECT 'Editorial', EditorialId, Nombre, 'PaisOrigen', PaisOrigen
FROM Editoriales
WHERE PaisOrigen LIKE '%[0-9]%'
UNION ALL
SELECT 'Cliente', ClienteId, Apellido + ', ' + Nombre, 'Telefono', Telefono
FROM Clientes
WHERE Telefono IS NOT NULL AND Telefono LIKE '%[^0-9 +()-]%'
UNION ALL
SELECT 'Cliente', ClienteId, Apellido + ', ' + Nombre, 'CodigoPostal', CodigoPostal
FROM Clientes
WHERE CodigoPostal IS NOT NULL
  AND NOT (LEN(CodigoPostal) = 4 AND CodigoPostal NOT LIKE '%[^0-9]%')
  AND NOT (LEN(CodigoPostal) = 8 AND CodigoPostal LIKE '[A-Z][0-9][0-9][0-9][0-9][A-Z][A-Z][A-Z]')
UNION ALL
SELECT 'Cliente', ClienteId, Apellido + ', ' + Nombre, 'Domicilio incompleto',
       CONCAT(Calle, ' ', Numero, ' - ', Localidad, ' - ', Provincia)
FROM Clientes
WHERE (Calle IS NOT NULL OR Numero IS NOT NULL OR Localidad IS NOT NULL OR Provincia IS NOT NULL OR CodigoPostal IS NOT NULL)
  AND (Calle IS NULL OR Numero IS NULL OR Localidad IS NULL OR Provincia IS NULL)
ORDER BY Tabla, Id;
GO
