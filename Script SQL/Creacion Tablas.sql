CREATE TABLE THE_FOREIGN_FOUR.Roles (
	cod_rol				int					IDENTITY(1,1) PRIMARY KEY,
	nombre				varchar(30),
	estado				char(1)					DEFAULT 'H' CHECK(estado IN ('H', 'I')),
)
CREATE TABLE THE_FOREIGN_FOUR.Funcionalidades (
	cod_funcion			int					IDENTITY (1,1) PRIMARY KEY,
	nombre				varchar(60),
)
CREATE TABLE THE_FOREIGN_FOUR.FuncionalidadPorRol (
	cod_funcion			int					REFERENCES THE_FOREIGN_FOUR.Funcionalidades,
	cod_rol				int					REFERENCES THE_FOREIGN_FOUR.Roles,
	PRIMARY KEY(cod_funcion, cod_rol)
)
CREATE TABLE THE_FOREIGN_FOUR.Hoteles (
	cod_hotel			int 					IDENTITY(1,1) PRIMARY KEY,			
	nombre				varchar(30),
	mail				varchar(60),
	telefono			varchar(30),
	nro_calle			bigint,
	nom_calle			varchar(255),
	cant_estrellas			int,
	ciudad				varchar(255),
	pais				varchar(30),
	fecha_creacion			datetime,
	recarga_estrellas		numeric(18,0),
	baja_logica			char(1)					DEFAULT 'N' CHECK(baja_logica IN ('S', 'N')),
	estado				char(1)					DEFAULT 'H' CHECK(estado IN ('H', 'I')),
)
CREATE TABLE THE_FOREIGN_FOUR.Usuarios (
	cod_usuario			numeric(18,0)				IDENTITY(1,1) PRIMARY KEY,
	cod_rol				int					REFERENCES THE_FOREIGN_FOUR.Roles,
	cod_hotel			int					REFERENCES THE_FOREIGN_FOUR.Hoteles,
	user_name			varchar(30),
	password			varchar(30),
	nombre				varchar(60),
	apellido			varchar(60),
	tipo_doc			varchar(3)				DEFAULT 'PAS' CHECK(tipo_doc IN ('DNI', 'PAS')),
	nro_doc				numeric(18,0),
	mail				varchar(60),
	telefono			varchar(60),
	direccion			varchar(60),
	fecha_nac			datetime,
	baja_logica			char(1)					DEFAULT 'N' CHECK(baja_logica IN ('S', 'N')),
	estado				char(1)					DEFAULT 'H' CHECK(estado IN ('H', 'I')),
)
CREATE TABLE THE_FOREIGN_FOUR.Clientes (
	cod_cliente			numeric(18,0)				IDENTITY(1,1) PRIMARY KEY,
	nombre				varchar(255),
	apellido			varchar(255),
	tipo_doc			char(3)					DEFAULT 'PAS' CHECK(tipo_doc IN ('DNI', 'PAS')),
	nro_doc				numeric(18,0),
	mail				varchar(255),
	telefono			varchar(60),
	nom_calle			varchar(255),
	nro_calle			varchar(255),
	pais_origen			varchar(60),
	nacionalidad			varchar(255),
	fecha_nac			datetime,
	baja_logica			char(1)					DEFAULT 'N' CHECK(baja_logica IN ('S', 'N')),
	estado				char(1)					DEFAULT 'H' CHECK(estado IN ('H', 'I')),
)
CREATE TABLE THE_FOREIGN_FOUR.InactividadHoteles (
	cod_tarea			int					IDENTITY(1,1) PRIMARY KEY,
	cod_hotel			int					REFERENCES THE_FOREIGN_FOUR.Hoteles,
	descripcion			varchar(255),
	fecha_desde			datetime,
	fecha_hasta			datetime,
)
CREATE TABLE THE_FOREIGN_FOUR.Regimenes (
	cod_regimen			int					IDENTITY(1,1) PRIMARY KEY,
	precio				numeric(18,2),
	descripcion			varchar(255),
	estado				char(1)					DEFAULT 'H' CHECK(estado IN ('H', 'I')),
)
CREATE TABLE THE_FOREIGN_FOUR.TipoHabitaciones (
	cod_tipo_hab			int						PRIMARY KEY,
	descripcion			varchar(255),
	recargo				numeric (18,2),
)
CREATE TABLE THE_FOREIGN_FOUR.Habitaciones (
	nro_habitacion			numeric(18,0)				PRIMARY KEY,
	cod_hotel			int					REFERENCES THE_FOREIGN_FOUR.Hoteles,
	cod_tipo_hab			int					REFERENCES THE_FOREIGN_FOUR.TipoHabitaciones,
	piso				int,
	ubicacion			varchar(50),
	descripcion			varchar(255),
	estado				char(1)					DEFAULT 'H' CHECK(estado IN ('H', 'I')),
)
CREATE TABLE THE_FOREIGN_FOUR.EstadosReserva (
	cod_estado			int					IDENTITY(1,1) PRIMARY KEY,
	descripcion			varchar(255),
)
CREATE TABLE THE_FOREIGN_FOUR.Reservas (
	cod_reserva			numeric(18,0)				PRIMARY KEY,
	cod_hotel			int					REFERENCES THE_FOREIGN_FOUR.Hoteles,
	cod_cliente			numeric(18,0)				REFERENCES THE_FOREIGN_FOUR.Clientes,
	cod_tipo_hab			int					REFERENCES THE_FOREIGN_FOUR.TipoHabitaciones,
	cod_regimen			int					REFERENCES THE_FOREIGN_FOUR.Regimenes,
	cod_estado_reserva		int					REFERENCES THE_FOREIGN_FOUR.EstadosReserva,
	fecha_creacion			datetime,
	fecha_desde			datetime,
	fecha_hasta			datetime,
	cant_noches			int,
)
CREATE TABLE THE_FOREIGN_FOUR.TiposPago (
	cod_tipo_pago		int						IDENTITY(1,1) PRIMARY KEY,
	descripcion			varchar(255),
	nro_tarjeta			numeric(18,0),
)
CREATE TABLE THE_FOREIGN_FOUR.Estadias (
	cod_estadia			numeric(18,0)				IDENTITY (1,1) PRIMARY KEY,
	cod_reserva			numeric(18,0)				REFERENCES THE_FOREIGN_FOUR.Reservas,
	nro_habitacion			numeric(18,0)				REFERENCES THE_FOREIGN_FOUR.Habitaciones,
	fecha_inicio			datetime,
	cant_noches			numeric(18,0),
)
CREATE TABLE THE_FOREIGN_FOUR.Facturas (
	nro_factura			numeric(18,0)				PRIMARY KEY,
	cod_estadia			numeric(18,0)				REFERENCES THE_FOREIGN_FOUR.Estadias,
	cod_tipo_pago			int					REFERENCES THE_FOREIGN_FOUR.TiposPago,
	fecha_factura			datetime,
	total				numeric(18,2),
)
CREATE TABLE THE_FOREIGN_FOUR.ItemsFactura (
	nro_item			numeric(18,0)				IDENTITY(1,1) PRIMARY KEY,
	nro_factura			numeric(18,0)				REFERENCES THE_FOREIGN_FOUR.Facturas,
	cantidad			int,
	precio_unitario			decimal(6,2),
	descripcion			varchar(255),
)
CREATE TABLE THE_FOREIGN_FOUR.Consumibles (
	cod_consumible			numeric(18,0)				PRIMARY KEY,
	descripcion			varchar(255),
	precio				numeric(18,2),
)
CREATE TABLE THE_FOREIGN_FOUR.ClientePorEstadia (
	cod_estadia			numeric(18,0)				REFERENCES THE_FOREIGN_FOUR.Estadias,
	cod_cliente			numeric(18,0)				REFERENCES THE_FOREIGN_FOUR.Clientes,
	PRIMARY KEY (cod_estadia, cod_cliente)
)
CREATE TABLE THE_FOREIGN_FOUR.ConsumiblesPorEstadia (
	cod_estadia			numeric(18,0)				REFERENCES THE_FOREIGN_FOUR.Estadias,
	cod_consumible			numeric(18,0)				REFERENCES THE_FOREIGN_FOUR.Consumibles,
	cantidad			int,
	PRIMARY KEY (cod_estadia, cod_consumible)
)
CREATE TABLE THE_FOREIGN_FOUR.RegimenPorHotel (
	cod_hotel			int					REFERENCES THE_FOREIGN_FOUR.Hoteles,
	cod_regimen			int					REFERENCES THE_FOREIGN_FOUR.Regimenes
	PRIMARY KEY (cod_hotel, cod_regimen)
)
CREATE TABLE THE_FOREIGN_FOUR.ReservasPorTipoHabitacion (
	cod_tipo_hab			numeric(18,0)				REFERENCES THE_FOREIGN_FOUR.Habitaciones,
	cod_reserva			numeric(18,0)				REFERENCES THE_FOREIGN_FOUR.Reservas,
	cantidad			int,
	PRIMARY KEY (cod_tipo_hab, cod_reserva)
)
CREATE TABLE THE_FOREIGN_FOUR.UsuariosPorHotel (
	cod_usuario			numeric(18,0)				REFERENCES THE_FOREIGN_FOUR.Usuarios,
	cod_hotel			int					REFERENCES THE_FOREIGN_FOUR.Hoteles,
	PRIMARY KEY(cod_usuario, cod_hotel)
)
