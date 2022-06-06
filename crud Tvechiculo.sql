
-- SELECCIONAR TODAS LAS tipo_vehiculoS
create procedure tipo_vehiculo_select
as
begin 
	select id,nombre_tipo_vehiculo from [dbo].[tipo_vehiculo];
end;

--SELECCIONAR tipo_vehiculo POR ID
create procedure tipo_vehiculo_id_select
 @id int
as
begin 
	select id,nombre_tipo_vehiculo from [dbo].[tipo_vehiculo]
	where id = @id;
end;

--INSERTAR tipo_vehiculo
create procedure tipo_vehiculo_insert
 @nombre_tipo_vehiculo varchar(30)
as
begin 
	insert into [dbo].[tipo_vehiculo] values (@nombre_tipo_vehiculo);
end;




-- ACTUALIZAR tipo_vehiculo
create procedure tipo_vehiculo_update
	@id int,
	@nombre_tipo_vehiculo varchar(30)
as
begin 
	update [dbo].[tipo_vehiculo]
	set nombre_tipo_vehiculo = @nombre_tipo_vehiculo
	where id = @id
end;

-- ELIMINAR tipo_vehiculo
create procedure tipo_vehiculo_delete
	@id int	
as
begin 
	delete [dbo].[tipo_vehiculo]
	where id = @id
end;