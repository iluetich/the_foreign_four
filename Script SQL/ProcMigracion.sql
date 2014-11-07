--Nuevo Script de migracion sin triggers

--*********migracion de datos ppdicha************
CREATE PROCEDURE THE_FOREIGN_FOUR.proc_migracion
AS

DECLARE CursorMigracion CURSOR FOR 
SELECT	Hotel_Ciudad, Hotel_Calle, Hotel_Nro_Calle, Hotel_CantEstrella, Hotel_Recarga_Estrella,
		Habitacion_Numero, Habitacion_Piso, Habitacion_Frente, 
		Habitacion_Tipo_Codigo,Habitacion_Tipo_Descripcion, Habitacion_Tipo_Porcentual,
		Regimen_Descripcion, Regimen_Precio,
		Reserva_Codigo, Reserva_Fecha_Inicio, Reserva_Cant_Noches,
		Estadia_Cant_Noches, Estadia_Fecha_Inicio,
		Consumible_Codigo, Consumible_Descripcion, Consumible_Precio,
		Item_Factura_Cantidad, Item_Factura_Monto,
		Factura_Nro, Factura_Fecha, Factura_Total,
		Cliente_Apellido, Cliente_Depto, Cliente_Dom_Calle, Cliente_Fecha_Nac, Cliente_Mail, 
		Cliente_Nacionalidad, Cliente_Nombre, Cliente_Nro_Calle, Cliente_Pasaporte_Nro, Cliente_Piso
FROM gd_esquema.Maestra m

DECLARE @Hotel_Ciudad nvarchar(255),
		@Hotel_Calle nvarchar(255),
		@Hotel_Nro_Calle numeric(18,0), 
		@Hotel_CantEstrella numeric(18,0), 
		@Hotel_Recarga_Estrella numeric(18,0),
		@Habitacion_Numero numeric(18,0), 
		@Habitacion_Piso numeric(18,0), 
		@Habitacion_Frente nvarchar(50), 
		@Habitacion_Tipo_Codigo numeric(18,0),
		@Habitacion_Tipo_Descripcion nvarchar(255), 
		@Habitacion_Tipo_Porcentual numeric(18,2),
		@Regimen_Descripcion nvarchar(255),  
		@Regimen_Precio numeric(18,2),
		@Reserva_Codigo numeric(18,0), 
		@Reserva_Fecha_Inicio datetime, 
		@Reserva_Cant_Noches numeric(18,0),
		@Estadia_Cant_Noches numeric(18,0), 
		@Estadia_Fecha_Inicio datetime,
		@Consumible_Codigo numeric(18,0), 
		@Consumible_Descripcion nvarchar(255),  
		@Consumible_Precio numeric(18,2),
		@Item_Factura_Cantidad numeric(18,0), 
		@Item_Factura_Monto numeric(18,2),
		@Factura_Nro numeric(18,0), 
		@Factura_Fecha datetime, 
		@Factura_Total numeric(18,2),
		@Cliente_Apellido nvarchar(255), 
		@Cliente_Depto nvarchar(50), 
		@Cliente_Dom_Calle nvarchar(255), 
		@Cliente_Fecha_Nac datetime, 
		@Cliente_Mail nvarchar(255), 
		@Cliente_Nacionalidad nvarchar(255), 
		@Cliente_Nombre nvarchar(255), 
		@Cliente_Nro_Calle numeric(18,0), 
		@Cliente_Pasaporte_Nro numeric(18,0), 
		@Cliente_Piso numeric(18,0)


