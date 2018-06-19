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
Valor integer,
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
Ouro integer,
[Desc] varchar (max),
[Exp] integer,
Agressividade Varchar(20),
Perigo Varchar(30),
Bando varchar(10),
Classificacao varchar(20)
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
DropRate integer,
Item_Id integer references Item(Id),
Criat_Id integer references Criatura(Id),
id_ItemxCriat integer primary key identity(1,1)
);
go
create table Cena
(
Id int primary key identity(1,1),
Identi int,
fim int
);
go
create table Questao
(
Id int primary key,
Cena int references Cena(Id),
Personagem int references Personagem(Id),
Descr varchar(max),
Identi int 
);
go
create table Resposta
(
Descr varchar(max),
Questao int references Questao(Id),
Id int primary key identity(1,1),
Identi int, 
Cena INT references Cena(Id)
);
go
create table Lugar 
(
Id int primary key identity(1,1),
Imagem Varchar(30)
);
go
create table LugarxQuestao
(
Questao int references Questao(Id),
Lugar int references Lugar(Id),
id_LugarxQuestao integer primary key identity(1,1)
);
go
create table Momento
(
Id int primary key identity(1,1),
Cena int references Cena(Id),
Questao int references Questao(Id),
Usuario int references Usuario(Id),
Personagem int references Personagem(Id)
);
go
create table Distancia
(
Lugar1 int references Lugar(Id),
Lugar2 int references Lugar(Id),
Passos int,
CriaturaNumeroInicial int,
CriaturaNumeroFinal int,
Id int primary key identity(1,1),
);
go
create table Construcao
(
Item int references Item(Id),
Resultado int references Item(Id),
id int primary key identity(1,1)
);
go

select * from Criatura
go

BULK INSERT Questao
FROM 'C:\Users\Aluno\Desktop\Questoes-Teste.txt'
with(CODEPAGE='ACP')
go
BULK INSERT Cena
FROM 'C:\Users\Aluno\Desktop\Cena-Teste.txt'
with(CODEPAGE='ACP')
go
BULK INSERT Resposta
FROM 'C:\Users\Aluno\Desktop\Respostas-Teste.txt'
with(CODEPAGE='ACP')
go
BULK INSERT Lugar
FROM 'C:\Users\Aluno\Desktop\Lugar-Teste.txt'
with(CODEPAGE='ACP')
go
BULK INSERT Personagem
FROM 'C:\Users\Aluno\Desktop\Personagem-Teste-Escolha.txt'
with(CODEPAGE='ACP')
go
BULK INSERT LugarxQuestao
FROM 'C:\Users\Aluno\Desktop\LugarxQuestao-Teste.txt'
with(CODEPAGE='ACP')
go
/*
Use master;
drop database HNI
*/
select * FROM Momento;