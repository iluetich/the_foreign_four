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
				 @nro_habitacion numeric(18,0),
				 @fecha_inicio datetime,
				 @cant_noches numeric(18,0))
AS
	INSERT INTO THE_FOREIGN_FOUR.Estadias (cod_reserva, nro_habitacion, fecha_inicio, cant_noches)
	VALUES	(@cod_reserva, @nro_habitacion, @fecha_inicio, @cant_noches)
GO

--***********************************************************

CREATE PROCEDURE THE_FOREIGN_FOUR.proc_modificar_reserva
				(@cod_reserva numeric(18,0),
				 @fecha_desde datetime,
				 @fecha_hasta datetime,
				 @cod_tipo_hab numeric(18,0),
				 @cod_regimen int)
AS
	UPDATE THE_FOREIGN_FOUR.Reservas
	SET fecha_desde = @fecha_desde,
		fecha_hasta = @fecha_hasta,
		cod_tipo_hab = @cod_tipo_hab,
		cod_regimen = @cod_regimen
	WHERE @cod_reserva = cod_reserva
GO

--***********************************************************
DROP PROCEDURE THE_FOREIGN_FOUR.proc_generar_reserva
CREATE PROCEDURE THE_FOREIGN_FOUR.proc_generar_reserva
				(@cod_hotel int,
				 @cod_cliente numeric(18,0),
				 @cod_tipo_hab numeric(18,0),
				 @cod_regimen int,
				 @fecha_desde datetime,
				 @fecha_hasta datetime,
				 @fecha_creacion datetime)
