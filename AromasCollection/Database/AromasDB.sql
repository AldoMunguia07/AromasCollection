/*
	EQUIPO 2

	Aldo Josué Munguía Hernández.............0607200100897	Carlos Daniel Amaya Montalván............0703199901926	David Antonio Mendoza....................0601199800243	Francisco Fernando Madrid Sikaffy........0512200100506	Jordy Josué Castillo Núñez...............0601200202272	Jorge Daniel Reyes García................0508200100052
*/


USE tempdb
go

-- Crear la base de datos 
CREATE DATABASE AromasDB
GO

USE AromasDB
GO

--TABLAS



CREATE TABLE Cliente
(
	idCliente INT NOT NULL IDENTITY,
	dni VARCHAR(15) NOT NULL UNIQUE,
	rtn VARCHAR(15) NOT NULL UNIQUE,
	nombreCliente VARCHAR(55) NOT NULL,
	apellidoCliente VARCHAR(55) NOT NULL,

	CONSTRAINT PK_Cliente_idCliente
		PRIMARY KEY CLUSTERED (idCliente)

);

CREATE TABLE Puesto
(

	idPuesto INT NOT NULL IDENTITY,
	puesto VARCHAR(25) NOT NULL UNIQUE,

	CONSTRAINT PK_Puesto_idPuesto
		PRIMARY KEY CLUSTERED (idPuesto)

)


CREATE TABLE Colaborador
(
	idColaborador INT NOT NULL IDENTITY,
	nombreColaborador VARCHAR(55) NOT NULL,
	apellidoColaborador VARCHAR(55) NOT NULL,
	usuario VARCHAR(30) NOT NULL UNIQUE,
	contrasenia VARBINARY(MAX) NOT NULL,
	idPuesto INT NOT NULL,
	estado BIT NOT NULL,

	CONSTRAINT PK_Colaborador_idColaborador
		PRIMARY KEY CLUSTERED (idColaborador),

	CONSTRAINT FK_Empleado$Existe$Puesto
		FOREIGN KEY (idPuesto) REFERENCES Puesto(idPuesto),

);


CREATE TABLE Categoria
(
	idCategoria INT NOT NULL IDENTITY,
	categoria VARCHAR(30) NOT NULL UNIQUE,

	CONSTRAINT PK_Categoria_idCategoiria
		PRIMARY KEY CLUSTERED (idCategoria)
);

CREATE TABLE Producto
(
	idProducto INT NOT NULL,
	nombreProducto VARCHAR(150) NOT NULL UNIQUE,
	descripcion VARCHAR(255) NOT NULL,
	precioDetalle FLOAT NOT NULL,
	precioMayorista FLOAT NOT NULL,
	idCategoria INT NOT NULL,

	CONSTRAINT PK_Producto_idProducto
		PRIMARY KEY CLUSTERED (idProducto),

	CONSTRAINT FK_Producto$Existe$Categoria
		FOREIGN KEY (idCategoria) REFERENCES Categoria(idCategoria)
);

CREATE TABLE Lote
(
	idLote INT NOT NULL IDENTITY,
	idProducto INT NOT NULL,
	cantidad INT NOT NULL,
	precioCompra FLOAT NOT NULL,
	fecha DATETIME NOT NULL,

	CONSTRAINT PK_Lote_idLote
		PRIMARY KEY CLUSTERED (idLote),

		
	CONSTRAINT FK_Lote$Existe$Producto
		FOREIGN KEY (idProducto) REFERENCES Producto(idProducto)

);

Create table SAR(	CodigoSAR INT NOT NULL IDENTITY,  	rangoInicial INT NOT NULL,	rangoFinal INT	NOT NULL, 	fechaRecepecion DATE NOT NULL,	fechaLimiteEmision DATE NOT NULL,	cai VARCHAR(200) NOT NULL,	estado BIT NOT NULL,	CONSTRAINT PK_CodigoSar_CodigoSar		PRIMARY KEY CLUSTERED (CodigoSar));


