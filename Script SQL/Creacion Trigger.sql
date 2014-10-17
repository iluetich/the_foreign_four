CREATE TRIGGER trg_clientes_error
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

CREATE TRIGGER trg_reservas_error
ON THE_FOREIGN_FOUR.Reservas
INSTEAD OF INSERT
AS
BEGIN

	DECLARE TrigInsCursor CURSOR FOR
	SELECT cod_reserva, cod_hotel, cod_cliente, cod_tipo_hab, cod_regimen, cod_estado_reserva, fecha_creacion, 
			fecha_desde, fecha_hasta, cant_noches  
	FROM inserted
	DECLARE @cod_reserva numeric(18,0),
			@cod_hotel int,
			@cod_cliente numeric(18,0),
			@cod_tipo_hab int,
			@cod_regimen int,
			@cod_estado_reserva int,
			@fecha_creacion datetime, 
			@fecha_desde datetime,
			@fecha_hasta datetime,
			@cant_noches int
			
	OPEN TrigInsCursor;

	FETCH NEXT FROM TrigInsCursor INTO	@cod_reserva, @cod_hotel,@cod_cliente, @cod_tipo_hab, @cod_regimen, 
										@cod_estado_reserva, @fecha_creacion, @fecha_desde, @fecha_hasta, @cant_noches

	WHILE @@FETCH_STATUS = 0
	BEGIN
	
		IF(	@cod_hotel IS NULL OR
			@cod_cliente IS NULL OR
			@cod_tipo_hab IS NULL OR
			@cod_regimen IS NULL
			)
		BEGIN
			INSERT INTO THE_FOREIGN_FOUR.ReservasDefectuosas (cod_reserva, cod_hotel, cod_cliente, 
						cod_tipo_hab, cod_regimen, fecha_creacion, fecha_desde, fecha_hasta, cant_noches)
			VALUES (@cod_reserva, @cod_hotel, @cod_cliente, @cod_tipo_hab, @cod_regimen, 
					@fecha_creacion, @fecha_desde, @fecha_hasta, @cant_noches);
		END	
		ELSE
		BEGIN
			INSERT INTO THE_FOREIGN_FOUR.Reservas(cod_reserva, cod_hotel, cod_cliente, cod_tipo_hab, 
						cod_regimen, cod_estado_reserva, fecha_creacion, fecha_desde, fecha_hasta, cant_noches)
			VALUES (@cod_reserva, @cod_hotel, @cod_cliente, @cod_tipo_hab, @cod_regimen, 
					@cod_estado_reserva, @fecha_creacion, @fecha_desde, @fecha_hasta, @cant_noches);
		END			
			
		FETCH NEXT FROM TrigInsCursor INTO	@cod_reserva, @cod_hotel,@cod_cliente, @cod_tipo_hab, @cod_regimen, 
											@cod_estado_reserva, @fecha_creacion, @fecha_desde, @fecha_hasta, @cant_noches      

  END

  CLOSE TrigInsCursor;
  DEALLOCATE TrigInsCursor;

END
GO
