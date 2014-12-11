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
	SET @fecha_inicio = CAST(THE_FOREIGN_FOUR.func_get_fecha_sistema() AS DATETIME)
	
	INSERT INTO THE_FOREIGN_FOUR.Estadias (cod_reserva, fecha_inicio)
	VALUES	(@cod_reserva, @fecha_inicio)
	
	INSERT INTO THE_FOREIGN_FOUR.AuditoriaEstadias (cod_usuario, cod_estadia, cod_operacion)
	VALUES ((SELECT THE_FOREIGN_FOUR.func_obtener_cod_usuario(@usuario)), (SELECT cod_estadia FROM THE_FOREIGN_FOUR.Estadias WHERE cod_reserva = @cod_reserva), 'I')
	
	UPDATE THE_FOREIGN_FOUR.Reservas
	SET cod_estado_reserva  = (SELECT cod_estado
								FROM THE_FOREIGN_FOUR.EstadosReserva
								WHERE descripcion = 'efectivizada')
	WHERE cod_reserva = @cod_reserva
	
	DECLARE		@cod_estadia numeric(18,0),
				@cod_hotel numeric(18,0),
				@cant_noches numeric(18,0),
				@cod_habitacion_a_ocupar numeric(18,0)
				
	SET @cod_estadia = (SELECT cod_estadia
						FROM THE_FOREIGN_FOUR.Estadias
						WHERE cod_reserva = @cod_reserva)
	SET @cod_hotel = (SELECT cod_hotel
					 FROM THE_FOREIGN_FOUR.Reservas
					 WHERE cod_reserva = @cod_reserva)
	SET @cant_noches = (SELECT	cant_noches
						FROM THE_FOREIGN_FOUR.Reservas	
						WHERE cod_reserva = @cod_reserva)
	
	SELECT	cod_tipo_hab
	INTO THE_FOREIGN_FOUR.#TipoHabReserva
	FROM THE_FOREIGN_FOUR.TipoHabitacion_Reservas
	WHERE cod_reserva = @cod_reserva

	--**cursor********
	DECLARE CursorHabitaciones CURSOR FOR
	SELECT cod_tipo_hab
	FROM THE_FOREIGN_FOUR.#TipoHabReserva
	DECLARE @cod_tipo_hab numeric(18,0)
	OPEN CursorHabitaciones;
	FETCH NEXT FROM CursorHabitaciones INTO @cod_tipo_hab
	
	WHILE @@FETCH_STATUS = 0
	BEGIN
		SET @cod_habitacion_a_ocupar = (SELECT cod_habitacion 
										FROM THE_FOREIGN_FOUR.Habitaciones h
										WHERE	h.cod_hotel = @cod_hotel
										AND		h.nro_habitacion = (SELECT TOP 1 *
																	FROM THE_FOREIGN_FOUR.func_obtener_hab_disponibles(@fecha_inicio, @cod_tipo_hab, @cod_hotel, @cant_noches)))
		
		IF (@cod_habitacion_a_ocupar IS NULL) 
		BEGIN
			RAISERROR(13000, -1, -1)
		END	
		
		INSERT INTO THE_FOREIGN_FOUR.Habitaciones_Estadia (cod_estadia, cod_habitacion)
		VALUES (@cod_estadia, @cod_habitacion_a_ocupar)
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
CREATE FUNCTION THE_FOREIGN_FOUR.func_validar_reserva_no_cancelada_user 
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
	
	
	IF( (@codigo = 1) AND (@estadoReserva = 1 OR @estadoReserva = 2 OR @estadoReserva = 6))
	BEGIN
		RETURN 1
	END
	RETURN -1
