CREATE TRIGGER trg_clientes_error
ON THE_FOREIGN_FOUR.Clietes
INSTEAD OF INSERT
AS
BEGIN

	DECLARE TrigInsCursor CURSOR FOR
	SELECT nombre, apellido, fecha_nac, nom_calle, nro_calle, piso, depto, nacionalidad, nro_doc, mail  
	FROM inserted
	DECLARE @nombre nvarchar(255),
			@apellido nvarchar(255),
			@fecha_nac datetime,
			@nom_calle nvarchar(255),
			@nro_calle	numeric(18,0),
			@piso numeric(18,0),
			@depto nvarchar(50),
			@nacionalidad nvarchar(255),
			@nro_doc numeric(18,0), 
			@mail nvarchar(255)

	OPEN TrigInsCursor;

	FETCH NEXT FROM TrigInsCursor INTO @nombre, @apellido, @fecha_nac, @nom_calle, @nro_calle, @piso, @depto, @nacionalidad, @nro_doc, @mail

	WHILE @@FETCH_STATUS = 0
	BEGIN
	
		IF(NOT EXISTS (SELECT nro_doc
						FROM THE_FOREIGN_FOUR.Clientes
						WHERE nro_doc = @nro_doc
						OR mail = @mail))
		BEGIN
			INSERT INTO THE_FOREIGN_FOUR.Clientes (nombre, apellido, fecha_nac, nom_calle, nro_calle, piso, depto, nacionalidad, nro_doc, mail)
			VALUES (@nombre, @apellido, @fecha_nac, @nom_calle, @nro_calle, @piso, @depto, @nacionalidad, @nro_doc, @mail);
		END	
		ELSE
		BEGIN
			INSERT INTO THE_FOREIGN_FOUR.ClientesDefectuosos (nombre, apellido, fecha_nac, nom_calle, nro_calle, piso, depto, nacionalidad, nro_doc, mail)
			VALUES (@nombre, @apellido, @fecha_nac, @nom_calle, @nro_calle, @piso, @depto, @nacionalidad, @nro_doc, @mail);
		END			
			
		FETCH NEXT FROM TrigInsCursor INTO @nombre, @apellido, @fecha_nac, @nom_calle, @nro_calle, @piso, @depto, @nacionalidad, @nro_doc, @mail      

  END

  CLOSE TrigUpdCursor;
  DEALLOCATE TrigUpdCursor;

END
GO