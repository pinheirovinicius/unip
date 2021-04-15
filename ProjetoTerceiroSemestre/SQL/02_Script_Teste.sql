use db_Bitchain

Insert Into Perfil
	Values	( 'Administrador'),
					( 'Usuario'),
					( 'Cliente')
Go

Insert Into Usuario
	Values	('Administrador', '00000000000', 'admin@gmail.com', '1133333333', '11999999997', 'admin', 'admin1234', 1, 1, 0, 'admin', GetDate(), Null, Null, 0, Null),
					('Samuel', '00000000001', 'samuel@gmail.com', '1133333334', '11999999998', 'samuel', 'samuel', 1, 1, 0, 'admin', GetDate(), Null, Null, 0, Null),
					('Cris', '00000000002', 'cris@gmail.com', '1133333335', '11999999999', 'cris', 'cris', 1, 1, 0, 'admin', GetDate(), Null, Null, 0, Null)
Go

Insert Into Sistema
	Values	('Desktop',	GetDate()),
					('Web',			GetDate()),
					('Mobile',		GetDate())
Go

Insert Into Menu_Web
	Values	(10,	Null,	'Configurações',	NULL, 1),
					(11,		10,	'Usuários',				'Usuarios.aspx', 1),
					(12,		10,	'Moedas',	'Moeda.aspx',	1),
					(13,		10,	'Bancos',	'Bancos.aspx',	1),
					(20,	Null, 'Cliente', NULL, 1),
					(21,		20, 'Conta', 'Contas.aspx', 1),
					(22,		20, 'Transacao', 'Transacoes.aspx', 1),
					(90,	Null,	'Sair',	'Login.aspx', 1)
Go

Insert Into Menu_Web_Permissao Values (10,	1), (11,	1), (12,	1), (13,	1), (20,	1), (21,	1), (22,	1), (90,	1)
Go

Insert Into ParamSite 
	Values ('http://Bitchain', 'bitchain@gmail.com', NULL, 'PimBitchain', 1, 25, NULL, 'bitchain@gmail.com', '\Images\Logo.png')
Go

Insert Into ListaMoeda
	Values (1, 'R$', 'Real', 1, 1, 1),
				 (2, 'USD', 'Dólar Americano', 1, 5.7, 1)
Go

-- Criar uma conta


-- Dar um saldo pra conta criada
UpDate Conta Set VL_SALDO = 100 Where ID_CONTA = 1