END
GO
--**********************************************************
CREATE FUNCTION THE_FOREIGN_FOUR.func_validar_reserva_no_cancelada_guest
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
	
	IF( (@codigo = 1) AND (@estadoReserva = 1 OR @estadoReserva = 2 OR @estadoReserva = 6))
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
		cod_estado_reserva = (SELECT cod_estado
							  FROM THE_FOREIGN_FOUR.EstadosReserva
							  WHERE descripcion = 'modificada')
	WHERE @cod_reserva = cod_reserva
	
	INSERT INTO THE_FOREIGN_FOUR.AuditoriaReservas(cod_reserva, cod_usuario, cod_operacion)
	VALUES (@cod_reserva, (SELECT THE_FOREIGN_FOUR.func_obtener_cod_usuario(@usuario)), 'M')
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
	VALUES (@cod_reserva, @motivo, (SELECT THE_FOREIGN_FOUR.func_obtener_cod_usuario(@usuario)), THE_FOREIGN_FOUR.func_get_fecha_sistema())
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
	
	INSERT INTO THE_FOREIGN_FOUR.Reservas (cod_reserva, cod_hotel, cod_cliente, cod_estado_reserva, cod_regimen, fecha_desde, fecha_hasta, fecha_creacion, cant_noches)
	VALUES (@cod_reserva_generada, @cod_hotel, @cod_cliente, @cod_estado_reserva, @cod_regimen, @fecha_desde, @fecha_hasta, CAST(THE_FOREIGN_FOUR.func_get_fecha_sistema() AS DATETIME), CONVERT(int, @fecha_hasta - @fecha_desde))
	
	INSERT INTO THE_FOREIGN_FOUR.AuditoriaReservas (cod_reserva, cod_usuario, cod_operacion)
	VALUES (@cod_reserva_generada, (SELECT THE_FOREIGN_FOUR.func_obtener_cod_usuario(@usuario)), 'G')
	
	RETURN @cod_reserva_generada
END
GO
--***********************************************************
CREATE FUNCTION THE_FOREIGN_FOUR.func_validar_fecha_reserva
				(@cod_hotel numeric(18,0),
				 @fecha_desde datetime)
RETURNS int
AS
BEGIN
	IF ((SELECT fecha_creacion FROM THE_FOREIGN_FOUR.Hoteles WHERE cod_hotel = @cod_hotel) > @fecha_desde OR
		THE_FOREIGN_FOUR.func_get_fecha_sistema() > @fecha_desde)
	BEGIN
		RETURN -1
	END
	RETURN 1
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
	IF(EXISTS (SELECT cod_reserva
				   FROM	THE_FOREIGN_FOUR.Reservas
				   WHERE	cod_hotel = @cod_hotel
				   AND		(fecha_desde BETWEEN @fecha_inicio AND @fecha_fin
				   OR		 fecha_hasta BETWEEN @fecha_inicio AND @fecha_fin)))
	BEGIN 
		RETURN -1
	END
	IF(@fecha_inicio < (SELECT fecha_creacion
						FROM THE_FOREIGN_FOUR.Hoteles
						WHERE cod_hotel = @cod_hotel))
	BEGIN
		RETURN 0
	END
	RETURN 1
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
								  AND		@cod_tipo_hab = ha.cod_tipo_hab
								  AND		ha.estado = 'H') 
								  
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
				(@user_name nvarchar(30))
