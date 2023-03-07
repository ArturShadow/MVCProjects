CREATE DATABASE Tienda;

CREATE TABLE Clientes (
    CodClientes INT NOT NULL IDENTITY(1,1),
    Nombre VARCHAR(50),
    Apellidos VARCHAR(100),
    Empresa VARCHAR(100),
    Puesto VARCHAR(20),
    CP VARCHAR(30),
    Provincia VARCHAR(60),
    Telefono VARCHAR(15),
    FehaNacimiento Date,
    CONSTRAINT  PK_Clientes PRIMARY KEY(CodClientes)
);

CREATE TABLE Articulos (
    CodArticulo INT NOT NULL IDENTITY(1,1),
    NombreArticulo VARCHAR(100),
    
    CONSTRAINT PK_Articulos PRIMARY KEY(CodArticulo)
);

-- 520-614-256-286