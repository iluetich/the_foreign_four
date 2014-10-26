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

DROP FUNCTION THE_FOREIGN_FOUR.login_password
DROP FUNCTION THE_FOREIGN_FOUR. login_funcionalidades
DROP FUNCTION THE_FOREIGN_FOUR.buscar_clientes

CREATE FUNCTION THE_FOREIGN_FOUR.buscar_clientes(
				@nombre nvarchar(255),
				@apellido nvarchar(255),
				@tipo_doc char(3),
				@nro_doc numeric(18,0),
				@mail nvarchar(255) )
RETURNS TABLE
AS
RETURN(

	SELECT nombre, apellido, tipo_doc, nro_doc, mail, telefono, fecha_nac, nom_calle, nacionalidad
	FROM THE_FOREIGN_FOUR.Clientes
	WHERE nombre LIKE 
		(CASE WHEN @nombre IS NULL  THEN '%'ELSE @nombre END)
	AND apellido =
		(CASE WHEN @apellido IS NULL THEN '%' ELSE @apellido END)
	AND tipo_doc = 
		(CASE WHEN @tipo_doc IS NULL THEN '%' ELSE  @tipo_doc END)
	--AND nro_doc = 
	--	(CASE WHEN @nro_doc IS NOT NULL THEN @nro_doc ELSE '%' END)
	AND mail = 
		(CASE WHEN @mail IS NULL THEN '%' ELSE @mail   END)
)


--**********************************
--****DATOS PARA TESTEAR************
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
FROM THE_FOREIGN_FOUR.buscar_clientes('AARON', NULL, 'PAS' ,NULL , 'aaron_Alonso@gmail.com')



SELECT * FROM THE_FOREIGN_FOUR.Clientes
WHERE nombre LIKE '%'