
-- SELECCIONAR TODAS LAS servicioes
create procedure servicio_select
as
begin 
	select id,nombre_servicio, detalle_servicio from [dbo].[servicio];
end;

--SELECCIONAR servicio POR ID
create procedure servicio_id_select
 @id int
as
begin 
	select id,nombre_servicio, detalle_servicio from [dbo].[servicio]
	where id = @id;
end;

--INSERTAR servicio
create procedure servicio_insert
 @nombre_servicio varchar(30),
 @detalle_servicio nvarchar(max)
as
begin 
	insert into [dbo].[servicio] values (@nombre_servicio, @detalle_servicio);
end;




-- ACTUALIZAR servicio
create procedure servicio_update
	@id int,
	@nombre_servicio varchar(30),
	@detalle_servicio nvarchar(max)
as
begin 
	update [dbo].[servicio]
	set nombre_servicio = @nombre_servicio,
	detalle_servicio = @detalle_servicio
	where id = @id
end;

-- ELIMINAR servicio
create procedure servicio_delete
	@id int	
as
begin 
	delete [dbo].[servicio]
	where id = @id
end;