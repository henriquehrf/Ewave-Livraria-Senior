IF NOT EXISTS (SELECT name FROM [master].[dbo].[sysdatabases] WHERE name = N'ToDo')
BEGIN
	USE [master];
	CREATE DATABASE [ToDo];
END
GO

USE [ToDo];
GO

CREATE TABLE [dbo].[InstituicaoEnsino](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](100) NOT NULL,
	[Endereco] [varchar](200) NOT NULL,
	[CNPJ] [char](18) NOT NULL,
	[Telefone] [varchar](20) NOT NULL,
	[GuidFoto] [uniqueidentifier] NULL,
	[Ativo] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[InstituicaoEnsino](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](100) NOT NULL,
	[Endereco] [varchar](200) NOT NULL,
	[CNPJ] [char](18) NOT NULL,
	[Telefone] [varchar](20) NOT NULL,
	[GuidFoto] [uniqueidentifier] NULL,
	[Ativo] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


CREATE TABLE [dbo].[Livro](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Titulo] [varchar](100) NOT NULL,
	[Genero] [varchar](100) NOT NULL,
	[Autor] [varchar](100) NOT NULL,
	[Sinopse] [varchar](200) NOT NULL,
	[GuidCapa] [uniqueidentifier] NOT NULL,
	[Ativo] [bit] NOT NULL,
 CONSTRAINT [PK_Livro] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Usuario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](100) NOT NULL,
	[Endereco] [varchar](200) NULL,
	[Cpf] [char](14) NOT NULL,
	[IdInstituicaoEnsino] [int] NULL,
	[Telefone] [varchar](20) NULL,
	[Email] [varchar](100) NULL,
	[Login] [varchar](100) NOT NULL,
	[Senha] [varchar](500) NOT NULL,
	[DataSuspencao] [datetime] NULL,
	[PerfilUsuario] [int] NOT NULL,
	[GuidFoto] [uniqueidentifier] NULL,
	[Ativo] [bit] NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_InstituicaoEnsino] FOREIGN KEY([IdInstituicaoEnsino])
REFERENCES [dbo].[InstituicaoEnsino] ([Id])
GO

ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_InstituicaoEnsino]
GO

CREATE TABLE [dbo].[Emprestimo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdUsuario] [int] NOT NULL,
	[IdLivro] [int] NOT NULL,
	[DataEmprestimo] [datetime] NOT NULL,
	[DataPrevistaDevolucao] [datetime] NULL,
	[DataDevolucao] [datetime] NULL,
 CONSTRAINT [PK_Emprestimo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Emprestimo]  WITH CHECK ADD  CONSTRAINT [FK_Emprestimo_Livro] FOREIGN KEY([IdLivro])
REFERENCES [dbo].[Livro] ([Id])
GO

ALTER TABLE [dbo].[Emprestimo] CHECK CONSTRAINT [FK_Emprestimo_Livro]
GO

ALTER TABLE [dbo].[Emprestimo]  WITH CHECK ADD  CONSTRAINT [FK_Emprestimo_Usuario] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([Id])
GO

ALTER TABLE [dbo].[Emprestimo] CHECK CONSTRAINT [FK_Emprestimo_Usuario]
GO


CREATE TABLE [dbo].[Reserva](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdUsuario] [int] NOT NULL,
	[IdLivro] [int] NOT NULL,
	[DataReserva] [datetime] NOT NULL,
	[Ativo] [bit] NOT NULL,
 CONSTRAINT [PK_Reserva] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Reserva]  WITH CHECK ADD  CONSTRAINT [FK_Reserva_Livro] FOREIGN KEY([IdLivro])
REFERENCES [dbo].[Livro] ([Id])
GO

ALTER TABLE [dbo].[Reserva] CHECK CONSTRAINT [FK_Reserva_Livro]
GO

ALTER TABLE [dbo].[Reserva]  WITH CHECK ADD  CONSTRAINT [FK_Reserva_Usuario] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([Id])
GO

ALTER TABLE [dbo].[Reserva] CHECK CONSTRAINT [FK_Reserva_Usuario]
GO