OPEN CursorMigracion;
FETCH NEXT FROM CursorMigracion 
INTO	@Hotel_Ciudad,@Hotel_Calle,@Hotel_Nro_Calle, @Hotel_CantEstrella, @Hotel_Recarga_Estrella,
		@Habitacion_Numero, @Habitacion_Piso, @Habitacion_Frente, 
		@Habitacion_Tipo_Codigo, @Habitacion_Tipo_Descripcion, @Habitacion_Tipo_Porcentual,
		@Regimen_Descripcion, @Regimen_Precio, 
		@Reserva_Codigo, @Reserva_Fecha_Inicio, @Reserva_Cant_Noches,
		@Estadia_Cant_Noches, @Estadia_Fecha_Inicio,
		@Consumible_Codigo, @Consumible_Descripcion, @Consumible_Precio,
		@Item_Factura_Cantidad, @Item_Factura_Monto,
		@Factura_Nro, @Factura_Fecha, @Factura_Total,
		@Cliente_Apellido, @Cliente_Depto, @Cliente_Dom_Calle, @Cliente_Fecha_Nac, @Cliente_Mail, 
		@Cliente_Nacionalidad, @Cliente_Nombre, @Cliente_Nro_Calle, @Cliente_Pasaporte_Nro, @Cliente_Piso

WHILE @@FETCH_STATUS = 0
BEGIN

--******Clientes********
	IF(NOT EXISTS (SELECT cod_cliente
					FROM THE_FOREIGN_FOUR.Clientes
					WHERE nro_doc = @Cliente_Pasaporte_Nro
					AND mail = @Cliente_Mail))
	BEGIN 

		IF(NOT EXISTS (SELECT nro_doc
						FROM THE_FOREIGN_FOUR.Clientes
						WHERE nro_doc = @Cliente_Pasaporte_Nro
						OR mail = @Cliente_Mail))
		BEGIN
			INSERT INTO THE_FOREIGN_FOUR.Clientes (nombre, apellido, fecha_nac, 
						nom_calle, nro_calle, piso, depto, nacionalidad, tipo_doc, nro_doc, mail, estado, baja_logica)
			VALUES(	@Cliente_Nombre, @Cliente_Apellido, @Cliente_Fecha_Nac, @Cliente_Dom_Calle,
					@Cliente_Nro_Calle, @Cliente_Piso, @Cliente_Depto, @Cliente_Nacionalidad,
					'PAS', @Cliente_Pasaporte_Nro, @Cliente_Mail, 'H', 'N')
		END
		ELSE
			BEGIN
			INSERT INTO THE_FOREIGN_FOUR.ClientesDefectuosos (nombre, apellido, fecha_nac, 
						nom_calle, nro_calle, piso, depto, nacionalidad, tipo_doc, nro_doc, mail)
			VALUES(	@Cliente_Nombre, @Cliente_Apellido, @Cliente_Fecha_Nac, @Cliente_Dom_Calle,
					@Cliente_Nro_Calle, @Cliente_Piso, @Cliente_Depto, @Cliente_Nacionalidad,
					'PAS', @Cliente_Pasaporte_Nro, @Cliente_Mail)
			END


		FETCH NEXT FROM CursorMigracion 
		INTO	@Hotel_Ciudad,@Hotel_Calle,@Hotel_Nro_Calle, @Hotel_CantEstrella, @Hotel_Recarga_Estrella,
				@Habitacion_Numero, @Habitacion_Piso, @Habitacion_Frente, 
				@Habitacion_Tipo_Codigo, @Habitacion_Tipo_Descripcion, @Habitacion_Tipo_Porcentual,
				@Regimen_Descripcion, @Regimen_Precio, 
				@Reserva_Codigo, @Reserva_Fecha_Inicio, @Reserva_Cant_Noches,
				@Estadia_Cant_Noches, @Estadia_Fecha_Inicio,
				@Consumible_Codigo, @Consumible_Descripcion, @Consumible_Precio,
				@Item_Factura_Cantidad, @Item_Factura_Monto,
				@Factura_Nro, @Factura_Fecha, @Factura_Total,
				@Cliente_Apellido, @Cliente_Depto, @Cliente_Dom_Calle, @Cliente_Fecha_Nac, @Cliente_Mail, 
				@Cliente_Nacionalidad, @Cliente_Nombre, @Cliente_Nro_Calle, @Cliente_Pasaporte_Nro, @Cliente_Piso
			
	END
	
