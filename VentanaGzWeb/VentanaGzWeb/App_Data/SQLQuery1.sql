select Descripcion, sum(Ancho) as Ancho, sum(altura) as altura
from ProyectosDetalle
where ProyectoId=12
group by Descripcion

select *
from ProyectosDetalle
where ProyectoId=12

--insert into ProyectosDetalle
--select ProyectoId	,Descripcion	,Pie	,Ancho	,Altura	,Cantidad,	Precio from ProyectosDetalle where ProyectoDetalleId = 23

