Create database BancoSimple2T1

GO
Use BancoSimple2T1
GO

Create table Cliente (
ClienteId int primary key identity (1,1),
Nombre Nvarchar (50) not null,
Identificacion Nvarchar (14) not null
);

Create table Cuenta (
CuentaId Int primary key identity (1,1),
NumeroCuenta Nvarchar (20) not null,
Saldo Decimal (18,2) not null default 0,
Activa Bit not null default 1,
ClienteId int not null,
Foreign key (ClienteId) references Cliente (ClienteId)
);

create table Transacciones (
TransaccionId Int primary key identity (1,1),
Monto decimal (18,2) not null,
Fecha datetime not null default getdate (),
Descripcion Nvarchar (200),
CuentaOrigenId int,
CuentaDestinoId int,
Foreign key (CuentaOrigenId) references Cuenta (CuentaId),
Foreign key (CuentaDestinoId) references Cuenta (CuentaId)
);

