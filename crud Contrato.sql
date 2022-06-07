
-- SELECCIONAR TODAS LOS Contratos
create procedure contrato_select
as
begin 
	select c.id, c.fecha, s.id, s.nombre_servicio, cliente.id, cliente.nombres, vendedor.id, vendedor.nombres, v.id, v.precio, m.nombre_marca 
	from contrato c inner join servicio s on s.id = c.FK_servicio
	inner join usuario cliente on cliente.id = c.FK_cliente
	inner join usuario vendedor on vendedor.id = c.FK_vendedor
	inner join vehiculo v on v.id = c.FK_vehiculo
	INNER JOIN Marca m ON v.fkmarca = m.id
end;

--SELECCIONAR contrato POR ID
create procedure contrato_id_select
 @id int
as
begin 

	select c.id, c.fecha, s.id, s.nombre_servicio, cliente.id, cliente.nombres, vendedor.id, vendedor.nombres, v.id, v.precio, m.nombre_marca 
	from contrato c inner join servicio s on s.id = c.FK_servicio
	inner join usuario cliente on cliente.id = c.FK_cliente
	inner join usuario vendedor on vendedor.id = c.FK_vendedor
	inner join vehiculo v on v.id = c.FK_vehiculo
	INNER JOIN Marca m ON v.fkmarca = m.id

	where c.id = @id

end;

--INSERTAR contrato
create procedure contrato_insert	
	
	@FK_servicio int,
	@FK_cliente int,
	@FK_vendedor int,
	@FK_vehiculo int
as
begin 
	insert into [dbo].[contrato] values (GETDATE(),@FK_servicio,@FK_cliente,@FK_vendedor,@FK_vehiculo);
end;




-- ACTUALIZAR contrato
create procedure contrato_update	
	@id int ,
	@FK_servicio int,
	@FK_cliente int,
	@FK_vendedor int,
	@FK_vehiculo int 
as
begin 
	update [dbo].[contrato]
	set 
		FK_servicio = @FK_servicio,
		FK_cliente = @FK_cliente,
		FK_vendedor = @FK_vendedor,
		@FK_vehiculo = @FK_vehiculo
	where id = @id
end;

-- ELIMINAR contrato
create procedure contrato_delete
	@id int
as
begin 
	delete [dbo].[contrato]
	where id = @id
end;