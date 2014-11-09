EXEC THE_FOREIGN_FOUR.porc_insercion_estados_reserva

--***CLIENTES********************************

INSERT INTO THE_FOREIGN_FOUR.Clientes (nombre, apellido, fecha_nac, nom_calle, nro_calle, piso, depto, nacionalidad, nro_doc, mail)
SELECT DISTINCT Cliente_Nombre, Cliente_Apellido, Cliente_Fecha_Nac, Cliente_Dom_Calle, Cliente_Nro_Calle, Cliente_Piso, Cliente_Depto, Cliente_Nacionalidad, Cliente_Pasaporte_Nro, Cliente_Mail
FROM gd_esquema.Maestra

--***HOTELES***********************************

INSERT INTO THE_FOREIGN_FOUR.Hoteles (nom_calle, ciudad, nro_calle, cant_estrellas, recarga_estrellas)
SELECT DISTINCT Hotel_Calle, Hotel_Ciudad, Hotel_Nro_Calle, Hotel_CantEstrella, Hotel_Recarga_Estrella
FROM gd_esquema.Maestra

--***REGIMENES********************************

INSERT INTO THE_FOREIGN_FOUR.Regimenes (descripcion, precio)
SELECT DISTINCT Regimen_Descripcion, Regimen_Precio
FROM gd_esquema.Maestra

--***TIPO HABITACIONES***************************

INSERT INTO THE_FOREIGN_FOUR.TipoHabitaciones (cod_tipo_hab, descripcion, recargo)
SELECT DISTINCT Habitacion_Tipo_Codigo, Habitacion_Tipo_Descripcion, Habitacion_Tipo_Porcentual
FROM gd_esquema.Maestra

--***CONSUMIBLES**************************************

INSERT INTO THE_FOREIGN_FOUR.Consumibles (cod_consumible, descripcion, precio)
SELECT DISTINCT Consumible_Codigo, Consumible_Descripcion, Consumible_Precio
FROM gd_esquema.Maestra
WHERE Consumible_Codigo IS NOT NULL
AND Consumible_Descripcion IS NOT NULL

--***HABITACIONES**************************************

INSERT INTO THE_FOREIGN_FOUR.Habitaciones (piso, ubicacion, cod_tipo_hab, nro_habitacion, cod_hotel)
SELECT DISTINCT Habitacion_Piso,
				Habitacion_Frente, 
				Habitacion_Tipo_Codigo, 
				Habitacion_Numero, 
			   (SELECT cod_hotel
			    FROM THE_FOREIGN_FOUR.Hoteles ho
			    WHERE	ho.ciudad = m.Hotel_Ciudad
			    AND		ho.nom_calle = m.Hotel_Calle
			    AND		ho.nro_calle = m.Hotel_Nro_Calle
			    AND		ho.cant_estrellas = m.Hotel_CantEstrella
			    AND		ho.recarga_estrellas = m.Hotel_Recarga_Estrella) AS 'cod_hotel'
FROM gd_esquema.Maestra m

--***RESERVAS***************************************

INSERT INTO THE_FOREIGN_FOUR.Reservas	(cod_reserva, fecha_desde, cant_noches, cod_hotel, cod_cliente, cod_tipo_hab,
										 cod_regimen, fecha_hasta)
SELECT	DISTINCT m.Reserva_Codigo,
		m.Reserva_Fecha_Inicio,
		m.Reserva_Cant_Noches,
		
	   (SELECT cod_hotel
		FROM THE_FOREIGN_FOUR.Hoteles h
		WHERE	h.nom_calle = m.Hotel_Calle
		AND		h.nro_calle = m.Hotel_Nro_Calle
		AND		h.ciudad = m.Hotel_Ciudad
		AND		h.cant_estrellas = m.Hotel_CantEstrella
		AND		h.recarga_estrellas = m.Hotel_Recarga_Estrella) AS 'cod_hotel',
		
       (SELECT cod_cliente
		FROM THE_FOREIGN_FOUR.Clientes c
		WHERE	c.nro_doc = m.Cliente_Pasaporte_Nro
		AND		c.mail = m.Cliente_Mail),
				
		m.Habitacion_Tipo_Codigo,
		
		(SELECT cod_regimen
		FROM THE_FOREIGN_FOUR.Regimenes r
		WHERE r.descripcion = m.Regimen_Descripcion
		AND r.precio = m.Regimen_Precio) AS 'cod_regimen',
		
		--hay que hacer una funcion o procedure para establecer el codigo de estado de reserva
		
		(m.Reserva_Fecha_Inicio + m.Reserva_Cant_Noches) AS 'fecha_hasta'
