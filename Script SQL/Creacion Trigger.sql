CREATE TRIGGER THE_FOREIGN_FOUR.trg_clientes_error
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

CREATE TRIGGER THE_FOREIGN_FOUR.trg_reservas_error
ON THE_FOREIGN_FOUR.Reservas
INSTEAD OF INSERT
AS
BEGIN

	DECLARE TrigInsCursor CURSOR FOR
	SELECT cod_reserva, cod_hotel, cod_cliente, cod_regimen, /*cod_estado_reserva,*/ fecha_creacion, 
		   fecha_desde, fecha_hasta, cant_noches  
	FROM inserted
	DECLARE @cod_reserva numeric(18,0),
			@cod_hotel int,
			@cod_cliente numeric(18,0),
			@cod_regimen int,
			/*@cod_estado_reserva int,*/
			@fecha_creacion datetime, 
			@fecha_desde datetime,
			@fecha_hasta datetime,
			@cant_noches int,
			@fecha_sys datetime
			
			
	SET @fecha_sys = (SELECT MAX(Estadia_Fecha_Inicio + Estadia_Cant_Noches)
						FROM gd_esquema.Maestra)
	
	OPEN TrigInsCursor;

	FETCH NEXT FROM TrigInsCursor INTO	@cod_reserva, @cod_hotel,@cod_cliente, @cod_regimen, 
										/*@cod_estado_reserva,*/ @fecha_creacion, @fecha_desde, @fecha_hasta, @cant_noches

	WHILE @@FETCH_STATUS = 0
	BEGIN
	
		IF(	@cod_hotel IS NULL OR
			@cod_cliente IS NULL OR
			@cod_regimen IS NULL OR
			@fecha_desde IS NULL OR
			@cant_noches IS NULL)
			
		BEGIN
			INSERT INTO THE_FOREIGN_FOUR.ReservasDefectuosas (cod_reserva, cod_hotel, cod_cliente, 
						cod_regimen, fecha_creacion, fecha_desde, fecha_hasta, cant_noches)
			VALUES (@cod_reserva, @cod_hotel, @cod_cliente, @cod_regimen, 
					@fecha_creacion, @fecha_desde, @fecha_hasta, @cant_noches);
		END	
		ELSE
		BEGIN
			INSERT INTO THE_FOREIGN_FOUR.Reservas(cod_reserva, cod_hotel, cod_cliente, 
						cod_regimen, cod_estado_reserva, fecha_creacion, fecha_desde, fecha_hasta, cant_noches)
			VALUES (@cod_reserva, @cod_hotel, @cod_cliente, @cod_regimen, 
					(SELECT THE_FOREIGN_FOUR.func_estado_reserva(@fecha_desde, @fecha_sys)), 
					@fecha_creacion, @fecha_desde, @fecha_hasta, @cant_noches);
		END			
			
		FETCH NEXT FROM TrigInsCursor INTO	@cod_reserva, @cod_hotel,@cod_cliente, @cod_regimen, 
											/*@cod_estado_reserva,*/ @fecha_creacion, @fecha_desde, @fecha_hasta, @cant_noches      

  END

  CLOSE TrigInsCursor;
  DEALLOCATE TrigInsCursor;

END
GO

--*****************************************************

CREATE TRIGGER THE_FOREIGN_FOUR.trg_estadias_error
ON THE_FOREIGN_FOUR.Estadias
INSTEAD OF INSERT
AS
BEGIN

	DECLARE TrigInsCursor CURSOR FOR
	SELECT cod_reserva, fecha_inicio, cant_noches
	FROM inserted
	DECLARE @cod_reserva numeric(18,0),
			@nro_habitacion numeric(18,0),
			@fecha_inicio datetime,
			@cant_noches numeric(18,0)

	OPEN TrigInsCursor;

	FETCH NEXT FROM TrigInsCursor INTO @cod_reserva, @fecha_inicio, @cant_noches

	WHILE @@FETCH_STATUS = 0
	BEGIN
	
		IF(@cod_reserva IS NULL OR
		   @fecha_inicio IS NULL OR
		   @cant_noches IS NULL)
		   
		BEGIN
			INSERT INTO THE_FOREIGN_FOUR.EstadiasDefectuosas (cod_reserva, fecha_inicio, cant_noches)
			VALUES (@cod_reserva, @fecha_inicio, @cant_noches);
		END	
		ELSE
		BEGIN
		
			INSERT INTO THE_FOREIGN_FOUR.Estadias (cod_reserva, fecha_inicio, cant_noches)
			VALUES (@cod_reserva, @fecha_inicio, @cant_noches);

		END			
			
		FETCH NEXT FROM TrigInsCursor INTO @cod_reserva, @fecha_inicio, @cant_noches      

  END

  CLOSE TrigInsCursor;
  DEALLOCATE TrigInsCursor;

END
GO

--*****************************************************

