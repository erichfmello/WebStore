create database databaseWebStore;

USE databaseWebStore;

CREATE TABLE People 
(
	_cpf char(11) primary key, 
	[Name] varchar(100) not null, 
	Email varchar(50) not null, 
	Ddi int not null, 
	Ddd int not null, 
	CelphoneNumber int not null, 
	Cep int not null, 
	[Address] varchar(50) not null, 
	Number int not null, 
	Complement varchar(50), 
	Neighborhood varchar(50) not null, 
	City varchar(50) not null, 
	[State] char(2) not null, 
	AccessType varchar(4) not null,
	[user] varchar(10) not null, 
	[password] varchar(10) not null,
	constraint CKAccessType CHECK (AccessType = 'SADM' OR AccessType = 'ADM' OR AccessType = 'CLI')
)

INSERT INTO People VALUES ('11122233377', 'Erich de Mello', 'erichfmello@gmail.com', 55, 11, 979794646, 04015070, 'Rua Area', 111, NULL, 'Vila Vila', 'São Paulo', 'SP', 'SADM', 'erich', '123456')

CREATE TABLE Category 
(
	_idCategory int identity(1, 1) primary key, 
	[Name] varchar(100) not null
)

CREATE TABLE Product 
(
	_idProduct int identity(1, 1) primary key, 
	[Description] varchar(255),
	Title varchar(50) not null, 
	Price decimal not null, 
	Picture image, 
	[state] char(2) not null, 
	_idCategory int,
	constraint fk_idCategoryToCategory FOREIGN KEY (_idCategory) REFERENCES Category (_idCategory)
)

CREATE TABLE ShoppingCart 
(
	_cpf char(11),
	_idProduct int,
	amount int,
	CONSTRAINT pk PRIMARY KEY (_cpf, _idProduct),
	CONSTRAINT FkToPeople FOREIGN KEY (_cpf) REFERENCES People (_cpf),
	CONSTRAINT FkToProduct FOREIGN KEY (_idProduct) REFERENCES Product (_idProduct)
)


