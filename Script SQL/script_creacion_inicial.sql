CREATE SCHEMA THE_FOREIGN_FOUR AUTHORIZATION gd

CREATE TABLE THE_FOREIGN_FOUR.Roles (
	cod_rol				numeric(18,0)			IDENTITY(1,1) PRIMARY KEY,
	nombre				nvarchar(30)			UNIQUE,
	estado				char(1)					DEFAULT 'H' CHECK(estado IN ('H', 'I')),
)
CREATE TABLE THE_FOREIGN_FOUR.Funcionalidades (
	cod_funcion			numeric(18,0)			IDENTITY (1,1) PRIMARY KEY,
	nombre				varchar(60)				UNIQUE,
)
CREATE TABLE THE_FOREIGN_FOUR.FuncionalidadPorRol (
	cod_funcion			numeric(18,0)			REFERENCES THE_FOREIGN_FOUR.Funcionalidades,
	cod_rol				numeric(18,0)			REFERENCES THE_FOREIGN_FOUR.Roles,
	PRIMARY KEY(cod_funcion, cod_rol)
)
CREATE TABLE THE_FOREIGN_FOUR.Hoteles (
	cod_hotel			numeric(18,0)			IDENTITY(1,1) PRIMARY KEY,			
	nombre				nvarchar(60),
	mail				nvarchar(60),
	telefono			nvarchar(30),
	nro_calle			numeric(18,0),
	nom_calle			nvarchar(255),
	cant_estrellas		numeric(18,0),
	ciudad				nvarchar(255),
	pais				nvarchar(30),
	fecha_creacion		datetime,
	recarga_estrellas	numeric(18,0),
	baja_logica			char(1)					DEFAULT 'N' CHECK(baja_logica IN ('S', 'N')),
	estado				char(1)					DEFAULT 'H' CHECK(estado IN ('H', 'I')),
)
CREATE TABLE THE_FOREIGN_FOUR.Usuarios (
	cod_usuario			numeric(18,0)			IDENTITY(1,1) PRIMARY KEY,
	user_name			nvarchar(30)			UNIQUE,
	password			nvarchar(255),
	nombre				nvarchar(60),
	apellido			nvarchar(60),
	tipo_doc			nvarchar(3)				DEFAULT 'PAS' CHECK(tipo_doc IN ('DNI', 'PAS')),
	nro_doc				numeric(18,0),
	mail				nvarchar(60),			--saco los unique ya que no es necesario para los usuarios
	telefono			nvarchar(60),
	direccion			nvarchar(60),
	fecha_nac			datetime,
	baja_logica			char(1)					DEFAULT 'N' CHECK(baja_logica IN ('S', 'N')),
	estado				char(1)					DEFAULT 'H' CHECK(estado IN ('H', 'I')),
)
CREATE TABLE THE_FOREIGN_FOUR.Clientes (
	cod_cliente			numeric(18,0)			IDENTITY(1,1) PRIMARY KEY,
	nombre				nvarchar(255),
	apellido			nvarchar(255),
	tipo_doc			char(3)					DEFAULT 'PAS' CHECK(tipo_doc IN ('DNI', 'PAS')),
	nro_doc				numeric(18,0)			UNIQUE,
	mail				nvarchar(255)			UNIQUE,
	telefono			nvarchar(60),
	nom_calle			nvarchar(255),
	nro_calle			numeric(18,0),
	pais_origen			nvarchar(255),
	localidad			nvarchar(255),
	nacionalidad		nvarchar(255),
	piso				numeric(18,0),
	depto				nvarchar(50),
	fecha_nac			datetime,
	estado				char(1)					DEFAULT 'H' CHECK(estado IN ('H', 'I')),
	baja_logica			char(1)					DEFAULT 'N'	CHECK(baja_logica IN ('S', 'N')) --Si el usuario elimina un cliente
																							 --NO se borra nunca fisicamente
)
CREATE TABLE THE_FOREIGN_FOUR.ClientesDefectuosos (
	cod_cliente			numeric(18,0)			IDENTITY(1,1) PRIMARY KEY,
	nombre				nvarchar(255),
	apellido			nvarchar(255),
	tipo_doc			char(3)					DEFAULT 'PAS',
	nro_doc				numeric(18,0),
	mail				nvarchar(255),
	telefono			nvarchar(60),
	nom_calle			nvarchar(255),
	nro_calle			numeric(18,0),
	pais_origen			nvarchar(60),
	nacionalidad		nvarchar(255),
	piso				numeric(18,0),
	depto				nvarchar(50),
	fecha_nac			datetime,
)
CREATE TABLE THE_FOREIGN_FOUR.InactividadHoteles (
	cod_tarea			numeric(18,0)			IDENTITY(1,1) PRIMARY KEY,
	cod_hotel			numeric(18,0)			REFERENCES THE_FOREIGN_FOUR.Hoteles,
	descripcion			nvarchar(255),
	fecha_desde			datetime,
	fecha_hasta			datetime,
)
CREATE TABLE THE_FOREIGN_FOUR.Regimenes (
	cod_regimen			numeric(18,0)			IDENTITY(1,1) PRIMARY KEY,
	precio				numeric(18,2),
	descripcion			nvarchar(255),
	estado				char(1)					DEFAULT 'H' CHECK(estado IN ('H', 'I')),
)
CREATE TABLE THE_FOREIGN_FOUR.TipoHabitaciones (
	cod_tipo_hab		numeric(18,0)			PRIMARY KEY,
	descripcion			nvarchar(255),
	recargo				numeric (18,2),
)
CREATE TABLE THE_FOREIGN_FOUR.Habitaciones (
	cod_habitacion		numeric(18,0)			PRIMARY KEY IDENTITY(1,1),
	cod_hotel			numeric(18,0)			REFERENCES THE_FOREIGN_FOUR.Hoteles,
	cod_tipo_hab		numeric(18,0)			REFERENCES THE_FOREIGN_FOUR.TipoHabitaciones,
	nro_habitacion		numeric(18,0),
	piso				numeric(18,0),
	ubicacion			nvarchar(50),
	descripcion			nvarchar(255), 		
	estado				char(1)					DEFAULT 'H' CHECK(estado IN ('H', 'I')),
)
CREATE TABLE THE_FOREIGN_FOUR.EstadosReserva (
	cod_estado			numeric(18,0)			IDENTITY(1,1) PRIMARY KEY,
	descripcion			varchar(255),
)
CREATE TABLE THE_FOREIGN_FOUR.Reservas (
	cod_reserva			numeric(18,0)			PRIMARY KEY,
	cod_hotel			numeric(18,0)			REFERENCES THE_FOREIGN_FOUR.Hoteles,
	cod_cliente			numeric(18,0)			REFERENCES THE_FOREIGN_FOUR.Clientes,
	cod_regimen			numeric(18,0)			REFERENCES THE_FOREIGN_FOUR.Regimenes,
	cod_estado_reserva	numeric(18,0)			REFERENCES THE_FOREIGN_FOUR.EstadosReserva,
	fecha_creacion		datetime,
	fecha_desde			datetime,
	fecha_hasta			datetime,
	cant_noches			int,
	usuario				nvarchar(255)
)
CREATE TABLE THE_FOREIGN_FOUR.ReservasDefectuosas (
	cod_reserva			numeric(18,0)			PRIMARY KEY,
	cod_hotel			numeric(18,0),
	cod_cliente			numeric(18,0),
	cod_regimen			numeric(18,0),
	fecha_creacion		datetime,
	fecha_desde			datetime,
	fecha_hasta			datetime,
	cant_noches			int,
)
CREATE TABLE THE_FOREIGN_FOUR.Cancelaciones (
	cod_cancelacion		numeric(18,0)			PRIMARY KEY IDENTITY(1,1),
	cod_reserva			numeric(18,0)			REFERENCES THE_FOREIGN_FOUR.Reservas,
	usuario				numeric(18,0)			REFERENCES THE_FOREIGN_FOUR.Usuarios,
	motivo				varchar(255),
	fecha_operacion		datetime
)
CREATE TABLE THE_FOREIGN_FOUR.Estadias (
	cod_estadia			numeric(18,0)			IDENTITY (1,1) PRIMARY KEY,
	cod_reserva			numeric(18,0)			REFERENCES THE_FOREIGN_FOUR.Reservas,
	fecha_inicio		datetime,
	cant_noches			numeric(18,0),
	checkout			datetime
)
CREATE TABLE THE_FOREIGN_FOUR.EstadiasDefectuosas (
	cod_estadia			numeric(18,0)			IDENTITY (1,1) PRIMARY KEY,
	cod_reserva			numeric(18,0)			REFERENCES THE_FOREIGN_FOUR.Reservas,
	fecha_inicio		datetime,
	cant_noches			numeric(18,0),
)
CREATE TABLE THE_FOREIGN_FOUR.TiposPago (
	cod_tipo_pago		numeric(18,0)			IDENTITY(1,1) PRIMARY KEY,
	descripcion			nvarchar(255),
)
CREATE TABLE THE_FOREIGN_FOUR.Pagos (
	cod_pago			numeric(18,0)			PRIMARY KEY IDENTITY(1,1),
	cod_tipo_pago		numeric(18,0)			REFERENCES THE_FOREIGN_FOUR.TiposPago,
	nro_tarjeta			nvarchar(30),
	nro_factura			numeric(18,0)			UNIQUE,
	fecha_pago			datetime				DEFAULT GETDATE(),
)
CREATE TABLE THE_FOREIGN_FOUR.Facturas (
	nro_factura			numeric(18,0)			PRIMARY KEY,
	cod_estadia			numeric(18,0)			REFERENCES THE_FOREIGN_FOUR.Estadias,
	cod_pago			numeric(18,0)			REFERENCES THE_FOREIGN_FOUR.Pagos,
	fecha_factura		datetime,
	total				numeric(18,2),
)
CREATE TABLE THE_FOREIGN_FOUR.FacturasDefectuosas (
	nro_factura			numeric(18,0),
	cod_estadia			numeric(18,0),
	cod_tipo_pago		numeric(18,0),
	fecha_factura		datetime,
	total				numeric(18,2),
)
CREATE TABLE THE_FOREIGN_FOUR.Consumibles (
	cod_consumible		numeric(18,0)			PRIMARY KEY,
	descripcion			nvarchar(255),
	precio				numeric(18,2),
)
CREATE TABLE THE_FOREIGN_FOUR.ClientePorEstadia (
	cod_estadia			numeric(18,0)			REFERENCES THE_FOREIGN_FOUR.Estadias,
	cod_cliente			numeric(18,0)			REFERENCES THE_FOREIGN_FOUR.Clientes,
	PRIMARY KEY (cod_estadia, cod_cliente)
)
CREATE TABLE THE_FOREIGN_FOUR.ItemsFactura (
	nro_item			numeric(18,0)			IDENTITY(1,1) PRIMARY KEY,
	nro_factura			numeric(18,0)			REFERENCES THE_FOREIGN_FOUR.Facturas,
	cod_consumible		numeric(18,0)			REFERENCES THE_FOREIGN_FOUR.Consumibles,
	cantidad			int			
)
CREATE TABLE THE_FOREIGN_FOUR.ItemsFacturaDefectuosos (
	nro_item			numeric(18,0)			IDENTITY(1,1) PRIMARY KEY,
	nro_factura			numeric(18,0),
	cod_consumible		numeric(18,0),
	cantidad			int,
)
CREATE TABLE THE_FOREIGN_FOUR.RegimenPorHotel (
	cod_hotel			numeric(18,0)			REFERENCES THE_FOREIGN_FOUR.Hoteles,
	cod_regimen			numeric(18,0)			REFERENCES THE_FOREIGN_FOUR.Regimenes
	PRIMARY KEY (cod_hotel, cod_regimen)
)
CREATE TABLE THE_FOREIGN_FOUR.UsuariosPorHotel (
	cod_usuario			numeric(18,0)			REFERENCES THE_FOREIGN_FOUR.Usuarios,
	cod_hotel			numeric(18,0)			REFERENCES THE_FOREIGN_FOUR.Hoteles,
	cod_rol				numeric(18,0)			REFERENCES THE_FOREIGN_FOUR.Roles
	PRIMARY KEY(cod_usuario, cod_hotel)
)
CREATE TABLE THE_FOREIGN_FOUR.Habitaciones_Estadia (
	cod_hab_estadia		numeric(18,0)			PRIMARY KEY IDENTITY(1,1),
	cod_estadia			numeric(18,0)			REFERENCES THE_FOREIGN_FOUR.Estadias,
	cod_habitacion		numeric(18,0)			REFERENCES THE_FOREIGN_FOUR.Habitaciones
)
CREATE TABLE THE_FOREIGN_FOUR.TipoHabitacion_Reservas (
	cod_hab_reserva		numeric(18,0)			PRIMARY KEY IDENTITY(1,1),
	cod_reserva			numeric(18,0)			REFERENCES THE_FOREIGN_FOUR.Reservas,
	cod_tipo_hab		numeric(18,0)			REFERENCES THE_FOREIGN_FOUR.TipoHabitaciones,
)
CREATE TABLE THE_FOREIGN_FOUR.AuditoriaEstadias (
	cod_audit			int						IDENTITY(1,1) PRIMARY KEY,
	cod_usuario			numeric(18,0)			REFERENCES THE_FOREIGN_FOUR.Usuarios,
	cod_estadia			numeric(18,0)			REFERENCES THE_FOREIGN_FOUR.Estadias,
	cod_operacion		char(1)					CHECK(cod_operacion IN ('I', 'O')),
	fecha				datetime				DEFAULT getdate()
)
GO

