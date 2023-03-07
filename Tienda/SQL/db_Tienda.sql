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
    FehaNacimiento Date,
    CONSTRAINT  PK_Clientes PRIMARY KEY(CodCliente)
);

CREATE TABLE Articulos (
    CodArticulo INT NOT NULL IDENTITY(1,1),
    NombreArticulo VARCHAR(100),
    Descripcion VARCHAR(250),
    PrecioUnitario DECIMAL,
    Stock INT,
    StockExtra INT,
    imagen image,
    CONSTRAINT PK_Articulos PRIMARY KEY(CodArticulo)
);

CREATE TABLE Compras (
    Cliente INT,
    Articulo INT,
    Fecha DATE,
    Unidades INT,
    Total DECIMAL
    CONSTRAINT FK_Cliente FOREIGN KEY(Cliente) REFERENCES Clientes(CodCliente),
    CONSTRAINT FK_Articulo FOREIGN KEY(Articulo) REFERENCES Articulos(CodArticulo),
    CONSTRAINT PK_Compras PRIMARY KEY(Cliente, Articulo)
);

-- Insert rows into table 'Articulos'
INSERT INTO Articulos ("NombreArticulo", "Descripcion", "PrecioUnitario","Stock", "StockExtra") VALUES ('Tijeras','Cortan papel',2.99,30,8);
GO
-- 520-614-256-286

ALTER TABLE Articulos
DROP COLUMN Imagen;