--****HOTELES******************
	IF(NOT EXISTS (SELECT cod_hotel
					FROM THE_FOREIGN_FOUR.Hoteles
					WHERE ciudad = @Hotel_Ciudad
					AND nro_calle = @Hotel_Nro_Calle
					AND nom_calle = @Hotel_Calle))
	BEGIN
		INSERT INTO THE_FOREIGN_FOUR.Hoteles (nom_calle, ciudad, nro_calle, cant_estrellas, recarga_estrellas, baja_logica, estado)
		VALUES (@Hotel_Calle, @Hotel_Ciudad, @Hotel_Nro_Calle, @Hotel_CantEstrella, @Hotel_Recarga_Estrella, 'N', 'H')
	END
--***REGIMENES****************
	IF(NOT EXISTS (SELECT cod_regimen
					FROM THE_FOREIGN_FOUR.Regimenes
					WHERE descripcion = @Regimen_Descripcion))
	BEGIN
		INSERT INTO THE_FOREIGN_FOUR.Regimenes (descripcion, precio, estado)
		VALUES (@Regimen_Descripcion, @Regimen_Precio, 'H')
	END
--***TIPO_HABITACIONES**********
	IF(NOT EXISTS (SELECT cod_tipo_hab
					FROM THE_FOREIGN_FOUR.TipoHabitaciones
					WHERE cod_tipo_hab = @Habitacion_Tipo_Codigo))
	BEGIN
		INSERT INTO THE_FOREIGN_FOUR.TipoHabitaciones (cod_tipo_hab, descripcion, recargo)
		VALUES (@Habitacion_Tipo_Codigo, @Habitacion_Tipo_Descripcion, @Habitacion_Tipo_Porcentual)
	END
--***CONSUMIBLES****************
	IF(NOT EXISTS (SELECT cod_consumible
					FROM THE_FOREIGN_FOUR.Consumibles
					WHERE cod_consumible = @Consumible_Codigo))
	BEGIN
		IF(@Consumible_Descripcion IS NOT NULL AND @Consumible_Descripcion IS NOT NULL)
		BEGIN
			INSERT INTO THE_FOREIGN_FOUR.Consumibles (cod_consumible, descripcion, precio)
			VALUES( @Consumible_Codigo, @Consumible_Descripcion, @Consumible_Descripcion)
		END
	END
	
--****VARIABLES**************************
DECLARE @cod_hotel numeric(18,0),
		@cod_cliente numeric(18,0),
		@cod_regimen numeric(18,0),
		@cod_estadia numeric(18,0),
		@cod_consumible numeric(18,0) 

SET @cod_hotel =(SELECT cod_hotel
				FROM THE_FOREIGN_FOUR.Hoteles ho
				WHERE	ho.ciudad = @Hotel_Ciudad
				AND ho.nom_calle = @Hotel_Calle
				AND ho.nro_calle = @Hotel_Nro_Calle)
				
SET @cod_cliente = (SELECT cod_cliente
					FROM THE_FOREIGN_FOUR.Clientes c
					WHERE	c.nro_doc = @Cliente_Pasaporte_Nro
					AND		c.mail = @Cliente_Mail)

SET @cod_regimen = (SELECT cod_regimen
					FROM THE_FOREIGN_FOUR.Regimenes r
					WHERE r.descripcion = @Regimen_Descripcion 
					AND r.precio = @Regimen_Precio)
				
SET @cod_estadia = (SELECT cod_estadia
					FROM THE_FOREIGN_FOUR.Estadias e
					WHERE	e.cod_reserva = @Reserva_Codigo)

SET @cod_consumible = (SELECT cod_consumible
					   FROM THE_FOREIGN_FOUR.Consumibles
					   WHERE cod_consumible = @cod_consumible)				
					