RETURNS TABLE  
AS
RETURN(
	SELECT h.cod_hotel, h.nombre, h.nom_calle, h.nro_calle
	FROM THE_FOREIGN_FOUR.Usuarios u, THE_FOREIGN_FOUR.Hoteles h, THE_FOREIGN_FOUR.UsuariosPorHotel uh
	WHERE	u.cod_usuario = uh.cod_usuario
	AND		h.cod_hotel = uh.cod_hotel
	AND		u.user_name = @user_name
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
	AND	  u.estado = 'H'
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
			nom_calle, nro_calle, nacionalidad, pais_origen, estado, piso, depto
	FROM THE_FOREIGN_FOUR.Clientes
	WHERE nombre LIKE 
		(CASE WHEN @nombre IS NULL  THEN '%' ELSE @nombre +'%' END)
	AND apellido LIKE
		(CASE WHEN @apellido IS NULL THEN '%' ELSE @apellido +'%' END)
	AND tipo_doc LIKE 
		(CASE WHEN @tipo_doc IS NULL THEN '%' ELSE  @tipo_doc +'%' END)
	AND CAST(nro_doc AS nvarchar(10)) LIKE 
		(CASE WHEN @nro_doc IS NULL THEN '%' ELSE CAST(@nro_doc AS nvarchar(10))+'%' END)
	AND mail LIKE 
		(CASE WHEN @mail IS NULL THEN '%' ELSE @mail+'%' END)
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
			   WHERE ((nro_doc = @nro_doc
			   AND	 tipo_doc = @tipo_doc)
			   OR	 mail = @mail)
			   AND	 estado = 'I'))
	BEGIN
		RETURN 0 --el cliente existe y esta inhabilidato
	END
	ELSE
	IF(EXISTS (SELECT cod_cliente
			   FROM THE_FOREIGN_FOUR.Clientes
			   WHERE (nro_doc = @nro_doc
			   AND	 tipo_doc = @tipo_doc)
			   OR	 mail = @mail))
	BEGIN
		RETURN -1 --el cliente existe
	END
	RETURN 1 --el cliente no existe
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
	
	CREATE TABLE THE_FOREIGN_FOUR.VarGlobal (
	fecha_sistema		datetime				NOT NULL
	)

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
	
	
	DECLARE CursorTotalItem CURSOR FOR
	SELECT THE_FOREIGN_FOUR.func_get_precio(c.cod_consumible, @cod_estadia), c.cod_consumible
	FROM THE_FOREIGN_FOUR.Consumibles c, THE_FOREIGN_FOUR.ItemsFactura i
	WHERE c.cod_consumible = i.cod_consumible
	AND i.nro_factura = @nro_factura
	
	DECLARE @precioItem int,
			@cod_consumible numeric(18,0)
	
	OPEN CursorTotalItem;
	
	FETCH NEXT FROM CursorTotalItem INTO @precioItem, @cod_consumible
	WHILE @@FETCH_STATUS = 0
	BEGIN
		UPDATE THE_FOREIGN_FOUR.ItemsFactura
		SET total_item = @precioItem
		WHERE nro_factura = @nro_factura
		AND cod_consumible = @cod_consumible
		FETCH NEXT FROM CursorTotalItem INTO @precioItem, @cod_consumible
	END 
	 
	CLOSE CursorTotalItem;
	DEALLOCATE CursorTotalItem;
	
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
	SET @fecha_check_out = (SELECT checkout
							FROM THE_FOREIGN_FOUR.Estadias
							WHERE cod_estadia = (SELECT cod_estadia
												FROM THE_FOREIGN_FOUR.Facturas
												WHERE nro_factura = @nro_factura))
	
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
				 @nro_factura numeric(18,0) OUTPUT,
				 @cod_cliente numeric(18,0))
AS
BEGIN
	SET @nro_factura = (SELECT THE_FOREIGN_FOUR.func_sgte_nro_factura ())
	INSERT INTO THE_FOREIGN_FOUR.Facturas (nro_factura, cod_estadia, cod_cliente, fecha_factura) 
	VALUES (@nro_factura , @cod_estadia, @cod_cliente, CAST(THE_FOREIGN_FOUR.func_get_fecha_sistema() AS DATETIME))
	RETURN 
END
GO

--******************************************************
CREATE VIEW THE_FOREIGN_FOUR.view_facturas
(nro_factura, cod_estadia, cod_consumible, descripcion, precio_unitario, cantidad, subtotal, total_factura)
AS

SELECT f.nro_factura, f.cod_estadia, c.cod_consumible, c.descripcion, 
		(SELECT THE_FOREIGN_FOUR.func_get_precio(c.cod_consumible, f.cod_estadia)),
		 i.cantidad, (SELECT THE_FOREIGN_FOUR.func_get_precio(c.cod_consumible, f.cod_estadia))*i.cantidad, f.total
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
	SET checkout = THE_FOREIGN_FOUR.func_get_fecha_sistema()
	WHERE cod_estadia = @cod_estadia

END
GO

--**********************************************
CREATE FUNCTION THE_FOREIGN_FOUR.func_check_out(@cod_estadia numeric(18,0),
												@username nvarchar(30))
RETURNS int
AS
BEGIN
	
	IF (NOT EXISTS(SELECT cod_estadia
				   FROM THE_FOREIGN_FOUR.Estadias
			   	   WHERE cod_estadia = @cod_estadia))
	BEGIN
		RETURN -1
	END
	IF ((SELECT checkout
		FROM THE_FOREIGN_FOUR.Estadias
		WHERE cod_estadia = @cod_estadia) IS NOT NULL)
	BEGIN
		RETURN 0
	END
	
	RETURN 1
END
GO	

