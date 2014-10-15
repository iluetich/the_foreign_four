SELECT DISTINCT Cliente_Nombre AS 'Nombre',
				Cliente_Apellido AS 'Apellido' , 
				Cliente_Fecha_Nac AS 'Nacimiento',
				Cliente_Pasaporte_Nro AS 'Pasaporte', 
				Cliente_Mail AS 'e-mail'
FROM gd_esquema.Maestra
ORDER BY 1,2

SELECT DISTINCT Hotel_Calle AS 'Calle',
				Hotel_Nro_Calle AS 'NroCalle',
				Hotel_Ciudad AS 'Ciudad',
				Hotel_CantEstrella AS 'Estrellas',
				Hotel_Recarga_Estrella AS 'Recarga'
FROM gd_esquema.Maestra
ORDER BY 1,2

SELECT DISTINCT Reserva_Codigo AS 'Código',
				Reserva_Fecha_Inicio AS 'Inicio',
				Reserva_Cant_Noches AS 'Noches'
FROM gd_esquema.Maestra
ORDER BY 1

SELECT DISTINCT Factura_Nro AS 'NroFactura',
				Factura_Fecha AS 'Fecha',
				Factura_Total AS 'Total'
FROM gd_esquema.Maestra
ORDER BY 1,3


SELECT DISTINCT Estadia_Fecha_Inicio AS 'Inicio',
				Estadia_Cant_Noches AS 'Noches'
FROM gd_esquema.Maestra
ORDER BY 1,2

-------------------------------------------------------<<<

SELECT DISTINCT Factura_Nro AS 'NroFactura',
				Cliente_Nombre AS 'Nombre',
				Cliente_Apellido AS 'Apellido',
				Cliente_Pasaporte_Nro AS 'Pasaporte',
				Factura_Fecha AS 'Fecha',
				Factura_Total AS 'Total'
FROM gd_esquema.Maestra
ORDER BY NroFactura, Pasaporte, Apellido
