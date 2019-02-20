CREATE TABLE [dbo].[tblMovie]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Title] VARCHAR(50) NOT NULL, 
    [Description] VARCHAR(255) NOT NULL, 
    [ImagePath] VARCHAR(255) NOT NULL, 
	[Cost] DECIMAL(19, 4) NOT NULL,
    [RatingId] INT NOT NULL, 
    [FormatId] INT NOT NULL, 
    [DirectorId] INT NOT NULL, 
    [Quantity] INT NOT NULL
)
