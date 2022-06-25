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
	correo VARCHAR(50) NOT NULL,
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
	idProducto INT NOT NULL IDENTITY,
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



--INSERTS

-- Datos tabla puesto
INSERT INTO Puesto VALUES ('Administrador');

INSERT INTO Puesto VALUES ('Doctor');


-- Datos de un usuario tipo Administrador.

INSERT INTO Colaborador VALUES ('Admin', 'Admin', 'admin@gmail.com', 'admin', (ENCRYPTBYPASSPHRASE('ACecrypt02','admin123')), 1, 1)
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
@nombreProducto nvarchar(150) = NULL,
@descripcion nvarchar(150) = NULL,
@precioDetalle float = NULL,
@precioMayorista float = NULL,
@idCategoria int = NULL,
@accion nvarchar(50),
@productoBuscado VARCHAR(150)  = NULL

AS
BEGIN
	
	IF @accion = 'insertar'
		BEGIN
			INSERT INTO Producto VALUES (@nombreProducto, @descripcion, @precioDetalle, @precioMayorista, @idCategoria);
		END
	ELSE IF @accion = 'modificar'
		BEGIN
			  UPDATE Producto
			  SET nombreProducto = @nombreProducto, descripcion = @descripcion, precioDetalle = @precioDetalle, precioMayorista = @precioMayorista, idCategoria = @idCategoria
			  WHERE idProducto = @idProducto
		END
	ELSE IF @accion = 'mostrar'
		BEGIN
			  SELECT p.idProducto Codigo, p.nombreProducto Producto, p.descripcion Descripcion, p.precioDetalle 'Precio detalle', p.precioMayorista 'Precio mayorista',c.idCategoria, c.categoria Catgeoria,
				(SELECT ISNULL(SUM(cantidad), 0) FROM Lote WHERE idProducto = p.idProducto) - (SELECT ISNULL(SUM(cantidad), 0) FROM DetalleFactura WHERE idProducto = p.idProducto)  Existencia
				FROM Producto p JOIN Categoria c
				ON p.idCategoria = C.idCategoria
		END
	ELSE IF @accion = 'buscar'
		BEGIN
			  SELECT p.idProducto Codigo, p.nombreProducto Producto, p.descripcion Descripcion, p.precioDetalle 'Precio detalle', p.precioMayorista 'Precio mayorista', c.idCategoria,c.categoria Catgeoria,
				(SELECT ISNULL(SUM(cantidad), 0) FROM Lote WHERE idProducto = p.idProducto) - (SELECT ISNULL(SUM(cantidad), 0) FROM DetalleFactura WHERE idProducto = p.idProducto)  Existencia
				FROM Producto p JOIN Categoria c
				ON p.idCategoria = C.idCategoria
				 WHERE  CONCAT(p.idProducto, ' ', p.nombreProducto, ' ', c.categoria) LIKE CONCAT('%', @productoBuscado,'%')
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

CREATE PROCEDURE sp_Colaborador
@idColaborador INT = NULL,
@nombreColaborador VARCHAR(55)   = NULL,
@apellidoColaborador VARCHAR(55)  = NULL,
@correo VARCHAR(50)  = NULL,
@usuario VARCHAR(30) = NULL,
@contrasenia VARCHAR(50) = NULL,
@idPuesto INT   = NULL,
@estado BIT  = NULL,
@accion VARCHAR(50),
@nombreEmpleado VARCHAR(80)  = NULL