--***HABITACIONES**************
	IF(NOT EXISTS(SELECT nro_habitacion
					FROM THE_FOREIGN_FOUR.Habitaciones
					WHERE cod_hotel = @cod_hotel
					AND nro_habitacion = @Habitacion_Numero))
	BEGIN
		IF(@Habitacion_Piso IS NULL OR
		   @Habitacion_Frente IS NULL OR
		   @Habitacion_Tipo_Codigo IS NULL OR
		   @Habitacion_Numero IS NULL OR
		   @cod_hotel IS NULL)
			BEGIN
				INSERT INTO THE_FOREIGN_FOUR.HabitacionesDefectuosas (piso, ubicacion, cod_tipo_hab, nro_habitacion, cod_hotel)
				VALUES (@Habitacion_Piso, @Habitacion_Frente, @Habitacion_Tipo_Codigo, @Habitacion_Numero,@cod_hotel);
			END
		ELSE
			BEGIN
				INSERT INTO THE_FOREIGN_FOUR.Habitaciones (piso, ubicacion, cod_tipo_hab, nro_habitacion, cod_hotel, estado)
				VALUES (@Habitacion_Piso, @Habitacion_Frente, @Habitacion_Tipo_Codigo, @Habitacion_Numero,@cod_hotel, 'H');
			END
	END
	
--***RESERVAS*****************
	IF(NOT EXISTS (SELECT cod_reserva
					FROM THE_FOREIGN_FOUR.Reservas
					WHERE cod_reserva = @Reserva_Codigo))
	BEGIN				
		IF(	@cod_hotel IS NULL OR
			@Habitacion_Tipo_Codigo IS NULL OR
			@Reserva_Fecha_Inicio IS NULL OR
			@Reserva_Cant_Noches IS NULL)
		
			BEGIN
				INSERT INTO THE_FOREIGN_FOUR.ReservasDefectuosas (cod_reserva, fecha_desde, cant_noches,
							 cod_tipo_hab, cod_hotel, cod_cliente, cod_regimen, fecha_hasta)
				VALUES(@Reserva_Codigo, @Reserva_Fecha_Inicio, @Reserva_Cant_Noches, @Habitacion_Tipo_Codigo, @cod_hotel,
						@cod_cliente, @cod_regimen,	@Reserva_Fecha_Inicio + @Reserva_Cant_Noches)
			END
		ELSE
			BEGIN
				INSERT INTO THE_FOREIGN_FOUR.Reservas (cod_reserva, fecha_desde, cant_noches, cod_tipo_hab, cod_hotel, cod_cliente, 
														cod_regimen, fecha_hasta)
				VALUES (@Reserva_Codigo, @Reserva_Fecha_Inicio, @Reserva_Cant_Noches, @Habitacion_Tipo_Codigo, @cod_hotel,
						@cod_cliente, @cod_regimen,	@Reserva_Fecha_Inicio + @Reserva_Cant_Noches)
			END
	END	
	
--****ESTADIAS***************
	IF(NOT EXISTS (SELECT cod_estadia
					FROM THE_FOREIGN_FOUR.Estadias
					WHERE cod_reserva = @Reserva_Codigo))
	BEGIN
	
		IF(@Reserva_Codigo IS NULL OR
		   @Habitacion_Numero IS NULL OR
		   @Estadia_Fecha_Inicio IS NULL OR
		   @Estadia_Cant_Noches IS NULL)
			BEGIN
				INSERT INTO THE_FOREIGN_FOUR.EstadiasDefectuosas(fecha_inicio, cant_noches, nro_habitacion, cod_reserva)
				VALUES (@Estadia_Fecha_Inicio, @Estadia_Cant_Noches, @Habitacion_Numero, @Reserva_Codigo)	
			END
		ELSE
			BEGIN
				INSERT INTO THE_FOREIGN_FOUR.Estadias(fecha_inicio, cant_noches, nro_habitacion, cod_reserva)
				VALUES (@Estadia_Fecha_Inicio, @Estadia_Cant_Noches, @Habitacion_Numero, @Reserva_Codigo)
			END
	END	

