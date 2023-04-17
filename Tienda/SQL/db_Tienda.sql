CREATE DATABASE Tienda;
USE Tienda;

CREATE TABLE Clientes (
    CodCliente INT NOT NULL IDENTITY(1,1),
    Nombre VARCHAR(50),
    Apellidos VARCHAR(100),
    Empresa VARCHAR(100),
    Puesto VARCHAR(20),
    CP VARCHAR(30),
    Provincia VARCHAR(60),
    Telefono VARCHAR(15),
    CONSTRAINT PK_Clientes PRIMARY KEY(CodCliente)
);

CREATE TABLE Articulos (
    CodArticulo INT NOT NULL IDENTITY(1,1),
    NombreArticulo VARCHAR(100),
    Descripcion VARCHAR(1024),
    PrecioUnitario DECIMAL(8,2),
    Stock INT,
    StockExtra INT,
    Imagen VARCHAR(1024) DEFAULT 'no-image-found.png',
    CONSTRAINT PK_Articulos PRIMARY KEY(CodArticulo)
);
DROP TABLE Articulos;

DROP TABLE Compras;
CREATE TABLE Compras (
    noCompra INT NOT NULL IDENTITY(1,1),
    Cliente INT,
    Articulo INT,
    Fecha DATE,
    Unidades INT,
    Total DECIMAL(8,2),
    CONSTRAINT FK_Cliente FOREIGN KEY(Cliente) REFERENCES Clientes(CodCliente),
    CONSTRAINT FK_Articulo FOREIGN KEY(Articulo) REFERENCES Articulos(CodArticulo),
    CONSTRAINT PK_Compras PRIMARY KEY(noCompra)
);


-- Insert rows into table 'Articulos'
INSERT INTO Articulos ("NombreArticulo", "Descripcion", "PrecioUnitario","Stock","StockExtra") VALUES ('Tijeras','Cortan papel',2.99,30,8);
GO
-- 520-614-256-286

ALTER TABLE Articulos
ALTER Imagen VARCHAR(1024)  DEFAULT 'no-image-found.png';

ALTER TABLE Clientes
add Estado INT DEFAULT 1;


UPDATE Articulos
set imagen = 'no-image-found.png'
where CodArticulo = 2;


SELECT NombreArticulo, imagen from Articulos;

-- Drop the table 'TableName' in schema 'SchemaName'
DROP TABLE Compras, Clientes,Articulos;

UPDATE Articulos 
set Estado = 1;

UPDATE Clientes 
set Estado = 1;

ALTER TABLE Clientes
DROP COLUMN FechaNacimiento;


SELECT * from Clientes