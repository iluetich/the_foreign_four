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
			@cod_tipo_hab numeric(18,0),
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
			@cod_regimen IS NULL OR
			@fecha_desde IS NULL OR
			@cant_noches IS NULL)
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

--*****************************************************

CREATE TRIGGER trg_estadias_error
ON THE_FOREIGN_FOUR.Estadias
INSTEAD OF INSERT
AS
BEGIN

	DECLARE TrigInsCursor CURSOR FOR
	SELECT cod_reserva, nro_habitacion, fecha_inicio, cant_noches
	FROM inserted
	DECLARE @cod_reserva numeric(18,0),
			@nro_habitacion numeric(18,0),
			@fecha_inicio datetime,
			@cant_noches numeric(18,0)

	OPEN TrigInsCursor;

	FETCH NEXT FROM TrigInsCursor INTO @cod_reserva, @nro_habitacion, @fecha_inicio, @cant_noches

	WHILE @@FETCH_STATUS = 0
	BEGIN
	
		IF(@cod_reserva IS NULL OR
		   @nro_habitacion IS NULL OR
		   @fecha_inicio IS NULL OR
		   @cant_noches IS NULL OR
		  (SELECT DATEADD(day, @cant_noches, @fecha_inicio)) > GETDATE() OR
		   EXISTS (SELECT cod_estadia
					   FROM THE_FOREIGN_FOUR.Estadias
					   WHERE cod_reserva = @cod_reserva
					   AND nro_habitacion = @nro_habitacion
					   AND fecha_inicio = @fecha_inicio
					   AND cant_noches = @cant_noches))
		   
		BEGIN
			INSERT INTO THE_FOREIGN_FOUR.EstadiasDefectuosas (cod_reserva, nro_habitacion, fecha_inicio, cant_noches)
			VALUES (@cod_reserva, @nro_habitacion, @fecha_inicio, @cant_noches);
		END	
		ELSE
		BEGIN
			INSERT INTO THE_FOREIGN_FOUR.Estadias (cod_reserva, nro_habitacion, fecha_inicio, cant_noches)
			VALUES (@cod_reserva, @nro_habitacion, @fecha_inicio, @cant_noches);
		END			
			
		FETCH NEXT FROM TrigInsCursor INTO @cod_reserva, @nro_habitacion, @fecha_inicio, @cant_noches      

  END

  CLOSE TrigInsCursor;
  DEALLOCATE TrigInsCursor;

END
GO

--*****************************************************
/*
CREATE TRIGGER trg_precio_estadia
ON THE_FOREIGN_FOUR.Estadias
AFTER INSERT
AS
BEGIN
	DECLARE TrgInsCursor CURSOR FOR
	SELECT cod_reserva FROM inserted
	DECLARE @cod_reserva numeric(18,0)
	
	OPEN  TrgInsCursor
	FETCH NEXT FROM TrgInsCurson INTO @cod_reserva
	WHILE @@FETCH_STATUS = 0
	BEGIN
		INSERT INTO THE_FOREIGN_FOUR.Estadias
		SELECT r.cant_noches * th.recargo
		FROM	THE_FOREIGN_FOUR.Reservas r,
				THE_FOREIGN_FOUR.TipoHabitaciones th
		WHERE r.cod_
	
	END
	CLOSE TrgInsCursor
	DEALLOCATE TrgInsCursor
END
GO*/
--*************************************************
CREATE TRIGGER trg_habitaciones_error
ON THE_FOREIGN_FOUR.Habitaciones
INSTEAD OF INSERT
AS
BEGIN

	DECLARE TrigInsCursor CURSOR FOR
	SELECT piso, ubicacion, cod_tipo_hab, nro_habitacion, cod_hotel
	FROM inserted
	DECLARE @piso int,
			@ubicacion nvarchar(255),
			@cod_tipo_hab numeric(18,0),
			@nro_habitacion numeric(18,0),
			@cod_hotel int

	OPEN TrigInsCursor;

	FETCH NEXT FROM TrigInsCursor INTO @piso, @ubicacion, @cod_tipo_hab, @nro_habitacion, @cod_hotel

	WHILE @@FETCH_STATUS = 0
	BEGIN
	
		IF(@piso IS NULL OR
		   @ubicacion IS NULL OR
		   @cod_tipo_hab IS NULL OR
		   @nro_habitacion IS NULL OR
		   @cod_hotel IS NULL)
		   
		BEGIN
			INSERT INTO THE_FOREIGN_FOUR.HabitacionesDefectuosas (piso, ubicacion, cod_tipo_hab, nro_habitacion, cod_hotel)
			VALUES (@piso, @ubicacion, @cod_tipo_hab, @nro_habitacion, @cod_hotel);
		END	
		ELSE
		BEGIN
			INSERT INTO THE_FOREIGN_FOUR.Habitaciones (piso, ubicacion, cod_tipo_hab, nro_habitacion, cod_hotel)
			VALUES (@piso, @ubicacion, @cod_tipo_hab, @nro_habitacion, @cod_hotel);
		END			
			
		FETCH NEXT FROM TrigInsCursor INTO @piso, @ubicacion, @cod_tipo_hab, @nro_habitacion, @cod_hotel     

  END

  CLOSE TrigInsCursor;
  DEALLOCATE TrigInsCursor;

