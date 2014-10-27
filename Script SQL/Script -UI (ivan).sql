CREATE FUNCTION	THE_FOREIGN_FOUR.func_obtener_cant_huespedes
				(@cod_reserva numeric(18,0))
				
RETURNS TABLE
AS
RETURN (SELECT	COUNT(c.cod_cliente) AS cantidad_huespedes
		FROM THE_FOREIGN_FOUR.Clientes c JOIN THE_FOREIGN_FOUR.ClientePorEstadia cpe ON(c.cod_cliente = cpe.cod_cliente)
										 JOIN THE_FOREIGN_FOUR.Estadias e ON(cpe.cod_estadia = e.cod_estadia)
		WHERE @cod_reserva = e.cod_reserva)
		
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
				 @cod_tipo_hab int,
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

CREATE PROCEDURE THE_FOREIGN_FOUR.proc_generar_reserva
				(@cod_hotel int,
				 @cod_tipo_hab int,
				 @cod_regimen int,
				 @fecha_desde datetime,
				 @fecha_hasta datetime,
				 @fecha_creacion datetime,
				 @cant_huespedes int)
AS
	INSERT INTO THE_FOREIGN_FOUR.Reservas (cod_hotel, cod_tipo_hab, cod_regimen, fecha_desde, fecha_hasta, fecha_creacion)
	VALUES (@cod_hotel, @cod_tipo_hab, @cod_regimen, @fecha_desde, @fecha_hasta, @fecha_creacion)
GO

--***********************************************************

CREATE VIEW THE_FOREIGN_FOUR.view_mostrar_hoteles
AS
	SELECT cod_hotel, nombre
	FROM THE_FOREIGN_FOUR.Hoteles
GO

--***********************************************************

