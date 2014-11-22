CREATE SCHEMA THE_FOREIGN_FOUR AUTHORIZATION gd

CREATE TABLE THE_FOREIGN_FOUR.Roles (
	cod_rol				numeric(18,0)			IDENTITY(1,1) PRIMARY KEY,
	nombre				nvarchar(30)			UNIQUE,
	estado				char(1)					DEFAULT 'H' CHECK(estado IN ('H', 'I')),
)
CREATE TABLE THE_FOREIGN_FOUR.Funcionalidades (
	cod_funcion			numeric(18,0)			IDENTITY (1,1) PRIMARY KEY,
	nombre				varchar(60)				UNIQUE,
)
CREATE TABLE THE_FOREIGN_FOUR.FuncionalidadPorRol (
	cod_funcion			numeric(18,0)			REFERENCES THE_FOREIGN_FOUR.Funcionalidades,
	cod_rol				numeric(18,0)			REFERENCES THE_FOREIGN_FOUR.Roles,
	PRIMARY KEY(cod_funcion, cod_rol)
)
CREATE TABLE THE_FOREIGN_FOUR.Hoteles (
	cod_hotel			numeric(18,0)			IDENTITY(1,1) PRIMARY KEY,			
	nombre				nvarchar(60),
	mail				nvarchar(60),
	telefono			nvarchar(30),
	nro_calle			numeric(18,0),
	nom_calle			nvarchar(255),
	cant_estrellas		numeric(18,0),
	ciudad				nvarchar(255),
	pais				nvarchar(30),
	fecha_creacion		datetime,
	recarga_estrellas	numeric(18,0),
	baja_logica			char(1)					DEFAULT 'N' CHECK(baja_logica IN ('S', 'N')),
	estado				char(1)					DEFAULT 'H' CHECK(estado IN ('H', 'I')),
)
CREATE TABLE THE_FOREIGN_FOUR.Usuarios (
	cod_usuario			numeric(18,0)			IDENTITY(1,1) PRIMARY KEY,
	user_name			nvarchar(30)			UNIQUE,
	password			nvarchar(255),
	nombre				nvarchar(60),
	apellido			nvarchar(60),
	tipo_doc			nvarchar(3)				DEFAULT 'PAS' CHECK(tipo_doc IN ('DNI', 'PAS')),
	nro_doc				numeric(18,0),
	mail				nvarchar(60),			--saco los unique ya que no es necesario para los usuarios
	telefono			nvarchar(60),
	direccion			nvarchar(60),
	fecha_nac			datetime,
	baja_logica			char(1)					DEFAULT 'N' CHECK(baja_logica IN ('S', 'N')),
	estado				char(1)					DEFAULT 'H' CHECK(estado IN ('H', 'I')),
)
CREATE TABLE THE_FOREIGN_FOUR.Clientes (
	cod_cliente			numeric(18,0)			IDENTITY(1,1) PRIMARY KEY,
	nombre				nvarchar(255),
	apellido			nvarchar(255),
	tipo_doc			varchar(3)				DEFAULT 'PAS' CHECK(tipo_doc IN ('DNI', 'PAS')),
	nro_doc				numeric(18,0)			UNIQUE,
	mail				nvarchar(255)			UNIQUE,
	telefono			nvarchar(60),
	nom_calle			nvarchar(255),
	nro_calle			numeric(18,0),
	pais_origen			nvarchar(255),
	localidad			nvarchar(255),
	nacionalidad		nvarchar(255),
	piso				numeric(18,0),
	depto				nvarchar(50),
	fecha_nac			datetime,
	estado				char(1)					DEFAULT 'H' CHECK(estado IN ('H', 'I')),
	baja_logica			char(1)					DEFAULT 'N'	CHECK(baja_logica IN ('S', 'N')) --Si el usuario elimina un cliente
																							 --NO se borra nunca fisicamente
)
CREATE TABLE THE_FOREIGN_FOUR.ClientesDefectuosos (
	cod_cliente			numeric(18,0)			IDENTITY(1,1) PRIMARY KEY,
	nombre				nvarchar(255),
	apellido			nvarchar(255),
	tipo_doc			varchar(3),
	nro_doc				numeric(18,0),
	mail				nvarchar(255),
	telefono			nvarchar(60),
	nom_calle			nvarchar(255),
	nro_calle			numeric(18,0),
	pais_origen			nvarchar(60),
	nacionalidad		nvarchar(255),
	piso				numeric(18,0),
	depto				nvarchar(50),
	fecha_nac			datetime,
)
CREATE TABLE THE_FOREIGN_FOUR.InactividadHoteles (
	cod_tarea			numeric(18,0)			IDENTITY(1,1) PRIMARY KEY,
	cod_hotel			numeric(18,0)			REFERENCES THE_FOREIGN_FOUR.Hoteles,
	descripcion			nvarchar(255),
	fecha_desde			datetime,
	fecha_hasta			datetime,
)
CREATE TABLE THE_FOREIGN_FOUR.Regimenes (
	cod_regimen			numeric(18,0)			IDENTITY(1,1) PRIMARY KEY,
	precio				numeric(18,2),
	descripcion			nvarchar(255),
	estado				char(1)					DEFAULT 'H' CHECK(estado IN ('H', 'I')),
)
CREATE TABLE THE_FOREIGN_FOUR.TipoHabitaciones (
	cod_tipo_hab		numeric(18,0)			PRIMARY KEY,
	descripcion			nvarchar(255),
	recargo				numeric (18,2),
)
CREATE TABLE THE_FOREIGN_FOUR.Habitaciones (
	cod_habitacion		numeric(18,0)			PRIMARY KEY IDENTITY(1,1),
	cod_hotel			numeric(18,0)			REFERENCES THE_FOREIGN_FOUR.Hoteles,
	cod_tipo_hab		numeric(18,0)			REFERENCES THE_FOREIGN_FOUR.TipoHabitaciones,
	nro_habitacion		numeric(18,0),
	piso				numeric(18,0),
	ubicacion			nvarchar(50),
	descripcion			nvarchar(255), 		
	estado				char(1)					DEFAULT 'H' CHECK(estado IN ('H', 'I')),
)
CREATE TABLE THE_FOREIGN_FOUR.EstadosReserva (
	cod_estado			numeric(18,0)			IDENTITY(1,1) PRIMARY KEY,
	descripcion			varchar(255),
)
CREATE TABLE THE_FOREIGN_FOUR.Reservas (
	cod_reserva			numeric(18,0)			PRIMARY KEY,
	cod_hotel			numeric(18,0)			REFERENCES THE_FOREIGN_FOUR.Hoteles,
	cod_cliente			numeric(18,0)			REFERENCES THE_FOREIGN_FOUR.Clientes,
	cod_regimen			numeric(18,0)			REFERENCES THE_FOREIGN_FOUR.Regimenes,
	cod_estado_reserva	numeric(18,0)			REFERENCES THE_FOREIGN_FOUR.EstadosReserva,
	fecha_creacion		datetime,
	fecha_desde			datetime,
	fecha_hasta			datetime,
	cant_noches			int,
	usuario				nvarchar(255)
)
CREATE TABLE THE_FOREIGN_FOUR.ReservasDefectuosas (
	cod_reserva			numeric(18,0)			PRIMARY KEY,
	cod_hotel			numeric(18,0),
	cod_cliente			numeric(18,0),
	cod_regimen			numeric(18,0),
	fecha_creacion		datetime,
	fecha_desde			datetime,
	fecha_hasta			datetime,
	cant_noches			int,
)
CREATE TABLE THE_FOREIGN_FOUR.Cancelaciones (
	cod_cancelacion		numeric(18,0)			PRIMARY KEY IDENTITY(1,1),
	cod_reserva			numeric(18,0)			REFERENCES THE_FOREIGN_FOUR.Reservas,
	usuario				numeric(18,0)			REFERENCES THE_FOREIGN_FOUR.Usuarios,
	motivo				varchar(255),
	fecha_operacion		datetime
)
CREATE TABLE THE_FOREIGN_FOUR.Estadias (
	cod_estadia			numeric(18,0)			IDENTITY (1,1) PRIMARY KEY,
	cod_reserva			numeric(18,0)			REFERENCES THE_FOREIGN_FOUR.Reservas,
	fecha_inicio		datetime,
	cant_noches			numeric(18,0),
	checkout			datetime
)
CREATE TABLE THE_FOREIGN_FOUR.EstadiasDefectuosas (
	cod_estadia			numeric(18,0)			IDENTITY (1,1) PRIMARY KEY,
	cod_reserva			numeric(18,0)			REFERENCES THE_FOREIGN_FOUR.Reservas,
	fecha_inicio		datetime,
	cant_noches			numeric(18,0),
)
CREATE TABLE THE_FOREIGN_FOUR.TiposPago (
	cod_tipo_pago		numeric(18,0)			IDENTITY(1,1) PRIMARY KEY,
	descripcion			nvarchar(255),
)
CREATE TABLE THE_FOREIGN_FOUR.Pagos (
	cod_pago			numeric(18,0)			PRIMARY KEY IDENTITY(1,1),
	cod_tipo_pago		numeric(18,0)			REFERENCES THE_FOREIGN_FOUR.TiposPago,
	nro_tarjeta			nvarchar(30),
	nro_factura			numeric(18,0)			UNIQUE,
	fecha_pago			datetime				DEFAULT GETDATE(),
)
CREATE TABLE THE_FOREIGN_FOUR.Facturas (
	nro_factura			numeric(18,0)			PRIMARY KEY,
	cod_estadia			numeric(18,0)			REFERENCES THE_FOREIGN_FOUR.Estadias,
	cod_pago			numeric(18,0)			REFERENCES THE_FOREIGN_FOUR.Pagos,
	cod_cliente			numeric(18,0)			REFERENCES THE_FOREIGN_FOUR.Clientes,
	fecha_factura		datetime,
	total				numeric(18,2),
)
CREATE TABLE THE_FOREIGN_FOUR.FacturasDefectuosas (
	nro_factura			numeric(18,0),
	cod_estadia			numeric(18,0),
	cod_tipo_pago		numeric(18,0),
	fecha_factura		datetime,
	total				numeric(18,2),
)
CREATE TABLE THE_FOREIGN_FOUR.Consumibles (
	cod_consumible		numeric(18,0)			PRIMARY KEY,
	descripcion			nvarchar(255),
	precio				numeric(18,2),
)
CREATE TABLE THE_FOREIGN_FOUR.ClientePorEstadia (
	cod_estadia			numeric(18,0)			REFERENCES THE_FOREIGN_FOUR.Estadias,
	cod_cliente			numeric(18,0)			REFERENCES THE_FOREIGN_FOUR.Clientes,
	PRIMARY KEY (cod_estadia, cod_cliente)
)
CREATE TABLE THE_FOREIGN_FOUR.ItemsFactura (
	nro_item			numeric(18,0)			IDENTITY(1,1) PRIMARY KEY,
	nro_factura			numeric(18,0)			REFERENCES THE_FOREIGN_FOUR.Facturas,
	cod_consumible		numeric(18,0)			REFERENCES THE_FOREIGN_FOUR.Consumibles,
	cantidad			int			
)
CREATE TABLE THE_FOREIGN_FOUR.ItemsFacturaDefectuosos (
	nro_item			numeric(18,0)			IDENTITY(1,1) PRIMARY KEY,
	nro_factura			numeric(18,0),
	cod_consumible		numeric(18,0),
	cantidad			int,
)
CREATE TABLE THE_FOREIGN_FOUR.RegimenPorHotel (
	cod_hotel			numeric(18,0)			REFERENCES THE_FOREIGN_FOUR.Hoteles,
	cod_regimen			numeric(18,0)			REFERENCES THE_FOREIGN_FOUR.Regimenes
	PRIMARY KEY (cod_hotel, cod_regimen)
)
CREATE TABLE THE_FOREIGN_FOUR.UsuariosPorHotel (
	cod_usuario			numeric(18,0)			REFERENCES THE_FOREIGN_FOUR.Usuarios,
	cod_hotel			numeric(18,0)			REFERENCES THE_FOREIGN_FOUR.Hoteles,
	cod_rol				numeric(18,0)			REFERENCES THE_FOREIGN_FOUR.Roles
	PRIMARY KEY(cod_usuario, cod_hotel)
)
CREATE TABLE THE_FOREIGN_FOUR.Habitaciones_Estadia (
	cod_hab_estadia		numeric(18,0)			PRIMARY KEY IDENTITY(1,1),
	cod_estadia			numeric(18,0)			REFERENCES THE_FOREIGN_FOUR.Estadias,
	cod_habitacion		numeric(18,0)			REFERENCES THE_FOREIGN_FOUR.Habitaciones
)
CREATE TABLE THE_FOREIGN_FOUR.TipoHabitacion_Reservas (
	cod_hab_reserva		numeric(18,0)			PRIMARY KEY IDENTITY(1,1),
	cod_reserva			numeric(18,0)			REFERENCES THE_FOREIGN_FOUR.Reservas,
	cod_tipo_hab		numeric(18,0)			REFERENCES THE_FOREIGN_FOUR.TipoHabitaciones,
)
CREATE TABLE THE_FOREIGN_FOUR.AuditoriaEstadias (
	cod_audit			int						IDENTITY(1,1) PRIMARY KEY,
	cod_usuario			numeric(18,0)			REFERENCES THE_FOREIGN_FOUR.Usuarios,
	cod_estadia			numeric(18,0)			REFERENCES THE_FOREIGN_FOUR.Estadias,
	cod_operacion		char(1)					CHECK(cod_operacion IN ('I', 'O')),
	fecha				datetime				DEFAULT getdate()
)
CREATE TABLE THE_FOREIGN_FOUR.Consumibles_Estadia (
	cod_estadia			numeric(18,0)			REFERENCES THE_FOREIGN_FOUR.Estadias,
	cod_consumible		numeric(18,0)			REFERENCES THE_FOREIGN_FOUR.Consumibles,
	cantidad			int,
)
GO
CREATE NONCLUSTERED INDEX idx_fecha_factura ON THE_FOREIGN_FOUR.Facturas (fecha_factura)

