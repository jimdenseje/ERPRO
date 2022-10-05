-- CREATE TABLE Addresse (
--     ID INT IDENTITY (1,1) NOT NULL PRIMARY KEY,
--     Country VARCHAR(60) NOT NULL,
--     City VARCHAR(60) NOT NULL,
--     ZipCode VARCHAR(60) NOT NULL,
--     BuildingNumber VARCHAR(60) NOT NULL,
--     Road VARCHAR(60) NOT NULL,
--     LocationName VARCHAR(60) NOT NULL
-- );

SELECT * FROM Addresse

-- SELECT * FROM Addresse WHERE ID=2

-- CREATE TABLE Person (
--     ID INT IDENTITY (1,1) NOT NULL PRIMARY KEY,
--     FirstName VARCHAR(max) NOT NULL,
--     LastName VARCHAR(max) NOT NULL,
--     PhoneNumber VARCHAR(100) NOT NULL,
--     Email VARCHAR(max) NOT NULL,
--     AddresseID INT FOREIGN KEY REFERENCES Addresse(ID)
-- );

-- SELECT * FROM Person WHERE ID=1

-- DROP TABLE Customer
-- CREATE TABLE Customer (
--     ID INT FOREIGN KEY REFERENCES Person(ID),
--     CustomerNumber INT IDENTITY (1,1) NOT NULL,
--     LastPurchase DATETIME NOT NULL,
-- );
-- ALTER TABLE Customer
-- ALTER COLUMN LastPurchase DATETIME NULL

-- INSERT INTO Customer (ID)
-- VALUES (3)

-- SELECT * FROM Addresse

-- SELECT * FROM Person

-- SELECT * FROM Customer

-- CREATE TABLE Corporation (
--     ID INT IDENTITY (1,1) NOT NULL PRIMARY KEY,
--     CorporationName VARCHAR(60) NOT NULL,
--     Currency VARCHAR(60),
--     AddresseID INT FOREIGN KEY REFERENCES Addresse(ID)
-- );

-- CREATE TABLE SaleOrderStatus (
--     ID TINYINT NOT NULL PRIMARY KEY,
--     name VARCHAR(12) NOT NULL,
-- );

-- SELECT * FROM Product
-- DROP TABLE Product

-- CREATE TABLE Product (
--     ID INT IDENTITY (1,1) NOT NULL PRIMARY KEY,
--     ItemName VARCHAR(max) NOT NULL,
--     ItemDescription VARCHAR(max) NULL,
--     SellingPrice DECIMAL NOT NULL,
--     PurchasePrice DECIMAL NOT NULL,
--     StorageID INT FOREIGN KEY REFERENCES Addresse(ID) NOT NULL,
--     QTY DECIMAL NOT NULL,
--     UNIT VARCHAR(max) NOT NULL,
-- );

CREATE TABLE SaleOrder (
    OrderNumber INT IDENTITY (1,1) NOT NULL PRIMARY KEY,
    TimeOfCreation DATETIME NOT NULL,
    TimeOfAcceptance DATETIME NOT NULL,
    PersonID INT FOREIGN KEY REFERENCES Person(ID),
    Status TINYINT FOREIGN KEY REFERENCES SaleOrderStatus(ID)
);

SELECT * FROM Person

DROP TABLE SalesOrderLineProduct

SELECT * FROM SalesOrderLineProduct

CREATE TABLE SalesOrderLineProduct (
    ID INT IDENTITY (1,1) NOT NULL PRIMARY KEY,
    ItemName VARCHAR(max) NOT NULL,
    ItemDescription VARCHAR(max) NOT NULL,
    SellingPrice DECIMAL NOT NULL,
    PurchasePrice DECIMAL NOT NULL,
    StorageID INT FOREIGN KEY REFERENCES Addresse(ID) NOT NULL,
    UNIT VARCHAR(max) NOT NULL,
);

DROP TABLE SaleOrderLine

SELECT * FROM Product
SELECT * FROM SaleOrder
SELECT * FROM SaleOrderLine
SELECT * FROM SalesOrderLineProduct

CREATE TABLE SaleOrderLine (
    ID INT IDENTITY (1,1) NOT NULL PRIMARY KEY,
    SaleOrder INT FOREIGN KEY REFERENCES SaleOrder(OrderNumber),
    SalesOrderLineProductID INT FOREIGN KEY REFERENCES SalesOrderLineProduct(ID),
    QTY DECIMAL NOT NULL
);

DROP TABLE SaleOrderLine


DELETE FROM Product
DELETE FROM SaleOrder
DELETE FROM SalesOrderLineProduct
DELETE FROM SaleOrderLine