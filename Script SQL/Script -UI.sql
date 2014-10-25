CREATE FUNCTION THE_FOREIGN_FOUR.login_password 
				(@user_name nvarchar(30), 
				@password nvarchar(30))
RETURNS TABLE  
AS
RETURN(
SELECT u.cod_hotel, h.nombre
FROM THE_FOREIGN_FOUR.Usuarios u, THE_FOREIGN_FOUR.Hoteles h
WHERE	u.cod_hotel = h.cod_hotel
AND		user_name = @user_name
AND		password = @password
)