CREATE TRIGGER THE_FOREIGN_FOUR.trg_clientes_error
ON THE_FOREIGN_FOUR.Clientes
INSTEAD OF INSERT
AS
BEGIN

	DECLARE TrigInsCursor CURSOR FOR
	SELECT nombre, apellido, fecha_nac, nom_calle, nro_calle, piso, depto, nacionalidad, nro_doc, mail  
	FROM inserted
	DECLARE @nombre nvarchar(255),
			@apellido nvarchar(255),
			@fecha_nac datetime,
			@nom_calle nvarchar(255),
			@nro_calle	numeric(18,0),
			@piso numeric(18,0),
			@depto nvarchar(50),
			@nacionalidad nvarchar(255),
			@nro_doc numeric(18,0), 
			@mail nvarchar(255)

	OPEN TrigInsCursor;

	FETCH NEXT FROM TrigInsCursor INTO @nombre, @apellido, @fecha_nac, @nom_calle, @nro_calle, @piso, @depto, @nacionalidad, @nro_doc, @mail

	WHILE @@FETCH_STATUS = 0
	BEGIN
	
		IF(NOT EXISTS (SELECT nro_doc
					   FROM THE_FOREIGN_FOUR.Clientes
					   WHERE nro_doc = @nro_doc
					   OR mail = @mail))
		BEGIN
			INSERT INTO THE_FOREIGN_FOUR.Clientes (nombre, apellido, fecha_nac, nom_calle, nro_calle, piso, depto, nacionalidad, nro_doc, mail)
			VALUES (@nombre, @apellido, @fecha_nac, @nom_calle, @nro_calle, @piso, @depto, @nacionalidad, @nro_doc, @mail);
		END	
		ELSE
		BEGIN
			INSERT INTO THE_FOREIGN_FOUR.ClientesDefectuosos (nombre, apellido, fecha_nac, nom_calle, nro_calle, piso, depto, nacionalidad, nro_doc, mail)
			VALUES (@nombre, @apellido, @fecha_nac, @nom_calle, @nro_calle, @piso, @depto, @nacionalidad, @nro_doc, @mail);
		END			
			
		FETCH NEXT FROM TrigInsCursor INTO @nombre, @apellido, @fecha_nac, @nom_calle, @nro_calle, @piso, @depto, @nacionalidad, @nro_doc, @mail      

  END

  CLOSE TrigInsCursor;
  DEALLOCATE TrigInsCursor;

END
GO

--*****************************************************

CREATE TRIGGER THE_FOREIGN_FOUR.trg_reservas_error
ON THE_FOREIGN_FOUR.Reservas
INSTEAD OF INSERT
AS
BEGIN

	DECLARE TrigInsCursor CURSOR FOR
	SELECT cod_reserva, cod_hotel, cod_cliente, cod_regimen, /*cod_estado_reserva,*/ fecha_creacion, 
		   fecha_desde, fecha_hasta, cant_noches  
	FROM inserted
	DECLARE @cod_reserva numeric(18,0),
			@cod_hotel int,
			@cod_cliente numeric(18,0),
			@cod_regimen int,
			/*@cod_estado_reserva int,*/
			@fecha_creacion datetime, 
			@fecha_desde datetime,
			@fecha_hasta datetime,
			@cant_noches int,
			@fecha_sys datetime
			
			
	SET @fecha_sys = (SELECT MAX(Estadia_Fecha_Inicio + Estadia_Cant_Noches)
						FROM gd_esquema.Maestra)
	
	OPEN TrigInsCursor;

	FETCH NEXT FROM TrigInsCursor INTO	@cod_reserva, @cod_hotel,@cod_cliente, @cod_regimen, 
										/*@cod_estado_reserva,*/ @fecha_creacion, @fecha_desde, @fecha_hasta, @cant_noches

	WHILE @@FETCH_STATUS = 0
	BEGIN
	
		IF(	@cod_hotel IS NULL OR
			@cod_cliente IS NULL OR
			@cod_regimen IS NULL OR
			@fecha_desde IS NULL OR
			@cant_noches IS NULL)
			
		BEGIN
			INSERT INTO THE_FOREIGN_FOUR.ReservasDefectuosas (cod_reserva, cod_hotel, cod_cliente, 
						cod_regimen, fecha_creacion, fecha_desde, fecha_hasta, cant_noches)
			VALUES (@cod_reserva, @cod_hotel, @cod_cliente, @cod_regimen, 
					@fecha_creacion, @fecha_desde, @fecha_hasta, @cant_noches);
		END	
		ELSE
		BEGIN
			INSERT INTO THE_FOREIGN_FOUR.Reservas(cod_reserva, cod_hotel, cod_cliente, 
						cod_regimen, cod_estado_reserva, fecha_creacion, fecha_desde, fecha_hasta, cant_noches)
			VALUES (@cod_reserva, @cod_hotel, @cod_cliente, @cod_regimen, 
					(SELECT THE_FOREIGN_FOUR.func_estado_reserva(@fecha_desde, @fecha_sys)), 
					@fecha_creacion, @fecha_desde, @fecha_hasta, @cant_noches);
		END			
			
		FETCH NEXT FROM TrigInsCursor INTO	@cod_reserva, @cod_hotel,@cod_cliente, @cod_regimen, 
											/*@cod_estado_reserva,*/ @fecha_creacion, @fecha_desde, @fecha_hasta, @cant_noches      

  END

  CLOSE TrigInsCursor;
  DEALLOCATE TrigInsCursor;

END
GO

--*****************************************************

CREATE TRIGGER THE_FOREIGN_FOUR.trg_estadias_error
ON THE_FOREIGN_FOUR.Estadias
INSTEAD OF INSERT
AS
BEGIN

	DECLARE TrigInsCursor CURSOR FOR
	SELECT cod_reserva, fecha_inicio, cant_noches
	FROM inserted
	DECLARE @cod_reserva numeric(18,0),
			@nro_habitacion numeric(18,0),
			@fecha_inicio datetime,
			@cant_noches numeric(18,0)

	OPEN TrigInsCursor;

	FETCH NEXT FROM TrigInsCursor INTO @cod_reserva, @fecha_inicio, @cant_noches

	WHILE @@FETCH_STATUS = 0
	BEGIN
	
		IF(@cod_reserva IS NULL OR
		   @fecha_inicio IS NULL OR
		   @cant_noches IS NULL)
		   
		BEGIN
			INSERT INTO THE_FOREIGN_FOUR.EstadiasDefectuosas (cod_reserva, fecha_inicio, cant_noches)
			VALUES (@cod_reserva, @fecha_inicio, @cant_noches);
		END	
		ELSE
		BEGIN
		
			INSERT INTO THE_FOREIGN_FOUR.Estadias (cod_reserva, fecha_inicio, cant_noches)
			VALUES (@cod_reserva, @fecha_inicio, @cant_noches);

		END			
			
		FETCH NEXT FROM TrigInsCursor INTO @cod_reserva, @fecha_inicio, @cant_noches      

  END

  CLOSE TrigInsCursor;
  DEALLOCATE TrigInsCursor;

END
GO

--*****************************************************

CREATE TRIGGER THE_FOREIGN_FOUR.trg_facturas_error
ON THE_FOREIGN_FOUR.Facturas
INSTEAD OF INSERT
AS
BEGIN

	DECLARE TrigInsCursor CURSOR FOR
	SELECT nro_factura, fecha_factura, total, cod_estadia
	FROM inserted
	DECLARE @nro_factura numeric(18,0),
			@fecha_factura datetime,
			@total numeric(18,2),
			@cod_estadia numeric(18,0)

	OPEN TrigInsCursor;

	FETCH NEXT FROM TrigInsCursor INTO @nro_factura, @fecha_factura, @total, @cod_estadia

	WHILE @@FETCH_STATUS = 0
	BEGIN
	
		IF(@nro_factura IS NULL OR
		   @fecha_factura IS NULL OR
		   @total IS NULL OR
		   @cod_estadia IS NULL)
		   		   
		BEGIN
			INSERT INTO THE_FOREIGN_FOUR.FacturasDefectuosas (nro_factura, fecha_factura, total, cod_estadia)
			VALUES (@nro_factura, @fecha_factura, @total, @cod_estadia);
		END	
		ELSE
		BEGIN
			INSERT INTO THE_FOREIGN_FOUR.Facturas (nro_factura, fecha_factura, total, cod_estadia)
			VALUES (@nro_factura, @fecha_factura, @total, @cod_estadia);
		END			
			
		FETCH NEXT FROM TrigInsCursor INTO @nro_factura, @fecha_factura, @total, @cod_estadia     

  END

  CLOSE TrigInsCursor;
  DEALLOCATE TrigInsCursor;

END
GO


--***********************************************

CREATE TRIGGER THE_FOREIGN_FOUR.trg_clientes_por_estadia_err
ON THE_FOREIGN_FOUR.ClientePorEstadia
INSTEAD OF INSERT
AS
BEGIN

	DECLARE TrigInsCursor CURSOR FOR
	SELECT cod_cliente, cod_estadia
	FROM inserted
	DECLARE @cod_cliente numeric(18,0),
			@cod_estadia numeric(18,0)

	OPEN TrigInsCursor;

	FETCH NEXT FROM TrigInsCursor INTO @cod_cliente, @cod_estadia

	WHILE @@FETCH_STATUS = 0
	BEGIN
	
		IF(@cod_estadia IS NULL)
		
		BEGIN
			FETCH NEXT FROM TrigInsCursor INTO @cod_cliente, @cod_estadia
			CONTINUE
		END
		ELSE
		BEGIN
			INSERT INTO THE_FOREIGN_FOUR.ClientePorEstadia(cod_cliente, cod_estadia)
			VALUES (@cod_cliente, @cod_estadia);
		END			
		
		FETCH NEXT FROM TrigInsCursor INTO @cod_cliente, @cod_estadia    

  END

  CLOSE TrigInsCursor;
  DEALLOCATE TrigInsCursor;

END
GO

--*********************************************************

CREATE TRIGGER THE_FOREIGN_FOUR.trg_itemsFactura_error
ON THE_FOREIGN_FOUR.ItemsFactura
INSTEAD OF INSERT
AS
BEGIN

	DECLARE TrigInsCursor CURSOR FOR
	SELECT nro_factura, cantidad, cod_consumible
	FROM inserted
	DECLARE @nro_factura numeric(18,0),
			@cantidad numeric(18,0),
			@cod_consumible numeric(18,0)
			
	OPEN TrigInsCursor;

	FETCH NEXT FROM TrigInsCursor INTO @nro_factura, @cantidad, @cod_consumible
	WHILE @@FETCH_STATUS = 0
	BEGIN
	
		IF(@nro_factura IS NULL OR
		   @cantidad IS NULL OR
		   NOT EXISTS (SELECT cod_consumible
					   FROM THE_FOREIGN_FOUR.Consumibles
					   WHERE cod_consumible = @cod_consumible))
		   
		BEGIN
			INSERT INTO THE_FOREIGN_FOUR.ItemsFacturaDefectuosos (nro_factura, cantidad, cod_consumible)
			VALUES (@nro_factura, @cantidad, @cod_consumible);
		END	
		
		ELSE
		BEGIN
			
			INSERT INTO THE_FOREIGN_FOUR.ItemsFactura (nro_factura, cantidad, cod_consumible)
			VALUES (@nro_factura, @cantidad, @cod_consumible)
		END			
			
		FETCH NEXT FROM TrigInsCursor INTO @nro_factura, @cantidad, @cod_consumible 

  END

  CLOSE TrigInsCursor;
  DEALLOCATE TrigInsCursor;

END
GO


--******************
CREATE TRIGGER THE_FOREIGN_FOUR.trg_tipohab_reservas
ON THE_FOREIGN_FOUR.TipoHabitacion_Reservas
INSTEAD OF INSERT
AS
BEGIN

	DECLARE TrigInsCursor CURSOR FOR
	SELECT cod_reserva, cod_tipo_hab
	FROM inserted
	DECLARE @cod_reserva numeric(18,0),
			@cod_tipo_hab numeric(18,0)
			
	OPEN TrigInsCursor;

	FETCH NEXT FROM TrigInsCursor INTO @cod_reserva, @cod_tipo_hab
	WHILE @@FETCH_STATUS = 0
	BEGIN
	
		IF(@cod_reserva IS NULL OR
		   @cod_tipo_hab IS NULL)
		BEGIN
			FETCH NEXT FROM TrigInsCursor INTO @cod_reserva, @cod_tipo_hab
			CONTINUE
		END
		ELSE
		BEGIN
			INSERT INTO THE_FOREIGN_FOUR.TipoHabitacion_Reservas (cod_reserva, cod_tipo_hab)
			VALUES (@cod_reserva, @cod_tipo_hab)
		END	
			
		FETCH NEXT FROM TrigInsCursor INTO @cod_reserva, @cod_tipo_hab 

  END

  CLOSE TrigInsCursor;
  DEALLOCATE TrigInsCursor;