AS
DECLARE @password VARBINARY(max)
BEGIN
	IF @accion = 'insertar'
		BEGIN
			SET @password = (ENCRYPTBYPASSPHRASE('ACecrypt02',@contrasenia));
			INSERT INTO Colaborador VALUES (@nombreColaborador, @apellidoColaborador, @correo, @usuario, @password, @idPuesto, @estado)
		END
	ELSE IF @accion = 'modificar'
		BEGIN
			SET @password = (ENCRYPTBYPASSPHRASE('ACecrypt02',@contrasenia));
			UPDATE Colaborador
				SET nombreColaborador = @nombreColaborador, apellidoColaborador = @apellidoColaborador, correo = @correo, usuario = @usuario, 
				contrasenia = @password, idPuesto = @idPuesto, estado = @estado
				WHERE idColaborador =  idColaborador
		END
		ELSE IF @accion = 'mostrar'
		BEGIN
			  SELECT c.nombreColaborador'Nombre',c.apellidoColaborador 'Apellido',c.correo'Correo',c.usuario 'Usuario', CONVERT(VARCHAR,DECRYPTBYPASSPHRASE('ACecrypt02',contrasenia)) 'Contraseña', (p.puesto) 'Puesto'
				FROM Colaborador c JOIN Puesto p 
				ON c.idPuesto = p.idPuesto				
				
		END
	ELSE IF @accion = 'desactivar'
		BEGIN
		
			UPDATE Colaborador
				SET  estado = 0
				WHERE idColaborador =  @idColaborador
		END
	ELSE IF @accion = 'obtenerColaborador'
		BEGIN
			SELECT idColaborador, nombreColaborador, apellidoColaborador, correo, usuario, CONVERT(VARCHAR,DECRYPTBYPASSPHRASE('ACecrypt02',contrasenia)) contrasenia,
			idPuesto, estado  
			FROM Colaborador 
			WHERE usuario = @usuario
		END
	

END
GO
Create OR PROCEDURE [dbo].[sp_Lote]
	@idLote int = null,
	@idProducto int = null,
	@cantidad int = null,
	@preciocompra float = null,
	@fecha datetime = null,
	@accion NVARCHAR(50)
AS
BEGIN
	SET @fecha = GETDATE();
	IF @accion = 'insertar'
		BEGIN
			INSERT INTO [dbo].[Lote]
           (
			[idProducto],
			[cantidad],
			[precioCompra],
			[fecha]
		   )
			VALUES(@idProducto, @cantidad, @preciocompra, @fecha)
		END
	ELSE IF @accion = 'mostrar'
		BEGIN
			SELECT L.idLote Codigo, P.idProducto idProducto, L.cantidad Cantidad, L.precioCompra Costo, L.fecha Fecha 
			FROM Lote L join Producto p
			ON
				L.idProducto = P.idProducto
			WHERE L.idProducto = @idProducto
		END
	ELSE IF @accion = 'modificar'
		BEGIN
			UPDATE Lote 
			SET idProducto = @idProducto, cantidad = @cantidad, precioCompra = @preciocompra, fecha = @fecha
			WHERE Lote.idLote = @idLote
		END
END
GO
--Procedimientos almacenados para clientes

Create PROCEDURE sp_Clientes
	@idCliente int = NULL,
	@dni varchar(15) =  null,
	@rtn varchar(15) = null,
	@nombreCliente varchar(55) = null,
	@apellidoCliente varchar(55) = null,
	@accion varchar(55) = null,
	@clienteBuscado varchar(150) = null
AS
BEGIN
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	BEGIN

	IF @accion = 'insertar'
		BEGIN
			INSERT INTO [dbo].[Cliente]
           ([dni], 
		   [rtn], 
		   [nombreCliente], 
		   [apellidoCliente])
			VALUES(@dni, @rtn, @nombreCliente, @apellidoCliente)
		END
	ELSE IF @accion = 'mostrar'
		BEGIN
			Select Cl.idCliente, Cl.dni as Identidad, Cl.rtn as RTN, Cl.nombreCliente as Nombre, Cl.apellidoCliente as Apellido From Cliente Cl
			Order by Cl.nombreCliente ASC
		END
	ELSE IF @accion = 'modificar'
		BEGIN
			UPDATE Cliente
			SET dni=@dni, rtn=@rtn, nombreCliente=@nombreCliente, apellidoCliente=@apellidoCliente
			WHERE Cliente.idCliente=@idCliente
		END

	ELSE IF @accion = 'buscar'
		BEGIN
			Select C.dni as Identidad, C.rtn as RTN, C.nombreCliente as Nombre, C.apellidoCliente as Apellido 
			From Cliente C
			Where CONCAT(C.nombreCliente, ' ', C.apellidoCliente, ' ', C.dni, ' ', C.rtn) LIKE CONCAT('%', @clienteBuscado,'%')
		END
	END
END
