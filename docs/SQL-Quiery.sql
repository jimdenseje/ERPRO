CREATE TABLE Addresse (
    ID INT IDENTITY (1,1) NOT NULL PRIMARY KEY,
    Country VARCHAR(60) NOT NULL,
    City VARCHAR(60) NOT NULL,
    ZipCode VARCHAR(60) NOT NULL,
    BuildingNumber VARCHAR(60) NOT NULL,
    Road VARCHAR(60) NOT NULL,
    LocationName VARCHAR(60) NOT NULL
);

CREATE TABLE Person (
    ID INT IDENTITY (1,1) NOT NULL PRIMARY KEY,
    FirstName VARCHAR(max) NOT NULL,
    LastName VARCHAR(max) NOT NULL,
    PhoneNumber VARCHAR(100) NOT NULL,
    Email VARCHAR(max) NOT NULL,
    AddresseID INT FOREIGN KEY REFERENCES Addresse(ID)
);

--DROP TABLE Customer
CREATE TABLE Customer (
    ID INT FOREIGN KEY REFERENCES Person(ID),
    CustomerNumber INT IDENTITY (1,1) NOT NULL,
    LastPurchase DATETIME NOT NULL,
);

CREATE TABLE Corporation (
    ID INT IDENTITY (1,1) NOT NULL PRIMARY KEY,
    CorporationName VARCHAR(60) NOT NULL,
    Currency VARCHAR(60),
    AddresseID INT FOREIGN KEY REFERENCES Addresse(ID)
);

CREATE TABLE SaleOrderStatus (
    ID TINYINT NOT NULL PRIMARY KEY,
    name VARCHAR(12) NOT NULL,
);

CREATE TABLE Product (
    ID INT NOT NULL PRIMARY KEY,
    ItemName VARCHAR(max) NOT NULL,
    ItemDescription VARCHAR(max) NOT NULL,
    SellingPrice DECIMAL NOT NULL,
    PurchasePrice DECIMAL NOT NULL,
    StorageID INT FOREIGN KEY REFERENCES Addresse(ID) NOT NULL,
    QTY DECIMAL NOT NULL,
    UNIT VARCHAR(max) NOT NULL,
    -- CONSTRAINT UQ_Product UNIQUE NONCLUSTERED(
    --     ItemName, StorageID
    -- )
);

CREATE TABLE SaleOrder (
    OrderNumber INT IDENTITY (1,1) NOT NULL PRIMARY KEY,
    TimeOfCreation DATETIME NOT NULL,
    TimeOfAcceptance DATETIME NOT NULL,
    PersonID INT FOREIGN KEY REFERENCES Person(ID),
    Status TINYINT FOREIGN KEY REFERENCES SaleOrderStatus(ID)
);

CREATE TABLE SalesOrderLineProduct (
    ID INT NOT NULL PRIMARY KEY,
    ItemName VARCHAR(max) NOT NULL,
    ItemDescription VARCHAR(max) NOT NULL,
    SellingPrice DECIMAL NOT NULL,
    PurchasePrice DECIMAL NOT NULL,
    StorageID INT FOREIGN KEY REFERENCES Addresse(ID) NOT NULL,
    QTY DECIMAL NOT NULL,
    UNIT VARCHAR(max) NOT NULL,
    -- CONSTRAINT UQ_Product UNIQUE NONCLUSTERED(
    --     ItemName, StorageID
    -- )
);


CREATE TABLE SaleOrderLine (
    SaleOrder INT FOREIGN KEY REFERENCES SaleOrder(OrderNumber),
    SalesOrderLineProductID INT FOREIGN KEY REFERENCES SalesOrderLineProduct(ID)
);