END
GO
--****************************************************************

CREATE TRIGGER THE_FOREIGN_FOUR.trg_habitaciones_estadia
ON THE_FOREIGN_FOUR.Habitaciones_Estadia
INSTEAD OF INSERT
AS
BEGIN

	DECLARE TrigInsCursor CURSOR FOR
	SELECT cod_estadia, cod_habitacion
	FROM inserted
	DECLARE @cod_estadia numeric(18,0),
			@cod_habitacion numeric(18,0)
			
	OPEN TrigInsCursor;

	FETCH NEXT FROM TrigInsCursor INTO @cod_estadia, @cod_habitacion
	WHILE @@FETCH_STATUS = 0
	BEGIN
	
		IF(@cod_estadia IS NULL OR
		   @cod_habitacion IS NULL)
		BEGIN
			FETCH NEXT FROM TrigInsCursor INTO @cod_estadia, @cod_habitacion
			CONTINUE
		END
		ELSE
		BEGIN
			INSERT INTO THE_FOREIGN_FOUR.Habitaciones_Estadia (cod_estadia, cod_habitacion)
			VALUES (@cod_estadia, @cod_habitacion)
		END	
			
		FETCH NEXT FROM TrigInsCursor INTO @cod_estadia, @cod_habitacion 

  END

  CLOSE TrigInsCursor;
  DEALLOCATE TrigInsCursor;

END
GO
CREATE FUNCTION	THE_FOREIGN_FOUR.func_obtener_cant_huespedes
				(@cod_reserva numeric(18,0))
		
RETURNS TABLE
AS
RETURN (SELECT	COUNT(c.cod_cliente) AS cantidad_huespedes
		FROM THE_FOREIGN_FOUR.Clientes c JOIN THE_FOREIGN_FOUR.ClientePorEstadia cpe ON(c.cod_cliente = cpe.cod_cliente)
										 JOIN THE_FOREIGN_FOUR.Estadias e ON(cpe.cod_estadia = e.cod_estadia)
		WHERE @cod_reserva = e.cod_reserva)
GO		
--***********************************************************
CREATE FUNCTION THE_FOREIGN_FOUR.func_existe_huesped
				(@mail nvarchar(255))
RETURNS int
AS
BEGIN
	IF(EXISTS (SELECT cod_cliente
			   FROM THE_FOREIGN_FOUR.buscar_clientes (NULL, NULL, NULL, NULL, @mail)
			   WHERE mail = @mail))
	BEGIN
		RETURN 1
	END
	RETURN -1
END
GO
--***********************************************************
CREATE PROCEDURE THE_FOREIGN_FOUR.proc_registrar_huesped
				(@cod_cliente numeric(18,0),
				 @cod_estadia numeric(18,0))
AS
	INSERT INTO THE_FOREIGN_FOUR.ClientePorEstadia (cod_cliente, cod_estadia)
	VALUES	(@cod_cliente, @cod_estadia)
GO


--***********************************************************
CREATE PROCEDURE THE_FOREIGN_FOUR.proc_registrar_estadia 
				(@cod_reserva numeric(18,0),
				 @usuario nvarchar(255))
AS
BEGIN

	DECLARE @fecha_inicio datetime
	SET @fecha_inicio = CAST(GETDATE() AS DATETIME)
	
	INSERT INTO THE_FOREIGN_FOUR.Estadias (cod_reserva, fecha_inicio)
	VALUES	(@cod_reserva, @fecha_inicio)
	
	INSERT INTO THE_FOREIGN_FOUR.AuditoriaEstadias (cod_usuario, cod_estadia, cod_operacion)
	VALUES ((SELECT THE_FOREIGN_FOUR.func_obtener_cod_usuario(@usuario)), (SELECT cod_estadia FROM THE_FOREIGN_FOUR.Estadias WHERE cod_reserva = @cod_reserva), 'I')
	
	UPDATE THE_FOREIGN_FOUR.Reservas
	SET cod_estado_reserva  = (SELECT cod_estado
								FROM THE_FOREIGN_FOUR.EstadosReserva
								WHERE descripcion = 'efectivizada')
	WHERE cod_reserva = @cod_reserva
	
	
	
	DECLARE  @cod_estadia numeric(18,0),
				@cod_hotel numeric(18,0)
	SET @cod_estadia = (SELECT cod_estadia
						FROM THE_FOREIGN_FOUR.Estadias
						WHERE cod_reserva = @cod_reserva
						AND fecha_inicio = @fecha_inicio)
	SET @cod_hotel = (SELECT DISTINCT cod_hotel
					 FROM THE_FOREIGN_FOUR.Reservas
					 WHERE cod_reserva = @cod_reserva)	
	
	
	SELECT	cod_tipo_hab
	INTO THE_FOREIGN_FOUR.#TipoHabReserva
	FROM THE_FOREIGN_FOUR.TipoHabitacion_Reservas
	WHERE cod_reserva = @cod_reserva
	
	--**cursor********
	DECLARE CursorHabitaciones CURSOR FOR
	SELECT *
	FROM THE_FOREIGN_FOUR.#TipoHabReserva
	DECLARE @cod_tipo_hab numeric(18,0)
	OPEN CursorHabitaciones;
	FETCH NEXT FROM CursorHabitaciones INTO @cod_tipo_hab
	
	WHILE @@FETCH_STATUS = 0
	BEGIN
		INSERT INTO THE_FOREIGN_FOUR.Habitaciones_Estadia (cod_estadia, cod_habitacion)
		VALUES (@cod_estadia, (SELECT MIN(cod_habitacion)
								FROM THE_FOREIGN_FOUR.func_obtener_hab_disponibles(@fecha_inicio, @cod_tipo_hab, @cod_hotel)))
		
		FETCH NEXT FROM CursorHabitaciones INTO @cod_tipo_hab
	END
	CLOSE CursorHabitaciones;
	DEALLOCATE CursorHabitaciones;
	--**cursor********
	
	DROP TABLE THE_FOREIGN_FOUR.#TipoHabReserva
	
END
GO
--***********************************************************
CREATE FUNCTION THE_FOREIGN_FOUR.func_validar_existe_reserva
				(@cod_reserva numeric(18,0))
RETURNS int
AS 
BEGIN
	IF(NOT EXISTS (SELECT cod_reserva
				   FROM THE_FOREIGN_FOUR.Reservas
				   WHERE cod_reserva = @cod_reserva))
	BEGIN
		RETURN -1
	END  
	RETURN 1
END
GO
--***********************************************************
CREATE FUNCTION THE_FOREIGN_FOUR.func_validar_reserva 
				(@cod_reserva numeric(18,0),
				 @cod_hotel int)
RETURNS int
AS
BEGIN
	IF(NOT EXISTS(SELECT cod_reserva
				  FROM THE_FOREIGN_FOUR.Reservas
				  WHERE	cod_reserva = @cod_reserva
				  AND	cod_hotel = @cod_hotel))
	BEGIN
		RETURN -1
	END
	RETURN 1
END
GO
--*****************************************************
CREATE FUNCTION THE_FOREIGN_FOUR.func_validar_reserva_no_cancelada 
				(@cod_reserva numeric(18,0),
				 @cod_hotel int)
RETURNS int
AS
BEGIN
	DECLARE @codigo int,
			@estadoReserva int
			
	SET @codigo = (SELECT THE_FOREIGN_FOUR.func_validar_reserva(@cod_reserva,@cod_hotel))
	SET @estadoReserva = (SELECT cod_estado_reserva
							FROM THE_FOREIGN_FOUR.Reservas
							WHERE cod_reserva = @cod_reserva)
	
	
	IF( (@codigo = 1) AND (@estadoReserva = 1 OR @estadoReserva = 2))
	BEGIN
		RETURN 1
	END
	RETURN -1
END
GO
--**********************************************************
CREATE FUNCTION THE_FOREIGN_FOUR.func_validar_existe_reserva_no_cancelada 
				(@cod_reserva numeric(18,0))
RETURNS int
AS
BEGIN
	DECLARE @codigo int,
			@estadoReserva int
			
	SET @codigo = (SELECT THE_FOREIGN_FOUR.func_validar_existe_reserva(@cod_reserva))
	SET @estadoReserva = (SELECT cod_estado_reserva
							FROM THE_FOREIGN_FOUR.Reservas
							WHERE cod_reserva = @cod_reserva)
	
	
	IF( (@codigo = 1) AND (@estadoReserva = 1 OR @estadoReserva = 2))
	BEGIN
		RETURN 1
	END
	RETURN -1
END
GO
--***********************************************************
CREATE PROCEDURE THE_FOREIGN_FOUR.proc_agregar_hab_reserva
				(@cod_reserva numeric(18,0),
				 @cod_tipo_hab numeric(18,0))
AS
BEGIN
	INSERT INTO THE_FOREIGN_FOUR.TipoHabitacion_Reservas (cod_reserva, cod_tipo_hab)
	VALUES (@cod_reserva, @cod_tipo_hab)
END
GO
--***********************************************************
CREATE PROCEDURE THE_FOREIGN_FOUR.proc_modificar_reserva
				(@cod_reserva numeric(18,0),
				 @fecha_desde datetime,
				 @fecha_hasta datetime,
				 @cod_regimen int,
				 @usuario nvarchar(255))
AS
	UPDATE THE_FOREIGN_FOUR.Reservas
	SET fecha_desde = @fecha_desde,
		fecha_hasta = @fecha_hasta,
		cant_noches = DATEDIFF(DAY, @fecha_desde, @fecha_hasta),
		cod_regimen = @cod_regimen,
		usuario = (SELECT THE_FOREIGN_FOUR.func_obtener_cod_usuario(@usuario)),
		cod_estado_reserva = (SELECT cod_estado
							  FROM THE_FOREIGN_FOUR.EstadosReserva
							  WHERE descripcion = 'modificada')
	WHERE @cod_reserva = cod_reserva
GO
--***********************************************************
CREATE PROCEDURE THE_FOREIGN_FOUR.proc_liberar_habitaciones
					(@cod_reserva numeric(18,0))
AS
BEGIN
	DELETE	THE_FOREIGN_FOUR.TipoHabitacion_Reservas
	WHERE	cod_reserva = @cod_reserva
END
GO
--***********************************************************
CREATE PROCEDURE THE_FOREIGN_FOUR.proc_cancelar_reserva
				(@cod_reserva numeric(18,0),
				 @motivo varchar(255),
				 @usuario varchar(255))
AS				
BEGIN
	DECLARE @estado varchar(30),
			@fecha_sistema datetime
	
	IF(@usuario IS NULL) 
	BEGIN
		SET @estado = 'cancelacion_cliente'
	END
	ELSE
	BEGIN
		SET @estado = 'cancelacion_recepcion'
	END
	
	UPDATE	THE_FOREIGN_FOUR.Reservas
	SET		cod_estado_reserva = (SELECT cod_estado
								  FROM THE_FOREIGN_FOUR.EstadosReserva
								  WHERE descripcion = @estado)
	WHERE	cod_reserva = @cod_reserva
	
	EXEC THE_FOREIGN_FOUR.proc_liberar_habitaciones @cod_reserva
	
	INSERT INTO THE_FOREIGN_FOUR.Cancelaciones (cod_reserva, motivo, usuario, fecha_operacion)
	VALUES (@cod_reserva, @motivo, (SELECT THE_FOREIGN_FOUR.func_obtener_cod_usuario(@usuario)), GETDATE())
END
GO

--***********************************************************
CREATE PROCEDURE THE_FOREIGN_FOUR.proc_generar_reserva
				(@cod_hotel int,
				 @cod_cliente numeric(18,0),
				 @cod_regimen int,
				 @fecha_desde datetime,
				 @fecha_hasta datetime,
				 @usuario nvarchar(255))
AS
BEGIN
	DECLARE @cod_reserva_generada numeric(18,0),
			@cod_estado_reserva int
			
	SET @cod_estado_reserva = (SELECT cod_estado
							   FROM THE_FOREIGN_FOUR.EstadosReserva
							   WHERE descripcion = 'correcta')
	SET @cod_reserva_generada = (SELECT THE_FOREIGN_FOUR.func_sgte_cod_reserva ())
	
	INSERT INTO THE_FOREIGN_FOUR.Reservas (cod_reserva, cod_hotel, cod_cliente, cod_estado_reserva, cod_regimen, fecha_desde, fecha_hasta, fecha_creacion, cant_noches, usuario)
	VALUES (@cod_reserva_generada, @cod_hotel, @cod_cliente, @cod_estado_reserva, @cod_regimen, @fecha_desde, @fecha_hasta, CAST(GETDATE() AS DATETIME), CONVERT(int, @fecha_hasta - @fecha_desde), (SELECT THE_FOREIGN_FOUR.func_obtener_cod_usuario(@usuario)))
	
	RETURN @cod_reserva_generada
