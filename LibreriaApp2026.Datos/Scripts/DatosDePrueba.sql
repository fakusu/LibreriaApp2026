-- Datos de prueba: más autores, editoriales, temas y libros (físicos y digitales)
-- Solo agrega registros; no modifica ni borra lo existente. Se puede ejecutar más de una vez
-- (cada autor, editorial, tema y libro se inserta solo si todavía no existe).
-- Ejecutar con codificación UTF-8:  sqlcmd -S . -E -C -f 65001 -i DatosDePrueba.sql
USE LibreriaIo2026;
GO
SET XACT_ABORT ON;
SET NOCOUNT ON;
BEGIN TRAN;

-- Autores
INSERT INTO Autores (Nombre, Apellido, FechaNacimiento, Nacionalidad, Activo)
SELECT v.Nombre, v.Apellido, v.Fecha, v.Nac, 1
FROM (VALUES
    (N'Mario',   N'Vargas Llosa', CAST('1936-03-28' AS date), N'Peruana'),
    (N'Ernesto', N'Sabato',       CAST('1911-06-24' AS date), N'Argentina'),
    (N'Mario',   N'Benedetti',    CAST('1920-09-14' AS date), N'Uruguaya'),
    (N'Stephen', N'King',         CAST('1947-09-21' AS date), N'Estadounidense'),
    (N'J. R. R.',N'Tolkien',      CAST('1892-01-03' AS date), N'Británica'),
    (N'Agatha',  N'Christie',     CAST('1890-09-15' AS date), N'Británica'),
    (N'Julio',   N'Verne',        CAST('1828-02-08' AS date), N'Francesa'),
    (N'Ray',     N'Bradbury',     CAST('1920-08-22' AS date), N'Estadounidense')
) v (Nombre, Apellido, Fecha, Nac)
WHERE NOT EXISTS (SELECT 1 FROM Autores a WHERE a.Apellido = v.Apellido AND a.Nombre = v.Nombre);

-- Editoriales
INSERT INTO Editoriales (Nombre, PaisOrigen, Activo)
SELECT v.Nombre, v.Pais, 1
FROM (VALUES
    (N'Alfaguara',  N'España'),
    (N'Seix Barral',N'España'),
    (N'Minotauro',  N'España'),
    (N'Debolsillo', N'España'),
    (N'Emecé',      N'Argentina')
) v (Nombre, Pais)
WHERE NOT EXISTS (SELECT 1 FROM Editoriales e WHERE e.Nombre = v.Nombre);

-- Temas
INSERT INTO Temas (Nombre, Descripcion, Activo)
SELECT v.Nombre, v.Descripcion, 1
FROM (VALUES
    (N'Cuento',   N'Relatos breves'),
    (N'Terror',   N'Narrativa de miedo y suspenso sobrenatural'),
    (N'Policial', N'Novelas de investigación y crimen'),
    (N'Ensayo',   N'Textos de reflexión y análisis')
) v (Nombre, Descripcion)
WHERE NOT EXISTS (SELECT 1 FROM Temas t WHERE t.Nombre = v.Nombre);

-- Libros a cargar. Tipo: F = físico, D = digital
CREATE TABLE #L
(
    N INT IDENTITY(1,1), Tipo CHAR(1), ISBN NVARCHAR(13), Nombre NVARCHAR(150), Descripcion NVARCHAR(500),
    Anio INT, Precio DECIMAL(18,2), Editorial NVARCHAR(100), Autor NVARCHAR(100), Tema1 NVARCHAR(100), Tema2 NVARCHAR(100) NULL,
    Peso INT NULL, Paginas INT NULL, Stock INT NULL, Formato NVARCHAR(10) NULL, MB DECIMAL(10,2) NULL, Url NVARCHAR(300) NULL
);