FROM gd_esquema.Maestra m

--***ESTADIAS***************************************
--no hace falta validar todos los datos de la reserva mas que el codigo, ni el tipo porque ya esta implicito en el cod_reserva
--Tampoco hace falta la validacion de los datos del hotel ya que tambien se encuentran implicitos en la reserva

INSERT INTO THE_FOREIGN_FOUR.Estadias (fecha_inicio, cant_noches, nro_habitacion, cod_reserva)
SELECT DISTINCT  m.Estadia_Fecha_Inicio,
				 m.Estadia_Cant_Noches,
			     m.Habitacion_Numero,
				 (SELECT cod_reserva
				 FROM THE_FOREIGN_FOUR.Reservas r
				 WHERE	r.cod_reserva = m.Reserva_Codigo) AS 'cod_reserva'
FROM gd_esquema.Maestra m


--***FACTURAS***************************************

INSERT INTO THE_FOREIGN_FOUR.Facturas (nro_factura, fecha_factura, total, cod_estadia)
SELECT DISTINCT	m.Factura_Nro,
				m.Factura_Fecha,
				m.Factura_Total,
				(SELECT cod_estadia
				FROM THE_FOREIGN_FOUR.Estadias e
				WHERE	e.cod_reserva = m.Reserva_Codigo)
FROM gd_esquema.Maestra m

--***ITEMS FACTURAS***************************************
INSERT INTO THE_FOREIGN_FOUR.ItemsFactura (cantidad, cod_consumible, nro_factura)
SELECT m.Item_Factura_Cantidad, 
	   m.Consumible_Codigo,
	   (SELECT nro_factura
		FROM THE_FOREIGN_FOUR.Facturas f
		WHERE	m.Factura_Nro = f.nro_factura)
FROM gd_esquema.Maestra m


--***CLIENTES POR ESTADIA***************************************

INSERT INTO THE_FOREIGN_FOUR.ClientePorEstadia (cod_cliente, cod_estadia)
SELECT DISTINCT (SELECT c.cod_cliente
				 FROM THE_FOREIGN_FOUR.Clientes c
				 WHERE	c.nro_doc = m.Cliente_Pasaporte_Nro
				 AND	c.mail = m.Cliente_Mail),
				(SELECT e.cod_estadia
				 FROM THE_FOREIGN_FOUR.Estadias e
				 WHERE	e.fecha_inicio = m.Estadia_Fecha_Inicio
				 AND	e.cant_noches = m.Estadia_Cant_Noches
				 AND	e.cod_reserva = m.Reserva_Codigo)
FROM gd_esquema.Maestra m


--***JUEGO DE DATOS************************************************
EXEC THE_FOREIGN_FOUR.proc_juego_datos

--** ELIMINACION DE LOS TRIGGERS*******************************
DROP TRIGGER THE_FOREIGN_FOUR.trg_clientes_error
DROP TRIGGER THE_FOREIGN_FOUR.trg_reservas_error
DROP TRIGGER THE_FOREIGN_FOUR.trg_estadias_error
DROP TRIGGER THE_FOREIGN_FOUR.trg_facturas_error
DROP TRIGGER THE_FOREIGN_FOUR.trg_clientes_por_estadia_err
DROP TRIGGER THE_FOREIGN_FOUR.trg_itemsFactura_error