END
GO

--***********************************************************
CREATE FUNCTION THE_FOREIGN_FOUR.func_hotel_inhabilitable 
				(@cod_hotel int,
				 @fecha_inicio datetime,
				 @fecha_fin datetime)
RETURNS int
AS
BEGIN
	IF(NOT EXISTS (SELECT cod_reserva
				   FROM	THE_FOREIGN_FOUR.Reservas
				   WHERE fecha_desde BETWEEN @fecha_inicio AND @fecha_fin
				   OR	 fecha_hasta BETWEEN @fecha_inicio AND @fecha_fin))
	BEGIN 
		RETURN 1
	END
	RETURN -1
END
GO
--***********************************************************
CREATE PROCEDURE THE_FOREIGN_FOUR.proc_inhabilitar_hotel
				(@cod_hotel int,
				 @motivo nvarchar(255),
				 @fecha_inicio datetime,
				 @fecha_fin datetime)
AS
BEGIN
	INSERT INTO THE_FOREIGN_FOUR.InactividadHoteles (cod_hotel, descripcion, fecha_desde, fecha_hasta)
	VALUES (@cod_hotel, @motivo, @fecha_inicio, @fecha_fin)
END
GO
--***********************************************************
CREATE VIEW THE_FOREIGN_FOUR.view_hoteles
AS
	SELECT cod_hotel, nombre
	FROM THE_FOREIGN_FOUR.Hoteles
GO

--***********************************************************
CREATE FUNCTION THE_FOREIGN_FOUR.func_obtener_regimenes_hab
				(@cod_hotel int)

RETURNS TABLE
AS
RETURN
		(SELECT	r.cod_regimen, r.descripcion, r.precio
		 FROM THE_FOREIGN_FOUR.RegimenPorHotel rph JOIN THE_FOREIGN_FOUR.Regimenes r ON(rph.cod_regimen = r.cod_regimen)
		 WHERE	r.estado = 'H'
		 AND	@cod_hotel = rph.cod_hotel)
GO
--**************************************************************
CREATE FUNCTION THE_FOREIGN_FOUR.func_hab_disponibles
				(@cod_hotel int,
				 @cod_tipo_hab numeric(18,0),
				 @fecha_inicio datetime,
				 @fecha_fin	datetime)
RETURNS INT
AS
BEGIN
	DECLARE @cant_hab_por_tipo int,
			@cant_hab_reservadas int,
			@cant_hab_disponibles int,
			@cant_hab_checkout int

	SET		@cant_hab_por_tipo = (SELECT	COUNT(nro_habitacion)
								  FROM		THE_FOREIGN_FOUR.Habitaciones ha
								  WHERE		@cod_hotel = ha.cod_hotel
								  AND		@cod_tipo_hab = ha.cod_tipo_hab) 
								  
	SET		@cant_hab_reservadas = (SELECT	COUNT(thr.cod_reserva)
									FROM	THE_FOREIGN_FOUR.Reservas r JOIN THE_FOREIGN_FOUR.TipoHabitacion_Reservas thr ON(r.cod_reserva = thr.cod_reserva)
									WHERE	@cod_hotel = r.cod_hotel
									AND		((r.cod_estado_reserva = 1) 
									OR		(r.cod_estado_reserva = 6))
									AND		@cod_tipo_hab = thr.cod_tipo_hab
									AND		(@fecha_inicio BETWEEN r.fecha_desde AND r.fecha_hasta
									OR		@fecha_fin BETWEEN r.fecha_desde AND r.fecha_hasta))
									
	SET		@cant_hab_checkout = (	SELECT	COUNT(th.cod_tipo_hab)
									FROM	THE_FOREIGN_FOUR.Reservas r,
											THE_FOREIGN_FOUR.Estadias e,
											THE_FOREIGN_FOUR.TipoHabitacion_Reservas th
									WHERE	r.cod_reserva = e.cod_reserva
									AND		e.cod_reserva = th.cod_reserva
									AND		th.cod_tipo_hab = @cod_tipo_hab
									AND		@fecha_inicio > e.checkout
									AND		@fecha_fin <= r.fecha_hasta)
	IF(EXISTS (SELECT	cod_tarea
				FROM	THE_FOREIGN_FOUR.InactividadHoteles
				WHERE	cod_hotel = @cod_hotel
				AND		(@fecha_inicio BETWEEN fecha_desde AND fecha_hasta
				OR		 @fecha_fin BETWEEN fecha_desde AND fecha_hasta)))	
	BEGIN
		SET @cant_hab_disponibles = -33
	END	
	ELSE
	BEGIN		
		SET	@cant_hab_disponibles = @cant_hab_por_tipo - @cant_hab_reservadas + @cant_hab_checkout
	END
	RETURN	@cant_hab_disponibles
END
GO
--***********************************************************
CREATE FUNCTION THE_FOREIGN_FOUR.func_hay_disponibilidad
				(@cod_hotel int,
				 @cod_tipo_hab numeric(18,0),
				 @cod_regimen int,
				 @fecha_desde datetime,
				 @fecha_hasta datetime)
RETURNS INT
AS
BEGIN
	IF	(NOT EXISTS (SELECT cod_regimen
				     FROM THE_FOREIGN_FOUR.func_obtener_regimenes_hab (@cod_hotel)
				     WHERE @cod_regimen = cod_regimen))
	BEGIN
		RETURN -1
	END
	IF	(THE_FOREIGN_FOUR.func_hab_disponibles (@cod_hotel,
											    @cod_tipo_hab,
											    @fecha_desde,
											    @fecha_hasta) <= 0)
	BEGIN
		RETURN 0
	END				
	
	RETURN 1
END
GO
--***********************************************************
CREATE FUNCTION THE_FOREIGN_FOUR.login_password 
				(@user_name nvarchar(30), 
				 @password nvarchar(255))
RETURNS TABLE  
AS
RETURN(
	SELECT h.cod_hotel, h.nombre, h.nom_calle, h.nro_calle
	FROM THE_FOREIGN_FOUR.Usuarios u, THE_FOREIGN_FOUR.Hoteles h, THE_FOREIGN_FOUR.UsuariosPorHotel uh
	WHERE	u.cod_usuario = uh.cod_usuario
	AND		h.cod_hotel = uh.cod_hotel
	AND		u.user_name = @user_name
	AND		u.password = @password
)
GO
--***********************************************************
CREATE FUNCTION THE_FOREIGN_FOUR.login_funcionalidades(
				@user_name nvarchar(30),
				@cod_hotel int)
				
RETURNS TABLE
AS
RETURN(
	SELECT f.cod_funcion,f.nombre
	FROM THE_FOREIGN_FOUR.Usuarios u,
	THE_FOREIGN_FOUR.UsuariosPorHotel uh,
	THE_FOREIGN_FOUR.FuncionalidadPorRol fr,
	THE_FOREIGN_FOUR.Funcionalidades f
	WHERE u.cod_usuario = uh.cod_usuario
	AND   uh.cod_rol = fr.cod_rol
	AND   fr.cod_funcion = f.cod_funcion
	AND   uh.cod_hotel = @cod_hotel	
	AND   u.user_name = @user_name
)
GO
--***********************************************************
CREATE FUNCTION THE_FOREIGN_FOUR.buscar_clientes(
				@nombre nvarchar(255),
				@apellido nvarchar(255),
				@tipo_doc char(3),
				@nro_doc numeric(18,0),
				@mail nvarchar(255))
RETURNS TABLE
AS
RETURN(

	SELECT cod_cliente, nombre, apellido, tipo_doc, nro_doc, mail, telefono, fecha_nac, 
			nom_calle, nro_calle, nacionalidad, pais_origen, estado, piso
	FROM THE_FOREIGN_FOUR.Clientes
	WHERE nombre LIKE 
		(CASE WHEN @nombre IS NULL  THEN '%' ELSE @nombre END)
	AND apellido LIKE
		(CASE WHEN @apellido IS NULL THEN '%' ELSE @apellido END)
	AND tipo_doc LIKE 
		(CASE WHEN @tipo_doc IS NULL THEN '%' ELSE  @tipo_doc END)
	AND CAST(nro_doc AS nvarchar(10)) LIKE 
		(CASE WHEN @nro_doc IS NULL THEN '%' ELSE CAST(@nro_doc AS nvarchar(10)) END)
	AND mail LIKE 
		(CASE WHEN @mail IS NULL THEN '%' ELSE @mail   END)
)
GO
--***********************************************************
CREATE FUNCTION THE_FOREIGN_FOUR.func_validar_cliente(
					@tipo_doc char(3),
					@nro_doc numeric(18,0),
					@mail nvarchar(255))
RETURNS int
AS
BEGIN
	IF(EXISTS (SELECT cod_cliente
			   FROM THE_FOREIGN_FOUR.Clientes
			   WHERE nro_doc = @nro_doc
			   OR	 mail = @mail))
		BEGIN
			RETURN -1
		END
	RETURN 1
END
GO
--***********************************************************
CREATE PROCEDURE THE_FOREIGN_FOUR.proc_registrar_cliente(
					@nombre nvarchar(255),
					@apellido nvarchar(255),
					@tipo_doc char(3),
					@nro_doc numeric(18,0),
					@mail nvarchar(255),
					@telefono numeric(18,0),
					@fecha_nac datetime,
					@nom_calle nvarchar(255),
					@nro_calle numeric(18,0),
					@depto nvarchar(50),
					@piso numeric(18,0),
					@nacionalidad nvarchar(255),
					@pais_origen nvarchar(255),
					@localidad nvarchar(255))
AS
BEGIN
	INSERT INTO THE_FOREIGN_FOUR.Clientes (nombre, apellido, tipo_doc, nro_doc, mail, telefono, fecha_nac, 
										   nom_calle, nro_calle, depto, piso, nacionalidad, pais_origen, localidad)
	VALUES (@nombre, @apellido, @tipo_doc, @nro_doc, @mail, @telefono, @fecha_nac, @nom_calle, @nro_calle,
										   @depto, @piso, @nacionalidad, @pais_origen, @localidad)
	DECLARE @cod_cliente_registrado numeric(18,0)
	SET @cod_cliente_registrado = (SELECT cod_cliente
								   FROM THE_FOREIGN_FOUR.Clientes
								   WHERE @mail = mail
								   AND	@nro_doc = nro_doc
								   AND	@fecha_nac = fecha_nac)
	RETURN @cod_cliente_registrado
END
GO
--***********************************************************
CREATE VIEW THE_FOREIGN_FOUR.view_funcionalidades_rol 
AS
SELECT r.nombre as 'Rol' , f.nombre as 'Funcionalidad' 
FROM THE_FOREIGN_FOUR.FuncionalidadPorRol fr,THE_FOREIGN_FOUR.Funcionalidades f,THE_FOREIGN_FOUR.Roles r
WHERE fr.cod_funcion=f.cod_funcion
AND r.cod_rol=fr.cod_rol
GO
--***********************************************************
CREATE VIEW THE_FOREIGN_FOUR.view_roles_hoteles_usuarios
AS
SELECT u.cod_usuario, u.user_name, uh.cod_hotel, r.nombre as 'rol'
FROM THE_FOREIGN_FOUR.Usuarios u, THE_FOREIGN_FOUR.UsuariosPorHotel uh, THE_FOREIGN_FOUR.Roles r
WHERE u.cod_usuario = uh.cod_usuario
AND uh.cod_rol = r.cod_rol
GO
--***********************************************************
CREATE VIEW THE_FOREIGN_FOUR.view_todos_los_clientes 
AS
SELECT cod_cliente, nombre, apellido, tipo_doc, nro_doc, mail, telefono, fecha_nac, nom_calle, 
		nro_calle, nacionalidad, pais_origen,  estado, piso
FROM THE_FOREIGN_FOUR.Clientes
GO
--***********************************************************
CREATE PROCEDURE THE_FOREIGN_FOUR.proc_inhabilitar_cliente
					(@mail nvarchar(255))
AS
BEGIN
	UPDATE THE_FOREIGN_FOUR.Clientes
	SET estado = 'I'
	WHERE mail = @mail
END
GO
--***********************************************************
CREATE PROCEDURE THE_FOREIGN_FOUR.proc_eliminar_cliente (@mail nvarchar(255))
AS

	UPDATE THE_FOREIGN_FOUR.Clientes
	SET baja_logica = 'S'
	WHERE mail = @mail
GO
--***********************************************************
CREATE FUNCTION THE_FOREIGN_FOUR.obtener_tipo_habitaciones (
				@cod_hotel int)
