
--------------------- Criando Banco de dados, Tabelas e Alimentando as Tabelas
Create Database db_Bitchain
Go

Create Table Usuario(
	 ID_USUARIO						Int	Identity(1,1) NOT NULL
	,NM_NOME							Varchar(100)			NULL
	,NR_CPF								Varchar(14)				NULL
	,NM_EMAIL							Varchar(100)			NULL
	,NR_TELEFONE					Varchar(25)				NULL
	,NR_CELULAR						Varchar(25)				NULL
	,NM_LOGIN							Varchar(50)				NULL
	,NM_SENHA							Varchar(10)				NULL
	,ID_PERFIL						Int								NULL
	,FL_HABILITA					Tinyint						NULL
	,FL_TROCA_SENHA				Tinyint						NULL
	,NM_USUARIO_CADASTRO	Varchar(50)				NULL
	,DT_CADASTRO					DateTime					NULL
	,NM_USUARIO_ALTERACAO	Varchar(50)				NULL
	,DT_ALTERACAO					DateTime					NULL
	,NR_ULTIMO_ACESSO			Int								NULL
	,DT_ULTIMO_ACESSO			DateTime					NULL

	CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
	(
		ID_USUARIO	ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
Go

Create Table UsuarioLogado(
	 ID_USUARIOLOGADO			Int Identity(1,1) NOT NULL,
	 ID_USUARIO						Int NULL
	CONSTRAINT [PK_UsuarioLogado] PRIMARY KEY CLUSTERED 
	(
		ID_USUARIOLOGADO	ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
Go

Create Table Perfil(
	ID_PERFIL			Int	Identity(1,1) NOT NULL
	,NM_DESCRICAO	Varchar(60)				NOT NULL

	CONSTRAINT [PK_Perfil] PRIMARY KEY CLUSTERED 
	(
	ID_PERFIL Asc
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

Alter Table Usuario Add Constraint DF_Usuario_FL_HABILITA	Default (1) For FL_HABILITA
Go

Alter Table Usuario With Check Add Constraint FK_Usuario_Perfil Foreign Key (ID_PERFIL)
References Perfil (ID_PERFIL)
Go

Alter Table Usuario Check Constraint FK_Usuario_Perfil
Go

Create Table Menu_Web(
	ID_MENU_WEB		Int NOT NULL
	,ID_MENU_PAI		Int NULL
	,NM_DESCRICAO	Varchar(100) NOT NULL
	,NM_URL				Varchar(120) NULL
	,ID_Sistema		Int NOT NULL
 CONSTRAINT [PK_MENU_WEB] PRIMARY KEY CLUSTERED 
(
	[ID_MENU_WEB] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

Create Table Menu_Web_Permissao(
	ID_MENU_WEB	Int Not Null,
	ID_USUARIO	Int Not Null,
 Constraint [PK_Menu_Web_Permissao] PRIMARY KEY CLUSTERED 
(
	ID_MENU_WEB Asc,
	ID_USUARIO	Asc
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
Go

Alter Table Menu_Web_Permissao WITH NOCHECK ADD CONSTRAINT [FK_Menu_Web_Permissao_Usuario] FOREIGN KEY([ID_USUARIO])
References Usuario ([ID_USUARIO])
On Delete Cascade
Go

Alter Table Menu_Web_Permissao CHECK CONSTRAINT [FK_Menu_Web_Permissao_Usuario]
Go

Alter Table Menu_Web_Permissao WITH NOCHECK ADD CONSTRAINT [FK_Menu_Web_Permissao_Menu_Web] FOREIGN KEY([ID_MENU_WEB])
References Menu_Web ([ID_MENU_WEB])
On Delete Cascade
Go

Alter Table Menu_Web_Permissao Check Constraint [FK_Menu_Web_Permissao_Menu_Web]
Go

Create Table Sistema(
	ID_SISTEMA		Int Identity(1,1) NOT NULL
	,NM_DESCRICAO	Varchar(50) NOT NULL
	,DT_CADASTRO	DateTime NOT NULL
 CONSTRAINT [PK_Sistema] PRIMARY KEY CLUSTERED 
(
	[ID_Sistema] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

Alter Table Menu_Web With Check Add Constraint  [FK_Menu_Web_Sistema] FOREIGN KEY(ID_SISTEMA)
References Sistema (ID_SISTEMA)
Go

Alter Table Menu_Web Check Constraint [FK_Menu_Web_Sistema]
Go


Create Table ListaMoeda(
	 ID_MOEDA			Int						Not Null
	,NM_SIGLA			Varchar(5)		NULL
	,NM_DESCRICAO	Varchar(50)		NULL
	,VL_BASE			Decimal(20,2)	NULL
	,VL_REAL			Decimal(20,2)	NULL 
	,FL_HABILITA	Tinyint				NULL
 CONSTRAINT [PK_MOEDA] PRIMARY KEY CLUSTERED 
(
	[ID_MOEDA] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
Go

Create Table ParamSite(
	ID_PARAMSITE	Tinyint IDENTITY(1,1) NOT NULL,
	NM_URLSITE		Varchar(512) NULL,
	NM_SMTP_USER	Varchar(100) NULL,
	NM_SMTP_SRV		Varchar(50) NULL,
	NM_SMTP_PASS	Varchar(50) NULL,
	TP_SMTP_AUTENTIC Tinyint NULL,
	NR_SMTP_PORT	Int NULL,
	DS_EMAILBCC		Varchar(100) NULL,
	NM_SMTP_EMAIL	Varchar(100) NULL,
	NM_DIRETORIO_LOGO	Varchar(max) NULL,
 Constraint [PK_ParamSite] PRIMARY KEY CLUSTERED 
(
	[ID_PARAMSITE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
Go

Create Table Banco(
	ID_BANCO			Int	Identity(1,1) NOT NULL
	,NM_DESCRICAO	Varchar(100)			NULL
	,NR_BANCO			Varchar(5)				NULL

	CONSTRAINT [PK_Banco] PRIMARY KEY CLUSTERED 
	(
		ID_BANCO	ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
Go

Create Table Conta(
	ID_CONTA						Int	Identity(1,1) NOT NULL
	,ID_USUARIO					Int								NOT NULL
	,ID_BANCO						Int								NOT NULL
	,NR_AGENCIA					Varchar(10)				NOT NULL
	,NR_CCORRENTE				Varchar(20)				NOT NULL
	,NR_DV							Varchar(3)				NOT NULL
	,VL_SALDO						Decimal(20,2)			NULL
	,FL_HABILITA				Tinyint						NULL					
	,DT_CADASTRO				DateTime					NULL
	,ID_USUARIOCADASTRO	Int								NULL
	CONSTRAINT [PK_Conta] PRIMARY KEY CLUSTERED 
	(
		ID_CONTA	ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
Go

Alter Table Conta WITH NOCHECK ADD CONSTRAINT [FK_Conta_Usuario] FOREIGN KEY([ID_USUARIO])
References Usuario ([ID_USUARIO])
On Delete Cascade
Go

Alter Table Conta CHECK CONSTRAINT [FK_Conta_Usuario]
Go

Alter Table Conta WITH NOCHECK ADD CONSTRAINT [FK_Conta_BANCO] FOREIGN KEY([ID_BANCO])
References Banco ([ID_BANCO])
On Delete Cascade
Go

Alter Table Conta CHECK CONSTRAINT [FK_Conta_Banco]
Go

Create Table Transacao(
	ID_TRANSACAO			Int Identity(1,1) NOT NULL
	,ID_USUARIO_DE		Int								NOT NULL
	,ID_CONTA_DE			Int
	,ID_USUARIO_PARA	Int								NOT NULL
	,ID_CONTA_PARA		Int
	,VL_BRUTO					Decimal(20,2)			NOT NULL
	,DT_TRANSACAO			DateTime					NOT NULL
	CONSTRAINT [PK_Transacao] PRIMARY KEY CLUSTERED 
	(
		ID_TRANSACAO	ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
Go

Alter Table Transacao WITH NOCHECK ADD CONSTRAINT [FK_Transacao_Usuario_DE] FOREIGN KEY([ID_USUARIO_DE])
References Usuario ([ID_USUARIO])
On Delete Cascade
Go

Alter Table Transacao CHECK CONSTRAINT [FK_Transacao_Usuario_DE]
Go

Create View [dbo].[vw_lstTransacao]
As
Select T.ID_TRANSACAO			As ID_Transacao
			,T.ID_USUARIO_DE		As ID_Usuario_De
			,U1.NM_NOME					As NM_Usuario_De
			,U1.NR_CPF					As NR_CPF_De
			,B1.NM_DESCRICAO		As NM_Banco_De
			,C1.VL_SALDO				As VL_Saldo_De
			,T.VL_BRUTO					As VL_Transacao
			,T.ID_USUARIO_PARA	As ID_Usuario_Para
			,U2.NM_NOME					As NM_Usuario_Para
			,U2.NR_CPF					As NR_CPF_Para
			,B2.NM_DESCRICAO		As NM_Banco_Para
			,C2.VL_SALDO				As VL_Saldo_Para
			,T.DT_TRANSACAO			As DT_Transacao
	From Transacao As T
	Inner Join Usuario As U1
		On T.ID_USUARIO_DE = U1.ID_USUARIO
	Inner Join Usuario As U2
		On T.ID_USUARIO_PARA = U2.ID_USUARIO
	Inner Join Conta As C1
		On T.ID_CONTA_DE = C1.ID_CONTA
	Inner Join Banco As B1
		On C1.ID_BANCO = B1.ID_BANCO
	Inner Join Conta As C2
		On T.ID_CONTA_PARA = C2.ID_CONTA
	Inner Join Banco As B2
		On C2.ID_BANCO = B2.ID_BANCO
Go

Create View [dbo].[vw_lstContas]
As
Select C.ID_CONTA			As ID
			,U.NM_NOME			As NM_Cliente
			,U.NR_CPF				As NR_CPF
			,B.NR_BANCO			As NR_Banco
			,B.NM_DESCRICAO	As NM_Banco
			,C.NR_AGENCIA		As NR_Agencia
			,C.NR_CCORRENTE	As NR_ContaCorrente
			,C.NR_DV				As NR_Digito
			,C.VL_SALDO			As VL_Saldo
			,Cast(C.DT_CADASTRO	as Date) As DT_Cadastro
	From Conta As C
	Inner Join Usuario As U
		On C.ID_USUARIO = U.ID_USUARIO
	Inner Join Banco As B
		On C.ID_BANCO = B.ID_BANCO
Go
