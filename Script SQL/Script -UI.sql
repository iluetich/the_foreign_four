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
	INSERT INTO THE_FOREIGN_FOUR.Estadias (cod_reserva, fecha_inicio)
	VALUES	(@cod_reserva, CAST(GETDATE() AS DATETIME))
	
	INSERT INTO THE_FOREIGN_FOUR.AuditoriaEstadias (cod_usuario, cod_estadia, cod_operacion)
	VALUES ((SELECT THE_FOREIGN_FOUR.func_obtener_cod_usuario(@usuario)), (SELECT cod_estadia FROM THE_FOREIGN_FOUR.Estadias WHERE cod_reserva = @cod_reserva), 'I')
	
	UPDATE THE_FOREIGN_FOUR.Reservas
	SET cod_estado_reserva  = (SELECT cod_estado_reserva
								FROM THE_FOREIGN_FOUR.EstadosReserva
								WHERE descripcion = 'efectivizada')
	WHERE cod_reserva = @cod_reserva
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
		cod_regimen = @cod_regimen,
		usuario = (SELECT THE_FOREIGN_FOUR.func_obtener_cod_usuario(@usuario)),
		cod_estado_reserva = (SELECT cod_estado
							  FROM THE_FOREIGN_FOUR.EstadosReserva
							  WHERE descripcion = 'modificada')
	WHERE @cod_reserva = cod_reserva
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
				 @fecha_creacion datetime,
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
	VALUES (@cod_reserva_generada, @cod_hotel, @cod_cliente, @cod_estado_reserva, @cod_regimen, @fecha_desde, @fecha_hasta, @fecha_creacion, CONVERT(int, @fecha_hasta - @fecha_desde), (SELECT THE_FOREIGN_FOUR.func_obtener_cod_usuario(@usuario)))
	
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
				   WHERE @fecha_inicio BETWEEN fecha_desde AND fecha_hasta
				   OR	 @fecha_fin BETWEEN fecha_desde AND fecha_hasta))
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
			@cant_hab_disponibles int

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
									AND		(@fecha_inicio BETWEEN r.fecha_desde AND R.fecha_hasta
									OR		@fecha_fin BETWEEN r.fecha_desde AND r.fecha_hasta))
									
	SET		@cant_hab_disponibles = @cant_hab_por_tipo - @cant_hab_reservadas
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
				@password nvarchar(30))
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
				@mail nvarchar(255) )
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
	VALUES	('admin', 'w23e','Administrador General')
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
	UPDATE THE_FOREIGN_FOUR.Hoteles 
	SET nombre = 'Conrad'
	WHERE cod_hotel = 1;

	UPDATE THE_FOREIGN_FOUR.Hoteles 
	SET nombre = 'Hilton'
	WHERE cod_hotel = 2;

	UPDATE THE_FOREIGN_FOUR.Hoteles 
	SET nombre = 'Sheraton'
	WHERE cod_hotel = 3;

	UPDATE THE_FOREIGN_FOUR.Hoteles 
	SET nombre = 'Palacio Duhau'
	WHERE cod_hotel = 4;

	UPDATE THE_FOREIGN_FOUR.Hoteles 
	SET nombre = 'Melia'
	WHERE cod_hotel = 5;

	UPDATE THE_FOREIGN_FOUR.Hoteles 
	SET nombre = 'Madero'
	WHERE cod_hotel = 6;
	
	UPDATE THE_FOREIGN_FOUR.Hoteles 
	SET nombre = 'Alvear Palace'
	WHERE cod_hotel = 7;

	UPDATE THE_FOREIGN_FOUR.Hoteles 
	SET nombre = 'Intercontinental'
	WHERE cod_hotel = 8;

	UPDATE THE_FOREIGN_FOUR.Hoteles 
	SET nombre = 'Emeperador'
	WHERE cod_hotel = 9;

	UPDATE THE_FOREIGN_FOUR.Hoteles 
	SET nombre = 'BA Grand Hotel'
	WHERE cod_hotel = 10;

	UPDATE THE_FOREIGN_FOUR.Hoteles 
	SET nombre = 'Four Seasons'
	WHERE cod_hotel = 11;

	UPDATE THE_FOREIGN_FOUR.Hoteles 
	SET nombre = 'Faena'
	WHERE cod_hotel = 12;

	UPDATE THE_FOREIGN_FOUR.Hoteles 
	SET nombre = 'Regal Pacific'
	WHERE cod_hotel = 13;
	
	UPDATE THE_FOREIGN_FOUR.Hoteles 
	SET nombre = 'Hotel Club Frances'
	WHERE cod_hotel = 14;
	
	UPDATE THE_FOREIGN_FOUR.Hoteles 
	SET nombre = 'Caesar Park'
	WHERE cod_hotel = 15;
	
	UPDATE THE_FOREIGN_FOUR.Hoteles 
	SET nombre = 'Claridge'
	WHERE cod_hotel = 16;
	
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

--******************************************************
CREATE VIEW THE_FOREIGN_FOUR.view_facturas
AS
SELECT f.nro_factura, f.cod_estadia, i.nro_item, c.cod_consumible, c.descripcion, c.precio, i.cantidad, f.total
FROM	THE_FOREIGN_FOUR.Facturas f, 
		THE_FOREIGN_FOUR.ItemsFactura i,
		THE_FOREIGN_FOUR.Consumibles c
