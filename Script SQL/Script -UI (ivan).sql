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
				 @cod_tipo_hab numeric(18,0),
				 @cod_regimen int,
				 @fecha_desde datetime,
				 @fecha_hasta datetime,
				 @fecha_creacion datetime,
				 @cant_huespedes int)
AS
BEGIN
	DECLARE @cod_reserva_generada numeric(18,0)
	
	INSERT INTO THE_FOREIGN_FOUR.Reservas (cod_hotel, cod_tipo_hab, cod_regimen, fecha_desde, fecha_hasta, fecha_creacion)
	VALUES (@cod_hotel, @cod_tipo_hab, @cod_regimen, @fecha_desde, @fecha_hasta, @fecha_creacion)
	
	SET		@cod_reserva_generada = (SELECT	cod_reserva
									 FROM THE_FOREIGN_FOUR.Reservas
									 WHERE	@cod_hotel = cod_hotel
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
									AND		r.fecha_desde BETWEEN @fecha_inicio AND @fecha_fin
									OR		r.fecha_hasta BETWEEN @fecha_inicio AND @fecha_fin)
									
	SET		@cant_hab_disponibles = @cant_hab_por_tipo - @cant_hab_reservadas
	RETURN	@cant_hab_disponibles
END
	
--***********************************************************
DROP FUNCTION THE_FOREIGN_FOUR.func_hay_disponibilidad
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
								   
--***********************************************************



--***********************************************************
--***********************************************************
--*********************TESTEO DE DISPONIBILIDAD**************
--***********************************************************
--***********************************************************
INSERT INTO THE_FOREIGN_FOUR.RegimenPorHotel 
VALUES (1,1)

SELECT THE_FOREIGN_FOUR.func_hay_disponibilidad (1, 1001, 1, GETDATE() + 999, GETDATE() + 1000)

SELECT COUNT(cod_reserva)
FROM THE_FOREIGN_FOUR.Reservas
WHERE	cod_hotel = 1
AND		cod_tipo_hab = 1001
AND		fecha_desde BETWEEN GETDATE() + 999 AND GETDATE() + 1000
OR		fecha_hasta BETWEEN GETDATE() + 999 AND GETDATE() + 1000

SELECT COUNT(nro_habitacion)
FROM THE_FOREIGN_FOUR.Habitaciones
WHERE	cod_hotel = 1
AND		cod_tipo_hab = 1001
