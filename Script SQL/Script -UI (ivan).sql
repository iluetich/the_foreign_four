CREATE FUNCTION	THE_FOREIGN_FOUR.func_obtener_huespedes
				(@cod_reserva numeric(18,0))
				
RETURNS TABLE
AS
RETURN (SELECT	c.cod_cliente, c.nombre, c.apellido, c.mail, c.tipo_doc, c.nro_doc, c.fecha_nac
		FROM THE_FOREIGN_FOUR.Clientes c JOIN THE_FOREIGN_FOUR.ClientePorEstadia cpe ON(c.cod_cliente = cpe.cod_cliente)
										 JOIN THE_FOREIGN_FOUR.Estadias e ON(cpe.cod_estadia = e.cod_estadia)
		WHERE 46005 = e.cod_reserva)
