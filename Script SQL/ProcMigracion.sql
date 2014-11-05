--Nuevo Script de migracion sin triggers

CREATE PROCEDURE proc_migracion
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
	IF(NOT EXISTS (SELECT nro_doc
					FROM THE_FOREIGN_FOUR.Clientes
					WHERE nro_doc = @Cliente_Pasaporte_Nro
					OR mail = @Cliente_Mail))
	BEGIN
		INSERT INTO THE_FOREIGN_FOUR.Clientes (nombre, apellido, fecha_nac, 
					nom_calle, nro_calle, piso, depto, nacionalidad, tipo_doc, nro_doc, mail)
		VALUES(	@Cliente_Nombre, @Cliente_Apellido, @Cliente_Fecha_Nac, @Cliente_Dom_Calle,
				@Cliente_Nro_Calle, @Cliente_Piso, @Cliente_Depto, @Cliente_Nacionalidad,
				'PAS', @Cliente_Pasaporte_Nro, @Cliente_Mail)
	END
	ELSE
		BEGIN
		INSERT INTO THE_FOREIGN_FOUR.ClientesDefectuosos (nombre, apellido, fecha_nac, 
					nom_calle, nro_calle, piso, depto, nacionalidad, nro_doc, mail)
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
	
--****HOTELES******************
	INSERT INTO THE_FOREIGN_FOUR.Hoteles (nom_calle, ciudad, nro_calle, cant_estrellas, recarga_estrellas)
	VALUES (@Hotel_Calle, @Hotel_Ciudad, @Hotel_Nro_Calle, @Hotel_CantEstrella, @Hotel_Recarga_Estrella)

--***REGIMENES****************
	INSERT INTO THE_FOREIGN_FOUR.Regimenes (descripcion, precio)
	VALUES (@Regimen_Descripcion, @Regimen_Precio)
	
--***TIPO_HABITACIONES**********
	INSERT INTO THE_FOREIGN_FOUR.TipoHabitaciones (cod_tipo_hab, descripcion, recargo)
	VALUES (@Habitacion_Tipo_Codigo, @Habitacion_Tipo_Descripcion, @Habitacion_Tipo_Porcentual)
	
--***CONSUMIBLES****************
	IF(@Consumible_Descripcion IS NOT NULL AND @Consumible_Descripcion IS NOT NULL)
	BEGIN
		INSERT INTO THE_FOREIGN_FOUR.Consumibles (cod_consumible, descripcion, precio)
		VALUES( @Consumible_Codigo, @Consumible_Descripcion, @Consumible_Descripcion)
	END


--******VRIABLES***********
DECLARE @cod_hotel numeric(18,0),
		@cod_cliente numeric(18,0),
		@cod_regimen numeric(18,0)

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
				

--***HABITACIONES**************
	INSERT INTO THE_FOREIGN_FOUR.Habitaciones (piso, ubicacion, cod_tipo_hab, nro_habitacion, cod_hotel)
	VALUES (@Habitacion_Piso, @Habitacion_Frente, @Habitacion_Tipo_Codigo, @Habitacion_Numero,@cod_hotel)
			 
--***RESERVAS*****************

	IF(	@cod_hotel IS NULL OR
		@Habitacion_Tipo_Codigo IS NULL OR
		@Reserva_Fecha_Inicio IS NULL OR
		@Reserva_Cant_Noches IS NULL)
		
		BEGIN
			INSERT INTO THE_FOREIGN_FOUR.ReservasDefectuosas (cod_reserva, cod_hotel, cod_cliente, 
						cod_tipo_hab, cod_regimen, fecha_creacion, fecha_desde, fecha_hasta, cant_noches)
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
GO

