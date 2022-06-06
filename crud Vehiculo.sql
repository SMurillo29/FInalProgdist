
-- SELECCIONAR TODAS LAS vehiculoes
create procedure vehiculo_select
as
begin 
	select v.kilometraje, v.precio, v.color, t.id, t.nombre_tipo_vehiculo, m.id, m.nombre_marca from [dbo].[vehiculo] v
	inner join [dbo].[tipo_vehiculo] t on v.fktipo = t.id
	inner join [dbo].[Marca] m on v.fkmarca = m.id

end;

--SELECCIONAR vehiculo POR ID
create procedure vehiculo_id_select
 @id int
as
begin 

	select v.kilometraje, v.precio, v.color, t.id, t.nombre_tipo_vehiculo, m.id, m.nombre_marca from [dbo].[vehiculo] v
	inner join [dbo].[tipo_vehiculo] t on v.fktipo = t.id
	inner join [dbo].[Marca] m on v.fkmarca = m.id
	where v.id = @id

end;

--INSERTAR vehiculo
create procedure vehiculo_insert	
	@kilometraje Float,
	@precio Float,
	@color varchar(30),
	@fktipo int ,
	@fkmarca int
as
begin 
	insert into [dbo].[vehiculo] values (@kilometraje,@precio,@color,@fktipo,@fkmarca);
end;




-- ACTUALIZAR vehiculo
create procedure vehiculo_update	
	@id int ,
	@kilometraje Float,
	@precio Float,
	@color varchar(30),
	@fktipo int ,
	@fkmarca int 
as
begin 
	update [dbo].[vehiculo]
	set 
		kilometraje = @kilometraje,
		precio = @precio,
		color = @color,
		fktipo = @fktipo,
		fkmarca = @fkmarca
	where id = @id
end;

-- ELIMINAR vehiculo
create procedure vehiculo_delete
	@id int
as
begin 
	delete [dbo].[vehiculo]
	where id = @id
end;