WHERE f.nro_factura = i.nro_factura
AND c.cod_consumible = i.cod_consumible
GO


--***********************************************************
CREATE FUNCTION THE_FOREIGN_FOUR.facturacion(@cod_estadia int)
RETURNS TABLE
AS
RETURN(
SELECT *
FROM THE_FOREIGN_FOUR.view_facturas
WHERE cod_estadia = @cod_estadia
)
GO

--**************************************************************

CREATE FUNCTION THE_FOREIGN_FOUR.func_calcular_precio (@cod_regimen		numeric(18,0),
														@cod_hotel		numeric(18,0),
														@cod_tipo_hab	numeric(18,0),
														@cant_noches		int)
RETURNS numeric(18,2)
AS
BEGIN
RETURN(

	SELECT DISTINCT	( ((r.precio* th.capacidad) + (h.cant_estrellas * h.recarga_estrellas))*@cant_noches)
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

--**********************************************************
/*
El valor de la habitación se obtiene a través de su precio base 
(ver abm de régimen) multiplicando la cantidad de personas que se 
alojarán en la habitación (tipo de habitación) y luego de ello aplicando 
un incremento en función de la categoría del Hotel (cantidad de estrellas)
*/

CREATE FUNCTION THE_FOREIGN_FOUR.calcular_precio_hab_estadia(@cod_hab_estadia numeric(18,0))
RETURNS numeric(18,2)
AS
BEGIN

DECLARE @cod_regimen numeric(18,0),
		@cod_hotel	numeric(18,0),
		@cod_tipo_hab numeric(18,0),
		@cant_noches numeric(18,0)

	SET @cod_regimen = (SELECT DISTINCT res.cod_regimen
						FROM	THE_FOREIGN_FOUR.Habitaciones_Estadia he,
								THE_FOREIGN_FOUR.Reservas res,
								THE_FOREIGN_FOUR.Estadias e
						WHERE he.cod_estadia = e.cod_estadia
						AND	he.cod_hab_estadia = @cod_hab_estadia
						AND e.cod_reserva = res.cod_reserva)
	
	SET @cant_noches = (SELECT	res.cant_noches
						FROM	THE_FOREIGN_FOUR.Reservas res,
								THE_FOREIGN_FOUR.Estadias e,
								THE_FOREIGN_FOUR.Habitaciones_Estadia he
						WHERE	he.cod_estadia = e.cod_estadia
						AND		he.cod_hab_estadia = @cod_hab_estadia
						AND		e.cod_reserva = res.cod_reserva)
						
	SET @cod_hotel = (SELECT	res.cod_hotel
						FROM	THE_FOREIGN_FOUR.Reservas res,
								THE_FOREIGN_FOUR.Estadias e,
								THE_FOREIGN_FOUR.Habitaciones_Estadia he
						WHERE	he.cod_estadia = e.cod_estadia
						AND		he.cod_hab_estadia = @cod_hab_estadia
						AND		e.cod_reserva = res.cod_reserva)
						
	SET @cod_tipo_hab = (SELECT	ha.cod_tipo_hab
							FROM	THE_FOREIGN_FOUR.Estadias e,
									THE_FOREIGN_FOUR.Habitaciones_Estadia he,
									THE_FOREIGN_FOUR.Habitaciones ha
							WHERE	he.cod_estadia = e.cod_estadia
							AND		he.cod_hab_estadia = @cod_hab_estadia
							AND		ha.cod_habitacion = he.cod_habitacion)
						
						
						
	RETURN(	SELECT THE_FOREIGN_FOUR.func_calcular_precio (@cod_regimen, @cod_hotel, @cod_tipo_hab, @cant_noches )
)
END
GO



--****************************************************************
CREATE PROCEDURE THE_FOREIGN_FOUR.proc_actualizar_total_factura @nro_factura numeric(18,0)
AS
BEGIN
	
	DECLARE @cod_hab_estadia numeric(18,0)
	SET @cod_hab_estadia = (SELECT he.cod_hab_estadia
							FROM	THE_FOREIGN_FOUR.Facturas f,
									THE_FOREIGN_FOUR.Habitaciones_Estadia he
							WHERE f.cod_estadia = he.cod_estadia)

	UPDATE THE_FOREIGN_FOUR.Facturas
	SET total = (SELECT (SUM(c.precio * i.cantidad) + THE_FOREIGN_FOUR.calcular_precio_hab_estadia(@cod_hab_estadia))
				FROM THE_FOREIGN_FOUR.Consumibles c, THE_FOREIGN_FOUR.ItemsFactura i, THE_FOREIGN_FOUR.Facturas f
				WHERE c.cod_consumible = i.cod_consumible
				AND f.nro_factura = i.nro_factura
				AND i.nro_factura = @nro_factura
				GROUP BY f.cod_estadia)
	WHERE nro_factura = @nro_factura
END
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
	
	EXECUTE THE_FOREIGN_FOUR.proc_actualizar_total_factura @nro_factura
	
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
/*CREATE FUNCTION THE_FOREIGN_FOUR.fecha_sys() --ya no se usa, porque se usa directamente una variable en el trigger de reservas
RETURNS datetime
AS
BEGIN
RETURN (SELECT MAX(fecha_inicio + cant_noches)
		FROM THE_FOREIGN_FOUR.Estadias)
END	
GO*/

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
	
	EXECUTE THE_FOREIGN_FOUR.proc_realizar_checkout @cod_estadia, @username 
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