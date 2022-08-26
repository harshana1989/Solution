CREATE TABLE [dbo].[Options]
(
	[Id] INT NOT NULL identity(1,1) PRIMARY KEY,
	[Name] NVARCHAR(MAX) NULL,
	IsActive BIT NULL
)
