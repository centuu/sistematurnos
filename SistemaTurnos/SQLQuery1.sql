create database TurnosMontagne

CREATE TABLE Horarios(
	idHorario int primary key identity(1,1) not null,
	descripcion nvarchar(50)
)

CREATE TABLE Usuarios(
	idUsuario int primary key identity(1,1) not null,
	Usuario nvarchar(20),
	Clave nvarchar(20),
	NroLocal int,
	Mail nvarchar(50),
	Cupos int, 
	Nombre nvarchar(50),
	TelLocal nvarchar(20)
)

CREATE TABLE Turnos(
	idTurno int primary key identity(1,1) not null,
	NroLocal int,
	Fecha nvarchar(50),
	Horario int,
	NroOrden int,
	Cliente nvarchar(50),
	dniCliente nvarchar(20),
	telCliente nvarchar(20),
	mailCliente nvarchar(50),
	Compro nvarchar(2),
	Observaciones nvarchar(MAX)
)