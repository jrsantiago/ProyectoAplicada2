create table Productos(
ProductoId int primary key identity,
Descripcion varchar(150),
Pie float,
MinimoPie float
);
create table ProductosDetalle(
ProductosDetalleId int primary key identity,
ProductoId int references Productos(ProductoId),
Detalle varchar(150),
Asociacion int,
Pie float
);