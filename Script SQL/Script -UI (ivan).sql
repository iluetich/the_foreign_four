CREATE PROCEDURE THE_FOREIGN_FOUR.proc_juego_datos
AS
BEGIN
	INSERT INTO THE_FOREIGN_FOUR.EstadosReserva(descripcion)
	VALUES	('correcta'),
			('modificada'),
			('cancelacion_recepcion'),
			('cancelacion_cliente'),
			('cancelacion_noshow'),
			('efectivizada')
	INSERT INTO THE_FOREIGN_FOUR.Usuarios(user_name, password)
	VALUES	('admin', 'w23b')
	INSERT INTO THE_FOREIGN_FOUR.Roles(nombre)
	VALUES	('administrador'),
			('recepcionista'),
			('guest')
	INSERT INTO THE_FOREIGN_FOUR.Funcionalidades(nombre)
	VALUES	('login'),
			('abm_rol'),
			('abm_usuario'),
			('abm_cliente'),
			('abm_hotel'),
			('abm_habitacion'),
			('generar_modificar_reserva'),
			('cancelar_reserva'),
			('registrar_estadia'),
			('registrar_consumible'),
			('facturar_estadia'),
			('listado_estadistico')
	INSERT INTO THE_FOREIGN_FOUR.FuncionalidadPorRol(cod_rol, cod_funcion)
	VALUES	(1,1), (1,2), (1,3), (1,4), (1,5), (1,6), (1,7), (1,8), (1,9), (1,10), (1,11), (1,12),
			(2,1), (2,4), (2,7), (2,8), (2,9), (2,10),
			(3,7), (3,8)
	INSERT INTO THE_FOREIGN_FOUR.RegimenPorHotel(cod_hotel, cod_regimen)
	VALUES	(1,1), (1,2), (1,3), (1,4),
			(2,1), (2,2), (2,3), (2,4),
			(3,1), (3,2), (3,3), (3,4),
			(4,1), (4,2), (4,3), (4,4),
			(5,1), (5,2), (5,3), (5,4),
			(6,1), (6,2), (6,3), (6,4),
			(7,1), (7,2), (7,3), (7,4),
			(8,1), (8,2), (8,3), (8,4),
			(9,1), (9,2), (9,3), (9,4),
			(10,1), (10,2), (10,3), (10,4),
			(11,1), (11,2), (11,3), (11,4),
			(12,1), (12,2), (12,3), (12,4),
			(13,1), (13,2), (13,3), (13,4),
			(14,1), (14,2), (14,3), (14,4),
			(15,1), (15,2), (15,3), (15,4),
			(16,1), (16,2), (16,3), (16,4)
	INSERT INTO THE_FOREIGN_FOUR.UsuariosPorHotel(cod_usuario, cod_hotel, cod_rol)
	VALUES	(1, 1, 1), (1, 2, 1), (1, 3, 1), (1, 4, 1), (1, 5, 1), 
			(1, 6, 1), (1, 7, 1), (1, 8, 1), (1, 9, 1), (1, 10, 1),
			(1, 11, 1), (1, 12, 1), (1, 13, 1), (1, 14, 1), (1, 15, 1), 
			(1, 16, 1)
END	

