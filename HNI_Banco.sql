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
);
go
create table Classe
(
Id int primary key identity(1,1),
Imagem Varchar(20),
Nome varchar(100),
[Desc] varchar(max),
Mana integer,
Hp integer,
AtkF integer,
AtkM integer,
Def integer,
Nivel integer
);
go
create table Personagem
(
Id int primary key identity(1,1),
Id_Usuario integer references Usuario(Id),
Classe integer references Classe(Id),
Imagem Varchar(20),
Nome Varchar(50),
Genero Varchar(10),
ouro integer,
Mana integer,
Hp integer,
AtkF integer,
AtkM integer,
Def integer,
Nivel integer,
[Exp] integer
);
go
create table Item
(
Id int primary key identity(1,1),
Imagem Varchar(20),
Nome Varchar(50),
Mana integer,
Hp integer,
AtkF integer,
AtkM integer,
Def integer,
Nivel integer,
);
go
create table AtkE
(
Id int primary key identity(1,1),
Imagem Varchar(20),
Nome Varchar(50),
AtkM integer,
Def integer,
AtkF integer,
Hp integer,
Mana integer,
);
go
create table Criatura
(
Id int primary key identity(1,1),
Imagem Varchar(20),
Nome Varchar(50),
Mana integer,
Hp integer,
AtkF integer,
AtkM integer,
Def integer,
ouro integer,
[Exp] integer,
);
go
create table AtkexPerson
(
AtkE_Id integer references AtkE(Id),
Personegem_Id integer references Personagem(Id),
id_AtkexPerson integer primary key identity(1,1)
);
go
create table ItemxPerson
(
Item_Id integer references Item(Id),
Personagem_Id integer references Personagem(Id),
id_ItemxPerson integer primary key identity(1,1)
);
go
create table AtkexClasse
(
AtkE_Id integer references AtkE(Id),
Classe_Id integer references Classe(Id),
id_AtkexClasse integer primary key identity(1,1)
);
go
create table AtkexCriat
(
AtkE_Id integer references AtkE(Id),
Criat_Id integer references Criatura(Id),
id_AtkexCriat integer primary key identity(1,1)
);
go
create table ItemxCriat
(
Item_Id integer references Item(Id),
Criat_Id integer references Criatura(Id),
id_ItemxCriat integer primary key identity(1,1)
);
go

create table Cena
(
Id int primary key identity(1,1),
IdP int references Personagem(Id),
Imagem varchar(20)
);
go