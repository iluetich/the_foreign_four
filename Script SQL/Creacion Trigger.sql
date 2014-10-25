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
			@mail nvarchar(255),
			@baja_logica char(1)

	OPEN TrigInsCursor;

	FETCH NEXT FROM TrigInsCursor INTO @nombre, @apellido, @fecha_nac, @nom_calle, @nro_calle, @piso, @depto, @nacionalidad, @nro_doc, @mail

	WHILE @@FETCH_STATUS = 0
	BEGIN
	
		IF(NOT EXISTS (SELECT nro_doc
					   FROM THE_FOREIGN_FOUR.Clientes
					   WHERE nro_doc = @nro_doc
					   OR mail = @mail))
		BEGIN
				SET @baja_logica = 'N'
		END	
		ELSE
		BEGIN 
				SET @baja_logica = 'S'
		END
		
		INSERT INTO THE_FOREIGN_FOUR.Clientes (nombre, apellido, fecha_nac, nom_calle, nro_calle, piso, depto, nacionalidad, nro_doc, mail, baja_logica)
		VALUES (@nombre, @apellido, @fecha_nac, @nom_calle, @nro_calle, @piso, @depto, @nacionalidad, @nro_doc, @mail, @baja_logica)
		
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
			@cant_noches int,
			@baja_logica char(1)
			
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
				SET @baja_logica = 'S'
		END	
		ELSE
		BEGIN 
				SET @baja_logica = 'N'
		END
			
		INSERT INTO THE_FOREIGN_FOUR.Reservas(cod_reserva, cod_hotel, cod_cliente, cod_tipo_hab, 
						cod_regimen, cod_estado_reserva, fecha_creacion, fecha_desde, fecha_hasta, cant_noches, baja_logica)
		VALUES (@cod_reserva, @cod_hotel, @cod_cliente, @cod_tipo_hab, @cod_regimen, 
					@cod_estado_reserva, @fecha_creacion, @fecha_desde, @fecha_hasta, @cant_noches, @baja_logica);
			
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
			@cant_noches numeric(18,0),
			@baja_logica char(1)

	OPEN TrigInsCursor;

	FETCH NEXT FROM TrigInsCursor INTO @cod_reserva, @nro_habitacion, @fecha_inicio, @cant_noches

	WHILE @@FETCH_STATUS = 0
	BEGIN
	
		IF(@cod_reserva IS NULL OR
		   @nro_habitacion IS NULL OR
		   @fecha_inicio IS NULL OR
		   @cant_noches IS NULL OR
		   EXISTS (SELECT cod_estadia
					   FROM THE_FOREIGN_FOUR.Estadias
					   WHERE cod_reserva = @cod_reserva
					   AND nro_habitacion = @nro_habitacion
					   AND fecha_inicio = @fecha_inicio
					   AND cant_noches = @cant_noches))
		   
		BEGIN
				SET @baja_logica = 'N'
		END	
		ELSE
		BEGIN 
				SET @baja_logica = 'S'
		END
			
		INSERT INTO THE_FOREIGN_FOUR.Estadias (cod_reserva, nro_habitacion, fecha_inicio, cant_noches, baja_logica)
		VALUES (@cod_reserva, @nro_habitacion, @fecha_inicio, @cant_noches, @baja_logica);
			
		FETCH NEXT FROM TrigInsCursor INTO @cod_reserva, @nro_habitacion, @fecha_inicio, @cant_noches      

  END

  CLOSE TrigInsCursor;
  DEALLOCATE TrigInsCursor;

END
GO

--*****************************************************

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
			@cod_hotel int,
			@baja_logica char(1)

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
				SET @baja_logica = 'S'
		END	
		ELSE
		BEGIN 
				SET @baja_logica = 'N'
		END
		
		INSERT INTO THE_FOREIGN_FOUR.Habitaciones (piso, ubicacion, cod_tipo_hab, nro_habitacion, cod_hotel, baja_logica)
		VALUES (@piso, @ubicacion, @cod_tipo_hab, @nro_habitacion, @cod_hotel, @baja_logica);
			
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
			@cod_estadia numeric(18,0),
			@baja_logica char(1)

	OPEN TrigInsCursor;

	FETCH NEXT FROM TrigInsCursor INTO @nro_factura, @fecha_factura, @total, @cod_estadia

	WHILE @@FETCH_STATUS = 0
	BEGIN
	
		IF(@nro_factura IS NULL OR
		   @fecha_factura IS NULL OR
		   @total IS NULL OR
		   @cod_estadia IS NULL)
		   		   
		BEGIN
				SET @baja_logica = 'S'
		END
		ELSE	
		BEGIN 
				SET @baja_logica = 'N'
		END
			
		INSERT INTO THE_FOREIGN_FOUR.Facturas (nro_factura, fecha_factura, total, cod_estadia, baja_logica)
		VALUES (@nro_factura, @fecha_factura, @total, @cod_estadia, @baja_logica);
			
		FETCH NEXT FROM TrigInsCursor INTO @nro_factura, @fecha_factura, @total, @cod_estadia     

  END

  CLOSE TrigInsCursor;
  DEALLOCATE TrigInsCursor;

END
GO

--********************************************

CREATE TRIGGER trg_itemsFactura_error
ON THE_FOREIGN_FOUR.ItemsFactura
INSTEAD OF INSERT
AS
BEGIN

	DECLARE TrigInsCursor CURSOR FOR
	SELECT nro_factura, descripcion, cantidad, precio_unitario
	FROM inserted
	DECLARE @nro_factura numeric(18,0),
			@descripcion nvarchar(255),
			@cantidad numeric(18,0),
			@precio_unitario numeric(18,2),
			@baja_logica char(1)

	OPEN TrigInsCursor;

	FETCH NEXT FROM TrigInsCursor INTO @nro_factura, @descripcion, @cantidad, @precio_unitario

	WHILE @@FETCH_STATUS = 0
	BEGIN
		
		IF(	@nro_factura IS NULL OR
			@cantidad IS NULL OR
			@precio_unitario IS NULL)
			--si todo es null, no tiene uso potencial alguno ingresar filas nulas
			--a una tabla auxiliar
			
		BEGIN
				SET @baja_logica = 'S'
		END	
		ELSE
		BEGIN 
				SET @baja_logica = 'N'
		END
		
		INSERT INTO THE_FOREIGN_FOUR.ItemsFactura(nro_factura, descripcion, cantidad, precio_unitario, baja_logica)
		VALUES (@nro_factura, @descripcion, @cantidad, @precio_unitario, @baja_logica);
			
		FETCH NEXT FROM TrigInsCursor INTO @nro_factura, @descripcion, @cantidad, @precio_unitario     

  END

  CLOSE TrigInsCursor;
  DEALLOCATE TrigInsCursor;

END
GO
