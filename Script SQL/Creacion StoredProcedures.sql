CREATE PROCEDURE obtener_id_hotel(	@calle nvarchar(255),
									@nro_calle numeric(18,0),
									@ciudad nvarchar(255),
									@cant_estrellas numeric(18,0),
									@recarga_estrellas numeric(18,0) )
AS
BEGIN
	SELECT cod_hotel
	FROM THE_FOREIGN_FOUR.Hoteles
	WHERE	nom_calle = @calle
	AND		nro_calle = @nro_calle
	AND		ciudad = @ciudad
	AND		cant_estrellas = @cant_estrellas
	AND		recarga_estrellas = @recarga_estrellas
END