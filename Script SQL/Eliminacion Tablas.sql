--******TABLAS******************
DROP TABLE THE_FOREIGN_FOUR.TipoHabitacion_Reservas
DROP TABLE THE_FOREIGN_FOUR.Habitaciones_Estadia
DROP TABLE THE_FOREIGN_FOUR.AuditoriaEstadias
DROP TABLE THE_FOREIGN_FOUR.UsuariosPorHotel
DROP TABLE THE_FOREIGN_FOUR.RegimenPorHotel
DROP TABLE THE_FOREIGN_FOUR.ClientePorEstadia 
DROP TABLE THE_FOREIGN_FOUR.ItemsFactura
DROP TABLE THE_FOREIGN_FOUR.ItemsFacturaDefectuosos
DROP TABLE THE_FOREIGN_FOUR.Consumibles
DROP TABLE THE_FOREIGN_FOUR.Facturas
DROP TABLE THE_FOREIGN_FOUR.FacturasDefectuosas
DROP TABLE THE_FOREIGN_FOUR.Estadias
DROP TABLE THE_FOREIGN_FOUR.EstadiasDefectuosas 
DROP TABLE THE_FOREIGN_FOUR.TiposPago 
DROP TABLE THE_FOREIGN_FOUR.Cancelaciones 
DROP TABLE THE_FOREIGN_FOUR.Reservas
DROP TABLE THE_FOREIGN_FOUR.ReservasDefectuosas 
DROP TABLE THE_FOREIGN_FOUR.EstadosReserva 
DROP TABLE THE_FOREIGN_FOUR.Habitaciones 
DROP TABLE THE_FOREIGN_FOUR.TipoHabitaciones 
DROP TABLE THE_FOREIGN_FOUR.Regimenes 
DROP TABLE THE_FOREIGN_FOUR.InactividadHoteles 
DROP TABLE THE_FOREIGN_FOUR.Clientes 
DROP TABLE THE_FOREIGN_FOUR.ClientesDefectuosos 
DROP TABLE THE_FOREIGN_FOUR.Usuarios 
DROP TABLE THE_FOREIGN_FOUR.Hoteles 
DROP TABLE THE_FOREIGN_FOUR.FuncionalidadPorRol 
DROP TABLE THE_FOREIGN_FOUR.Funcionalidades 
DROP TABLE THE_FOREIGN_FOUR.Roles 

