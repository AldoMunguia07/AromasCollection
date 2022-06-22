/*
	EQUIPO 2

	Aldo Josué Munguía Hernández.............0607200100897
	Carlos Daniel Amaya Montalván............0703199901926
	David Antonio Mendoza....................0601199800243
	Francisco Fernando Madrid Sikaffy........0512200100506
	Jordy Josué Castillo Núñez...............0601200202272
	Jorge Daniel Reyes García................0508200100052
*/


USE tempdb
go

-- Crear la base de datos DROP DATABASE AromasDB
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
GO

CREATE TABLE Puesto
(

	idPuesto INT NOT NULL IDENTITY,
	puesto VARCHAR(25) NOT NULL UNIQUE,

	CONSTRAINT PK_Puesto_idPuesto
		PRIMARY KEY CLUSTERED (idPuesto)

);
GO


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
GO

CREATE TABLE Categoria
(
	idCategoria INT NOT NULL IDENTITY,
	categoria VARCHAR(30) NOT NULL UNIQUE,

	CONSTRAINT PK_Categoria_idCategoiria
		PRIMARY KEY CLUSTERED (idCategoria)
);
GO

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
GO

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
GO

Create table SAR(

	CodigoSAR INT NOT NULL IDENTITY,  
	rangoInicial INT NOT NULL,
	rangoFinal INT	NOT NULL, 
	fechaRecepecion DATE NOT NULL,
	fechaLimiteEmision DATE NOT NULL,
	cai VARCHAR(200) NOT NULL,
	estado BIT NOT NULL,
	CONSTRAINT PK_CodigoSar_CodigoSar
		PRIMARY KEY CLUSTERED (CodigoSar)

);
GO


CREATE TABLE Factura
(
	idFactura INT NOT NULL,
	CodigoSAR INT NOT NULL,
	idColaborador INT NOT NULL,
	idCliente INT NOT NULL,
	fechaVenta DATETIME NOT NULL,
	descuento FLOAT NOT NULL,
	observaciones VARCHAR(150) 

	CONSTRAINT PK_Factura_idFactura
		PRIMARY KEY CLUSTERED (idFactura, CodigoSAR),

	CONSTRAINT FKVenta$Existe$Colaborador
		FOREIGN KEY (idColaborador) REFERENCES Colaborador(idColaborador),

	CONSTRAINT FK_Venta$Existe$Cliente
		FOREIGN KEY (idCliente) REFERENCES Cliente(idCliente),

	CONSTRAINT FK_FacturaVenta$Existe$SAR
		FOREIGN KEY (CodigoSAR) REFERENCES SAR(CodigoSAR)


);
GO

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
GO

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

);
GO


--PROCEDIMIENTOS ALMACENADOS

CREATE PROCEDURE sp_Venta
@idFactura int = NULL,
@codigoSAR int = NULL,
@idColaborador int = NULL,
@idCliente int = NULL,
@fechaVenta DATETIME = NULL,
@descuento FLOAT = NULL,
@observaciones nvarchar(150) = NULL,
@accion nvarchar(50),
@facturaBuscada VARCHAR(150)  = NULL

AS
BEGIN
	SET @fechaVenta = CONVERT(DATE, GETDATE());
	IF @accion = 'insertar'
		BEGIN
			INSERT INTO Factura VALUES (@idFactura,@codigoSAR, @idColaborador, @idCliente, @fechaVenta, @descuento, @observaciones)
		END
	ELSE IF @accion = 'mostrar'
		BEGIN
			SELECT f.idFactura 'Código factura', f.fechaVenta 'Fecha venta', CONCAT(co.nombreColaborador, ' ', co.apellidoColaborador) Colaborador, CONCAT(c.nombreCliente,' ', c.apellidoCliente) Cliente, c.rtn 'RTN cliente',
			SUM(df.cantidad * df.precio) Subtotal, (SUM(df.cantidad * df.precio) * 0.15) ISV, F.descuento Descuento, SUM(df.cantidad * df.precio) +  ((SUM(df.cantidad * df.precio) * 0.15) - f.descuento) Total,
			f.observaciones Observaciones
			FROM Factura f JOIN DetalleFactura df 
			ON df.idFactura = f.idFactura
			JOIN Cliente c ON c.idCliente = f.idCliente
			JOIN Colaborador co on co.idColaborador = f.idColaborador
			GROUP BY f.idFactura, f.fechaVenta, co.nombreColaborador, co.apellidoColaborador, c.nombreCliente, c.apellidoCliente, c.rtn, F.descuento, f.observaciones
			
		END
		ELSE IF @accion = 'buscar'
		BEGIN
			SELECT f.idFactura 'Código factura', f.fechaVenta 'Fecha venta', CONCAT(co.nombreColaborador, ' ', co.apellidoColaborador) Colaborador, CONCAT(c.nombreCliente,' ', c.apellidoCliente) Cliente, c.rtn 'RTN cliente',
			SUM(df.cantidad * df.precio) Subtotal, (SUM(df.cantidad * df.precio) * 0.15) ISV, F.descuento Descuento, SUM(df.cantidad * df.precio) +  ((SUM(df.cantidad * df.precio) * 0.15) - f.descuento) Total,
			f.observaciones Observaciones
			FROM Factura f JOIN DetalleFactura df 
			ON df.idFactura = f.idFactura
			JOIN Cliente c ON c.idCliente = f.idCliente
			JOIN Colaborador co on co.idColaborador = f.idColaborador
			WHERE  CONCAT(f.idFactura, ' ', f.fechaVenta, ' ', c.nombreCliente, ' ', c.apellidoCliente, ' ', c.rtn, co.nombreColaborador, ' ', co.apellidoColaborador) LIKE CONCAT('%', @facturaBuscada,'%')
			GROUP BY f.idFactura, f.fechaVenta, co.nombreColaborador, co.apellidoColaborador, c.nombreCliente, c.apellidoCliente, c.rtn, F.descuento, f.observaciones
			
		END

