﻿CREATE TABLE [dbo].[USUARIO]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [USERNAME] VARCHAR(50) NOT NULL, 
    [PASSWORD] VARCHAR(50) NOT NULL, 
    [DATA] DATETIME NULL, 
    [TOKEN] VARCHAR(MAX) NULL
)