--*******FUNC / PROC / VIEWS *****************
DROP FUNCTION THE_FOREIGN_FOUR.func_estado_reserva
DROP FUNCTION THE_FOREIGN_FOUR.fecha_sys
DROP FUNCTION THE_FOREIGN_FOUR.func_sgte_cod_reserva
DROP FUNCTION THE_FOREIGN_FOUR.func_sgte_nro_factura
DROP FUNCTION THE_FOREIGN_FOUR.func_obtener_cant_huespedes
DROP FUNCTION THE_FOREIGN_FOUR.func_validar_cliente
DROP FUNCTION THE_FOREIGN_FOUR.func_obtener_regimenes_hab 
DROP FUNCTION THE_FOREIGN_FOUR.func_hab_disponibles 
DROP FUNCTION THE_FOREIGN_FOUR.func_hay_disponibilidad 
DROP FUNCTION THE_FOREIGN_FOUR.login_password 
DROP FUNCTION THE_FOREIGN_FOUR.login_funcionalidades 
DROP FUNCTION THE_FOREIGN_FOUR.buscar_clientes 
DROP FUNCTION THE_FOREIGN_FOUR.obtener_tipo_habitaciones 
DROP FUNCTION THE_FOREIGN_FOUR.buscar_habitaciones
DROP FUNCTION THE_FOREIGN_FOUR.buscar_tipo_hab_hotel
DROP FUNCTION THE_FOREIGN_FOUR.func_validar_reserva
DROP FUNCTION THE_FOREIGN_FOUR.func_validar_reserva_no_cancelada 
DROP FUNCTION THE_FOREIGN_FOUR.func_validar_existe_reserva
DROP FUNCTION THE_FOREIGN_FOUR.func_validar_existe_reserva_no_cancelada 
DROP FUNCTION THE_FOREIGN_FOUR.func_hotel_inhabilitable 
DROP FUNCTION THE_FOREIGN_FOUR.buscar_regimenes_hotel
DROP FUNCTION THE_FOREIGN_FOUR.func_obtener_cod_usuario
DROP FUNCTION THE_FOREIGN_FOUR.func_check_out
DROP FUNCTION THE_FOREIGN_FOUR.func_igual_fecha
DROP FUNCTION THE_FOREIGN_FOUR.func_validar_hab_hotel
DROP FUNCTION THE_FOREIGN_FOUR.func_existe_huesped
DROP FUNCTION THE_FOREIGN_FOUR.func_existe_factura
DROP FUNCTION THE_FOREIGN_FOUR.func_validar_consumible
DROP PROCEDURE THE_FOREIGN_FOUR.proc_agregar_hab_reserva
DROP FUNCTION THE_FOREIGN_FOUR.func_calcular_precio
DROP FUNCTION THE_FOREIGN_FOUR.calcular_precio_estadia
DROP FUNCTION THE_FOREIGN_FOUR.func_get_precio
DROP PROCEDURE THE_FOREIGN_FOUR.proc_registrar_consumible
DROP PROCEDURE THE_FOREIGN_FOUR.proc_crear_factura
DROP PROCEDURE THE_FOREIGN_FOUR.proc_inhabilitar_usuario
DROP PROCEDURE THE_FOREING_FOUR.proc_inhabilitar_cliente
DROP PROCEDURE THE_FOREIGN_FOUR.proc_validar_check_in
DROP PROCEDURE THE_FOREIGN_FOUR.proc_inhabilitar_hotel
DROP PROCEDURE THE_FOREIGN_FOUR.proc_juego_datos
DROP PROCEDURE THE_FOREIGN_FOUR.proc_cancelar_reserva
DROP PROCEDURE THE_FOREIGN_FOUR.proc_registrar_cliente
DROP PROCEDURE THE_FOREIGN_FOUR.proc_registrar_huesped 
DROP PROCEDURE THE_FOREIGN_FOUR.proc_registrar_estadia 
DROP PROCEDURE THE_FOREIGN_FOUR.proc_modificar_reserva 
DROP PROCEDURE THE_FOREIGN_FOUR.proc_generar_reserva
DROP PROCEDURE THE_FOREIGN_FOUR.proc_eliminar_cliente 
DROP PROCEDURE THE_FOREIGN_FOUR.proc_inhabilitar_rol 
DROP PROCEDURE THE_FOREIGN_FOUR.proc_inhabilitar_habitacion  
DROP PROCEDURE THE_FOREIGN_FOUR.porc_insercion_estados_reserva
DROP PROCEDURE THE_FOREIGN_FOUR.proc_realizar_checkout
DROP VIEW THE_FOREIGN_FOUR.view_hoteles 
DROP VIEW THE_FOREIGN_FOUR.view_funcionalidades_rol 
DROP VIEW THE_FOREIGN_FOUR.view_roles_hoteles_usuarios 
DROP VIEW THE_FOREIGN_FOUR.view_todos_los_clientes 
DROP VIEW THE_FOREIGN_FOUR.view_tipo_hab
DROP VIEW THE_FOREIGN_FOUR.view_funcionalidades 
DROP VIEW THE_FOREIGN_FOUR.view_facturas
DROP FUNCTION THE_FOREIGN_FOUR.facturacion
DROP PROCEDURE THE_FOREIGN_FOUR.proc_actualizar_total_factura


DROP SCHEMA THE_FOREIGN_FOUR