CREATE TRIGGER THE_FOREIGN_FOUR.trg_facturas_error
ON THE_FOREIGN_FOUR.Facturas
INSTEAD OF INSERT
AS
BEGIN

	DECLARE TrigInsCursor CURSOR FOR
	SELECT nro_factura, fecha_factura, total, cod_cliente, cod_estadia
	FROM inserted
	DECLARE @nro_factura numeric(18,0),
			@fecha_factura datetime,
			@total numeric(18,2),
			@cod_cliente numeric(18,0),
			@cod_estadia numeric(18,0)

	OPEN TrigInsCursor;

	FETCH NEXT FROM TrigInsCursor INTO @nro_factura, @fecha_factura, @total, @cod_cliente, @cod_estadia

	WHILE @@FETCH_STATUS = 0
	BEGIN
	
		IF(@nro_factura IS NULL OR
		   @fecha_factura IS NULL OR
		   @total IS NULL OR
		   @cod_cliente IS NULL OR
		   @cod_estadia IS NULL)
		   		   
		BEGIN
			INSERT INTO THE_FOREIGN_FOUR.FacturasDefectuosas (nro_factura, fecha_factura, total, cod_estadia)
			VALUES (@nro_factura, @fecha_factura, @total, @cod_estadia);
		END	
		ELSE
		BEGIN
			INSERT INTO THE_FOREIGN_FOUR.Facturas (nro_factura, fecha_factura, total, cod_cliente, cod_estadia)
			VALUES (@nro_factura, @fecha_factura, @total, @cod_cliente, @cod_estadia);
		END			
			
		FETCH NEXT FROM TrigInsCursor INTO @nro_factura, @fecha_factura, @total, @cod_cliente, @cod_estadia     

  END

  CLOSE TrigInsCursor;
  DEALLOCATE TrigInsCursor;

END
GO


--***********************************************

CREATE TRIGGER THE_FOREIGN_FOUR.trg_clientes_por_estadia_err
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

--*********************************************************

CREATE TRIGGER THE_FOREIGN_FOUR.trg_itemsFactura_error
ON THE_FOREIGN_FOUR.ItemsFactura
INSTEAD OF INSERT
AS
BEGIN

	DECLARE TrigInsCursor CURSOR FOR
	SELECT nro_factura, cantidad, cod_consumible, importe
	FROM inserted
	DECLARE @nro_factura numeric(18,0),
			@cantidad numeric(18,0),
			@cod_consumible numeric(18,0),
			@importe decimal
			
	OPEN TrigInsCursor;

	FETCH NEXT FROM TrigInsCursor INTO @nro_factura, @cantidad, @cod_consumible, @importe
	WHILE @@FETCH_STATUS = 0
	BEGIN
	
		IF(@nro_factura IS NULL OR
		   @cantidad IS NULL OR
		   @importe IS NULL OR
		   NOT EXISTS (SELECT cod_consumible
					   FROM THE_FOREIGN_FOUR.Consumibles
					   WHERE cod_consumible = @cod_consumible))
		   
		BEGIN
			INSERT INTO THE_FOREIGN_FOUR.ItemsFacturaDefectuosos (nro_factura, cantidad, cod_consumible, importe)
			VALUES (@nro_factura, @cantidad, @cod_consumible, @importe);
		END	
		
		ELSE
		BEGIN
			
			INSERT INTO THE_FOREIGN_FOUR.ItemsFactura (nro_factura, cantidad, cod_consumible, importe)
			VALUES (@nro_factura, @cantidad, @cod_consumible, @importe)
		END			
			
		FETCH NEXT FROM TrigInsCursor INTO @nro_factura, @cantidad, @cod_consumible, @importe

  END

  CLOSE TrigInsCursor;
  DEALLOCATE TrigInsCursor;

END
GO


--******************
CREATE TRIGGER THE_FOREIGN_FOUR.trg_tipohab_reservas
ON THE_FOREIGN_FOUR.TipoHabitacion_Reservas
INSTEAD OF INSERT
AS
BEGIN

	DECLARE TrigInsCursor CURSOR FOR
	SELECT cod_reserva, cod_tipo_hab
	FROM inserted
	DECLARE @cod_reserva numeric(18,0),
			@cod_tipo_hab numeric(18,0)
			
	OPEN TrigInsCursor;

	FETCH NEXT FROM TrigInsCursor INTO @cod_reserva, @cod_tipo_hab
	WHILE @@FETCH_STATUS = 0
	BEGIN
	
		IF(@cod_reserva IS NULL OR
		   @cod_tipo_hab IS NULL)
		BEGIN
			FETCH NEXT FROM TrigInsCursor INTO @cod_reserva, @cod_tipo_hab
			CONTINUE
		END
		ELSE
		BEGIN
			INSERT INTO THE_FOREIGN_FOUR.TipoHabitacion_Reservas (cod_reserva, cod_tipo_hab)
			VALUES (@cod_reserva, @cod_tipo_hab)
		END	
			
		FETCH NEXT FROM TrigInsCursor INTO @cod_reserva, @cod_tipo_hab 

  END

  CLOSE TrigInsCursor;
  DEALLOCATE TrigInsCursor;

END
GO
--****************************************************************

CREATE TRIGGER THE_FOREIGN_FOUR.trg_habitaciones_estadia
ON THE_FOREIGN_FOUR.Habitaciones_Estadia
INSTEAD OF INSERT
AS
BEGIN

	DECLARE TrigInsCursor CURSOR FOR
	SELECT cod_estadia, cod_habitacion
	FROM inserted
	DECLARE @cod_estadia numeric(18,0),
			@cod_habitacion numeric(18,0)
			
	OPEN TrigInsCursor;

	FETCH NEXT FROM TrigInsCursor INTO @cod_estadia, @cod_habitacion
	WHILE @@FETCH_STATUS = 0
	BEGIN
	
		IF(@cod_estadia IS NULL OR
		   @cod_habitacion IS NULL)
		BEGIN
			FETCH NEXT FROM TrigInsCursor INTO @cod_estadia, @cod_habitacion
			CONTINUE
		END
		ELSE
		BEGIN
			INSERT INTO THE_FOREIGN_FOUR.Habitaciones_Estadia (cod_estadia, cod_habitacion)
			VALUES (@cod_estadia, @cod_habitacion)
		END	
			
		FETCH NEXT FROM TrigInsCursor INTO @cod_estadia, @cod_habitacion 

  END

  CLOSE TrigInsCursor;
  DEALLOCATE TrigInsCursor;

END
GO
