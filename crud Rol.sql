
-- SELECCIONAR TODAS LAS roles
create procedure rol_select
as
begin 
	select id,nombre_rol from [dbo].[rol];
end;

--SELECCIONAR rol POR ID
create procedure rol_id_select
 @id int
as
begin 
	select id,nombre_rol from [dbo].[rol]
	where id = @id;
end;

--INSERTAR rol
create procedure rol_insert
 @nombre_rol varchar(30)
as
begin 
	insert into [dbo].[rol] values (@nombre_rol);
end;




-- ACTUALIZAR rol
create procedure rol_update
	@id int,
	@nombre_rol varchar(30)
as
begin 
	update [dbo].[rol]
	set nombre_rol = @nombre_rol
	where id = @id
end;

-- ELIMINAR rol
create procedure rol_delete
	@id int	
as
begin 
	delete [dbo].[rol]
	where id = @id
end;