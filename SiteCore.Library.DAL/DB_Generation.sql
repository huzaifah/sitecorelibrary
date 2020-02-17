--
-- This script was generated by Valentina Studio
-- Application homepage: http://www.valentina-db.com/
--


-- --------------------------------------------------------------------------------
-- Create Schemas
-- --------------------------------------------------------------------------------

BEGIN TRANSACTION;

-- CREATE SCHEMA "dbo" -----------------------------------------
IF NOT EXISTS ( 
	SELECT sys_sch.name 
	FROM sys.schemas sys_sch 
	WHERE sys_sch.name = N'dbo' )
BEGIN
	EXEC sp_executesql N'CREATE SCHEMA [dbo] AUTHORIZATION dbo'
END
GO;
-- -------------------------------------------------------------

COMMIT TRANSACTION;
GO


-- --------------------------------------------------------------------------------
-- Create Tables
-- --------------------------------------------------------------------------------

BEGIN TRANSACTION;

-- CREATE TABLE "Books" ----------------------------------------
CREATE TABLE [dbo].[Books] ( 
	[Id] INT IDENTITY ( 1, 1 )  NOT NULL, 
	[Title] VARCHAR( 256 ) NOT NULL, 
	[Author] VARCHAR( 256 ) NULL, 
	CONSTRAINT [unique_Title] UNIQUE ( [Title] ) )
GO;
-- -------------------------------------------------------------

COMMIT TRANSACTION;
GO


-- --------------------------------------------------------------------------------
-- Populate Tables
-- --------------------------------------------------------------------------------

SET IDENTITY_INSERT [dbo].[Books] ON
GO
INSERT INTO [dbo].[Books] ([Id],[Title],[Author]) VALUES ( 1,N'Programming in C#',N'Microsoft' );
INSERT INTO [dbo].[Books] ([Id],[Title],[Author]) VALUES ( 2,N'Harry Porter',N'JK Rowling' );


GO

SET IDENTITY_INSERT [dbo].[Books] OFF
GO