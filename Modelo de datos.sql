 

 create database venta_vehiculos;

 use venta_vehiculos;

 create table Marca(
	id int identity(1,1) primary key not null,
	nombre_marca varchar(30) not null
 )

 create table tipo_vehiculo(
	id int identity(1,1) primary key not null,
	nombre_tipo_vehiculo varchar(30) not null
 )

 create table rol(
	id int identity(1,1) primary key not null,
	nombre_rol varchar(30) not null
 )

 create table usuario(
	id int identity(1,1) primary key not null,
	documento varchar(10) not null,
	nombres varchar(100) not null,
	apellidos varchar(200) not null,
	telefono varchar(10) not null,
	email varchar(50) not null,
	FKrol int not null,
	FOREIGN KEY (FKrol) REFERENCES rol(id)
 )



 create table vehiculo(
	id int identity(1,1) primary key not null,
	kilometraje NUMERIC(10,5)not null,
	precio NUMERIC(10,5) not null,
	color varchar(30),
	fktipo int not null,
	fkmarca int not null,
	FOREIGN KEY (fktipo) REFERENCES tipo_vehiculo(id),
	FOREIGN KEY (fkmarca) REFERENCES Marca(id)
 )

 create table servicio(
	id int identity(1,1) primary key not null,
	nombre_servicio varchar(100) not null,
	detalle_servicio nvarchar(max) null

 )

 create table contrato(
	id int identity(1,1) primary key not null,
	fecha date not null,
	FK_servicio int not null,
	FK_cliente int not null,
	FK_vendedor int not null,
	FK_vehiculo int not null
	FOREIGN KEY (FK_servicio) REFERENCES servicio(id),
	FOREIGN KEY (FK_cliente) REFERENCES usuario(id),
	FOREIGN KEY (FK_vendedor) REFERENCES usuario(id),
	FOREIGN KEY (FK_vehiculo) REFERENCES vehiculo(id)
 )