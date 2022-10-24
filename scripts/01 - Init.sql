PRINT N'Iniciando script para LeadProjectDatabase';
GO

IF NOT EXISTS (SELECT name FROM master.sys.databases WHERE name = N'LeadProjectDatabase')
CREATE DATABASE LeadProjectDatabase
GO

USE [LeadProjectDatabase]
GO

PRINT N'Criando a tabela Lead';
GO
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Lead') BEGIN
CREATE TABLE [dbo].[Lead](
	[Id] [UNIQUEIDENTIFIER] NOT NULL,
	[FirstName] [nvarchar](100) NOT NULL,
	[LastName] [nvarchar](100) NOT NULL,
	[DateCreated] datetime NOT NULL,
	[PhoneNumber] [nvarchar](30) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Suburb] [nvarchar](50) NOT NULL,
	[Category] [nvarchar](50) NOT NULL,
	[JobId] [bigint] NOT NULL,
	[Description] [nvarchar](1000) NOT NULL,
	[Price] [smallmoney] NOT NULL,
	[Status] [tinyint] NOT NULL,
	[ModifiedDate] datetime NOT NULL,
	[ModifiedUser] [nvarchar](100) NOT NULL
 CONSTRAINT [Lead_PK] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END