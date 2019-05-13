CREATE TABLE [dbo].[Aluno]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [nome] VARCHAR(50) NULL, 
    [sobrenome] VARCHAR(70) NULL, 
    [telefone] VARCHAR(50) NULL, 
    [data] VARCHAR(50) NULL, 
    [ra] INT NULL, 
    [descricao] TEXT NULL
)
