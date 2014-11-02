update THE_FOREIGN_FOUR.Hoteles 
set nombre = 'Conrad'
where cod_hotel = 1;

update THE_FOREIGN_FOUR.Hoteles 
set nombre = 'Hilton'
where cod_hotel = 2;

update THE_FOREIGN_FOUR.Hoteles 
set nombre = 'Sheraton'
where cod_hotel = 3;

update THE_FOREIGN_FOUR.Hoteles 
set nombre = 'Palacio Duhau'
where cod_hotel = 4;

update THE_FOREIGN_FOUR.Hoteles 
set nombre = 'Melia'
where cod_hotel = 5;

update THE_FOREIGN_FOUR.Hoteles 
set nombre = 'Madero'
where cod_hotel = 6;

update THE_FOREIGN_FOUR.Hoteles 
set nombre = 'Alvear Palace'
where cod_hotel = 7;

update THE_FOREIGN_FOUR.Hoteles 
set nombre = 'Intercontinental'
where cod_hotel = 8;

update THE_FOREIGN_FOUR.Hoteles 
set nombre = 'Emeperador'
where cod_hotel = 9;

update THE_FOREIGN_FOUR.Hoteles 
set nombre = 'BA Grand Hotel'
where cod_hotel = 10;

update THE_FOREIGN_FOUR.Hoteles 
set nombre = 'Four Seasons'
where cod_hotel = 11;

update THE_FOREIGN_FOUR.Hoteles 
set nombre = 'Faena'
where cod_hotel = 12;

update THE_FOREIGN_FOUR.Hoteles 
set nombre = 'Regal Pacific'
where cod_hotel = 13;

update THE_FOREIGN_FOUR.Hoteles 
set nombre = 'Hotel Club Frances'
where cod_hotel = 14;

update THE_FOREIGN_FOUR.Hoteles 
set nombre = 'Caesar Park'
where cod_hotel = 15;

update THE_FOREIGN_FOUR.Hoteles 
set nombre = 'Claridge'
where cod_hotel = 16;

-- -----------------------------------------------

delete from THE_FOREIGN_FOUR.RegimenPorHotel
where cod_hotel = 3
and
cod_regimen = 2;