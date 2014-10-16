INSERT INTO THE_FOREIGN_FOUR.Clientes (nombre, apellido, fecha_nac, nom_calle, nro_calle, piso, depto, nacionalidad, nro_doc, mail)
SELECT DISTINCT Cliente_Nombre, Cliente_Apellido, Cliente_Fecha_Nac, Cliente_Dom_Calle, Cliente_Nro_Calle, Cliente_Piso, Cliente_Depto, Cliente_Nacionalidad, Cliente_Pasaporte_Nro, Cliente_Mail
FROM gd_esquema.Maestra
