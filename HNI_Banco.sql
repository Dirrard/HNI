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
Classe integer references Classe(Id) ,
Imagem Varchar(20),
Nome Varchar(50),
Genero Varchar(10),
Ouro integer,
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
insert into Classe
values
('Guerreiro-01','Guerreiro','Bravos, fortes e habilidosos com utilização de armas fisicas, possuem pouca habiliade magica porem compensam em força bruta',100,550,100,20,100,1),
('Mago-01','Mago','Inteligentes,astutos e habilidosos com as energias e poderes magicos,possuem pouca habilidade fisica porem compensam em poder especias',600,300,20,100,50,1),
('Ladino-01','Ladino','Bravos,astutos e habilidosos com as energias e armas fisicas , possuem habilidades equilibradas são fortes fiscamente e magicamente',300,400,70,70,700,1);
go

insert into Usuario
values
('Diego Castilho Lourenço','Historia','diegocastilho6@gmail.com','diego123','17/07/2001','Masculino')
go



create table Cena
(
Id int primary key identity(1,1)
);
create table Questao
(
Id int primary key identity(1,1),
Cena int references Cena(Id),
Descr varchar(max)
);
create table Resposta
(
Id int primary key identity(1,1),
Descr varchar(max),
Questao int references Questao(Id),
);

create table Momento
(
Cena int references Cena(Id),
Questao int references Questao(Id),
Personagem int references Personagem(Id)
);
go
select * from Personagem
