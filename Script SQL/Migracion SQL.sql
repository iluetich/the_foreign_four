CREATE TABLE THE_FOREIGN_FOUR.Clientes (
	cod_cliente		numeric(18,0)		 	NOT NULL IDENTITY(1,1) PRIMARY KEY ,
	nombre			varchar(255)			NOT NULL,
	apellido		varchar(255)			NOT NULL,
	fecha_nac		datetime				NOT NULL,
	nro_pasaporte	numeric(18,0)			NOT NULL,
	mail			varchar(255)			NOT NULL,
	dom_calle		varchar(255)			NOT NULL,
	nro_calle		numeric(18,0)			NOT NULL,
	nacionalidad	varchar(255)			NOT NULL,
	piso			numeric(18,0),
	depto			varchar(50)
)
CREATE TABLE THE_FOREIGN_FOUR.Hoteles (
	cod_hotel			int 			NOT NULL IDENTITY(1,1) PRIMARY KEY,			
	ciudad				varchar(255)	NOT NULL,
	calle				varchar(255)	NOT NULL,
	nro_calle			bigint			NOT NULL,
	cant_estrellas		int				NOT NULL,
	recarga_estrellas	numeric(18,0)	NOT NULL
)
CREATE TABLE THE_FOREIGN_FOUR.Regimenes (
	cod_regimen		int IDENTITY(1,1)	NOT NULL PRIMARY KEY,
	precio			numeric(18,2)		NOT NULL,
	descripcion		varchar(255)		NOT	NULL	
)
CREATE TABLE THE_FOREIGN_FOUR.TipoHabitaciones (
	cod_tipo_hab	int					NOT NULL PRIMARY KEY,
	descripcion		varchar(255)		NOT NULL,
	recargo			numeric (18,2)		NOT NULL
)
CREATE TABLE THE_FOREIGN_FOUR.Habitaciones (
	nro_habitacion	numeric(18,0)		NOT NULL PRIMARY KEY,
	cod_hotel		int					NOT NULL REFERENCES THE_FOREIGN_FOUR.Hoteles,
	cod_tipo_hab	int					NOT NULL REFERENCES THE_FOREIGN_FOUR.TipoHabitaciones,
	piso			int					NOT NULL,
	frente			varchar(50)			NOT NULL
)
CREATE TABLE THE_FOREIGN_FOUR.Reservas (
	cod_reserva		numeric(18,0)		NOT NULL PRIMARY KEY,
	cod_hotel		int					NOT NULL REFERENCES THE_FOREIGN_FOUR.Hoteles,
	cod_cliente		numeric(18,0)		NOT NULL REFERENCES THE_FOREIGN_FOUR.Clientes,
	cod_tipo_hab	int					NOT NULL REFERENCES THE_FOREIGN_FOUR.TipoHabitaciones,
	cod_regimen		int					NOT NULL REFERENCES THE_FOREIGN_FOUR.Regimenes,
	fecha_inicio	datetime			NOT NULL,
	cant_noches		int					NOT NULL,
	fecha_reserva	datetime			NOT NULL
)
CREATE TABLE THE_FOREIGN_FOUR.TipoPagos (
	cod_tipo_pago	int					NOT NULL IDENTITY(1,1) PRIMARY KEY,
	descripcion		varchar(255)		NOT NULL,
	nro_tarjeta		numeric(18,0)		
)
CREATE TABLE THE_FOREIGN_FOUR.Facturas (
	nro_factura		numeric(18,0)		NOT NULL PRIMARY KEY,
	cod_cliente		numeric(18,0)		NOT NULL REFERENCES THE_FOREIGN_FOUR.Clientes,
	cod_tipo_pago	int					NOT NULL REFERENCES THE_FOREIGN_FOUR.TipoPagos,
	fecha_factura	datetime			NOT NULL,
	total			numeric(18,2)		NOT NULL
)
CREATE TABLE THE_FOREIGN_FOUR.ItemsFacturas (
	nro_item		numeric(18,0)		NOT NULL IDENTITY(1,1) PRIMARY KEY,
	nro_factura		numeric(18,0)		NOT NULL REFERENCES THE_FOREIGN_FOUR.Facturas,
	cantidad		int					NOT NULL,
	precio_unitario decimal(6,2)		NOT NULL,
	descripcion		varchar(255)		NOT NULL,
)
CREATE TABLE THE_FOREIGN_FOUR.Consumibles (
	cod_consumible	numeric(18,0)		NOT NULL PRIMARY KEY,
	descripcion		varchar(255)		NOT NULL,
	precio			numeric(18,2)		NOT NULL
)
CREATE TABLE THE_FOREIGN_FOUR.Estadia (
	cod_estadia		numeric(18,0)		NOT NULL IDENTITY (1,1) PRIMARY KEY,
	cod_reserva		numeric(18,0)		NOT NULL REFERENCES THE_FOREIGN_FOUR.Reservas,
	cod_habitacion	numeric(18,0)		NOT NULL REFERENCES THE_FOREIGN_FOUR.Habitaciones,
	fecha_inicio	datetime			NOT NULL,
	cant_noches		numeric(18,0)		
)
CREATE TABLE THE_FOREIGN_FOUR.ClientePorEstadia (
	cod_estadia		numeric(18,0)		NOT NULL REFERENCES THE_FOREIGN_FOUR.Estadia,
	cod_cliente		numeric(18,0)		NOT NULL REFERENCES THE_FOREIGN_FOUR.Clientes,
	PRIMARY KEY (cod_estadia, cod_cliente)
)
CREATE TABLE THE_FOREIGN_FOUR.ConsumiblesPorEstadia (
	cod_estadia		numeric(18,0)		NOT NULL REFERENCES THE_FOREIGN_FOUR.Estadia,
	cod_consumible	numeric(18,0)		NOT NULL REFERENCES THE_FOREIGN_FOUR.Consumibles,
	cantidad		int					NOT NULL
	PRIMARY KEY (cod_estadia, cod_consumible)
)
CREATE TABLE THE_FOREIGN_FOUR.RegimenPorHotel (
	cod_hotel		int					NOT NULL REFERENCES THE_FOREIGN_FOUR.Hoteles,
	cod_regimen		int					NOT NULL REFERENCES THE_FOREIGN_FOUR.Regimenes
	PRIMARY KEY (cod_hotel, cod_regimen)
)
CREATE TABLE THE_FOREIGN_FOUR.ReservasPorHabitacion (
	nro_habitacion	numeric(18,0)		NOT NULL REFERENCES THE_FOREIGN_FOUR.Habitaciones,
	cod_reserva		numeric(18,0)		NOT NULL REFERENCES THE_FOREIGN_FOUR.Reservas
	PRIMARY KEY (nro_habitacion, cod_reserva)	
)


