
-- SELECCIONAR TODAS LAS usuarioes
create procedure usuario_select
as
begin 
	select u.id,u.documento, u.nombres, u.apellidos, u.telefono, u.email, r.id, r.nombre_rol
	from [dbo].[usuario] u
	inner join [dbo].[rol] r
	on r.id = u.FKrol
end;

--SELECCIONAR usuario POR DOCUMENTO
create procedure usuario_doc_select
 @documento varchar(10)
as
begin 

	select u.id,u.documento, u.nombres, u.apellidos, u.telefono, u.email, r.id, r.nombre_rol
	from [dbo].[usuario] u
	inner join [dbo].[rol] r
	on r.id = u.FKrol
	where u.documento = @documento

end;

--INSERTAR usuario
create procedure usuario_insert
	@documento varchar(10),
	@nombres varchar(100),
	@apellidos varchar(200),
	@telefono varchar(10),
	@email varchar(50),
	@FKrol int 
as
begin 
	insert into [dbo].[usuario] values (@documento,@nombres,@apellidos,@telefono,@email,@FKrol);
end;




-- ACTUALIZAR usuario
create procedure usuario_update	
	@documento varchar(10),
	@nombres varchar(100),
	@apellidos varchar(200),
	@telefono varchar(10),
	@email varchar(50),
	@FKrol int 
as
begin 
	update [dbo].[usuario]
	set 
	nombres = @nombres,
	apellidos = @apellidos,
	telefono = @telefono,
	email = @email,
	FKrol = @FKrol
	where documento = @documento
end;

-- ELIMINAR usuario
create procedure usuario_delete
	@documento varchar(10)
as
begin 
	delete [dbo].[usuario]
	where documento = @documento
end;