RETURNS TABLE
AS
RETURN(
	SELECT DISTINCT h.cod_tipo_hab, th.descripcion
	FROM THE_FOREIGN_FOUR.Habitaciones h, THE_FOREIGN_FOUR.TipoHabitaciones th
	WHERE h.cod_tipo_hab = th.cod_tipo_hab
	AND  h.cod_hotel = @cod_hotel
	
)
GO
--***********************************************************
CREATE FUNCTION THE_FOREIGN_FOUR.buscar_habitaciones(
				@nro_hab numeric(18,0),
				@cod_hotel int,
				@tipo_hab int,
				@ubicacion nvarchar(50),
				@piso numeric(18,0))
				
RETURNS TABLE
AS
RETURN(
	SELECT nro_habitacion, cod_hotel, h.cod_tipo_hab, th.descripcion, piso, ubicacion, estado
	FROM THE_FOREIGN_FOUR.Habitaciones h, THE_FOREIGN_FOUR.TipoHabitaciones th
	WHERE h.cod_tipo_hab = th.cod_tipo_hab
	AND CAST(nro_habitacion AS nvarchar(4)) LIKE
			(CASE WHEN @nro_hab IS NULL THEN '%' ELSE CAST(@nro_hab AS nvarchar(4)) END)
	AND CAST(cod_hotel AS nvarchar(10)) LIKE
			(CASE WHEN @cod_hotel IS NULL THEN '%' ELSE CAST(@cod_hotel AS nvarchar(10)) END)
	AND CAST(h.cod_tipo_hab AS nvarchar(20)) LIKE
			(CASE WHEN @tipo_hab IS NULL THEN '%' ELSE CAST(@tipo_hab AS nvarchar(20)) END)
	AND ubicacion LIKE
			(CASE WHEN @ubicacion IS NULL THEN '%' ELSE @ubicacion END)
	AND CAST(piso AS nvarchar(4)) LIKE
			(CASE WHEN @piso IS NULL THEN '%' ELSE CAST(@piso AS nvarchar(4)) END)
)
GO
--***********************************************************
CREATE PROCEDURE THE_FOREIGN_FOUR.proc_inhabilitar_habitacion(
					@nro_hab numeric(18,0),
					@cod_hotel int)
AS

UPDATE THE_FOREIGN_FOUR.Habitaciones
SET estado = 'I'
WHERE nro_habitacion = @nro_hab
AND cod_hotel = @cod_hotel

GO
--***********************************************************
CREATE VIEW THE_FOREIGN_FOUR.view_funcionalidades
AS
SELECT DISTINCT cod_funcion, nombre
FROM THE_FOREIGN_FOUR.Funcionalidades
GO
--***********************************************************
CREATE PROCEDURE THE_FOREIGN_FOUR.proc_inhabilitar_rol(@cod_rol int)
AS
UPDATE THE_FOREIGN_FOUR.Roles
SET estado = 'I'
WHERE cod_rol = @cod_rol
GO

--************************************************************
CREATE PROCEDURE THE_FOREIGN_FOUR.proc_juego_datos
AS
BEGIN
	
	INSERT INTO THE_FOREIGN_FOUR.Usuarios(user_name, password, nombre)
	VALUES	('admin', '52d77462b24987175c8d7dab901a5967e927ffc8d0b6e4a234e07a4aec5e3724','Administrador General')
	INSERT INTO THE_FOREIGN_FOUR.Roles(nombre)
	VALUES	('Administrador'),
			('Recepcionista'),
			('Guest'),
			('Administrador General')
	INSERT INTO THE_FOREIGN_FOUR.Funcionalidades(nombre)
	VALUES	('ABM Rol'),
			('ABM Usuario'),
			('ABM Clientes'),
			('ABM Hotel'),
			('ABM Habitacion'),
			('ABM Regimen De Estadia'),
			('Generar o Modificar Reserva'),
			('Cancelar Reserva'),
			('Registrar Estadia'),
			('Registrar Consumibles'),
			('Facturar Estadia'),
			('Listado Estadistico')
			
	INSERT INTO THE_FOREIGN_FOUR.FuncionalidadPorRol(cod_rol, cod_funcion)
	VALUES	(1,1), (1,2), (1,3), (1,4), (1,5), (1,6), (1,7), (1,9), (1,10), (1,11), (1,12), --verificar
			(2,1), (2,4), (2,7), (2,8), (2,9), (2,10),
			(3,7), (3,8),
			(4,1), (4,2), (4,3), (4,4), (4,5), (4,6), (4,7), (4,8), (4,9), (4,10), (4,11), (4,12)
			
	INSERT INTO THE_FOREIGN_FOUR.RegimenPorHotel(cod_hotel, cod_regimen)
	VALUES	(1,1), (1,2), (1,3), (1,4),
			(2,1), (2,2), (2,3), (2,4),
			(3,1), (3,2), (3,3), (3,4),
			(4,1), (4,2), (4,3), (4,4),
			(5,1), (5,2), (5,3), (5,4),
			(6,1), (6,2), (6,3), (6,4),
			(7,1), (7,2), (7,3), (7,4),
			(8,1), (8,2), (8,3), (8,4),
			(9,1), (9,2), (9,3), (9,4),
			(10,1), (10,2), (10,3), (10,4),
			(11,1), (11,2), (11,3), (11,4),
			(12,1), (12,2), (12,3), (12,4),
			(13,1), (13,2), (13,3), (13,4),
			(14,1), (14,2), (14,3), (14,4),
			(15,1), (15,2), (15,3), (15,4),
			(16,1), (16,2), (16,3), (16,4)
			
	INSERT INTO THE_FOREIGN_FOUR.UsuariosPorHotel(cod_usuario, cod_hotel, cod_rol)
	VALUES	(1, 1, 4), (1, 2, 4), (1, 3, 4), (1, 4, 4), (1, 5, 4), 
			(1, 6, 4), (1, 7, 4), (1, 8, 4), (1, 9, 4), (1, 10, 4),
			(1, 11, 4), (1, 12, 4), (1, 13, 4), (1, 14, 4), (1, 15, 4), 
			(1, 16, 4)
			
	INSERT INTO THE_FOREIGN_FOUR.Consumibles (cod_consumible, descripcion)
	VALUES (1, 'estadia'), (2, 'descuento all inclusive'), (3, 'noches no utilizadas')
	
	INSERT INTO THE_FOREIGN_FOUR.TiposPago (descripcion)
	VALUES ('Contado'), ('Tarjeta de Credito')

END	
GO

--**************************
CREATE PROCEDURE THE_FOREIGN_FOUR.porc_insercion_estados_reserva
AS
BEGIN
INSERT INTO THE_FOREIGN_FOUR.EstadosReserva(descripcion)
	VALUES	('correcta'),
			('modificada'),
			('cancelacion_recepcion'),
			('cancelacion_cliente'),
			('cancelacion_noshow'),
			('efectivizada')
END
GO
--*********************************************************************************
CREATE FUNCTION THE_FOREIGN_FOUR.func_sgte_cod_reserva ()
RETURNS numeric(18,0) AS
BEGIN
	RETURN (SELECT MAX(cod_reserva) + 1
			FROM THE_FOREIGN_FOUR.Reservas)
END
GO
--*********************************************************************************
CREATE FUNCTION THE_FOREIGN_FOUR.func_sgte_nro_factura
(
)
RETURNS numeric(18,0) AS
BEGIN
	RETURN (SELECT MAX(nro_factura) + 1
			FROM THE_FOREIGN_FOUR.Facturas)
END
GO
--**********************************************
CREATE VIEW THE_FOREIGN_FOUR.view_tipo_hab
(cod_tipo_hab, descripcion, recargo, capacidad)
AS
	SELECT cod_tipo_hab, descripcion, recargo, 1
	FROM THE_FOREIGN_FOUR.TipoHabitaciones
	WHERE descripcion = 'Base Simple'
	
	UNION
	
	SELECT cod_tipo_hab, descripcion, recargo, 2
	FROM THE_FOREIGN_FOUR.TipoHabitaciones
	WHERE descripcion = 'Base Doble'
	
	UNION
	
	SELECT cod_tipo_hab, descripcion, recargo, 3
	FROM THE_FOREIGN_FOUR.TipoHabitaciones
	WHERE descripcion = 'Base Triple'
	
	UNION
	
	SELECT cod_tipo_hab, descripcion, recargo, 4
	FROM THE_FOREIGN_FOUR.TipoHabitaciones
	WHERE descripcion = 'Base Cuadruple'
	
	UNION
	
	SELECT cod_tipo_hab, descripcion, recargo, 5
	FROM THE_FOREIGN_FOUR.TipoHabitaciones
	WHERE descripcion = 'King'
GO

--****************************************************
CREATE FUNCTION THE_FOREIGN_FOUR.buscar_tipo_hab_hotel (@cod_hotel numeric(18,0))
RETURNS TABLE
AS
RETURN
	(SELECT DISTINCT th.cod_tipo_hab, th.descripcion, th.recargo, th.capacidad
	FROM	THE_FOREIGN_FOUR.view_tipo_hab th, THE_FOREIGN_FOUR.Habitaciones h
	WHERE	th.cod_tipo_hab = h.cod_tipo_hab
	AND		h.cod_hotel = @cod_hotel
)
GO

--**************************************************************
--lo calcula por dia, si queres saber toda una estadia lo tenes que multiplicar por la cant de noches
CREATE FUNCTION THE_FOREIGN_FOUR.func_calcular_precio (@cod_regimen		numeric(18,0),
														@cod_hotel		numeric(18,0),
														@cod_tipo_hab	numeric(18,0))
RETURNS numeric(18,2)
AS
BEGIN
RETURN(

	SELECT DISTINCT	( ((r.precio* th.capacidad*th.recargo) + (h.cant_estrellas * h.recarga_estrellas)))
	FROM	THE_FOREIGN_FOUR.Regimenes r,
			THE_FOREIGN_FOUR.view_tipo_hab th,
			THE_FOREIGN_FOUR.Hoteles h,
			THE_FOREIGN_FOUR.Estadias e
	WHERE	h.cod_hotel = @cod_hotel
	AND		th.cod_tipo_hab = @cod_tipo_hab
	AND		r.cod_regimen = @cod_regimen
)
END
GO
--*************************************************************
CREATE FUNCTION THE_FOREIGN_FOUR.func_tipo_hab_estadia(@cod_estadia numeric(18,0))
RETURNS TABLE
AS
RETURN (
	SELECT	ha.cod_tipo_hab
	FROM	THE_FOREIGN_FOUR.Estadias e,
	THE_FOREIGN_FOUR.Habitaciones_Estadia he,
	THE_FOREIGN_FOUR.Habitaciones ha
	WHERE	he.cod_estadia = e.cod_estadia
	AND		e.cod_estadia = @cod_estadia
	AND		ha.cod_habitacion = he.cod_habitacion
)

GO

--**********************************************************
/*
El valor de la habitación se obtiene a través de su precio base 
(ver abm de régimen) multiplicando la cantidad de personas que se 
alojarán en la habitación (tipo de habitación) y luego de ello aplicando 
un incremento en función de la categoría del Hotel (cantidad de estrellas)
*/
CREATE FUNCTION THE_FOREIGN_FOUR.calcular_precio_estadia(@cod_estadia numeric(18,0))
RETURNS numeric(18,2)
AS
BEGIN

DECLARE @cod_regimen numeric(18,0),
		@cod_hotel	numeric(18,0),
		@cant_noches numeric(18,0),
		@precio numeric(18,0)

	SET @cod_regimen = (SELECT DISTINCT res.cod_regimen
						FROM	THE_FOREIGN_FOUR.Reservas res,
								THE_FOREIGN_FOUR.Estadias e
						WHERE e.cod_estadia = @cod_estadia
						AND e.cod_reserva = res.cod_reserva)
	
	SET @cant_noches = (SELECT	res.cant_noches
						FROM	THE_FOREIGN_FOUR.Reservas res,
								THE_FOREIGN_FOUR.Estadias e
						WHERE e.cod_estadia = @cod_estadia
						AND e.cod_reserva = res.cod_reserva)
	
						
	SET @cod_hotel = (SELECT	res.cod_hotel
						FROM	THE_FOREIGN_FOUR.Reservas res,
								THE_FOREIGN_FOUR.Estadias e
						WHERE   e.cod_estadia = @cod_estadia
						AND		e.cod_reserva = res.cod_reserva)
						
	DECLARE CursorTipoHab CURSOR FOR
	SELECT *
	FROM THE_FOREIGN_FOUR.func_tipo_hab_estadia(@cod_estadia)
	DECLARE @cod_tipo_hab numeric(18,0)
	
	OPEN CursorTipoHab;
	
	FETCH NEXT FROM CursorTipoHab INTO @cod_tipo_hab
	
	WHILE @@FETCH_STATUS = 0
	BEGIN
		SET @precio = (SELECT THE_FOREIGN_FOUR.func_calcular_precio (@cod_regimen, @cod_hotel, @cod_tipo_hab))
		FETCH NEXT FROM CursorTipoHab INTO @cod_tipo_hab
	END
	
	CLOSE CursorTipoHab;
	DEALLOCATE CursorTipoHab;						
						
	RETURN(@precio)