END
GO

CREATE PROCEDURE sp_detalleVenta
@idFactura int = NULL,
@codigoSAR int = NULL,
@idProducto int = NULL,
@precio float = NULL,
@cantidad int = NULL,
@accion nvarchar(50)

AS
BEGIN
	
	IF @accion = 'insertar'
		BEGIN
			INSERT INTO DetalleFactura VALUES (@idFactura,@codigoSAR, @idProducto, @precio, @cantidad)
		END

END
GO


CREATE PROCEDURE sp_Producto
@idProducto int = NULL,
@nombreProducto varchar(150) = NULL,
@descripcion varchar(255) = NULL,
@precioDetalle float = NULL,
@precioMayorista float = NULL,
@idCategoria int = NULL,
@accion nvarchar(50),
@productoBuscado VARCHAR(150)  = NULL

AS
BEGIN
	
	IF @accion = 'insertar'
		BEGIN
			INSERT INTO [dbo].[Producto]
					   (
					    [nombreProducto]
					   ,[descripcion]
					   ,[precioDetalle]
					   ,[precioMayorista]
					   ,[idCategoria])
				 VALUES
					   (@nombreProducto
					   ,@descripcion
					   ,@precioDetalle
					   ,@precioMayorista
					   ,@idCategoria)
		END
	ELSE IF @accion = 'modificar'
		BEGIN
			UPDATE [dbo].[Producto]
			   SET 
				   [nombreProducto] = @nombreProducto
				  ,[descripcion] = @descripcion
				  ,[precioDetalle] = @precioDetalle
				  ,[precioMayorista] = @precioMayorista
				  ,[idCategoria] = @idCategoria
			 WHERE Producto.idProducto = @idProducto
		END
	ELSE IF @accion = 'mostrar'
		BEGIN
			SELECT        Producto.idProducto, Producto.nombreProducto AS 'Producto', Producto.descripcion AS Descripcion, Producto.precioDetalle AS 'Precio Detalle', Producto.precioMayorista AS 'Precio Mayorista', Producto.idCategoria AS 'idCategoria', Categoria.categoria AS 'Categoria'
			FROM            Producto INNER JOIN
								   Categoria ON Producto.idCategoria = Categoria.idCategoria
			ORDER BY Producto.idProducto ASC
		END
END
GO

CREATE PROCEDURE sp_Cliente
@idCliente int = NULL,
@dni VARCHAR(15) = NULL,
@rtn VARCHAR(15) = NULL,
@nombreCliente VARCHAR(55) = NULL,
@apellidoCliente VARCHAR(55) = NULL,
@accion nvarchar(50),
@clienteBuscado VARCHAR(150)  = NULL

AS
BEGIN
	
	IF @accion = 'insertar'
		BEGIN
			select * from Producto --Agregar el de insertar
		END
	ELSE IF @accion = 'mostrarEnFactura'
		BEGIN
			  SELECT idCliente Codigo, rtn RTN, CONCAT(nombreCliente, ' ', apellidoCliente) 'Nombre cliente', nombreCliente, apellidoCliente
			  FROM Cliente
		END
	ELSE IF @accion = 'buscar'
		BEGIN
			  SELECT idCliente Codigo, rtn RTN, CONCAT(nombreCliente, ' ', apellidoCliente) 'Nombre cliente', nombreCliente, apellidoCliente
			  FROM Cliente
			  WHERE  CONCAT(nombreCliente, ' ', apellidoCliente, ' ', rtn, ' ', idCliente) LIKE CONCAT('%', @clienteBuscado,'%')
		END

END
GO

CREATE OR ALTER PROCEDURE [dbo].[sp_Categoria] 
	-- Add the parameters for the stored procedure here
	@idCategoria int = NULL,
	@categoria varchar(30) = null,
	@accion nvarchar(50),
	@categoriaBusquedad varchar(50) = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	BEGIN

	IF @accion = 'insertar'
		BEGIN
			INSERT INTO [dbo].[Categoria]
           ([categoria])
			VALUES(@categoria)
		END
	ELSE IF @accion = 'mostrar'
		BEGIN
			SELECT C.idCategoria AS ID, C.categoria AS Categoria FROM Categoria AS C
			ORDER BY C.idCategoria ASC
		END
	ELSE IF @accion = 'modificar'
		BEGIN
			UPDATE Categoria 
			SET Categoria.categoria = @categoria
			WHERE Categoria.idCategoria = @idCategoria
		END

	ELSE IF @accion = 'buscar'
		BEGIN
			SELECT C.idCategoria AS ID, C.categoria AS Categoria FROM Categoria AS C
			WHERE CONCAT(C.idCategoria, ' ', C.categoria) LIKE CONCAT('%', @categoriaBusquedad,'%')
		END

	END
END
GO

