CREATE TABLE [dbo].[User]
(
	[Id] INT NOT NULL identity(1,1) PRIMARY KEY,
	[FirstName] Nvarchar(Max)  NULL,
	[LastName] Nvarchar(Max)  NULL,
)