--*******************************************************************
CREATE FUNCTION THE_FOREIGN_FOUR.func_clientes_estadia (@cod_estadia numeric(18,0))
RETURNS TABLE
AS
RETURN(
	SELECT ce.cod_cliente, c.nombre, c.apellido
	FROM THE_FOREIGN_FOUR.ClientePorEstadia ce, THE_FOREIGN_FOUR.Clientes c 
	WHERE ce.cod_cliente = c.cod_cliente
	AND ce.cod_estadia = @cod_estadia)
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
			@cant_noches int,
			@puede_check_in int
			
	SET		@validacion_reserva = THE_FOREIGN_FOUR.func_validar_reserva_no_cancelada_user (@cod_reserva, @cod_hotel)
	SET		@fecha_inicio_reserva = (SELECT fecha_desde FROM THE_FOREIGN_FOUR.Reservas WHERE cod_reserva = @cod_reserva)
	SET		@cant_noches = (SELECT cant_noches FROM THE_FOREIGN_FOUR.Reservas WHERE cod_reserva = @cod_reserva)
	SET		@validacion_fechas = THE_FOREIGN_FOUR.func_igual_fecha(@fecha_inicio_reserva, THE_FOREIGN_FOUR.func_get_fecha_sistema())
	
	
	IF	((@validacion_reserva = 1) AND
		 (@validacion_fechas = 1))
	BEGIN
		SELECT	cod_tipo_hab
		INTO THE_FOREIGN_FOUR.#TipoHabReserva
		FROM THE_FOREIGN_FOUR.TipoHabitacion_Reservas
		WHERE cod_reserva = @cod_reserva
	
		DECLARE CursorHabitaciones CURSOR FOR
		SELECT cod_tipo_hab
		FROM THE_FOREIGN_FOUR.#TipoHabReserva
		DECLARE @cod_tipo_hab numeric(18,0)
		OPEN CursorHabitaciones;
		FETCH NEXT FROM CursorHabitaciones INTO @cod_tipo_hab

		WHILE @@FETCH_STATUS = 0
		BEGIN
		
			IF (NOT EXISTS(SELECT cod_habitacion 
							FROM THE_FOREIGN_FOUR.Habitaciones h
							WHERE	h.cod_hotel = @cod_hotel
							AND		h.nro_habitacion = (SELECT TOP 1 *
														FROM THE_FOREIGN_FOUR.func_obtener_hab_disponibles(@fecha_inicio_reserva, @cod_tipo_hab, @cod_hotel, @cant_noches)))) 
			BEGIN
				CLOSE CursorHabitaciones;
				DEALLOCATE CursorHabitaciones;
				DROP TABLE THE_FOREIGN_FOUR.#TipoHabReserva
				RETURN -2 -- no hay habitaciones habilitadas disponibles
			END	

			FETCH NEXT FROM CursorHabitaciones INTO @cod_tipo_hab
		END
		CLOSE CursorHabitaciones;
		DEALLOCATE CursorHabitaciones;
		--**cursor********
	
		DROP TABLE THE_FOREIGN_FOUR.#TipoHabReserva
		
		
		RETURN 1 -- las fechas estan bien y hay habitaciones habilitadas disponibles
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
		RETURN -1
	END
	RETURN 1
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
CREATE PROCEDURE THE_FOREIGN_FOUR.proc_aniadir_consumible_estadia
				(@cod_estadia numeric(18,0),
				 @cod_consumible numeric(18,0),
				 @cantidad int)
AS
BEGIN
	IF (@cod_estadia IS NULL OR
		@cod_consumible IS NULL OR
		@cantidad <= 0)
	BEGIN
		RAISERROR (15600,-1,-1, 'THE_FOREIGN_FOUR.proc_aniadir_consumible_estadia')
	END
	INSERT INTO THE_FOREIGN_FOUR.Consumibles_Estadia (cod_estadia, cod_consumible, cantidad)
	VALUES (@cod_estadia, @cod_consumible, @cantidad)
END
GO
--********************************************************
CREATE PROCEDURE THE_FOREIGN_FOUR.proc_registrar_consumibles
				(@nro_factura numeric(18,0))
