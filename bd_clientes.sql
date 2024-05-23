CREATE DATABASE bd_cliente
    WITH
    OWNER = postgres
    ENCODING = 'UTF8'
    CONNECTION LIMIT = -1
    IS_TEMPLATE = False;
	

	create table cliente_tb(
		
		IdCliente serial not null primary key,
		Nome varchar(300) not null,
		CPFCNPJ varchar,
		Telefone varchar(30),
		Celular varchar(30),
		Email varchar(200),
		CEP varchar(15),
		Logradouro varchar(300),
		Numero varchar(10),
		Cidade varchar(50),
		UF varchar(10),
		Complemento varchar(200)
	);
	
	select * from cliente_tb where IdCliente = 73
