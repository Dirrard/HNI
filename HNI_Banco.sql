create database HNI
go
use HNI
go

create table Usuario
(
Id int primary key identity(1,1),
Nome varchar(150) not null,
Nick varchar(50) not null,
Email varchar(150) not null,
Senha varchar(100) not null,
DataNasc varchar(30)not null, 
Genero varchar(20) not null 
)