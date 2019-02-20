﻿CREATE TABLE [dbo].[tblCustomer]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [FirstName] VARCHAR(50) NOT NULL, 
    [LastName] VARCHAR(50) NOT NULL, 
    [Address] VARCHAR(255) NOT NULL, 
    [City] VARCHAR(50) NOT NULL, 
    [State] VARCHAR(2) NOT NULL, 
    [ZIP] VARCHAR(10) NOT NULL, 
    [Phone] VARCHAR(15) NOT NULL, 
    [UserId] INT NOT NULL
)