--***FACTURAS****************
	IF(NOT EXISTS (SELECT nro_factura
					FROM THE_FOREIGN_FOUR.Facturas
					WHERE nro_factura = @Factura_Nro))
	BEGIN	
		IF(@Factura_Nro IS NULL OR
		   @Factura_Fecha IS NULL OR
		   @Factura_Total IS NULL OR
		   @cod_estadia IS NULL)
		   		   
			BEGIN
				INSERT INTO THE_FOREIGN_FOUR.FacturasDefectuosas (nro_factura, fecha_factura, total, cod_estadia)			
				VALUES (@Factura_Nro, @Factura_Fecha, @Factura_Total, @cod_estadia)
			END
		ELSE
			BEGIN
				INSERT INTO THE_FOREIGN_FOUR.Facturas (nro_factura, fecha_factura, total, cod_estadia)	
				VALUES(@Factura_Nro, @Factura_Fecha, @Factura_Total, @cod_estadia)
			END
	END
	
--***ITEMS FACTURA***********
	IF(NOT EXISTS(SELECT nro_factura, cod_consumible
					FROM THE_FOREIGN_FOUR.ItemsFactura))
	BEGIN
		IF(@Consumible_Descripcion IS NULL OR
		   @Factura_Nro IS NULL OR
		   @Item_Factura_Cantidad IS NULL OR
		   @cod_consumible IS NULL)
			BEGIN
				INSERT INTO THE_FOREIGN_FOUR.ItemsFacturaDefectuosos (nro_factura, cantidad, cod_consumible, descripcion)
				VALUES (@Factura_Nro, @Item_Factura_Cantidad, @cod_consumible, @Consumible_Descripcion);
			END	
		ELSE
			BEGIN
				INSERT INTO THE_FOREIGN_FOUR.ItemsFactura (nro_factura, cantidad, cod_consumible, descripcion)
				VALUES (@Factura_Nro, @Item_Factura_Cantidad, @cod_consumible, @Consumible_Descripcion);
			END
	END
	
--****CLIENTES POR ESTADIA***********
	IF(NOT EXISTS(SELECT cod_cliente
					FROM THE_FOREIGN_FOUR.ClientePorEstadia
					WHERE cod_cliente = @cod_cliente
					AND cod_estadia = @cod_estadia))
	BEGIN
		IF(@cod_estadia IS NOT NULL)
		BEGIN	
			INSERT INTO THE_FOREIGN_FOUR.ClientePorEstadia (cod_cliente, cod_estadia)
			VALUES (@cod_cliente, @cod_estadia)
		END
	END

	FETCH NEXT FROM CursorMigracion 
	INTO	@Hotel_Ciudad,@Hotel_Calle,@Hotel_Nro_Calle, @Hotel_CantEstrella, @Hotel_Recarga_Estrella,
			@Habitacion_Numero, @Habitacion_Piso, @Habitacion_Frente, 
			@Habitacion_Tipo_Codigo, @Habitacion_Tipo_Descripcion, @Habitacion_Tipo_Porcentual,
			@Regimen_Descripcion, @Regimen_Precio, 
			@Reserva_Codigo, @Reserva_Fecha_Inicio, @Reserva_Cant_Noches,
			@Estadia_Cant_Noches, @Estadia_Fecha_Inicio,
			@Consumible_Codigo, @Consumible_Descripcion, @Consumible_Precio,
			@Item_Factura_Cantidad, @Item_Factura_Monto,
			@Factura_Nro, @Factura_Fecha, @Factura_Total,
			@Cliente_Apellido, @Cliente_Depto, @Cliente_Dom_Calle, @Cliente_Fecha_Nac, @Cliente_Mail, 
			@Cliente_Nacionalidad, @Cliente_Nombre, @Cliente_Nro_Calle, @Cliente_Pasaporte_Nro, @Cliente_Piso
END
CLOSE CursorMigracion
DEALLOCATE CursorMigracion

GO

EXEC THE_FOREIGN_FOUR.proc_migracion
EXEC THE_FOREIGN_FOUR.proc_juego_datos