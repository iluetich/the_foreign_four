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

CREATE VIEW THE_FOREIGN_FOUR.view_todos_los_clientes 
AS
SELECT nombre, apellido, tipo_doc, nro_doc, mail, telefono, fecha_nac, nom_calle, nro_calle, nacionalidad, pais_origen
FROM THE_FOREIGN_FOUR.Clientes


CREATE PROCEDURE THE_FOREIGN_FOUR.proc_eliminar_cliente (@mail nvarchar(255))
AS

	UPDATE THE_FOREIGN_FOUR.Clientes
	SET baja_logica = 'S'
	WHERE mail = @mail
GO

 
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

CREATE PROCEDURE THE_FOREIGN_FOUR.proc_inhabilitar_habitacion(
					@nro_hab numeric(18,0),
					@cod_hotel int)
AS

UPDATE THE_FOREIGN_FOUR.Habitaciones
SET estado = 'I'
WHERE nro_habitacion = @nro_hab
AND cod_hotel = @cod_hotel

GO

CREATE VIEW THE_FOREIGN_FOUR.view_funcionalidades
AS
SELECT DISTINCT cod_funcion, nombre
FROM THE_FOREIGN_FOUR.Funcionalidades

CREATE PROCEDURE THE_FOREIGN_FOUR.proc_inhabilitar_rol(@cod_rol int)
AS
UPDATE THE_FOREIGN_FOUR.Roles
SET estado = 'I'
WHERE cod_rol = @cod_rol
GO


--********************************************
--******SCRIPT PARA DROPEAR*******************
DROP FUNCTION THE_FOREIGN_FOUR.login_password
DROP FUNCTION THE_FOREIGN_FOUR. login_funcionalidades
DROP FUNCTION THE_FOREIGN_FOUR.buscar_clientes
DROP FUNCTION THE_FOREIGN_FOUR.obtener_tipo_habitaciones
DROP FUNCTION THE_FOREIGN_FOUR.buscar_habitaciones
DROP PROCEDURE THE_FOREIGN_FOUR.proc_eliminar_cliente
DROP PROCEDURE THE_FOREIGN_FOUR.proc_inhabilitar_habitacion
DROP PROCEDURE THE_FOREIGN_FOUR.proc_inhabilitar_rol
DROP VIEW THE_FOREIGN_FOUR.view_todos_los_clientes
DROP VIEW THE_FOREIGN_FOUR.view_funcionalidades

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