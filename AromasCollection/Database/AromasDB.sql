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

-- Crear la base de datos USE tempdb DROP DATABASE AromasDB
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
	estado BIT NOT NULL,

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
	correo VARCHAR(50) NOT NULL UNIQUE,
	usuario VARCHAR(30) NOT NULL UNIQUE,
	contrasenia VARBINARY(MAX) NOT NULL,
	idPuesto INT NOT NULL,
	estado BIT NOT NULL,

	CONSTRAINT PK_Colaborador_idColaborador
		PRIMARY KEY CLUSTERED (idColaborador),

	CONSTRAINT FK_Empleado$Existe$Puesto
		FOREIGN KEY (idPuesto) REFERENCES Puesto(idPuesto)


);
GO

CREATE TABLE Categoria
(
	idCategoria INT NOT NULL IDENTITY,
	categoria VARCHAR(30) NOT NULL UNIQUE,
	estado BIT NOT NULL,

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
	estado BIT NOT NULL,

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
	fechaRecepcion DATE NOT NULL,
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
	esVenta BIT NOT NULL,
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

INSERT INTO Puesto VALUES ('Colaborador');


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
@esVenta BIT = NULL,
@observaciones nvarchar(150) = NULL,
@accion nvarchar(50),
@facturaBuscada VARCHAR(150)  = NULL

AS
BEGIN
	SET @fechaVenta = CONVERT(DATE, GETDATE());
	IF @accion = 'insertar'
		BEGIN
			INSERT INTO Factura VALUES (@idFactura,@codigoSAR, @idColaborador, @idCliente, @fechaVenta, @descuento, @esVenta, @observaciones)
		END
	ELSE IF @accion = 'mostrar'
		BEGIN
			SELECT f.idFactura 'Código factura', f.fechaVenta 'Fecha venta', CONCAT(co.nombreColaborador, ' ', co.apellidoColaborador) Colaborador, 
			CONCAT(c.nombreCliente,' ', c.apellidoCliente) Cliente, c.rtn 'RTN cliente',
			CASE WHEN esVenta = 1 THEN SUM(df.cantidad * df.precio) ELSE 0 END  Subtotal, CASE WHEN esVenta = 1 THEN (SUM(df.cantidad * df.precio) * 0.15) ELSE 0 END  ISV,
			 CASE WHEN esVenta = 1 THEN F.descuento ELSE 0 END Descuento,  CASE WHEN esVenta = 1 THEN SUM(df.cantidad * df.precio) +  ((SUM(df.cantidad * df.precio) * 0.15) - f.descuento) ELSE  0 END Total,
			f.observaciones Observaciones
			FROM Factura f JOIN DetalleFactura df 
			ON df.idFactura = f.idFactura
			JOIN Cliente c ON c.idCliente = f.idCliente
			JOIN Colaborador co on co.idColaborador = f.idColaborador
			GROUP BY f.idFactura, f.fechaVenta, co.nombreColaborador, co.apellidoColaborador, c.nombreCliente, c.apellidoCliente, c.rtn, F.descuento, f.observaciones, f.esVenta
		END
		ELSE IF @accion = 'buscar'
		BEGIN
			SELECT f.idFactura 'Código factura', f.fechaVenta 'Fecha venta', CONCAT(co.nombreColaborador, ' ', co.apellidoColaborador) Colaborador, 
			CONCAT(c.nombreCliente,' ', c.apellidoCliente) Cliente, c.rtn 'RTN cliente',
			CASE WHEN esVenta = 1 THEN SUM(df.cantidad * df.precio) ELSE 0 END  Subtotal, CASE WHEN esVenta = 1 THEN (SUM(df.cantidad * df.precio) * 0.15) ELSE 0 END  ISV,
			 CASE WHEN esVenta = 1 THEN F.descuento ELSE 0 END Descuento,  CASE WHEN esVenta = 1 THEN SUM(df.cantidad * df.precio) +  ((SUM(df.cantidad * df.precio) * 0.15) - f.descuento) ELSE  0 END Total,
			f.observaciones Observaciones
			FROM Factura f JOIN DetalleFactura df 
			ON df.idFactura = f.idFactura
			JOIN Cliente c ON c.idCliente = f.idCliente
			JOIN Colaborador co on co.idColaborador = f.idColaborador
			WHERE  CONCAT(f.idFactura, ' ', f.fechaVenta, ' ', c.nombreCliente, ' ', c.apellidoCliente, ' ', c.rtn, co.nombreColaborador, ' ', co.apellidoColaborador) LIKE CONCAT('%', @facturaBuscada,'%')
			GROUP BY f.idFactura, f.fechaVenta, co.nombreColaborador, co.apellidoColaborador, c.nombreCliente, c.apellidoCliente, c.rtn, F.descuento, f.observaciones, f.esVenta
			
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
	ELSE IF @accion = 'mostrarDetalle'
		BEGIN
			select P.idProducto 'Codigo del Producto', P.nombreProducto 'Producto',DF.cantidad,
			CASE WHEN esVenta = 1 THEN DF.precio ELSE 0 END  Precio,
			CASE WHEN esVenta = 1 THEN SUM(DF.cantidad * DF.precio) ELSE 0 END  Subtotal
			from Factura F INNER JOIN DetalleFactura DF 
			ON F.idFactura = DF.idFactura
			INNER JOIN Producto P 
			ON P.idProducto = DF.idProducto
			where F.idFactura = @idFactura
			GROUP BY P.idProducto, P.nombreProducto, F.esVenta, DF.cantidad, DF.precio
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
@estado bit = NULL,
@accion nvarchar(50),
@productoBuscado VARCHAR(150)  = NULL

AS
BEGIN
	
	IF @accion = 'insertar'
		BEGIN
			INSERT INTO Producto VALUES (@nombreProducto, @descripcion, @precioDetalle, @precioMayorista, @idCategoria, @estado);
		END
	ELSE IF @accion = 'modificar'
		BEGIN
			  UPDATE Producto
			  SET nombreProducto = @nombreProducto, descripcion = @descripcion, precioDetalle = @precioDetalle, precioMayorista = @precioMayorista, idCategoria = @idCategoria, estado = @estado
			  WHERE idProducto = @idProducto
		END
	ELSE IF @accion = 'mostrar'
		BEGIN
			  SELECT p.idProducto Codigo, p.nombreProducto Producto, p.descripcion Descripcion, p.precioDetalle 'Precio detalle', p.precioMayorista 'Precio mayorista',c.idCategoria, c.categoria Catgeoria,
				(SELECT ISNULL(SUM(cantidad), 0) FROM Lote WHERE idProducto = p.idProducto) - (SELECT ISNULL(SUM(cantidad), 0) FROM DetalleFactura WHERE idProducto = p.idProducto)  Existencia, p.estado Estado
				FROM Producto p JOIN Categoria c
				ON p.idCategoria = C.idCategoria
				WHERE p.estado = @estado
		END
	ELSE IF @accion = 'buscar'
		BEGIN
			  SELECT p.idProducto Codigo, p.nombreProducto Producto, p.descripcion Descripcion, p.precioDetalle 'Precio detalle', p.precioMayorista 'Precio mayorista', c.idCategoria,c.categoria Catgeoria,
				(SELECT ISNULL(SUM(cantidad), 0) FROM Lote WHERE idProducto = p.idProducto) - (SELECT ISNULL(SUM(cantidad), 0) FROM DetalleFactura WHERE idProducto = p.idProducto)  Existencia, p.estado Estado
				FROM Producto p JOIN Categoria c
				ON p.idCategoria = C.idCategoria
				 WHERE  CONCAT(p.idProducto, ' ', p.nombreProducto, ' ', c.categoria) LIKE CONCAT('%', @productoBuscado,'%') AND p.estado = @estado
		END
	ELSE IF @accion = 'CargarEstado'
	BEGIN
		SELECT '1' id, 'Activo' estado
        UNION
        SELECT '0', 'Inactivo'
	END
	ELSE IF @accion = 'desactivarProducto'
	BEGIN
		UPDATE Producto
		SET  estado = 0
		WHERE idProducto = @idProducto
	END

END
GO

CREATE PROCEDURE sp_Cliente
@idCliente int = NULL,
@dni VARCHAR(15) = NULL,
@rtn VARCHAR(15) = NULL,
@nombreCliente VARCHAR(55) = NULL,
@apellidoCliente VARCHAR(55) = NULL,
@estado bit = NULL,
@accion nvarchar(50),
@clienteBuscado VARCHAR(150)  = NULL

AS
BEGIN
	
	IF @accion = 'insertar'
		BEGIN
			INSERT INTO [dbo].[Cliente]	VALUES(@dni, @rtn, @nombreCliente, @apellidoCliente, @estado)
		END

	ELSE IF @accion = 'modificar'
		BEGIN
			UPDATE Cliente
			SET dni=@dni, rtn=@rtn, nombreCliente=@nombreCliente, apellidoCliente=@apellidoCliente, estado = @estado
			WHERE Cliente.idCliente=@idCliente
		END
		ELSE IF @accion = 'mostrar'
		BEGIN
			  SELECT idCliente Codigo, dni Identidad, rtn RTN, CONCAT(nombreCliente, ' ', apellidoCliente) 'Nombre cliente', nombreCliente, apellidoCliente, estado Estado
			  FROM Cliente
			  WHERE estado = @estado
		END
	ELSE IF @accion = 'buscar'
		BEGIN
			  SELECT idCliente Codigo, dni Identidad, rtn RTN, CONCAT(nombreCliente, ' ', apellidoCliente) 'Nombre cliente', nombreCliente, apellidoCliente, estado Estado
			  FROM Cliente
			  WHERE  CONCAT(nombreCliente, ' ', apellidoCliente, ' ', rtn, ' ', idCliente) LIKE CONCAT('%', @clienteBuscado,'%') AND estado = @estado
		END
	ELSE IF @accion = 'CargarEstado'
	BEGIN
		SELECT '1' id, 'Activos' estado
        UNION
        SELECT '0', 'Inactivos'
	END
	ELSE IF @accion = 'desactivarCliente'
	BEGIN
		UPDATE Cliente
		SET  estado = 0
		WHERE idCliente = @idCliente
	END

END
GO

CREATE OR ALTER PROCEDURE [dbo].[sp_Categoria] 
	-- Add the parameters for the stored procedure here
	@idCategoria int = NULL,
	@categoria varchar(30) = null,
	@estado bit = NULL,
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
			INSERT INTO [dbo].[Categoria] VALUES(@categoria, @estado)
		END
	ELSE IF @accion = 'mostrar'
		BEGIN
			SELECT C.idCategoria AS Codigo, C.categoria AS Categoria, C.estado Estado FROM Categoria AS C
			WHERE estado =  @estado
			ORDER BY C.idCategoria ASC
		END
	ELSE IF @accion = 'modificar'
		BEGIN
			UPDATE Categoria 
			SET Categoria.categoria = @categoria, estado = @estado
			WHERE Categoria.idCategoria = @idCategoria
		END

	ELSE IF @accion = 'buscar'
		BEGIN
			SELECT C.idCategoria AS Codigo, C.categoria AS Categoria,  C.estado Estado FROM Categoria AS C
			WHERE CONCAT(C.idCategoria, ' ', C.categoria) LIKE CONCAT('%', @categoriaBusquedad,'%') AND estado = @estado
		END
	ELSE IF @accion = 'CargarEstado'
	BEGIN
		SELECT '1' id, 'Activos' estado
        UNION
        SELECT '0', 'Inactivos'
	END
	ELSE IF @accion = 'desactivarCategoria'
	BEGIN
		UPDATE Categoria
		SET  estado = 0
		WHERE idCategoria = @idCategoria
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
@nombreEmpleado VARCHAR(80)  = NULL,
@colaboradorBuscado VARCHAR(80) = NULL

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
				WHERE idColaborador =  @idColaborador
		END
		ELSE IF @accion = 'mostrar'
		BEGIN
			  SELECT c.idColaborador 'Codigo', c.nombreColaborador'Nombre',c.apellidoColaborador 'Apellido',c.correo'Correo',c.usuario 'Usuario', CONVERT(VARCHAR,DECRYPTBYPASSPHRASE('ACecrypt02',contrasenia)) 'Contraseña', (p.puesto) 'Puesto', c.estado 'Estado'
				FROM Colaborador c JOIN Puesto p 
				ON c.idPuesto = p.idPuesto	
				WHERE estado = @estado
				ORDER BY p.idPuesto ASC		
				
		END
		ELSE IF @accion = 'mostrarPuesto'
		BEGIN
			  SELECT p.idPuesto, (p.puesto)
				FROM Colaborador c full JOIN Puesto p 
				ON c.idPuesto = p.idPuesto				
				
		END
		ELSE IF @accion = 'buscar'
		BEGIN
			SELECT c.idColaborador 'Codigo', c.nombreColaborador'Nombre',c.apellidoColaborador 'Apellido',c.correo'Correo',c.usuario 'Usuario', CONVERT(VARCHAR,DECRYPTBYPASSPHRASE('ACecrypt02',contrasenia)) 'Contraseña', (p.puesto) 'Puesto'
				FROM Colaborador c JOIN Puesto p 
				ON c.idPuesto = p.idPuesto	
			Where CONCAT(C.nombreColaborador, ' ', C.apellidoColaborador, ' ', C.usuario) LIKE CONCAT('%', @colaboradorBuscado,'%') and c.estado=@estado
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
	ELSE IF @accion = 'obtenerColaboradorCorreo'
		BEGIN
			SELECT idColaborador, nombreColaborador, apellidoColaborador, correo, usuario, CONVERT(VARCHAR,DECRYPTBYPASSPHRASE('ACecrypt02',contrasenia)) contrasenia,
			idPuesto, estado  
			FROM Colaborador 
			WHERE correo = @correo
		END
	ELSE IF @accion = 'recuperarPass'
		BEGIN
			SET @password = (ENCRYPTBYPASSPHRASE('ACecrypt02',@contrasenia));
			UPDATE Colaborador
				SET  contrasenia = @password
				WHERE idColaborador =  @idColaborador
		END
	ELSE IF @accion = 'CargarEstado'
	BEGIN
		SELECT '1' id, 'Activos' estado
        UNION
        SELECT '0', 'Inactivos'
	END
	ELSE IF @accion = 'desactivarColaborador'
	BEGIN
		UPDATE Colaborador
		SET  estado = 0
		WHERE idColaborador = @idColaborador
	END
	

END
GO
Create PROCEDURE [dbo].[sp_Lote]
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
CREATE PROCEDURE sp_SAR
@codigoSAR int = NULL,  
@rangoInicial int = NULL,
@rangoFinal int	= NULL,
@fechaRecepcion date = NULL,
@fechaLimiteEmision date = NULL,
@cai varchar(200) = NULL,
@estado bit = NULL,
@rangoBuscado varchar(200) =  NULL,
@accion nvarchar(50)
AS 
BEGIN


	IF @accion = 'insertarRango'
	BEGIN
		INSERT INTO [dbo].[SAR] VALUES (@rangoInicial, @rangoFinal,@fechaRecepcion ,@fechaLimiteEmision,@cai,@estado)
	END

	ELSE IF @accion = 'Buscar'
	BEGIN
		SELECT S.CodigoSAR 'Código', S.RangoInicial 'Valor Inicial', S.RangoFinal 'Valor Final', S.fechaRecepcion 'Fecha de Recepcion', S.FechaLimiteEmision 'Fecha Limite de Emision', 
		S.cai 'Cai',S.estado 'Estado' from [dbo].[SAR] S WHERE S.estado = @estado AND CONCAT(S.CodigoSAR,' ', S.cai) LIKE CONCAT('%',@rangoBuscado,'%')
	END

	ELSE IF @accion = 'mostrar'
	BEGIN
		SELECT S.CodigoSAR 'Código', S.RangoInicial 'Valor Inicial', S.RangoFinal 'Valor Final', S.fechaRecepcion 'Fecha de Recepcion', S.FechaLimiteEmision 'Fecha Limite de Emision', 
		S.cai 'Cai',S.estado 'Estado' from [dbo].[SAR] S WHERE S.estado = @estado
	END

	ELSE IF @accion = 'modificarRango'
	BEGIN
		UPDATE [dbo].[SAR]
		SET rangoInicial = @rangoInicial, rangoFinal = @rangoFinal, fechaLimiteEmision = @fechaLimiteEmision, fechaRecepcion = @fechaRecepcion, cai = @cai ,estado = @estado
		WHERE CodigoSAR = @codigoSAR
	END

	ELSE IF @accion = 'desactivarRango'
	BEGIN
		UPDATE [dbo].[SAR]
		SET  estado = 0
		WHERE CodigoSAR = @codigoSAR
	END

	ELSE IF @accion = 'CodigoSarActivo'
	BEGIN 
		select top 1 CodigoSAR from SAR WHERE estado = 1 ORDER BY CodigoSAR ASC
	END
	
	ELSE IF @accion = 'ObtenerSAR'
	BEGIN
		select top 1 RangoInicial from SAR WHERE estado = 1 ORDER BY CodigoSAR ASC
	END

	ELSE IF @accion = 'PrimerFactura'
	BEGIN 
		select * from Factura where CodigoSAR = (select top 1 CodigoSAR from SAR WHERE estado = 1 ORDER BY CodigoSAR ASC)
	END 

	ELSE IF @accion = 'InsertarCodigoFactura'
	BEGIN 
		select top 1  idFactura+1 'Codigo' from Factura where CodigoSAR = (select top 1 CodigoSAR from SAR WHERE estado = 1 ORDER BY CodigoSAR ASC)
		ORDER BY idFactura DESC
	END

	ELSE IF @accion = 'FechaLimiteEmision'
	BEGIN 
		select top 1  fechaLimiteEmision from SAR where estado = 1
	END

	ELSE IF @accion = 'CargarEstado'
	BEGIN
		SELECT '1' id, 'Activos' estado
        UNION
        SELECT '0', 'Inactivos'
	END

END
GO

CREATE PROCEDURE sp_bitacora@value sql_variant = NULL,@key sysname = NULL,@buscado nvarchar(200) = NULL,@accion nvarchar(50)ASBEGIN	IF @accion = 'idColaborador'	begin	EXEC sp_set_session_context @key, @value	end	ELSE IF @accion = 'Mostrar'	BEGIN		select B.idBitacora 'Codigo de Registro', B.idColaborador'Codigo de Colaborador',CONCAT(C.nombreColaborador,' ', C.apellidoColaborador) 'Nombre del Colaborador', b.pcUsuario 'PC del Usuario',		B.accion 'Accion', B.fecha 'Fecha'		from Bitacora B INNER JOIN Colaborador C 		ON C.idColaborador = B.idColaborador		ORDER BY B.idBitacora DESC	END	ELSE IF @accion = 'Buscar'	BEGIN		select B.idBitacora 'Codigo de Registro', B.idColaborador'Codigo de Colaborador',CONCAT(C.nombreColaborador,' ', C.apellidoColaborador) 'Nombre del Colaborador', b.pcUsuario 'PC del Usuario',		B.accion 'Accion', B.fecha 'Fecha'		from Bitacora B INNER JOIN Colaborador C 		ON C.idColaborador = B.idColaborador		WHERE CONCAT(B.idColaborador, ' ', C.nombreColaborador, ' ', C.apellidoColaborador,' ' ,B.accion) LIKE CONCAT('%',@buscado,'%')		ORDER BY B.idBitacora DESC	ENDEND
GO

CREATE PROCEDURE sp_VentasXMes
@mes int = NULL,
@anio int = NULL
AS 
BEGIN

SELECT f.idFactura, f.fechaVenta, CONCAT(co.nombreColaborador, ' ', co.apellidoColaborador) Colaborador, 
			CONCAT(c.nombreCliente,' ', c.apellidoCliente) Cliente, c.rtn,
			CASE WHEN esVenta = 1 THEN SUM(df.cantidad * df.precio) ELSE 0 END  Subtotal, CASE WHEN esVenta = 1 THEN (SUM(df.cantidad * df.precio) * 0.15) ELSE 0 END  ISV,
			 CASE WHEN esVenta = 1 THEN F.descuento ELSE 0 END Descuento,  CASE WHEN esVenta = 1 THEN SUM(df.cantidad * df.precio) +  ((SUM(df.cantidad * df.precio) * 0.15) - f.descuento) ELSE  0 END Total,
			f.observaciones Observaciones
			FROM Factura f JOIN DetalleFactura df 
			ON df.idFactura = f.idFactura
			JOIN Cliente c ON c.idCliente = f.idCliente
			JOIN Colaborador co on co.idColaborador = f.idColaborador
			--WHERE MONTH(F.fechaVenta) = @mes AND YEAR(F.fechaVenta) = @anio
			GROUP BY f.idFactura, f.fechaVenta, co.nombreColaborador, co.apellidoColaborador, c.nombreCliente, c.apellidoCliente, c.rtn, F.descuento, f.observaciones, f.esVenta

END
GO

CREATE PROCEDURE sp_GananciasXMes
@anio int = NULL
AS 
	BEGIN

			SELECT DATENAME(month,f.fechaVenta)'Mes',SUM(df.cantidad * df.precio) +  ((SUM(df.cantidad * df.precio) * 0.15) - SUM(f.descuento)) - (select SUM(L.precioCompra*L.cantidad) from Lote L) Ganancias
			FROM Factura f JOIN DetalleFactura df 
			ON df.idFactura = f.idFactura
			JOIN Cliente c ON c.idCliente = f.idCliente
			JOIN Colaborador co on co.idColaborador = f.idColaborador
			WHERE YEAR(F.fechaVenta) = @anio AND YEAR(F.fechaVenta) = @anio
			GROUP BY DATENAME(month,f.fechaVenta)

	END
GO


CREATE PROCEDURE sp_TotVentasYUnidades
@mes int = NULL,
@anio int = NULL
AS 
BEGIN


SELECT ISNULL(SUM(df.cantidad * df.precio) +  ((SUM(df.cantidad * df.precio) * 0.15) - SUM(f.descuento)),0) Ventas, ISNULL(SUM(df.cantidad),0) unidades
			FROM Factura f JOIN DetalleFactura df 
			ON df.idFactura = f.idFactura
			JOIN Cliente c ON c.idCliente = f.idCliente
			JOIN Colaborador co on co.idColaborador = f.idColaborador
			WHERE MONTH(F.fechaVenta) = @mes AND YEAR(F.fechaVenta) = @anio	

END
GO


CREATE PROCEDURE sp_TotalExistencias
AS 
BEGIN
	SELECT p.idProducto Codigo, p.nombreProducto Producto,c.categoria Categoria,
				(SELECT ISNULL(SUM(cantidad), 0) FROM Lote WHERE idProducto = p.idProducto) - (SELECT ISNULL(SUM(cantidad), 0) FROM DetalleFactura WHERE idProducto = p.idProducto)  Existencia
				FROM Producto p JOIN Categoria c
				ON p.idCategoria = C.idCategoria


END
GO


----------- Triggers

CREATE TRIGGER ValidarRango
ON FACTURA after insert
AS

BEGIN
	if((select I.idFactura from inserted I) = (select S.RangoFinal from SAR S where S.estado = 1))
	BEGIN 
		UPDATE SAR set 
			estado = 0
		where estado = 1
	END

END
GO

/*

*************Triggers para Bitacora*****************

*/



-------------------
------------------- Categoria
-------------------

CREATE TRIGGER InsertarCategoria 
ON Categoria AFTER INSERT
AS
BEGIN
declare @id sql_variant
	set @id = (select SESSION_CONTEXT(N'user_id'));
	INSERT INTO Bitacora
	select cast(@id as int), 
SYSTEM_USER,
CONCAT('Inserción de la categoria ', categoria,  ' con ID ', idCategoria),
GETDATE()
from inserted
END
GO

CREATE TRIGGER ModificarCategoria
ON Categoria AFTER UPDATE
AS
BEGIN
declare @id sql_variant
	set @id = (select SESSION_CONTEXT(N'user_id'));
	INSERT INTO Bitacora
select cast(@id as int), 
SYSTEM_USER,
CONCAT('Modificación de la categoria ', categoria,  ' con ID ', idCategoria),
GETDATE()
from inserted
END
GO

---------------
--------------- Cliente
--------------- 

CREATE TRIGGER InsertarCliente
ON Cliente AFTER INSERT
AS
BEGIN
declare @id sql_variant
	set @id = (select SESSION_CONTEXT(N'user_id'));
	INSERT INTO Bitacora
	select cast(@id as int), 
SYSTEM_USER,
CONCAT('Inserción del cliente ', nombreCliente,' ' , apellidoCliente,  ' con ID ', idCliente),
GETDATE()
from inserted
END
GO

CREATE TRIGGER ModificarCliente
ON Cliente AFTER UPDATE
AS
BEGIN
declare @id sql_variant
	set @id = (select SESSION_CONTEXT(N'user_id'));
	INSERT INTO Bitacora
	select cast(@id as int), 
SYSTEM_USER,
CONCAT('Modificación del cliente ', nombreCliente,' ' , apellidoCliente,  ' con ID ', idCliente),
GETDATE()
from inserted
END
GO

---------------
--------------- Colaborador
--------------- 

CREATE TRIGGER InsertarColaborador
ON Colaborador AFTER INSERT
AS
BEGIN
declare @id sql_variant
	set @id = (select SESSION_CONTEXT(N'user_id'));
	INSERT INTO Bitacora
	select cast(@id as int), 
SYSTEM_USER,
CONCAT('Inserción del colaborador ', nombreColaborador,' ' , apellidoColaborador,  ' con ID ', idColaborador),
GETDATE()
from inserted
END
GO


CREATE TRIGGER ModificarColaborador
ON Colaborador AFTER UPDATE
AS
BEGIN
declare @id sql_variant
	set @id = (select SESSION_CONTEXT(N'user_id'));
	INSERT INTO Bitacora
	select cast(@id as int), 
SYSTEM_USER,
CONCAT('Modificación del colaborador ', nombreColaborador,' ' , apellidoColaborador,  ' con ID ', idColaborador),
GETDATE()
from inserted
END
GO


---------------
--------------- Factura
--------------- 

CREATE TRIGGER InsertarFactura
ON Factura AFTER INSERT
AS
BEGIN
declare @id sql_variant
	set @id = (select SESSION_CONTEXT(N'user_id'));
	INSERT INTO Bitacora
	select cast(@id as int), 
SYSTEM_USER,
CONCAT('Creación de la factura numero ', idFactura),
GETDATE()
from inserted
END
GO


CREATE TRIGGER DesactivarFactura
ON Factura AFTER UPDATE
AS
BEGIN
declare @id sql_variant
	set @id = (select SESSION_CONTEXT(N'user_id'));
	INSERT INTO Bitacora
	select cast(@id as int), 
SYSTEM_USER,
CONCAT('Anulación de la factura numero ', idFactura),
GETDATE()
from inserted
END
GO

---------------
--------------- Lote
--------------- 

CREATE TRIGGER InsertarLote
ON Lote AFTER INSERT
AS
BEGIN
declare @id sql_variant
	set @id = (select SESSION_CONTEXT(N'user_id'));
	INSERT INTO Bitacora
	select cast(@id as int), 
SYSTEM_USER,
CONCAT('Inserción de un lote del articulo ', (select distinct P.nombreProducto from Producto P inner join Lote L on P.idProducto = L.idProducto WHERE P.idProducto = I.idProducto), ' con una existencia de ', I.cantidad,' al lote con ID ', I.idLote ),
GETDATE()
from inserted I
END
GO

CREATE TRIGGER ModificarLote
ON Lote AFTER UPDATE
AS
BEGIN
declare @id sql_variant
	set @id = (select SESSION_CONTEXT(N'user_id'));
	INSERT INTO Bitacora
	select cast(@id as int), 
SYSTEM_USER,
CONCAT('Modificación de un lote del articulo ', (select distinct P.nombreProducto from Producto P inner join Lote L on P.idProducto = L.idProducto WHERE P.idProducto = I.idProducto), ' con una existencia de ', I.cantidad,' al lote con ID ', I.idLote ),
GETDATE()
from inserted I
END
GO

---------------
--------------- Producto
--------------- 

CREATE TRIGGER InsertarProducto
ON Producto AFTER INSERT
AS
BEGIN
declare @id sql_variant
	set @id = (select SESSION_CONTEXT(N'user_id'));
	INSERT INTO Bitacora
	select cast(@id as int), 
SYSTEM_USER,
CONCAT('Inserción del producto ', nombreProducto , ' con ID ', idProducto),
GETDATE()
from inserted I
END
GO


CREATE TRIGGER ModificarProducto
ON Producto AFTER UPDATE
AS
BEGIN
declare @id sql_variant
	set @id = (select SESSION_CONTEXT(N'user_id'));
	INSERT INTO Bitacora
	select cast(@id as int), 
SYSTEM_USER,
CONCAT('Modificación del producto ', nombreProducto , ' con ID ', idProducto),
GETDATE()
from inserted I
END
GO

---------------
--------------- Puesto
--------------- 

CREATE TRIGGER InsertarPuesto
ON Puesto AFTER INSERT
AS
BEGIN
declare @id sql_variant
	set @id = (select SESSION_CONTEXT(N'user_id'));
	INSERT INTO Bitacora
	select cast(@id as int), 
SYSTEM_USER,
CONCAT('Inserción del puesto ', puesto , ' con ID ', idPuesto),
GETDATE()
from inserted I
END
GO

CREATE TRIGGER ModificarPuesto
ON Puesto AFTER UPDATE
AS
BEGIN
declare @id sql_variant
	set @id = (select SESSION_CONTEXT(N'user_id'));
	INSERT INTO Bitacora
	select cast(@id as int), 
SYSTEM_USER,
CONCAT('Modificación del puesto ', puesto , ' con ID ', idPuesto),
GETDATE()
from inserted I
END
GO

---------------
--------------- SAR
--------------- 

CREATE TRIGGER InsertarSAR
ON SAR AFTER INSERT
AS
BEGIN
declare @id sql_variant
	set @id = (select SESSION_CONTEXT(N'user_id'));
	INSERT INTO Bitacora
	select cast(@id as int), 
SYSTEM_USER,
CONCAT('Inserción del rango ', rangoInicial, ' - ', rangoFinal , ' con ID ', CodigoSAR),
GETDATE()
from inserted I
END
GO

CREATE TRIGGER ModificarSAR
ON SAR AFTER UPDATE
AS
BEGIN
declare @id sql_variant
	set @id = (select SESSION_CONTEXT(N'user_id'));
	INSERT INTO Bitacora
	select cast(@id as int), 
SYSTEM_USER,
CONCAT('Modificación del rango ', rangoInicial, ' - ', rangoFinal , ' con ID ', CodigoSAR),
GETDATE()
from inserted I
END
GO