END
GO

--***********************************************

CREATE TRIGGER trg_facturas_error
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
		   @cod_estadia IS NULL OR
		   @fecha_factura > GETDATE())
		   
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

CREATE TRIGGER trg_clientes_por_estadia_err
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


--***********************************************
/*
CREATE TRIGGER trg_consumibles_por_estadia
ON THE_FOREIGN_FOUR.ConsumiblesPorEstadia
INSTEAD OF INSERT
AS
BEGIN

	DECLARE TrigInsCursor CURSOR FOR
	SELECT cod_consumible, cantidad, cod_estadia
	FROM inserted
	DECLARE @cod_consumible numeric(18,0),
			@cantidad numeric(18,0),
			@cod_estadia numeric(18,0)

	OPEN TrigInsCursor;

	FETCH NEXT FROM TrigInsCursor INTO @cod_consumible, @cantidad, @cod_estadia

	WHILE @@FETCH_STATUS = 0
	BEGIN
	
		IF(@cod_consumible IS NULL OR
		   @cantidad IS NULL OR
		   @cod_estadia IS NULL)
		
		BEGIN
			FETCH NEXT FROM TrigInsCursor INTO @cod_consumible, @cantidad, @cod_estadia
			CONTINUE
		END
		IF(EXISTS (SELECT	cpe.cod_consumible, cpe.cod_estadia
				   FROM		THE_FOREIGN_FOUR.ConsumiblesPorEstadia cpe
				   WHERE	@cod_estadia = cpe.cod_estadia
				   AND		@cod_consumible = cpe.cod_consumible))
		BEGIN
			UPDATE	THE_FOREIGN_FOUR.ConsumiblesPorEstadia
			SET		cantidad += 1
			WHERE	@cod_estadia = cod_estadia
			AND		@cod_consumible = cod_consumible
		END
		ELSE
		BEGIN
			INSERT INTO THE_FOREIGN_FOUR.ConsumiblesPorEstadia(cod_consumible, cantidad, cod_estadia)
			VALUES (@cod_consumible, @cantidad, @cod_estadia);
		END			
		
		FETCH NEXT FROM TrigInsCursor INTO @cod_consumible, @cantidad, @cod_estadia   

  END

  CLOSE TrigInsCursor;
  DEALLOCATE TrigInsCursor;

END
GO
*/
--*********************************************************

CREATE TRIGGER trg_itemsFactura_error
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
		   NOT EXISTS( SELECT cod_consumible
			FROM THE_FOREIGN_FOUR.Consumibles
			WHERE cod_consumible = @cod_consumible))
		   
		BEGIN
			INSERT INTO THE_FOREIGN_FOUR.ItemsFacturaDefectuosos (nro_factura, cantidad, cod_consumible)
			VALUES (@nro_factura, @cantidad, @cod_consumible);
		END	
		
		ELSE
		BEGIN
			INSERT INTO THE_FOREIGN_FOUR.ItemsFactura (nro_factura, cantidad, cod_consumible, descripcion)
			VALUES (@nro_factura, @cantidad, @cod_consumible, 
			(SELECT descripcion
			FROM THE_FOREIGN_FOUR.Consumibles
			WHERE cod_consumible = @cod_consumible));
		END			
			
		FETCH NEXT FROM TrigInsCursor INTO @nro_factura, @cantidad, @cod_consumible  

  END

  CLOSE TrigInsCursor;
  DEALLOCATE TrigInsCursor;

END
GO

/* -- este trigger hay que activarlo despues de la migracion

CREATE TRIGGER trg_items_descripcion
ON THE_FOREIGN_FOUR.ItemsFactura
AFTER INSERT
AS
BEGIN

	DECLARE TrigCursor CURSOR FOR
	SELECT cod_consumible
	FROM inserted
	DECLARE @cod_consumible numeric(18,0)
			
	OPEN TrigCursor;

	FETCH NEXT FROM TrigCursor INTO @cod_consumible
	WHILE @@FETCH_STATUS = 0
	BEGIN
	
		INSERT INTO THE_FOREIGN_FOUR.ItemsFactura (descripcion)
		SELECT descripcion
		FROM THE_FOREIGN_FOUR.Consumibles
		WHERE cod_consumible = @cod_consumible;
			
		FETCH NEXT FROM TrigCursor INTO @cod_consumible  

	END

  CLOSE TrigCursor;
  DEALLOCATE TrigCursor;

END
GO*/