AS
BEGIN
	IF (@nro_factura IS NULL)
	BEGIN 
		RAISERROR (15600,-1,-1, 'THE_FOREIGN_FOUR.proc_registrar_consumibles')
	END
	ELSE
	BEGIN
		INSERT INTO THE_FOREIGN_FOUR.view_facturas (nro_factura, cod_consumible, cantidad)
		(SELECT	f.nro_factura, ce.cod_consumible, ce.cantidad
		 FROM	THE_FOREIGN_FOUR.Consumibles_Estadia ce JOIN THE_FOREIGN_FOUR.Facturas f ON(ce.cod_estadia = f.cod_estadia)
		 WHERE	f.nro_factura = @nro_factura)
	END
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
--***
--**
--*
CREATE FUNCTION THE_FOREIGN_FOUR.func_obtener_hab_disponibles (@fecha_desde datetime, @cod_tipo_hab numeric(18,0), @cod_hotel numeric(18,0), @cant_noches numeric(18,0))
RETURNS TABLE
AS
RETURN(
		/*SELECT  *
		FROM	THE_FOREIGN_FOUR.view_habitaciones_disp d
		WHERE	d.cod_tipo_hab = @cod_tipo_hab
		AND		d.cod_hotel = @cod_hotel
		AND		CAST(d.fecha_desde AS datetime) < @fecha_desde*/
		
		--habria que agregar las habitaciones de las estadias que fueron checkouteadas
		--solo si el intervalo en que se necesita la habitacion esta contenido en el intervalo
		--de las noches que no aprovecho la estadia	
	
		SELECT	nro_habitacion
		FROM	THE_FOREIGN_FOUR.Habitaciones ha
		WHERE	@cod_hotel = ha.cod_hotel
		AND		@cod_tipo_hab = ha.cod_tipo_hab
		AND		ha.estado = 'H'
		
		EXCEPT
		
		SELECT h.nro_habitacion
		FROM THE_FOREIGN_FOUR.Habitaciones_Estadia he, THE_FOREIGN_FOUR.Habitaciones h, THE_FOREIGN_FOUR.Estadias e, THE_FOREIGN_FOUR.Reservas r
		WHERE	he.cod_habitacion = h.cod_habitacion
		AND		e.cod_reserva = r.cod_reserva
		AND		h.cod_tipo_hab = @cod_tipo_hab
		AND		h.cod_hotel = @cod_hotel
		AND		r.cod_hotel = @cod_hotel
		AND		DATEADD(DAY, e.cant_noches, e.fecha_inicio) > @fecha_desde
		
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
	SET		cod_estado_reserva = (SELECT cod_estado
								  FROM THE_FOREIGN_FOUR.EstadosReserva
								  WHERE descripcion = 'modificada')
	WHERE	cod_reserva = @cod_reserva
END
GO
--**********************************************************
CREATE PROCEDURE THE_FOREIGN_FOUR.proc_crear_habitacion
				(@cod_hotel numeric(18,0),
				 @nro_habitacion numeric(18,0),
				 @piso numeric(18,0),
				 @ubicacion varchar(50),
				 @cod_tipo_hab numeric(18,0),
				 @descripcion nvarchar(255))
AS
BEGIN
	INSERT INTO THE_FOREIGN_FOUR.Habitaciones (cod_hotel, nro_habitacion, piso, ubicacion, cod_tipo_hab, descripcion)
	VALUES (@cod_hotel, @nro_habitacion, @piso, @ubicacion, @cod_tipo_hab, @descripcion)
END
GO
--**********************************************************
CREATE FUNCTION THE_FOREIGN_FOUR.func_existe_habitacion
				(@cod_hotel numeric(18,0),
				 @nro_habitacion numeric(18,0))
RETURNS int
AS
BEGIN
	IF (EXISTS (SELECT	@nro_habitacion
				FROM	THE_FOREIGN_FOUR.Habitaciones
				WHERE	cod_hotel = @cod_hotel
				AND		nro_habitacion = @nro_habitacion))
	BEGIN
		RETURN 1
	END
	RETURN 0
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
	RETURN (SELECT TOP 5 ho.nombre, COUNT(ca.cod_cancelacion) AS 'Cancelaciones efectuadas'
			FROM THE_FOREIGN_FOUR.Hoteles ho JOIN THE_FOREIGN_FOUR.Reservas res ON(ho.cod_hotel = res.cod_hotel)
											 JOIN THE_FOREIGN_FOUR.Cancelaciones ca ON(res.cod_reserva = ca.cod_reserva)
			WHERE ca.fecha_operacion BETWEEN @fecha_desde AND @fecha_hasta
			GROUP BY ho.nombre
			ORDER BY 2 DESC)
GO
--TOP 5 HOTELES MAS CONSUMIBLES FACTURADOS
CREATE FUNCTION THE_FOREIGN_FOUR.func_estadistica_consumibles_hotel
					(@fecha_desde datetime,
					 @fecha_hasta datetime)
RETURNS TABLE
AS
	RETURN (SELECT TOP 5 ho.nombre, SUM(cantidad) AS 'Consumibles facturados'
			FROM THE_FOREIGN_FOUR.Hoteles ho JOIN THE_FOREIGN_FOUR.Reservas res ON(ho.cod_hotel = res.cod_hotel)
											 JOIN THE_FOREIGN_FOUR.Estadias es ON(res.cod_reserva = es.cod_estadia)
											 JOIN THE_FOREIGN_FOUR.Facturas fa ON(es.cod_estadia = fa.cod_estadia)
											 JOIN THE_FOREIGN_FOUR.ItemsFactura itf ON(fa.nro_factura = itf.nro_factura)
			WHERE	cod_consumible > 1000
			AND		fa.fecha_factura BETWEEN @fecha_desde AND @fecha_hasta
			GROUP BY ho.nombre
			ORDER BY 2 DESC)
GO
--TOP 5 HOTELES MAS INACTIVOS
CREATE FUNCTION THE_FOREIGN_FOUR.func_estadistica_inactividad_hotel
					(@fecha_desde datetime,
					 @fecha_hasta datetime)
RETURNS TABLE
AS
	RETURN (SELECT TOP 5 ho.nombre, SUM(DATEDIFF(day, ih.fecha_desde, ih.fecha_hasta)) AS 'Días inactivo'
			FROM THE_FOREIGN_FOUR.Hoteles ho JOIN THE_FOREIGN_FOUR.InactividadHoteles ih ON(ho.cod_hotel = ih.cod_hotel)
			WHERE	ih.fecha_desde >= @fecha_desde
			AND		ih.fecha_hasta <= @fecha_hasta
			GROUP BY ho.nombre
			ORDER BY 2 DESC)
GO
--TOP 5 HABITACIONES MAS ACTIVAS
CREATE FUNCTION THE_FOREIGN_FOUR.func_estadistica_ocupacion_habitacion
					(@fecha_desde datetime,
					 @fecha_hasta datetime)
RETURNS TABLE
AS
	RETURN (SELECT	TOP 5 h.nombre, ha.nro_habitacion, COUNT(he.cod_estadia) 'Veces ocupada', SUM(e.cant_noches) 'Noches ocupada'
			FROM	THE_FOREIGN_FOUR.Habitaciones ha JOIN THE_FOREIGN_FOUR.Habitaciones_Estadia he ON(ha.cod_habitacion = he.cod_habitacion)
													 JOIN THE_FOREIGN_FOUR.Estadias e ON(he.cod_estadia = e.cod_estadia)
													 JOIN THE_FOREIGN_FOUR.Hoteles h ON(ha.cod_hotel = h.cod_hotel)
			WHERE	e.fecha_inicio BETWEEN @fecha_desde AND @fecha_hasta
			OR		e.checkout BETWEEN @fecha_desde AND @fecha_hasta
			GROUP BY ha.nro_habitacion, h.nombre
			ORDER BY 3 DESC, 4 DESC)
GO

--**************************************************************
CREATE FUNCTION THE_FOREIGN_FOUR.func_obtener_puntaje_factura
					(@nro_factura numeric(18,0))
RETURNS int
AS
BEGIN

	DECLARE	@puntos_consumibles int,
			@puntos_estadias int
			
	SET @puntos_consumibles = (SELECT SUM(total_item)
							   FROM THE_FOREIGN_FOUR.ItemsFactura
							   WHERE nro_factura = @nro_factura
							   AND cod_consumible > 2000) / 5
	SET	@puntos_estadias = (SELECT total_item		
							FROM THE_FOREIGN_FOUR.ItemsFactura
							WHERE nro_factura = @nro_factura
							AND	cod_consumible = 1) / 10
	RETURN @puntos_consumibles + @puntos_estadias
END
GO

--TOP 5 CLIENTES
CREATE FUNCTION THE_FOREIGN_FOUR.func_estadistica_puntaje_cliente
					(@fecha_desde datetime,
					 @fecha_hasta datetime)
RETURNS TABLE
AS
	RETURN (SELECT top 5 c.cod_cliente, c.nombre, c.apellido, c.mail, c.tipo_doc, c.nro_doc, THE_FOREIGN_FOUR.func_obtener_puntaje_factura(f.nro_factura) AS 'puntaje'
			FROM THE_FOREIGN_FOUR.Clientes c JOIN THE_FOREIGN_FOUR.Facturas f ON(c.cod_cliente = f.cod_cliente)
			WHERE f.fecha_factura BETWEEN @fecha_desde AND @fecha_hasta
			GROUP BY c.cod_cliente, c.nombre, c.apellido, c.mail, c.tipo_doc, c.nro_doc, f.nro_factura
			ORDER BY 7 DESC)
GO

--**************************************

CREATE PROCEDURE THE_FOREIGN_FOUR.borrar_usuarios_hotel @cod_usuario numeric(18,0)
AS
	DELETE THE_FOREIGN_FOUR.UsuariosPorHotel
	WHERE cod_usuario = @cod_usuario
GO

--*********************************
CREATE PROCEDURE THE_FOREIGN_FOUR.proc_insertar_rol_usuario	@cod_usuario numeric(18,0),
																@cod_hotel numeric(18,0),
																@cod_rol numeric(18,0)
AS
	INSERT INTO THE_FOREIGN_FOUR.UsuariosPorHotel
	(cod_hotel, cod_usuario, cod_rol)
	VALUES (@cod_hotel, @cod_usuario, @cod_rol)
GO
--**********************************
CREATE FUNCTION THE_FOREIGN_FOUR.func_validar_huesped 
					(@cod_cliente numeric(18,0),
					 @cod_estadia numeric(18,0))
RETURNS int
AS
BEGIN
	IF(EXISTS (SELECT	cod_cliente, cod_estadia
			   FROM		THE_FOREIGN_FOUR.ClientePorEstadia
			   WHERE	cod_cliente = @cod_cliente
			   AND		cod_estadia = @cod_estadia))
	BEGIN
		RETURN -1
	END
	RETURN 1
END
GO
--*********************************************
CREATE PROCEDURE THE_FOREIGN_FOUR.proc_ins_capacidad_hab
AS
BEGIN
	UPDATE	THE_FOREIGN_FOUR.TipoHabitaciones
	SET		capacidad = 1
	WHERE	cod_tipo_hab = 1001
	
	UPDATE	THE_FOREIGN_FOUR.TipoHabitaciones
	SET		capacidad = 2
	WHERE	cod_tipo_hab = 1002
	
	UPDATE	THE_FOREIGN_FOUR.TipoHabitaciones
	SET		capacidad = 3
	WHERE	cod_tipo_hab = 1003
	
	UPDATE	THE_FOREIGN_FOUR.TipoHabitaciones
	SET		capacidad = 4
	WHERE	cod_tipo_hab = 1004
	
	UPDATE	THE_FOREIGN_FOUR.TipoHabitaciones
	SET		capacidad = 5
	WHERE	cod_tipo_hab = 1005
END
GO
--*********************************************
create FUNCTION THE_FOREIGN_FOUR.func_max_cant_huespedes
					(@cod_reserva numeric(18,0))
RETURNS int
AS
BEGIN
	RETURN (SELECT	SUM(th.capacidad)
			FROM	THE_FOREIGN_FOUR.TipoHabitacion_Reservas thr JOIN THE_FOREIGN_FOUR.TipoHabitaciones th ON(thr.cod_tipo_hab = th.cod_tipo_hab)
			WHERE	cod_reserva = @cod_reserva)
END
GO
--*********************************************
CREATE FUNCTION THE_FOREIGN_FOUR.func_obtener_datos_reserva
					(@cod_reserva numeric(18,0))
RETURNS TABLE
AS
	RETURN (SELECT	cod_reserva, cod_cliente, cod_hotel, cod_regimen, fecha_desde, fecha_hasta
			FROM	THE_FOREIGN_FOUR.Reservas
			WHERE	cod_reserva = @cod_reserva)
GO
--********************************************
CREATE FUNCTION THE_FOREIGN_FOUR.func_obtener_tipo_hab_reserva
					(@cod_reserva numeric(18,0))
RETURNS TABLE
AS
	RETURN (SELECT	r.cod_tipo_hab, h.descripcion
			FROM	THE_FOREIGN_FOUR.TipoHabitacion_Reservas r,
					THE_FOREIGN_FOUR.TipoHabitaciones h
			WHERE	cod_reserva = @cod_reserva
			AND		r.cod_tipo_hab = h.cod_tipo_hab)
GO

--*******************************************
CREATE FUNCTION THE_FOREIGN_FOUR.func_obtener_estado_cliente
					(@cod_cliente numeric(18,0))
RETURNS int
AS
BEGIN
	DECLARE @estado varchar
	SET @estado = (SELECT estado
			FROM THE_FOREIGN_FOUR.Clientes
			WHERE cod_cliente = @cod_cliente)
	IF (@estado = 'H')
	BEGIN
		RETURN 1
	END
	RETURN 0
END
GO
--*******************************************
CREATE VIEW THE_FOREIGN_FOUR.view_consumibles
AS
	SELECT descripcion
	FROM THE_FOREIGN_FOUR.Consumibles
	WHERE	descripcion NOT LIKE 'estadia'
	AND		descripcion NOT LIKE 'descuento all inclusive'
	AND		descripcion NOT LIKE 'noches no utilizadas'
GO
--*******************************************
CREATE FUNCTION THE_FOREIGN_FOUR.func_hay_clientes (@cod_habitacion int)
RETURNS int
AS
BEGIN
	IF((SELECT COUNT(*) 
		FROM THE_FOREIGN_FOUR.Habitaciones_Estadia he,THE_FOREIGN_FOUR.Estadias e 
		WHERE he.cod_habitacion=@cod_habitacion AND
			he.cod_estadia = e.cod_estadia AND
			THE_FOREIGN_FOUR.func_get_fecha_sistema() BETWEEN e.fecha_inicio AND DATEADD(day,e.cant_noches,e.fecha_inicio)) >= 1)
	BEGIN
		RETURN 1
	END
	RETURN 0		
END
GO
--*****************************************************
CREATE PROCEDURE THE_FOREIGN_FOUR.proc_cancelar_reservas_no_efectivizadas
AS
BEGIN
	UPDATE THE_FOREIGN_FOUR.Reservas
	SET		cod_estado_reserva = (SELECT cod_estado
								  FROM THE_FOREIGN_FOUR.EstadosReserva
								  WHERE descripcion LIKE 'cancelacion_noshow')
	WHERE	fecha_desde < THE_FOREIGN_FOUR.func_get_fecha_sistema() 
	AND		cod_estado_reserva IN (SELECT cod_estado
								   FROM THE_FOREIGN_FOUR.EstadosReserva
								   WHERE descripcion LIKE 'correcta'
								   OR	 descripcion LIKE 'modificada')
END
GO
--*******************************************************
CREATE FUNCTION THE_FOREIGN_FOUR.func_reserva_cancelable
					(@cod_reserva numeric(18,0))
RETURNS int
AS
BEGIN
	IF((SELECT cod_estado_reserva 
	    FROM THE_FOREIGN_FOUR.Reservas 
	    WHERE cod_reserva = @cod_reserva) IN (SELECT cod_estado
											  FROM THE_FOREIGN_FOUR.EstadosReserva
											  WHERE descripcion LIKE 'cancelacion%'
											  OR	descripcion LIKE 'efectivizada'))
	BEGIN
		RETURN -1
	END
	RETURN (SELECT THE_FOREIGN_FOUR.func_operacion_en_fecha (@cod_reserva))
END
GO
--***************************************************
CREATE FUNCTION THE_FOREIGN_FOUR.func_operacion_en_fecha
					(@cod_reserva numeric(18,0))
RETURNS int
AS
BEGIN
	DECLARE @fecha_inicio_reserva datetime
	SET	@fecha_inicio_reserva = (SELECT fecha_desde
								 FROM THE_FOREIGN_FOUR.Reservas
								 WHERE cod_reserva = @cod_reserva)
	IF (DATEDIFF(day, @fecha_inicio_reserva, THE_FOREIGN_FOUR.func_get_fecha_sistema()) <= 1) --fecha_inicio es mayor a la actual en, por lo menos 1 o mas dias
	BEGIN
		RETURN 1
	END
	RETURN 0
END
GO
--***************************************************
CREATE PROCEDURE THE_FOREIGN_FOUR.proc_set_fecha_sistema 
					(@nueva_fecha_sistema datetime)
AS
BEGIN
	IF(EXISTS (SELECT * FROM THE_FOREIGN_FOUR.VarGlobal))
	BEGIN
		UPDATE THE_FOREIGN_FOUR.VarGlobal
		SET	fecha_sistema = @nueva_fecha_sistema
	END
	ELSE
	BEGIN
		INSERT INTO THE_FOREIGN_FOUR.VarGlobal (fecha_sistema)
		VALUES (@nueva_fecha_sistema)
	END
END
GO
--****************************************************
CREATE FUNCTION THE_FOREIGN_FOUR.func_get_fecha_sistema ()
RETURNS datetime
AS
BEGIN
	RETURN (SELECT fecha_sistema FROM THE_FOREIGN_FOUR.VarGlobal)
END
GO