INSERT INTO #L (Tipo, ISBN, Nombre, Descripcion, Anio, Precio, Editorial, Autor, Tema1, Tema2, Peso, Paginas, Stock)
VALUES
('F', N'9789504900011', N'Rayuela', N'Novela experimental que se puede leer en más de un orden.', 1963, 21900, N'Alfaguara', N'Cort_zar', N'Novela', N'Literatura', 650, 736, 12),
('F', N'9789504900012', N'El Aleph', N'Cuentos fantásticos sobre el infinito y los laberintos.', 1949, 14200, N'Debolsillo', N'Borges', N'Cuento', N'Literatura', 200, 192, 25),
('F', N'9789504900013', N'Ficciones', N'Colección de cuentos sobre bibliotecas, espejos y tiempos paralelos.', 1944, 13800, N'Debolsillo', N'Borges', N'Cuento', N'Literatura', 210, 224, 18),
('F', N'9789504900014', N'Cien años de soledad', N'La historia de la familia Buendía en Macondo.', 1967, 18500, N'Sudamericana', N'Garc_a M_rquez', N'Novela', N'Literatura', 480, 471, 30),
('F', N'9789504900015', N'El amor en los tiempos del cólera', N'Una historia de amor que espera más de cincuenta años.', 1985, 17900, N'Planeta', N'Garc_a M_rquez', N'Novela', NULL, 520, 432, 9),
('F', N'9789504900016', N'La casa de los espíritus', N'Saga familiar a lo largo de cuatro generaciones.', 1982, 16400, N'Planeta', N'Allende', N'Novela', N'Historia', 450, 448, 14),
('F', N'9789504900017', N'El nombre de la rosa', N'Crímenes en una abadía benedictina del siglo XIV.', 1980, 19800, N'Lumen', N'Eco', N'Misterio', N'Historia', 700, 592, 8),
('F', N'9789504900018', N'Yo, robot', N'Cuentos sobre las tres leyes de la robótica.', 1950, 15200, N'Minotauro', N'Asimov', N'Ciencia ficci_n', N'Cuento', 280, 288, 16),
('F', N'9789504900019', N'Fundación e Imperio', N'Segunda entrega de la saga de la Fundación.', 1952, 15500, N'Minotauro', N'Asimov', N'Ciencia ficci_n', NULL, 300, 256, 11),
('F', N'9789504900020', N'Sobre héroes y tumbas', N'Novela sobre Buenos Aires y el Informe sobre ciegos.', 1961, 19700, N'Seix Barral', N'Sabato', N'Novela', N'Literatura', 540, 512, 6),
('F', N'9789504900021', N'La tregua', N'Diario de un oficinista a punto de jubilarse.', 1960, 16300, N'Seix Barral', N'Benedetti', N'Novela', NULL, 260, 208, 4),
('F', N'9789504900022', N'It', N'Un grupo de amigos enfrenta a una criatura en Derry.', 1986, 24500, N'Debolsillo', N'King', N'Terror', NULL, 1100, 1138, 5),
('F', N'9789504900023', N'La Comunidad del Anillo', N'Primera parte de El Señor de los Anillos.', 1954, 26500, N'Minotauro', N'Tolkien', N'Fantasia medieval', N'Aventura', 620, 576, 10),
('F', N'9789504900024', N'Asesinato en el Orient Express', N'Poirot investiga un crimen en un tren detenido por la nieve.', 1934, 13900, N'Planeta', N'Christie', N'Policial', N'Misterio', 280, 256, 22),
('F', N'9789504900025', N'Fahrenheit 451', N'Una sociedad donde los bomberos queman libros.', 1953, 14900, N'Minotauro', N'Bradbury', N'Ciencia ficci_n', N'Novela', 250, 224, 13);

