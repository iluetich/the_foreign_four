INSERT INTO THE_FOREIGN_FOUR.Clientes (nombre, apellido, fecha_nac, nom_calle, nro_calle, piso, depto, nacionalidad, nro_doc, mail)
SELECT DISTINCT Cliente_Nombre, Cliente_Apellido, Cliente_Fecha_Nac, Cliente_Dom_Calle, Cliente_Nro_Calle, Cliente_Piso, Cliente_Depto, Cliente_Nacionalidad, Cliente_Pasaporte_Nro, Cliente_Mail
FROM gd_esquema.Maestra

--*********************************************

INSERT INTO THE_FOREIGN_FOUR.Hoteles (nom_calle, ciudad, nro_calle, cant_estrellas, recarga_estrellas)
SELECT DISTINCT Hotel_Calle, Hotel_Ciudad, Hotel_Nro_Calle, Hotel_CantEstrella, Hotel_Recarga_Estrella
FROM gd_esquema.Maestra

--*********************************************

INSERT INTO THE_FOREIGN_FOUR.Regimenes (descripcion, precio)
SELECT DISTINCT Regimen_Descripcion, Regimen_Precio
FROM gd_esquema.Maestra

--*********************************************

INSERT INTO THE_FOREIGN_FOUR.TipoHabitaciones (cod_tipo_hab, descripcion, recargo)
SELECT DISTINCT Habitacion_Tipo_Codigo, Habitacion_Tipo_Descripcion, Habitacion_Tipo_Porcentual
FROM gd_esquema.Maestra

--*********************************************

INSERT INTO THE_FOREIGN_FOUR.Estadias (fecha_inicio, cant_noches)
SELECT DISTINCT Estadia_Fecha_Inicio,
				Estadia_Cant_Noches,
			    (SELECT nro_habitacion
				 FROM THE_FOREIGN_FOUR.Habitaciones ha JOIN THE_FOREIGN_FOUR.Hoteles ho ON(ha.cod_hotel = ho.cod_hotel)
													   JOIN THE_FOREIGN_FOUR.TipoHabitaciones t ON(ha.cod_tipo_hab = t.cod_tipo_hab)
				 WHERE  ha.nro_habitacion = m.Habitacion_Numero
				 AND	ha.ubicacion = m.Habitacion_Frente
				 AND	ha.cod_tipo_hab = m.Habitacion_Tipo_Codigo
				 AND	ha.piso = m.Habitacion_Piso
				 AND	t.recargo = m.Habitacion_Tipo_Porcentual
				 AND	t.descripcion = m.Habitacion_Tipo_Descripcion)
FROM gd_esquema.Maestra m

--*********************************************

INSERT INTO THE_FOREIGN_FOUR.Reservas (cod_reserva, fecha_desde, cant_noches, cod_hotel, cod_cliente )
SELECT	DISTINCT m.Reserva_Codigo,
		m.Reserva_Fecha_Inicio,
		m.Reserva_Cant_Noches,
		(SELECT cod_hotel
		FROM THE_FOREIGN_FOUR.Hoteles h
		WHERE	h.nom_calle = m.Hotel_Calle
		AND		h.nro_calle = m.Hotel_Nro_Calle
		AND		h.ciudad = m.Hotel_Ciudad
		AND		h.cant_estrellas = m.Hotel_CantEstrella
		AND		h.recarga_estrellas = m.Hotel_Recarga_Estrella),
		(SELECT cod_cliente
		FROM THE_FOREIGN_FOUR.Clientes c
		WHERE	c.nombre = m.Cliente_Nombre
		AND		c.apellido = m.Cliente_Apellido
		AND		c.nro_doc = m.Cliente_Pasaporte_Nro
		AND		c.fecha_nac = m.Cliente_Fecha_Nac
		AND		c.mail = m.Cliente_Mail
		AND		c.nom_calle = m.Cliente_Dom_Calle
		AND		c.nro_calle = m.Cliente_Nro_Calle
		AND		c.piso = m.Cliente_Piso
		AND		c.depto = m.Cliente_Depto
		AND		c.nacionalidad = m.Cliente_Nacionalidad)
FROM gd_esquema.Maestra m
