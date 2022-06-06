
-- SELECCIONAR TODAS LAS MARCAS
create procedure marca_select
as
begin 
	select id,nombre_marca from [dbo].[Marca];
end;

--SELECCIONAR MARCA POR ID
create procedure marca_id_select
 @id int
as
begin 
	select id,nombre_marca from [dbo].[Marca]
	where id = @id;
end;

--INSERTAR MARCA
create procedure marca_insert
 @nombre_marca varchar(30)
as
begin 
	insert into [dbo].[Marca] values (@nombre_marca);
end;




-- ACTUALIZAR MARCA
create procedure marca_update
	@id int,
	@nombre_marca varchar(30)
as
begin 
	update [dbo].[Marca]
	set nombre_marca = @nombre_marca
	where id = @id
end;

-- ELIMINAR MARCA
create procedure marca_delete
	@id int	
as
begin 
	delete [dbo].[Marca]
	where id = @id
end;