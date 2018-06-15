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
Id int primary key identity(1,1)
);
go
create table Questao
(
Id int primary key,
Cena int references Cena(Id),
Personagem int references Personagem(Id),
Descr varchar(max)
Identi int 
);
create table Resposta
(
Descr varchar(max),
Questao int references Questao(Id),
Id int primary key identity(1,1),
Identi int 
);

create table Lugar 
(
Id int primary key identity(1,1),
CriaturaNumeroInicial int,
CriaturaNumeroFinal int,
Imagem Varchar(30)
);
go
create table LugarxQuestao
(
Questao integer references Questao(Id),
Lugar integer references Lugar(Id),
id_LugarxQuestao integer primary key identity(1,1)
);
create table Momento
(
Id int primary key identity(1,1),
Cena int references Cena(Id),
Questao int references Questao(Id),
Personagem int references Personagem(Id)
);
go
create table Distancia
(
Lugar1 int references Lugar(Id),
Lugar2 int references Lugar(Id),
Passos int,
Id int primary key identity(1,1),
);
go
create table Construcao
(
Item int references Item(Id),
Resultado int references Item(Id)
);
go
insert into Classe
values
('Guerreiro-01','Guerreiro','Bravos, fortes e habilidosos com utilização de armas fisicas, possuem pouca habiliade magica porem compensam em força bruta',100,550,100,20,100,1),
('Mago-01','Mago','Inteligentes,astutos e habilidosos com as energias e poderes magicos,possuem pouca habilidade fisica porem compensam em poder especias',600,300,20,100,50,1),
('Ladino-01','Ladino','Bravos,astutos e habilidosos com as energias e armas fisicas , possuem habilidades equilibradas são fortes fiscamente e magicamente',300,400,70,70,70,1);
go
insert into Usuario
values
('Diego Castilho Lourenço','Historia','diegocastilho6@gmail.com','diego123','17/07/2001','Masculino')
go
insert into Criatura
values
('Lobo-001','Lobo',20,100,60,10,40,5,'Criatura agressiva de intelecto limitado, custuma agir em bandos, separados não apresentam grande perigo mas em bando podem causar problemas a aventureiros iniciantes e camponeses',2,'Alta','Baixo','2 a 5','Animal'),
('Cobra-001','Cobra',20,140,80,30,55,8,'Criatura agressiva de intelecto mediano, custuma agir só ,não apresenta grande perigo porem pode causar problemas a aventureiros iniciantes e camponeses',4,'Media','Baixo','1 a 2','Animal'),
('Leão-001','Leão',80,200,90,60,60,20,'Criatura neutra de intelecto mediano, custuma agir só ou em grupos, apresentam grande perigo mas e em bando podem causar grandes problemas a aventureiros que submestimam o terretorio do Leão ,aventureiros iniciantes e camponeses',10,'Baixa','Media','1 a 4','Animal')
go
select * from Criatura
go

BULK INSERT Questao
FROM 'C:\Users\Aluno\Desktop\Questoes-Teste.txt'
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