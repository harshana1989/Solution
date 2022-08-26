/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/


INSERT INTO [dbo].[Categories] ([Name],[IsActive]) select 'Burgers',1 
where not exists(select 1 from [dbo].[Categories] where name='Burgers')
INSERT INTO [dbo].[Categories] ([Name],[IsActive]) select 'Drinks',1 
where not exists(select 1 from [dbo].[Categories] where name='Drinks')
INSERT INTO [dbo].[Categories] ([Name],[IsActive]) select 'Curries',1 
where not exists(select 1 from [dbo].[Categories] where name='Curries')

INSERT INTO [dbo].[Subcategory] ([Name],[Description],[Price],[AvalabalOptionsCount],[CatagoryId],[IsActive]) select 'Milkshakes','Milkshakes',200,2,1,1 
where not exists(select 1 from [dbo].[Subcategory] where name='Drinks')

INSERT INTO [dbo].[Subcategory] ([Name],[Description],[Price],[AvalabalOptionsCount],[CatagoryId],[IsActive]) select 'Soft drinks','Soft drinks',200,2,1,1 
where not exists(select 1 from [dbo].[Subcategory] where name='Soft drinks')


INSERT INTO [dbo].[Options] ([Name],[IsActive]) select 'Tomatoes',1 
where not exists(select 1 from [dbo].[Options] where name='Tomatoes')
INSERT INTO [dbo].[Options] ([Name],[IsActive]) select 'Onions',1 
where not exists(select 1 from [dbo].[Options] where name='Onions')
INSERT INTO [dbo].[Options] ([Name],[IsActive]) select 'Garlic Sauce',1 
where not exists(select 1 from [dbo].[Options] where name='Garlic Sauce')