END
GO

--********************************************************
CREATE FUNCTION THE_FOREIGN_FOUR.buscar_cod_consumible (@descripcion nvarchar(255))
RETURNS numeric(18,0)
AS
BEGIN
RETURN(SELECT cod_consumible
		FROM THE_FOREIGN_FOUR.Consumibles
		WHERE descripcion = @descripcion)
END
GO

--*******************************************************
CREATE FUNCTION THE_FOREIGN_FOUR.func_calcular_total_consumibles_posta (@cod_estadia numeric(18,0))
RETURNS numeric(18,2)
AS
BEGIN

	DECLARE @total numeric(18,2),
			@nro_factura numeric(18,0),
			@cod_cons_estadia numeric(18,0),
			@cod_cons_all_inc numeric(18,0),
			@cod_cons_noches_canc numeric(18,0)
			
	SET @cod_cons_estadia = THE_FOREIGN_FOUR.buscar_cod_consumible('estadia')
	SET @cod_cons_all_inc = THE_FOREIGN_FOUR.buscar_cod_consumible ('descuento all inclusive')
	SET @cod_cons_noches_canc = THE_FOREIGN_FOUR.buscar_cod_consumible ('noches no utilizadas')
								
SET @nro_factura = (SELECT nro_factura
					FROM THE_FOREIGN_FOUR.Facturas
					WHERE cod_estadia = @cod_estadia)

SET @total = (SELECT(SUM(c.precio * i.cantidad))
				FROM THE_FOREIGN_FOUR.Consumibles c, THE_FOREIGN_FOUR.ItemsFactura i
				WHERE c.cod_consumible = i.cod_consumible
				AND i.nro_factura = @nro_factura
				AND c.cod_consumible != @cod_cons_all_inc
				AND c.cod_consumible != @cod_cons_estadia
				AND c.cod_consumible != @cod_cons_noches_canc)
				
RETURN @total

END
GO
--***********************************************************
--***********************************************************
--DROP FUNCTION THE_FOREIGN_FOUR.func_get_precio
CREATE FUNCTION THE_FOREIGN_FOUR.func_get_precio (@cod_consumible numeric(18,0), @cod_estadia numeric(18,0))
RETURNS numeric(18,0)
AS
BEGIN
	DECLARE @cod_cons_estadia numeric(18,0),
			@cod_cons_all_inc numeric(18,0),
			@cod_cons_noches_canc numeric(18,0),
			@precio numeric(18,2),
			@costo_hab_dia numeric(18,2)
			
	SET @cod_cons_estadia = THE_FOREIGN_FOUR.buscar_cod_consumible ('estadia')
	SET @cod_cons_all_inc = THE_FOREIGN_FOUR.buscar_cod_consumible ('descuento all inclusive')
	SET @cod_cons_noches_canc = THE_FOREIGN_FOUR.buscar_cod_consumible ('noches no utilizadas')
								
	SET @costo_hab_dia = (SELECT THE_FOREIGN_FOUR.calcular_precio_estadia(@cod_estadia))
	
	SET @precio = (SELECT
					CASE @cod_consumible
						WHEN @cod_cons_estadia THEN @costo_hab_dia /* precio estadia*/ 
						WHEN @cod_cons_all_inc THEN -(SELECT THE_FOREIGN_FOUR.func_calcular_total_consumibles_posta(@cod_estadia)) /*resta all inclusive*/
						WHEN @cod_cons_noches_canc THEN @costo_hab_dia /*noches no utilizadas*/
						ELSE (SELECT precio  
								FROM THE_FOREIGN_FOUR.Consumibles
								WHERE cod_consumible = @cod_consumible)
						END)
	
	RETURN @precio