AS
BEGIN
	DECLARE @cod_reserva_generada numeric(18,0)
	
	INSERT INTO THE_FOREIGN_FOUR.Reservas (cod_hotel, cod_cliente, cod_tipo_hab, cod_regimen, fecha_desde, fecha_hasta, fecha_creacion, cant_noches)
	VALUES (@cod_hotel, @cod_cliente, @cod_tipo_hab, @cod_regimen, @fecha_desde, @fecha_hasta, @fecha_creacion, @fecha_hasta - @fecha_desde)
	
	SET		@cod_reserva_generada = (SELECT	cod_reserva
									 FROM THE_FOREIGN_FOUR.Reservas
									 WHERE	@cod_hotel = cod_hotel
									 AND	@cod_cliente = cod_cliente
									 AND	@cod_tipo_hab = cod_tipo_hab
									 AND	@cod_regimen = cod_regimen
									 AND	@fecha_desde = fecha_desde
									 AND	@fecha_hasta = fecha_hasta
									 AND	@fecha_creacion = fecha_creacion)
	
	RETURN @cod_reserva_generada
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
--***********************************************************

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
								  
	SET		@cant_hab_reservadas = (SELECT	COUNT(cod_reserva)
									FROM	THE_FOREIGN_FOUR.Reservas r
									WHERE	@cod_hotel = r.cod_hotel
									AND		@cod_tipo_hab = r.cod_tipo_hab
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

	SELECT nombre, apellido, tipo_doc, nro_doc, mail, telefono, fecha_nac, nom_calle, nro_calle, nacionalidad, pais_origen
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

CREATE VIEW THE_FOREIGN_FOUR.view_funcionalidades_rol 
AS
SELECT r.nombre as 'Rol' , f.nombre as 'Funcionalidad' 
FROM THE_FOREIGN_FOUR.Roles r,THE_FOREIGN_FOUR.FuncionalidadPorRol fr
	,THE_FOREIGN_FOUR.Funcionalidades f
WHERE r.cod_rol=fr.cod_rol
AND   fr.cod_funcion=f.cod_funcion
GO
--***********************************************************
CREATE VIEW THE_FOREIGN_FOUR.view_roles_hoteles_usuarios
AS
SELECT u.user_name,uh.cod_hotel,r.nombre as 'rol'
FROM THE_FOREIGN_FOUR.Usuarios u,THE_FOREIGN_FOUR.UsuariosPorHotel uh,THE_FOREIGN_FOUR.Roles r
WHERE u.cod_usuario = uh.cod_usuario
AND uh.cod_rol = r.cod_rol
GO
--***********************************************************
CREATE VIEW THE_FOREIGN_FOUR.RolesPorHotelesPorUsuarios
AS
SELECT u.cod_usuario,u.cod_hotel,r.nombre
FROM THE_FOREIGN_FOUR.UsuariosPorHotel u,THE_FOREIGN_FOUR.Roles r
WHERE u.cod_rol = r.cod_rol
GO
--***********************************************************
CREATE VIEW THE_FOREIGN_FOUR.FuncionesPorRol
AS
SELECT fr.cod_rol,f.nombre
FROM THE_FOREIGN_FOUR.FuncionalidadPorRol fr,THE_FOREIGN_FOUR.Funcionalidades f
WHERE fr.cod_funcion = f.cod_funcion
GO
--***********************************************************
CREATE VIEW THE_FOREIGN_FOUR.view_todos_los_clientes 
AS
SELECT nombre, apellido, tipo_doc, nro_doc, mail, telefono, fecha_nac, nom_calle, nro_calle, nacionalidad, pais_origen
FROM THE_FOREIGN_FOUR.Clientes
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
--***********************************************************
/*
CREATE VIEW THE_FOREIGN_FOUR.view_facturas
AS
SELECT f.nro_factura, f.cod_estadia, c.cod_consumible, c.descripcion, c.precio, ce.cantidad
FROM	THE_FOREIGN_FOUR.Facturas f, 
		THE_FOREIGN_FOUR.ItemsFactura i,
		THE_FOREIGN_FOUR.ConsumiblesPorEstadia ce,
		THE_FOREIGN_FOUR.Consumibles c
WHERE ce.cod_estadia = f.cod_estadia
AND f.nro_factura = i.nro_factura
AND c.cod_consumible = ce.cod_consumible
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
--***********************************************************
CREATE TRIGGER trg_separar_factura
ON THE_FOREIGN_FOUR.view_facturas
INSTEAD OF INSERT
AS
BEGIN

	DECLARE TrigInsCursor CURSOR FOR
	SELECT nro_factura, cod_estadia, cod_consumible, cantidad
	FROM inserted
	DECLARE	@nro_factura numeric(18,0),
			@cod_estadia int,
			@cod_consumible int,
			@cantidad int
			
	OPEN TrigInsCursor;
	
	FETCH NEXT FROM TrigInsCursor INTO @nro_factura, @cod_estadia, @cod_consumible
	WHILE @@FETCH_STATUS = 0
	BEGIN
	
	INSERT INTO THE_FOREIGN_FOUR.ConsumiblesPorEstadia (cod_estadia, cod_consumible, cantidad)
	VALUES (@cod_estadia, @cod_consumible, @cantidad)
	
	INSERT INTO THE_FOREIGN_FOUR.ItemsFactura (nro_factura, cantidad, 
	
	
	END
	CLOSE TrigInsCursor;
	DEALLOCATE TrigInsCursor;
END
GO



DROP VIEW THE_FOREIGN_FOUR.view_facturas*/

--********************************************
--******SCRIPT PARA DROPEAR*******************
/*
DROP FUNCTION THE_FOREIGN_FOUR.login_password
DROP FUNCTION THE_FOREIGN_FOUR.login_funcionalidades
DROP FUNCTION THE_FOREIGN_FOUR.buscar_clientes
DROP FUNCTION THE_FOREIGN_FOUR.obtener_tipo_habitaciones
DROP FUNCTION THE_FOREIGN_FOUR.buscar_habitaciones
DROP FUNCTION THE_FOREIGN_FOUR.func_hay_disponibilidad
DROP FUNCTION THE_FOREIGN_FOUR.func_obtener_cant_huespedes
DROP FUNCTION THE_FOREIGN_FOUR.func_obtener_regimenes_hab
DROP FUNCTION THE_FOREIGN_FOUR.func_sgte_cod_reserva
DROP FUNCTION THE_FOREIGN_FOUR.func_hab_disponibles
DROP FUNCTION THE_FOREIGN_FOUR.func_hay_disponibilidad
DROP PROCEDURE THE_FOREIGN_FOUR.proc_eliminar_cliente
DROP PROCEDURE THE_FOREIGN_FOUR.proc_inhabilitar_habitacion
DROP PROCEDURE THE_FOREIGN_FOUR.proc_inhabilitar_rol
DROP PROCEDURE THE_FOREIGN_FOUR.proc_generar_reserva
DROP PROCEDURE THE_FOREIGN_FOUR.proc_modificar_reserva
DROP PROCEDURE THE_FOREIGN_FOUR.proc_registrar_estadia
DROP PROCEDURE THE_FOREIGN_FOUR.proc_registrar_huesped
DROP VIEW THE_FOREIGN_FOUR.view_todos_los_clientes
DROP VIEW THE_FOREIGN_FOUR.view_funcionalidades
DROP VIEW THE_FOREIGN_FOUR.view_hoteles

--********************************************
--****DATOS PARA TESTEAR**********************
INSERT INTO THE_FOREIGN_FOUR.Usuarios
(user_name, password)
VALUES ('Ani', '1234')

SELECT * FROM THE_FOREIGN_FOUR.Usuarios

INSERT INTO THE_FOREIGN_FOUR.UsuariosPorHotel
(cod_usuario, cod_hotel)
VALUES (1,1),(1,2),(1,3)

SELECT * FROM THE_FOREIGN_FOUR.UsuariosPorHotel

SELECT * 
FROM THE_FOREIGN_FOUR.login_password('Ani', '124')

------------------------------------------------------
SELECT *
FROM THE_FOREIGN_FOUR.buscar_clientes('AARON', NULL, NULL ,NULL , NULL)
-------------------------------------------------------
SELECT * FROM THE_FOREIGN_FOUR.view_todos_los_clientes
---------------------------------------------------
INSERT INTO THE_FOREIGN_FOUR.Clientes
(nombre, apellido, tipo_doc, nro_doc,mail)
VALUES ('Ana', 'Perez Ghiglia', 'DNI', 38067003, 'anitperez2@gmail.com')

SELECT *
FROM THE_FOREIGN_FOUR.Clientes
WHERE nombre = 'Ana'

EXECUTE proc_eliminar_cliente 'anitperez2@gmail.com'
--------------------------------------------------------

SELECT *
FROM THE_FOREIGN_FOUR.obtener_tipo_habitaciones(9)

------------------------------------------------------------------
SELECT * FROM THE_FOREIGN_FOUR.Habitaciones

SELECT *
FROM THE_FOREIGN_FOUR.buscar_habitaciones(NULL, 1,  1001, NULL, 9)

------------------------------------------------------------
EXECUTE THE_FOREIGN_FOUR.proc_inhabilitar_habitacion 0,1

-------------------------------------------------------
INSERT INTO THE_FOREIGN_FOUR.Roles
(nombre)
VALUES ('Recepcionlista')

SELECT * FROM THE_FOREIGN_FOUR.Roles

EXECUTE THE_FOREIGN_FOUR.proc_inhabilitar_rol 1

----------------------------------------------------------
INSERT INTO THE_FOREIGN_FOUR.RegimenPorHotel 
VALUES (1,1)
----------------------------------------------------------
SELECT THE_FOREIGN_FOUR.func_hay_disponibilidad (1, 1001, 1, GETDATE() + 999, GETDATE() + 1000)
----------------------------------------------------------
SELECT COUNT(cod_reserva)
FROM THE_FOREIGN_FOUR.Reservas
WHERE	cod_hotel = 1
AND		cod_tipo_hab = 1001
AND		fecha_desde BETWEEN GETDATE() + 999 AND GETDATE() + 1000
OR		fecha_hasta BETWEEN GETDATE() + 999 AND GETDATE() + 1000
----------------------------------------------------------
SELECT COUNT(nro_habitacion)
FROM THE_FOREIGN_FOUR.Habitaciones
WHERE	cod_hotel = 1
AND		cod_tipo_hab = 1001
----------------------------------------------------------
*/


DECLARE @fecha1 datetime,
		@fecha2 datetime,
		@fecha3 datetime
SET		@fecha1 = 20160101
SET		@fecha2 = 20160106
SET		@fecha3 = 20141106
EXEC THE_FOREIGN_FOUR.proc_generar_reserva 15, 1001, 3, @fecha1, @fecha2, @fecha3, 2

CAST()