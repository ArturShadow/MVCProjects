--CREATE DATABASE TID81D;
USE TID81D;

CREATE TABLE Sexos(
    idSexo INT NOT NULL IDENTITY(1,1),
    descripcion VARCHAR(10),
    PRIMARY KEY (idSexo)
);

--DROP TABLE Cliente;
CREATE TABLE Clientes(
    idCliente INT NOT NULL IDENTITY(1,1),
    nombre    VARCHAR(50),
    aPaterno  VARCHAR(50),
    aMaterno  VARCHAR(50),
    email     VARCHAR(100),
    direccion VARCHAR (100),
    sexo      INT,
    telefono  VARCHAR(16),
    PRIMARY KEY (idCliente),
    CONSTRAINT FK_CLIENTE FOREIGN KEY(sexo) REFERENCES Sexos(idSexo)
);

--DROP TABLE Empleado;

CREATE TABLE Empleados(
    idEmpleado INT NOT NULL IDENTITY(1,1),
    nombre    VARCHAR(50),
    aPaterno  VARCHAR(50),
    aMaterno  VARCHAR(50),
    email     VARCHAR(100),
    direccion VARCHAR (100),
    sexo      INT,
    telefono  VARCHAR(16),
    fechaContrato DATE,
    sueldo DECIMAL(10,2),
    PRIMARY KEY (idEmpleado),
    CONSTRAINT FK_Sexo FOREIGN KEY(sexo) REFERENCES Sexos(idSexo)
);

INSERT INTO Sexos (descripcion) VALUES('Femenino');
INSERT INTO Sexos(descripcion) VALUES ('Maculino');

INSERT INTO Clientes(nombre,aPaterno,aMaterno,email,direccion,sexo,telefono) VALUES ('Luis','Loya','Baca','luis.arturo1738@outlook.com','C. Los mayas',2,'614-286-3943');

INSERT INTO Clientes(nombre,aPaterno,aMaterno,email,direccion,sexo,telefono) VALUES ('Gabriela','Baca','Maynez','gabrielanov29@hotmail.com','C. Los Olmecas',1,'614-142-3932');
INSERT INTO Clientes(nombre,aPaterno,aMaterno,email,direccion,sexo,telefono) VALUES ('Fernanda','Loya','Venegas','mafeloya93@outlook.com','Av. INFONAVIT',1,'614-114-5624');


DROP table Empleados;
INSERT INTO Empleados(nombre,aPaterno,aMaterno,email,direccion,sexo,telefono,fechaContrato,sueldo) VALUES ('Mariana','Garcia','Chacon','mgachon@gmail.com','C. Churubascos',2,'614-924-9447','2008-10-17',2640.20);
INSERT INTO Empleados(nombre,aPaterno,aMaterno,email,direccion,sexo,telefono,fechaContrato,sueldo) VALUES ('Humberto','Jaquez','Villalobos','hjaqVillalobos@gmail.com','C. Taracos',1,'614-742-852','2000-08-02',10000.42);


CREATE TABLE Productos
(idProducto int identity(1,1) not null,
Descripcion  varchar(50),
Precio    decimal(8,2),
inventario int,
Constraint PK_Producto Primary Key(idProducto)
);
select * from Productos;

insert into Productos values('Escoba magica',52.50,25);
insert into Productos values('Cubeta de 5 ltos',67.25,50);
insert into Productos values('Cepillo industrial',250.00,20);

--DROP table Productos;

CREATE TABLE TipoContrato (
    IdTipoContrato INT NOT NULL IDENTITY(1,1),
    Descripcion VARCHAR(50),
    PRIMARY KEY(IdTipoContrato) 
);

DROP table TipoUsuarios;

CREATE TABLE TipoUsuario (
    IdTipoUsuario INT NOT NULL IDENTITY(1,1),
    Descripcion VARCHAR(50),
    PRIMARY KEY(IdTipoUsuario) 
);

ALTER Table Empleados
ADD TipoContrato INT FOREIGN KEY(TipoContrato) REFERENCES TipoContrato(IdTipoContrato);

ALTER Table Empleados
ADD TipoUsuario INT FOREIGN KEY(TipoUsuario) REFERENCES TipoUsuario(IdTipoUsuario);

--DROP database TID81D;

drop table Clientes, Empleados, Producto, Sexo, TipoContrato, TipoUsuario, Sexo;

--use master;


INSERT INTO TipoContrato VALUES('Por horas');
INSERT INTO TipoContrato VALUES('Tiempo Completo');
INSERT INTO TipoContrato VALUES ('Indeterminado');

INSERT INTO TipoUsuario VALUES ('Administrador');
INSERT INTO TipoUsuario(Descripcion) VALUES ('Tecnico');
INSERT INTO TipoUsuario VALUES ('Vendedor');

UPDATE Empleados SET TipoContrato = 2, TipoUsuario = 1 WHERE idEmpleado = 1;
UPDATE Empleados SET TipoContrato = 3, TipoUsuario = 2 WHERE idEmpleado = 2;
