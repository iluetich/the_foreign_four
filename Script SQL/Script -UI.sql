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
	SELECT	f.cod_funcion, f.nombre
	FROM	THE_FOREIGN_FOUR.UsuariosPorHotel uh,
			THE_FOREIGN_FOUR.FuncionalidadPorRol fr,
			THE_FOREIGN_FOUR.Funcionalidades f
	WHERE	uh.cod_rol = fr.cod_funcion
	AND		f.cod_funcion = fr.cod_funcion
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
		(CASE WHEN @nombre IS NULL  THEN '%'ELSE @nombre END)
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


--********************************************
--******SCRIPT PARA DROPEAR*******************
DROP FUNCTION THE_FOREIGN_FOUR.login_password
DROP FUNCTION THE_FOREIGN_FOUR. login_funcionalidades
DROP FUNCTION THE_FOREIGN_FOUR.buscar_clientes
DROP FUNCTION THE_FOREIGN_FOUR.obtener_tipo_habitaciones
DROP PROCEDURE THE_FOREIGN_FOUR.proc_eliminar_cliente
DROP VIEW THE_FOREIGN_FOUR.view_todos_los_clientes

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

SELECT *
FROM THE_FOREIGN_FOUR.buscar_clientes('AARON', NULL, NULL ,NULL , NULL)

SELECT * FROM THE_FOREIGN_FOUR.view_todos_los_clientes

INSERT INTO THE_FOREIGN_FOUR.Clientes
(nombre, apellido, tipo_doc, nro_doc,mail)
VALUES ('Ana', 'Perez Ghiglia', 'DNI', 38067003, 'anitperez2@gmail.com')

SELECT *
FROM THE_FOREIGN_FOUR.Clientes
WHERE nombre = 'Ana'

EXECUTE proc_eliminar_cliente 'anitperez2@gmail.com'

DELETE FROM THE_FOREIGN_FOUR.Clientes
WHERE cod_cliente = 87275


SELECT *
FROM THE_FOREIGN_FOUR.obtener_tipo_habitaciones(9)