END
GO									
--****************************************************************
CREATE PROCEDURE THE_FOREIGN_FOUR.proc_actualizar_total_factura @nro_factura numeric(18,0)
AS
BEGIN
	
	DECLARE @cod_estadia numeric(18,0), 
			@total numeric(18,2),
			@sub_total numeric(18,2)
	SET @cod_estadia = (SELECT f.cod_estadia
						FROM	THE_FOREIGN_FOUR.Facturas f
						WHERE nro_factura = @nro_factura)
			
	
	SELECT (THE_FOREIGN_FOUR.func_get_precio(c.cod_consumible, @cod_estadia) * i.cantidad) 'subtotal'
	INTO THE_FOREIGN_FOUR.#subtotales
	FROM THE_FOREIGN_FOUR.Consumibles c, THE_FOREIGN_FOUR.ItemsFactura i
	WHERE c.cod_consumible = i.cod_consumible
	AND i.nro_factura = @nro_factura
	GROUP BY i.nro_item, cantidad, c.cod_consumible
	
	SET @total = (SELECT SUM (subtotal)
					FROM THE_FOREIGN_FOUR.#subtotales)
	
	UPDATE THE_FOREIGN_FOUR.Facturas
	SET total = @total
	WHERE nro_factura = @nro_factura
	
	DROP TABLE THE_FOREIGN_FOUR.#subtotales
	
END
GO

--******************************************************

CREATE FUNCTION THE_FOREIGN_FOUR.func_obtener_estadia (@cod_reserva numeric(18,0))
RETURNS numeric(18,0)
AS
BEGIN
	RETURN (SELECT DISTINCT cod_estadia
			FROM THE_FOREIGN_FOUR.Estadias
			WHERE cod_reserva = @cod_reserva)
END
GO

--**********************************************************
CREATE PROCEDURE THE_FOREIGN_FOUR.confirmar_factura (@nro_factura numeric(18,0))
AS
BEGIN
	DECLARE @cod_regimen numeric(18,0),
			@cod_all_inclusive numeric(18,0),
			@cod_consumible_inclusive numeric(18,0),
			@cod_consumible_noches numeric(18,0),
			@cod_consumible_estadia numeric(18,0),
			@fecha_check_out datetime,
			@fecha_ideal datetime,
			@noches_estadia numeric(18,0),
			@noches_sin_usar numeric(18,0)
	
	SET @cod_regimen = (SELECT r.cod_regimen
						FROM	THE_FOREIGN_FOUR.Facturas f,
								THE_FOREIGN_FOUR.Estadias e,
								THE_FOREIGN_FOUR.Reservas r
						WHERE f.nro_factura = @nro_factura
						AND	f.cod_estadia = e.cod_estadia
						AND e.cod_reserva = r.cod_reserva)
						
	SET @cod_all_inclusive = (SELECT cod_regimen
								FROM THE_FOREIGN_FOUR.Regimenes
								WHERE descripcion = 'All inclusive')	
								
	SET @cod_consumible_inclusive = (SELECT THE_FOREIGN_FOUR.buscar_cod_consumible('descuento all inclusive'))
	SET @cod_consumible_estadia = (SELECT THE_FOREIGN_FOUR.buscar_cod_consumible('estadia'))
	SET @cod_consumible_noches = (SELECT THE_FOREIGN_FOUR.buscar_cod_consumible('noches no utilizadas'))
	SET @fecha_check_out = (SELECT fecha
							FROM THE_FOREIGN_FOUR.AuditoriaEstadias
							WHERE cod_operacion = 'O'
							AND cod_estadia = (SELECT cod_estadia
												FROM THE_FOREIGN_FOUR.Facturas
												WHERE nro_factura = @nro_factura
												))
	
	SET @fecha_ideal = (SELECT r.fecha_hasta
						FROM THE_FOREIGN_FOUR.Reservas r,
								THE_FOREIGN_FOUR.Estadias e,
								THE_FOREIGN_FOUR.Facturas f
						WHERE f.nro_factura = @nro_factura
						AND f.cod_estadia = e.cod_estadia
						AND r.cod_reserva = e.cod_reserva)
	
	SET @noches_sin_usar = DATEDIFF(DAY, @fecha_check_out, @fecha_ideal)
	
	SET @noches_estadia = (SELECT r.cant_noches
							FROM THE_FOREIGN_FOUR.Reservas r,
								 THE_FOREIGN_FOUR.Facturas f,
								 THE_FOREIGN_FOUR.Estadias e
							WHERE f.nro_factura = @nro_factura
							AND f.cod_estadia = e.cod_estadia
							AND r.cod_reserva = e.cod_reserva) - @noches_sin_usar
		
							
	IF (@cod_regimen = @cod_all_inclusive)
	BEGIN
		INSERT INTO THE_FOREIGN_FOUR.ItemsFactura (cod_consumible, cantidad, nro_factura)
		VALUES (@cod_consumible_inclusive, 1, @nro_factura)
	END
	
	IF(@noches_sin_usar > 0 )
	BEGIN
		INSERT INTO THE_FOREIGN_FOUR.ItemsFactura (cod_consumible, cantidad, nro_factura)
		VALUES (@cod_consumible_noches, @noches_sin_usar, @nro_factura)
	END
	
	INSERT INTO THE_FOREIGN_FOUR.ItemsFactura (cod_consumible, cantidad, nro_factura)
	VALUES (@cod_consumible_estadia, @noches_estadia, @nro_factura)
		
		
	EXECUTE THE_FOREIGN_FOUR.proc_actualizar_total_factura @nro_factura
	
	UPDATE THE_FOREIGN_FOUR.Estadias
	SET cant_noches = @noches_estadia
	WHERE cod_estadia = (SELECT cod_estadia
						FROM THE_FOREIGN_FOUR.Facturas
						WHERE nro_factura = @nro_factura)
												
	
END
GO


--***********************************************************
CREATE FUNCTION THE_FOREIGN_FOUR.func_existe_factura
				(@cod_estadia numeric(18,0))
RETURNS int
AS
BEGIN
	IF (NOT EXISTS (SELECT nro_factura
				FROM THE_FOREIGN_FOUR.Facturas
				WHERE cod_estadia = @cod_estadia))
	BEGIN
		RETURN 1
	END
	RETURN -1
END
GO
--***********************************************************
CREATE PROCEDURE THE_FOREIGN_FOUR.proc_crear_factura
				(@cod_estadia numeric(18,0),
				 @nro_factura numeric(18,0) OUTPUT)
AS
BEGIN
	SET @nro_factura = (SELECT THE_FOREIGN_FOUR.func_sgte_nro_factura ())
	INSERT INTO THE_FOREIGN_FOUR.Facturas (nro_factura, cod_estadia, fecha_factura) 
	VALUES (@nro_factura , @cod_estadia, CAST(GETDATE() AS DATETIME))
	RETURN 
END
GO

--******************************************************
CREATE VIEW THE_FOREIGN_FOUR.view_facturas
(nro_factura, cod_estadia, cod_consumible, descripcion, precio_unitario, cantidad, total_factura)
AS
SELECT f.nro_factura, f.cod_estadia, c.cod_consumible, c.descripcion, 
		(SELECT THE_FOREIGN_FOUR.func_get_precio(c.cod_consumible, f.cod_estadia)), i.cantidad, f.total
FROM	THE_FOREIGN_FOUR.Facturas f, 
		THE_FOREIGN_FOUR.ItemsFactura i,
		THE_FOREIGN_FOUR.Consumibles c
WHERE f.nro_factura = i.nro_factura
AND c.cod_consumible = i.cod_consumible
GO


--***********************************************************
CREATE FUNCTION THE_FOREIGN_FOUR.facturacion(@nro_factura int)
RETURNS TABLE
AS
RETURN(
SELECT *
FROM THE_FOREIGN_FOUR.view_facturas
WHERE nro_factura = @nro_factura
)
GO

--***********************************************************
CREATE TRIGGER THE_FOREIGN_FOUR.trg_separar_factura
ON THE_FOREIGN_FOUR.view_facturas
INSTEAD OF INSERT
AS
BEGIN

	DECLARE TrigInsCursor CURSOR FOR
	SELECT nro_factura, cod_consumible, cantidad
	FROM inserted
	DECLARE	@nro_factura numeric(18,0),
			@cod_consumible numeric(18,0),
			@cantidad int
			
	OPEN TrigInsCursor;
	
	FETCH NEXT FROM TrigInsCursor INTO @nro_factura, @cod_consumible, @cantidad
	WHILE @@FETCH_STATUS = 0
	BEGIN
	
		INSERT INTO THE_FOREIGN_FOUR.ItemsFactura(nro_factura, cod_consumible, cantidad)
		VALUES (@nro_factura, @cod_consumible, @cantidad)
		
		FETCH NEXT FROM TrigInsCursor INTO @nro_factura, @cod_consumible, @cantidad
	
	END
	
	CLOSE TrigInsCursor;
	DEALLOCATE TrigInsCursor;
	
	
END
GO

--****************************************************
CREATE FUNCTION THE_FOREIGN_FOUR.func_estado_reserva(@fecha_inicio datetime, @fecha_sistema datetime)
RETURNS int
AS
BEGIN
	DECLARE @cod_estado_reserva int,
			@estado varchar(40)
	IF (@fecha_inicio >= @fecha_sistema) 
	BEGIN
		SET @estado = 'correcta'
	END
	ELSE
	BEGIN
		SET @estado = 'efectivizada' 
	END
	RETURN (SELECT cod_estado
			FROM THE_FOREIGN_FOUR.EstadosReserva
			WHERE descripcion = @estado)
END
GO
--******************************************************
CREATE FUNCTION THE_FOREIGN_FOUR.buscar_regimenes_hotel (@cod_hotel numeric(18,0))
RETURNS TABLE
AS
RETURN(
	SELECT rh.cod_hotel, r.cod_regimen, r.descripcion, r.precio 
	FROM THE_FOREIGN_FOUR.RegimenPorHotel rh, THE_FOREIGN_FOUR.Regimenes r
	WHERE rh.cod_regimen = r.cod_regimen
	AND rh.cod_hotel = @cod_hotel
)
GO


--*********************************************
CREATE FUNCTION THE_FOREIGN_FOUR.func_obtener_cod_usuario (@username nvarchar(30))
RETURNS numeric(18,0)
AS
BEGIN
RETURN (SELECT cod_usuario
		FROM THE_FOREIGN_FOUR.Usuarios
		WHERE user_name = @username)
END
GO

--************************************************
CREATE PROCEDURE THE_FOREIGN_FOUR.proc_realizar_checkout(@cod_estadia numeric(18,0), @username nvarchar(30))
AS
BEGIN
	DECLARE @cod_usuario numeric(18,0)
	
	SET @cod_usuario = (SELECT THE_FOREIGN_FOUR.func_obtener_cod_usuario(@username))
	
	INSERT INTO THE_FOREIGN_FOUR.AuditoriaEstadias
	(cod_usuario, cod_operacion, cod_estadia)
	VALUES (@cod_usuario, 'O', @cod_estadia)
	
	UPDATE THE_FOREIGN_FOUR.Estadias
	SET checkout = GETDATE()
	WHERE cod_estadia = @cod_estadia

END
GO

--**********************************************
CREATE FUNCTION THE_FOREIGN_FOUR.func_check_out(@cod_estadia numeric(18,0),
												@username nvarchar(30))
RETURNS int
AS
BEGIN
	
	IF( NOT EXISTS(SELECT cod_estadia
					FROM THE_FOREIGN_FOUR.Estadias
					WHERE cod_estadia = @cod_estadia)
		OR EXISTS(SELECT cod_audit
					FROM THE_FOREIGN_FOUR.AuditoriaEstadias
					WHERE cod_estadia = @cod_estadia
					AND cod_operacion = 'O'))
	BEGIN
		RETURN -1
	END
	
	RETURN 1
END
GO	

--**********************************************************************
CREATE FUNCTION THE_FOREIGN_FOUR.func_igual_fecha
				(@fecha_uno datetime,
				 @fecha_dos datetime)
RETURNS int
AS
BEGIN
	IF ((DATEDIFF(YEAR, @fecha_uno, @fecha_dos) = 0) AND
		(DATEDIFF(MONTH, @fecha_uno, @fecha_dos) = 0) AND
		(DATEDIFF(DAY, @fecha_uno, @fecha_dos) = 0))
	BEGIN
		RETURN 1
	END
	ELSE 
	IF(@fecha_uno > @fecha_dos)
	BEGIN
		RETURN 0
	END
	RETURN -1
END
GO
--**********************************************************************
CREATE PROCEDURE THE_FOREIGN_FOUR.proc_validar_check_in
				(@cod_reserva numeric(18,0),
				 @cod_hotel int)
AS
BEGIN
	DECLARE @validacion_reserva int,
			@validacion_fechas int,
			@fecha_inicio_reserva datetime,
			@puede_check_in int
			
	SET		@validacion_reserva = THE_FOREIGN_FOUR.func_validar_reserva_no_cancelada (@cod_reserva, @cod_hotel)
	SET		@fecha_inicio_reserva = (SELECT fecha_desde FROM THE_FOREIGN_FOUR.Reservas WHERE cod_reserva = @cod_reserva)
	SET		@validacion_fechas = THE_FOREIGN_FOUR.func_igual_fecha(@fecha_inicio_reserva, GETDATE())
	
	IF	((@validacion_reserva = 1) AND
		 (@validacion_fechas = 1))
	BEGIN
		RETURN 1
	END
	ELSE
	IF (@validacion_fechas = -1) --El dia actual supera al fecha_desde de la reserva
	BEGIN
		UPDATE THE_FOREIGN_FOUR.Reservas
		SET	cod_estado_reserva = (SELECT cod_estado
								  FROM THE_FOREIGN_FOUR.EstadosReserva
								  WHERE descripcion = 'cancelacion_noshow')
		WHERE cod_reserva = @cod_reserva
		RETURN 0
	END
	RETURN -1

END
GO
--***************************************************
CREATE FUNCTION THE_FOREIGN_FOUR.func_validar_hab_hotel
				(@cod_hotel numeric(18,0),
				 @nro_habitacion numeric(18,0))
RETURNS int
AS
BEGIN
	IF (EXISTS (SELECT nro_habitacion
				FROM THE_FOREIGN_FOUR.Habitaciones
				WHERE	nro_habitacion = @nro_habitacion
				AND		cod_hotel = @cod_hotel))
	BEGIN
		RETURN 1
	END
	RETURN -1
END
GO
--********************************************************
CREATE PROCEDURE THE_FOREIGN_FOUR.proc_inhabilitar_usuario
				(@usuario nvarchar(255))
AS
BEGIN
	UPDATE THE_FOREIGN_FOUR.Usuarios
	SET estado = 'I'
	WHERE user_name = @usuario
END
GO
--********************************************************

CREATE FUNCTION THE_FOREIGN_FOUR.func_validar_consumible
				(@cod_consumible numeric(18,0))
RETURNS int
AS
BEGIN
	IF(EXISTS (SELECT cod_consumible
			   FROM THE_FOREIGN_FOUR.Consumibles
			   WHERE cod_consumible = @cod_consumible))
	BEGIN
		RETURN 1
	END
	RETURN -1
END
GO
--********************************************************
CREATE PROCEDURE THE_FOREIGN_FOUR.proc_registrar_consumible
				(@nro_factura numeric(18,0),
				 @cod_consumible numeric(18,0),
				 @cantidad	int)
AS
BEGIN
	INSERT INTO THE_FOREIGN_FOUR.view_facturas (nro_factura, cod_consumible, cantidad)
	VALUES	(@nro_factura, @cod_consumible, @cantidad)
END
GO
--**********************************************************
CREATE PROCEDURE THE_FOREIGN_FOUR.proc_checkout_migracion
AS
BEGIN
	UPDATE THE_FOREIGN_FOUR.Estadias
	SET checkout = fecha_inicio + cant_noches
END
GO

--**************************************
CREATE VIEW THE_FOREIGN_FOUR.view_habitaciones_disp
(cod_habitacion, nro_habitacion, piso, cod_hotel, cod_tipo_hab, fecha_desde)
AS
SELECT	h.cod_habitacion, h.nro_habitacion, h.piso, h.cod_hotel, h.cod_tipo_hab, e.checkout
		
FROM	THE_FOREIGN_FOUR.Habitaciones h,
		THE_FOREIGN_FOUR.Habitaciones_Estadia he,
		THE_FOREIGN_FOUR.Estadias e
WHERE	h.cod_habitacion = he.cod_habitacion
AND		he.cod_estadia = e.cod_estadia
GO

--***************************************************
CREATE FUNCTION THE_FOREIGN_FOUR.func_obtener_hab_disponibles (@fecha_desde datetime, @cod_tipo_hab numeric(18,0), @cod_hotel numeric(18,0))
RETURNS TABLE
AS
RETURN(
		SELECT  *
		FROM	THE_FOREIGN_FOUR.view_habitaciones_disp d
		WHERE	d.cod_tipo_hab = @cod_tipo_hab
		AND		d.cod_hotel = @cod_hotel
		AND		CAST(d.fecha_desde AS datetime) < @fecha_desde
)
GO
--****************************************************
CREATE VIEW THE_FOREIGN_FOUR.view_tipos_pago
AS
SELECT cod_tipo_pago, descripcion
FROM THE_FOREIGN_FOUR.TiposPago
GO
--****************************************************
CREATE PROCEDURE THE_FOREIGN_FOUR.proc_registrar_pago
					(@nro_factura numeric(18,0),
					 @cod_tipo_pago numeric(18,0),
					 @nro_tarjeta nvarchar(30))
AS
BEGIN
	
	IF(@cod_tipo_pago = 1)
	BEGIN
		INSERT INTO THE_FOREIGN_FOUR.Pagos (cod_tipo_pago, nro_tarjeta, nro_factura)
		VALUES (@cod_tipo_pago, 'Abonó al contado', @nro_factura)
	END
	ELSE
	BEGIN
		INSERT INTO THE_FOREIGN_FOUR.Pagos (cod_tipo_pago, nro_tarjeta, nro_factura)
		VALUES (@cod_tipo_pago, @nro_tarjeta, @nro_factura)
	END
	
	UPDATE	THE_FOREIGN_FOUR.Facturas
	SET		cod_pago = (SELECT cod_pago FROM THE_FOREIGN_FOUR.Pagos WHERE nro_factura = @nro_factura)
	WHERE	nro_factura = @nro_factura
	
END
GO
--*********************************************
CREATE PROCEDURE THE_FOREIGN_FOUR.proc_eliminar_habitacion_reservada
						(@cod_reserva numeric(18,0),
						 @cod_tipo_hab numeric(18,0),
						 @usuario nvarchar(255))
AS
BEGIN
	DELETE	THE_FOREIGN_FOUR.TipoHabitacion_Reservas
	WHERE	cod_reserva = @cod_reserva
	AND		cod_tipo_hab = cod_tipo_hab
	
	UPDATE	THE_FOREIGN_FOUR.Reservas
	SET		usuario = @usuario,		
			cod_estado_reserva = (SELECT cod_estado
								  FROM THE_FOREIGN_FOUR.EstadosReserva
								  WHERE descripcion = 'modificada')
	WHERE	cod_reserva = @cod_reserva
END
GO
--***********************************************************
/* LISTADO ESTADISTICO */



--TOP 5 HOTELES MAS CANCELACIONES
CREATE FUNCTION THE_FOREIGN_FOUR.func_estadistica_cancelaciones_hotel
					(@fecha_desde datetime,
					 @fecha_hasta datetime)
RETURNS TABLE
AS
	RETURN (SELECT TOP 5 ho.cod_hotel, COUNT(ca.cod_cancelacion) AS 'cancelaciones'
			FROM THE_FOREIGN_FOUR.Hoteles ho JOIN THE_FOREIGN_FOUR.Reservas res ON(ho.cod_hotel = res.cod_hotel)
											 JOIN THE_FOREIGN_FOUR.Cancelaciones ca ON(res.cod_reserva = ca.cod_reserva)
			WHERE ca.fecha_operacion BETWEEN @fecha_desde AND @fecha_hasta
			GROUP BY ho.cod_hotel
			ORDER BY 2 DESC)
GO
--TOP 5 HOTELES MAS CONSUMIBLES FACTURADOS
CREATE FUNCTION THE_FOREIGN_FOUR.func_estadistica_consumibles_hotel
					(@fecha_desde datetime,
					 @fecha_hasta datetime)
RETURNS TABLE
AS
	RETURN (SELECT TOP 5 ho.cod_hotel, SUM(cantidad) AS 'consumibles'
			FROM THE_FOREIGN_FOUR.Hoteles ho JOIN THE_FOREIGN_FOUR.Reservas res ON(ho.cod_hotel = res.cod_hotel)
											 JOIN THE_FOREIGN_FOUR.Estadias es ON(res.cod_reserva = es.cod_estadia)
											 JOIN THE_FOREIGN_FOUR.Facturas fa ON(es.cod_estadia = fa.cod_estadia)
											 JOIN THE_FOREIGN_FOUR.ItemsFactura itf ON(fa.nro_factura = itf.nro_factura)
			WHERE	cod_consumible > 1000
			AND		fa.fecha_factura BETWEEN @fecha_desde AND @fecha_hasta
			GROUP BY ho.cod_hotel
			ORDER BY 2 DESC)
GO
--TOP 5 HOTELES MAS INACTIVOS
CREATE FUNCTION THE_FOREIGN_FOUR.func_estadistica_inactividad_hotel
					(@fecha_desde datetime,
					 @fecha_hasta datetime)
RETURNS TABLE
AS
	RETURN (SELECT TOP 5 ho.cod_hotel, SUM(DATEDIFF(day, ih.fecha_desde, ih.fecha_hasta)) AS 'dias inactivos'
			FROM THE_FOREIGN_FOUR.Hoteles ho JOIN THE_FOREIGN_FOUR.InactividadHoteles ih ON(ho.cod_hotel = ih.cod_hotel)
			WHERE	ih.fecha_desde >= @fecha_desde
			AND		ih.fecha_hasta <= @fecha_hasta
			GROUP BY ho.cod_hotel
			ORDER BY 2 DESC)
GO
--TOP 5 HABITACIONES MAS ACTIVAS
CREATE FUNCTION THE_FOREIGN_FOUR.func_estadistica_ocupacion_habitacion
					(@fecha_desde datetime,
					 @fecha_hasta datetime)
RETURNS TABLE
AS
	RETURN (SELECT	TOP 5 ha.cod_habitacion, ha.cod_hotel, ha.nro_habitacion, COUNT(he.cod_estadia) 'veces ocupada', SUM(e.cant_noches) 'noches ocupada'
			FROM	THE_FOREIGN_FOUR.Habitaciones ha JOIN THE_FOREIGN_FOUR.Habitaciones_Estadia he ON(ha.cod_habitacion = he.cod_habitacion)
													 JOIN THE_FOREIGN_FOUR.Estadias e ON(he.cod_estadia = e.cod_estadia)
			WHERE	e.fecha_inicio BETWEEN @fecha_desde AND @fecha_hasta
			OR		e.checkout BETWEEN @fecha_desde AND @fecha_hasta
			GROUP BY ha.cod_habitacion, ha.cod_hotel, ha.nro_habitacion
			ORDER BY 4 DESC, 5 DESC)
GO

--**************************************************************
CREATE FUNCTION THE_FOREIGN_FOUR.func_obtener_monto_consumibles
					(@nro_factura numeric(18,0))
RETURNS int
AS
BEGIN
	RETURN (SELECT SUM(total_factura)
			FROM THE_FOREIGN_FOUR.facturacion (@nro_factura)
			WHERE	cod_consumible > 2000)
END
GO

--TOP 5 CLIENTES
CREATE FUNCTION THE_FOREIGN_FOUR.func_estadistica_puntaje_cliente
					(@fecha_desde datetime,
					 @fecha_hasta datetime)
RETURNS TABLE
AS
	RETURN (SELECT TOP 5 c.cod_cliente, c.nombre, c.apellido, c.mail, c.tipo_doc, c.nro_doc, CAST((THE_FOREIGN_FOUR.func_obtener_monto_consumibles (f.nro_factura) / 5) + (THE_FOREIGN_FOUR.calcular_precio_estadia (e.cod_estadia) / 10) AS int) AS 'puntaje'
			FROM THE_FOREIGN_FOUR.Clientes c JOIN THE_FOREIGN_FOUR.Reservas r ON(c.cod_cliente = r.cod_cliente)
											 JOIN THE_FOREIGN_FOUR.Estadias e ON(r.cod_reserva = e.cod_reserva)
											 JOIN THE_FOREIGN_FOUR.Facturas f ON(e.cod_estadia = f.cod_estadia)
											 JOIN THE_FOREIGN_FOUR.ItemsFactura i ON(f.nro_factura = i.nro_factura)
			WHERE f.fecha_factura BETWEEN @fecha_desde AND @fecha_hasta
			GROUP BY c.cod_cliente, c.nombre, c.apellido, c.mail, c.tipo_doc, c.nro_doc, f.nro_factura, e.cod_estadia
			ORDER BY 7 DESC)
GO

--***CLIENTES********************************

INSERT INTO THE_FOREIGN_FOUR.Clientes (nombre, apellido, fecha_nac, nom_calle, nro_calle, piso, depto, nacionalidad, nro_doc, mail)
SELECT DISTINCT Cliente_Nombre, Cliente_Apellido, Cliente_Fecha_Nac, Cliente_Dom_Calle, Cliente_Nro_Calle, Cliente_Piso, Cliente_Depto, Cliente_Nacionalidad, Cliente_Pasaporte_Nro, Cliente_Mail
FROM gd_esquema.Maestra

--***HOTELES***********************************
INSERT INTO THE_FOREIGN_FOUR.Hoteles (nom_calle, ciudad, nro_calle, cant_estrellas, recarga_estrellas, nombre)
SELECT DISTINCT Hotel_Calle, Hotel_Ciudad, Hotel_Nro_Calle, 
				Hotel_CantEstrella, Hotel_Recarga_Estrella, (Hotel_Calle + ' ' + CAST(Hotel_Nro_Calle AS nvarchar(10)))
FROM gd_esquema.Maestra

--***REGIMENES********************************

INSERT INTO THE_FOREIGN_FOUR.Regimenes (descripcion, precio)
SELECT DISTINCT Regimen_Descripcion, Regimen_Precio
FROM gd_esquema.Maestra

--***TIPO HABITACIONES***************************

INSERT INTO THE_FOREIGN_FOUR.TipoHabitaciones (cod_tipo_hab, descripcion, recargo)
SELECT DISTINCT Habitacion_Tipo_Codigo, Habitacion_Tipo_Descripcion, Habitacion_Tipo_Porcentual
FROM gd_esquema.Maestra

--***CONSUMIBLES**************************************

INSERT INTO THE_FOREIGN_FOUR.Consumibles (cod_consumible, descripcion, precio)
SELECT DISTINCT Consumible_Codigo, Consumible_Descripcion, Consumible_Precio
FROM gd_esquema.Maestra
WHERE Consumible_Codigo IS NOT NULL
AND Consumible_Descripcion IS NOT NULL

--***HABITACIONES**************************************

INSERT INTO THE_FOREIGN_FOUR.Habitaciones (piso, ubicacion, cod_tipo_hab, nro_habitacion, cod_hotel)
SELECT DISTINCT Habitacion_Piso,
				Habitacion_Frente, 
				Habitacion_Tipo_Codigo, 
				Habitacion_Numero, 
			   (SELECT cod_hotel
			    FROM THE_FOREIGN_FOUR.Hoteles ho
			    WHERE	ho.ciudad = m.Hotel_Ciudad
			    AND		ho.nom_calle = m.Hotel_Calle
			    AND		ho.nro_calle = m.Hotel_Nro_Calle
			    AND		ho.cant_estrellas = m.Hotel_CantEstrella
			    AND		ho.recarga_estrellas = m.Hotel_Recarga_Estrella) AS 'cod_hotel'
FROM gd_esquema.Maestra m

--***RESERVAS***************************************

INSERT INTO THE_FOREIGN_FOUR.Reservas	(cod_reserva, fecha_desde, cant_noches, cod_hotel, cod_cliente, cod_regimen, fecha_hasta)
SELECT	DISTINCT m.Reserva_Codigo,
		m.Reserva_Fecha_Inicio,
		m.Reserva_Cant_Noches,
		
	   (SELECT cod_hotel
		FROM THE_FOREIGN_FOUR.Hoteles h
		WHERE	h.nom_calle = m.Hotel_Calle
		AND		h.nro_calle = m.Hotel_Nro_Calle
		AND		h.ciudad = m.Hotel_Ciudad
		AND		h.cant_estrellas = m.Hotel_CantEstrella
		AND		h.recarga_estrellas = m.Hotel_Recarga_Estrella) AS 'cod_hotel',
		
       (SELECT cod_cliente
		FROM THE_FOREIGN_FOUR.Clientes c
		WHERE	c.nro_doc = m.Cliente_Pasaporte_Nro
		AND		c.mail = m.Cliente_Mail),
		
		(SELECT cod_regimen
		FROM THE_FOREIGN_FOUR.Regimenes r
		WHERE r.descripcion = m.Regimen_Descripcion
		AND r.precio = m.Regimen_Precio) AS 'cod_regimen',
		
		--hay que hacer una funcion o procedure para establecer el codigo de estado de reserva
		
		(m.Reserva_Fecha_Inicio + m.Reserva_Cant_Noches) AS 'fecha_hasta'
FROM gd_esquema.Maestra m

--***ESTADIAS***************************************
--no hace falta validar todos los datos de la reserva mas que el codigo, ni el tipo porque ya esta implicito en el cod_reserva
--Tampoco hace falta la validacion de los datos del hotel ya que tambien se encuentran implicitos en la reserva

INSERT INTO THE_FOREIGN_FOUR.Estadias (fecha_inicio, cant_noches, cod_reserva)
SELECT DISTINCT  m.Estadia_Fecha_Inicio,
				 m.Estadia_Cant_Noches,
				 (SELECT cod_reserva
				 FROM THE_FOREIGN_FOUR.Reservas r
				 WHERE	r.cod_reserva = m.Reserva_Codigo) AS 'cod_reserva'
FROM gd_esquema.Maestra m


--***FACTURAS***************************************

INSERT INTO THE_FOREIGN_FOUR.Facturas (nro_factura, fecha_factura, total, cod_estadia)
SELECT DISTINCT	m.Factura_Nro,
				m.Factura_Fecha,
				m.Factura_Total,
				(SELECT cod_estadia
				FROM THE_FOREIGN_FOUR.Estadias e
				WHERE	e.cod_reserva = m.Reserva_Codigo)
FROM gd_esquema.Maestra m

--***ITEMS FACTURAS***************************************
INSERT INTO THE_FOREIGN_FOUR.ItemsFactura (cantidad, cod_consumible, nro_factura)
SELECT m.Item_Factura_Cantidad, 
	   m.Consumible_Codigo,
	   (SELECT nro_factura
		FROM THE_FOREIGN_FOUR.Facturas f
		WHERE	m.Factura_Nro = f.nro_factura)
FROM gd_esquema.Maestra m


--***CLIENTES POR ESTADIA***************************************

INSERT INTO THE_FOREIGN_FOUR.ClientePorEstadia (cod_cliente, cod_estadia)
SELECT DISTINCT (SELECT c.cod_cliente
				 FROM THE_FOREIGN_FOUR.Clientes c
				 WHERE	c.nro_doc = m.Cliente_Pasaporte_Nro
				 AND	c.mail = m.Cliente_Mail),
				(SELECT e.cod_estadia
				 FROM THE_FOREIGN_FOUR.Estadias e
				 WHERE	e.fecha_inicio = m.Estadia_Fecha_Inicio
				 AND	e.cant_noches = m.Estadia_Cant_Noches
				 AND	e.cod_reserva = m.Reserva_Codigo)
FROM gd_esquema.Maestra m

--***TIPOHABITACION POR RESERVAS********************************

INSERT INTO THE_FOREIGN_FOUR.TipoHabitacion_Reservas (cod_reserva, cod_tipo_hab)
SELECT DISTINCT (SELECT cod_reserva
	    FROM THE_FOREIGN_FOUR.Reservas r
	    WHERE r.cod_reserva = m.Reserva_Codigo) AS 'CODIGO_RESERVA',
	   (SELECT cod_tipo_hab
	    FROM THE_FOREIGN_FOUR.TipoHabitaciones th
	    WHERE	th.cod_tipo_hab = m.Habitacion_Tipo_Codigo) AS 'CODIGO_TIPO_HAB'

FROM gd_esquema.Maestra m
 --***HABITACIONES POR ESTADIA**********************************
 
INSERT INTO THE_FOREIGN_FOUR.Habitaciones_Estadia (cod_estadia, cod_habitacion)
SELECT DISTINCT (SELECT cod_estadia	
				 FROM THE_FOREIGN_FOUR.Estadias e
				 WHERE e.cod_reserva = m.Reserva_Codigo) AS 'COD_ESTADIA',
				(SELECT cod_habitacion
				 FROM THE_FOREIGN_FOUR.Habitaciones h
				 WHERE	h.nro_habitacion = m.Habitacion_Numero
				 AND	h.cod_hotel = (SELECT cod_hotel
									  FROM THE_FOREIGN_FOUR.Hoteles ho
									  WHERE ho.ciudad = m.Hotel_Ciudad
									  AND	ho.nom_calle = m.Hotel_Calle
									  AND	ho.nro_calle = m.Hotel_Nro_Calle)) AS 'COD_HABITACION'
FROM gd_esquema.Maestra m

--** CHECKOUT MIGRACION ESTADIAS ******************************
EXEC THE_FOREIGN_FOUR.proc_checkout_migracion

--** JUEGO DE DATOS********************************************
EXEC THE_FOREIGN_FOUR.proc_juego_datos

--** ELIMINACION DE LOS TRIGGERS*******************************
DROP TRIGGER THE_FOREIGN_FOUR.trg_clientes_error
DROP TRIGGER THE_FOREIGN_FOUR.trg_reservas_error
DROP TRIGGER THE_FOREIGN_FOUR.trg_estadias_error
DROP TRIGGER THE_FOREIGN_FOUR.trg_facturas_error
DROP TRIGGER THE_FOREIGN_FOUR.trg_clientes_por_estadia_err
DROP TRIGGER THE_FOREIGN_FOUR.trg_itemsFactura_error
DROP TRIGGER THE_FOREIGN_FOUR.trg_habitaciones_estadia
DROP TRIGGER THE_FOREIGN_FOUR.trg_tipohab_reservas
--** ELIMINACION PROCEDURES MIGRACION**************************
DROP PROCEDURE THE_FOREIGN_FOUR.proc_juego_datos
DROP PROCEDURE THE_FOREIGN_FOUR.proc_checkout_migracion



