CREATE TABLE [dbo].[Subcategory]
(
	[Id] INT NOT NULL identity(1,1) PRIMARY KEY,
	[Name] NVARCHAR(MAX) NULL,
	[Description] NVARCHAR(MAX) NULL,
	[Price] decimal(8,2) NULL,
	[AvalabalOptionsCount] INT NOT NULL DEFAULT 0,
	CatagoryId int NOT NULL,
	IsActive BIT NULL
	constraint FK_Catagory Foreign Key (CatagoryId) References [Subcategory](Id),
)