CREATE TABLE Factura
(
	idFactura INT NOT NULL,
	CodigoSAR INT NOT NULL,
	idColaborador INT NOT NULL,
	idCliente INT NOT NULL,
	fechaVenta DATETIME NOT NULL,
	observaciones VARCHAR(150) 

	CONSTRAINT PK_Factura_idFactura
		PRIMARY KEY CLUSTERED (idFactura, CodigoSAR),

	CONSTRAINT FKVenta$Existe$Colaborador
		FOREIGN KEY (idColaborador) REFERENCES Colaborador(idColaborador),

	CONSTRAINT FK_Venta$Existe$Cliente
		FOREIGN KEY (idCliente) REFERENCES Cliente(idCliente),

	CONSTRAINT FK_FacturaVenta$Existe$SAR		FOREIGN KEY (CodigoSAR) REFERENCES SAR(CodigoSAR)


);

CREATE TABLE DetalleFactura
(
	idFactura INT NOT NULL,
	CodigoSAR INT NOT NULL,
	idProducto INT NOT NULL,
	precio FLOAT NOT NULL,
	cantidad INT NOT NULL,

	CONSTRAINT PK_DetalleFactura_idVenta_idProducto
		PRIMARY KEY CLUSTERED (idFactura,idProducto, CodigoSAR),

	CONSTRAINT FK_DetalleFactura$Existe$Factura
		FOREIGN KEY (idFactura, CodigoSAR) REFERENCES Factura(idFactura, CodigoSAR),

	CONSTRAINT FK_Venta$Existe$Producto
		FOREIGN KEY (idProducto) REFERENCES Producto(idProducto),



);


CREATE TABLE Bitacora
(
	idBitacora INT NOT NULL IDENTITY,
	idColaborador INT NOT NULL,
	pcUsuario VARCHAR(70) NOT NULL,
	accion NVARCHAR(200) NOT NULL,
	fecha DATETIME NOT NULL

	CONSTRAINT PK_Bitacora_idBitacora
		PRIMARY KEY CLUSTERED (idBitacora),

	CONSTRAINT FK_Bitacora$Existe$Colaborador
		FOREIGN KEY (idColaborador) REFERENCES Colaborador(idColaborador),

)


--PROCEDIMIENTOS ALMACENADOS

CREATE PROCEDURE sp_Venta
@idFactura int = NULL,
@codigoSAR int = NULL,
@idColaborador int = NULL,
@idCliente int = NULL,
@fechaVenta DATETIME = NULL,
@observaciones nvarchar(150) = NULL,
@accion nvarchar(50)

AS
BEGIN
	SET @fechaVenta = CONVERT(DATE, GETDATE());
	IF @accion = 'insertar'
		BEGIN
			INSERT INTO Factura VALUES (@idFactura,@codigoSAR, @idColaborador, @idCliente, @fechaVenta, @observaciones)
		END

END
GO


CREATE PROCEDURE sp_Producto
@idProducto int = NULL,
@nombreProducto nvarchar(150) = NULL,
@precioDetalle float = NULL,
@precioMayorista float = NULL,
@idCategoria int = NULL,
@accion nvarchar(50)

AS
BEGIN
	
	IF @accion = 'insertar'
		BEGIN
			select * from Producto
		END
	ELSE IF @accion = 'mostrar'
		BEGIN
			SELECT p.idProducto Codigo, p.nombreProducto Producto, p.descripcion Descripcion, p.precioDetalle 'Precio detalle', p.precioMayorista 'Precio mayorista', c.categoria Catgeoria,
			sum(l.cantidad - ISNULL(df.cantidad, 0)) Existencia
			FROM Producto p JOIN Categoria c
			ON p.idCategoria = C.idCategoria
			JOIN Lote l
			ON l.idProducto = p.idProducto
			LEFT JOIN DetalleFactura df
			ON df.idProducto = p.idProducto
			GROUP BY p.idProducto, p.nombreProducto, p.descripcion, p.precioDetalle, p.precioMayorista, c.categoria
		END

END
GO

