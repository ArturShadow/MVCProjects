CREATE DATABASE TID81D;
USE TID81D;

CREATE TABLE Sexo(
    idSexo INT NOT NULL IDENTITY(1,1),
    descripcion VARCHAR(10),
    PRIMARY KEY (idSexo)
);

DROP TABLE Cliente;
CREATE TABLE Cliente(
    idCliente INT NOT NULL IDENTITY(1,1),
    nombre    VARCHAR(50),
    aPaterno  VARCHAR(50),
    aMaterno  VARCHAR(50),
    email     VARCHAR(100),
    direccion VARCHAR (100),
    sexo      INT,
    telefono  VARCHAR(16),
    PRIMARY KEY (idCliente),
    CONSTRAINT FK_CLIENTE FOREIGN KEY(sexo) REFERENCES Sexo(idSexo)
);

DROP TABLE Empleado;

CREATE TABLE Empleado(
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
    CONSTRAINT FK_Empleado FOREIGN KEY(sexo) REFERENCES Sexo(idSexo)
);

INSERT INTO Sexo (descripcion) VALUES('Femenino');
INSERT INTO Sexo(descripcion) VALUES ('Maculino');

INSERT INTO Cliente(nombre,aPaterno,aMaterno,email,direccion,sexo,telefono) VALUES ('Luis','Loya','Baca','luis.arturo1738@outlook.com','C. Los mayas',2,'614-286-3943');

INSERT INTO Cliente(nombre,aPaterno,aMaterno,email,direccion,sexo,telefono) VALUES ('Gabriela','Baca','Maynez','gabrielanov29@hotmail.com','C. Los Olmecas',1,'614-142-3932');
INSERT INTO Cliente(nombre,aPaterno,aMaterno,email,direccion,sexo,telefono) VALUES ('Fernanda','Loya','Venegas','mafeloya93@outlook.com','Av. INFONAVIT',1,'614-114-5624');

INSERT INTO Empleado(nombre,aPaterno,aMaterno,email,direccion,sexo,telefono,fechaContrato,sueldo) VALUES ('Mariana','Garcia','Chacon','mgachon@gmail.com','C. Churubascos',2,'614-924-9447','2008-10-17',2640.20);
INSERT INTO Empleado(nombre,aPaterno,aMaterno,email,direccion,sexo,telefono,fechaContrato,sueldo) VALUES ('Humberto','Jaquez','Villalobos','hjaqVillalobos@gmail.com','C. Taracos',1,'614-742-852-6468','2000-08-02',10000.42);


CREATE TABLE Producto
(idProducto int identity(1,1) not null,
Descripcion  varchar(50),
Precio    decimal(8,2),
inventario int,
Constraint PK_Producto Primary Key(idProducto)
);
select * from PRODUCTO

 

insert into PRODUCTO values('Escoba magica',52.50,25)
insert into PRODUCTO values('Cubeta de 5 ltos',67.25,50)
insert into PRODUCTO values('Cepillo industrial',250.00,20)

DROP table PRODUCTO;

