CREATE TABLE [dbo].[Items]
(
	[Id] INT NOT NULL identity(1,1) PRIMARY KEY,
	[SubCatID] int,
	[Title] NVARCHAR(MAX) NULL,
	[Description] NVARCHAR(MAX) NULL,
	[Price] decimal(8,2),
	IsActive BIT NULL, 
    constraint FK_Items Foreign Key (SubCatID) References [Subcategory](Id),
)