INSERT INTO #L (Tipo, ISBN, Nombre, Descripcion, Anio, Precio, Editorial, Autor, Tema1, Tema2, Formato, MB, Url)
VALUES
('D', N'9789504900031', N'La ciudad y los perros', N'Novela sobre un colegio militar de Lima.', 1963, 12000, N'Alfaguara', N'Vargas Llosa', N'Novela', NULL, N'EPUB', 2.40, N'https://ejemplo.com/descargas/la-ciudad-y-los-perros.epub'),
('D', N'9789504900032', N'Veinte mil leguas de viaje submarino', N'La expedición del capitán Nemo a bordo del Nautilus.', 1870, 6500, N'Anagrama', N'Verne', N'Aventura', N'Ciencia ficci_n', N'PDF', 5.80, N'https://ejemplo.com/descargas/veinte-mil-leguas.pdf'),
('D', N'9789504900033', N'Carrie', N'Primera novela publicada de Stephen King.', 1974, 9500, N'Debolsillo', N'King', N'Terror', NULL, N'MOBI', 1.10, N'https://ejemplo.com/descargas/carrie.mobi'),
('D', N'9789504900034', N'El hobbit', N'El viaje de Bilbo Bolsón hacia la Montaña Solitaria.', 1937, 11800, N'Minotauro', N'Tolkien', N'Fantasia medieval', N'Aventura', N'EPUB', 3.20, N'https://ejemplo.com/descargas/el-hobbit.epub'),
('D', N'9789504900035', N'Los diez negritos', N'Diez invitados atrapados en una isla.', 1939, 9800, N'Planeta', N'Christie', N'Policial', N'Misterio', N'EPUB', 1.90, N'https://ejemplo.com/descargas/los-diez-negritos.epub'),
('D', N'9789504900036', N'Crónica de una muerte anunciada', N'Reconstrucción de un crimen que todo el pueblo conocía.', 1981, 10500, N'Sudamericana', N'Garc_a M_rquez', N'Novela', NULL, N'PDF', 4.10, N'https://ejemplo.com/descargas/cronica-de-una-muerte-anunciada.pdf'),
('D', N'9789504900037', N'Eva Luna', N'Una narradora cuenta su vida en un país latinoamericano.', 1987, 11200, N'Planeta', N'Allende', N'Novela', NULL, N'EPUB', 2.70, N'https://ejemplo.com/descargas/eva-luna.epub');

DECLARE @n INT = 1, @max INT = (SELECT MAX(N) FROM #L);
DECLARE @id INT, @tipo CHAR(1), @isbn NVARCHAR(13), @ed INT, @au INT, @t1 INT, @t2 INT;

WHILE @n <= @max
BEGIN
    SELECT @isbn = ISBN, @tipo = Tipo FROM #L WHERE N = @n;

    IF NOT EXISTS (SELECT 1 FROM Libros WHERE ISBN = @isbn)
    BEGIN
        SELECT @ed = (SELECT MIN(EditorialId) FROM Editoriales e WHERE e.Nombre = l.Editorial),
               @au = (SELECT MIN(AutorId) FROM Autores a WHERE a.Apellido LIKE l.Autor),
               @t1 = (SELECT MIN(TemaId) FROM Temas t WHERE t.Nombre LIKE l.Tema1),
               @t2 = (SELECT MIN(TemaId) FROM Temas t WHERE t.Nombre LIKE l.Tema2)
        FROM #L l WHERE l.N = @n;

        IF @ed IS NULL OR @au IS NULL OR @t1 IS NULL
            THROW 50000, 'No se encontró editorial, autor o tema para un libro del script.', 1;

        INSERT INTO Productos (Nombre, Descripcion, Activo)
        SELECT Nombre, Descripcion, 1 FROM #L WHERE N = @n;
        SET @id = SCOPE_IDENTITY();

        INSERT INTO Libros (ProductoId, ISBN, AnioPublicacion, Precio, EditorialId)
        SELECT @id, ISBN, Anio, Precio, @ed FROM #L WHERE N = @n;

        IF @tipo = 'F'
            INSERT INTO LibrosFisicos (ProductoId, PesoEnGramos, CantidadPaginas, Stock)
            SELECT @id, Peso, Paginas, Stock FROM #L WHERE N = @n;
        ELSE
            INSERT INTO LibrosDigitales (ProductoId, Formato, TamanioMB, UrlDescarga)
            SELECT @id, Formato, MB, Url FROM #L WHERE N = @n;

        INSERT INTO LibrosAutores (ProductoId, AutorId) VALUES (@id, @au);
        INSERT INTO LibrosTemas (ProductoId, TemaId) VALUES (@id, @t1);
        IF @t2 IS NOT NULL AND @t2 <> @t1
            INSERT INTO LibrosTemas (ProductoId, TemaId) VALUES (@id, @t2);
    END

    SET @n += 1;
END

DROP TABLE #L;
COMMIT;
GO
