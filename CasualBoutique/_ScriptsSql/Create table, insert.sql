
DROP TABLE [dbo].[States]
GO

DROP TABLE [dbo].[Suppliers]
GO

CREATE TABLE [dbo].[States]
(
    [StateId] INT NOT NULL PRIMARY KEY IDENTITY(1, 1), 
    [StateName] NVARCHAR(100) NULL
)
GO

CREATE TABLE [dbo].[Suppliers]
(
    [SupplierId] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
    [CompanyName] NVARCHAR(200) NOT NULL,
    [ContactName] NVARCHAR(200) NOT NULL,
    [ContactTitle] NVARCHAR(200) NOT NULL,
    [Address] NVARCHAR(200) NOT NULL,
    [StateId] INT NOT NULL, 
    [Phone] NVARCHAR(50) NULL, 
    FOREIGN KEY(StateId) REFERENCES States(StateId)
)
GO

INSERT States VALUES('Connecticut')
INSERT States VALUES('Minnesota')

INSERT Suppliers VALUES(
'Connecticut Clothing', 
'Charlotte Taylor', 
'Salesperson', 
'Avenue 1 1001', 
1, 
'555-0114')
INSERT Suppliers VALUES(
'Minnesota Clothing', 
'Michael Davis', 
'Salesperson', 
'Avenue 2 2002', 
2, 
'555-0115')