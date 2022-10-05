            --The following adds the addresse data to the DB

-- INSERT INTO Addresse (Country, City, ZipCode, BuildingNumber, Road, LocationName)
-- VALUES ('', '', '', '', '', 'No Storage');

-- INSERT INTO Addresse (Country, City, ZipCode, BuildingNumber, Road, LocationName)
-- VALUES ('Danmark', 'Aarhus', '8600', '34', 'Karolinvej', 'Aarhus Lager');

-- INSERT INTO Addresse (Country, City, ZipCode, BuildingNumber, Road, LocationName)
-- VALUES ('Danmark', 'Odense', '4560', 'A2', 'Sveltevej', 'Odense Lager');

-- INSERT INTO Addresse (Country, City, ZipCode, BuildingNumber, Road, LocationName)
-- VALUES ('Danmark', 'Tønder', '2344', '3', 'Grænsevej', 'Tønder Lager');

-- INSERT INTO Addresse (Country, City, ZipCode, BuildingNumber, Road, LocationName)
-- VALUES ('England', 'Corptown', 'A325', '1', 'Corproad', 'Corporation');

-- INSERT INTO Addresse (Country, City, ZipCode, BuildingNumber, Road, LocationName)
-- VALUES ('Tyskland', 'Gesellschaftdurch', '3004', 'A56', 'Geselssweg', 'Gesellschaft');

                --Addresses used for persons:
-- INSERT INTO Addresse (Country, City, ZipCode, BuildingNumber, Road, LocationName)
-- VALUES ('Denmark', 'Haderslev', '6100', '32', 'Damsvej', 'Person Adresse');

-- INSERT INTO Addresse (Country, City, ZipCode, BuildingNumber, Road, LocationName)
-- VALUES ('Denmark', 'Sønderborg', '4600', '15', 'Ahornvej', 'Person Adresse');

-- FOR TESTING PURPOSES::
-- SELECT * FROM Addresse

SELECT * FROM Customer

SELECT * FROM Person WHERE ID = 1




            --The following adds the corporation data to the DB

-- INSERT INTO Corporation (CorporationName, Currency, AddresseID)
-- VALUES ('Fisketorvet', 'DKK', '5');

-- INSERT INTO Corporation (CorporationName, Currency, AddresseID)
-- VALUES ('Jensens Fiskebiks', 'DKK', '6');

-- INSERT INTO Corporation (CorporationName, Currency, AddresseID)
-- VALUES ('Skabsrokken', 'EUR', '5');

-- SELECT * FROM Corporation




            --The following adds persons to the db
-- INSERT INTO Person (FirstName, LastName, PhoneNumber, Email, AddresseID)
-- VALUES ('Jim', 'Damgaard', '+4550533174', 'jimdenseje@gmail.com', '7');

-- INSERT INTO Person (FirstName, LastName, PhoneNumber, Email, AddresseID)
-- VALUES ('Jonas', 'Luuk', '+456456443', 'jfd@gmail.com', '8');


            --Binding the two persons to customers
-- INSERT INTO Customer (ID, LastPurchase)
-- VALUES ('1', '20220820 10:34:09 AM');

-- INSERT INTO Customer (ID, LastPurchase)
-- VALUES ('2', '20220823 10:34:09 AM');

-- SELECT * FROM Customer





            --The following adds products to the DB
            --Storage ID 1 is nothing - 2 is Aarhus - 3 is Odense - 4 is Tønder

INSERT INTO Product (ItemName, ItemDescription, SellingPrice, PurchasePrice, StorageID, QTY, UNIT)
VALUES ('Bold', 'En rund hvid bold', '59.99', '39.99', '2', '100', 'Indefinite');

INSERT INTO Product (ItemName, ItemDescription, SellingPrice, PurchasePrice, StorageID, QTY, UNIT)
VALUES ('Basketbold', 'En rund orange og sort bold', '69.99', '42.99', '2', '100', 'Indefinite');

INSERT INTO Product (ItemName, ItemDescription, SellingPrice, PurchasePrice, StorageID, QTY, UNIT)
VALUES ('Bacon', 'Sprødt svin', '19.99', '2', '3', '40', 'Indefinite');

INSERT INTO Product (ItemName, ItemDescription, SellingPrice, PurchasePrice, StorageID, QTY, UNIT)
VALUES ('Kage', 'Kanelkage med kaffecreme', '24.99', '8', '3', '35', 'Indefinite');

INSERT INTO Product (ItemName, ItemDescription, SellingPrice, PurchasePrice, StorageID, QTY, UNIT)
VALUES ('Æble', 'Røde Pink Lady', '59.99', '38', '3', '78', 'Indefinite');

INSERT INTO Product (ItemName, ItemDescription, SellingPrice, PurchasePrice, StorageID, QTY, UNIT)
VALUES ('Maleri', 'Ægte fake picasso', '599.99', '5', '1', '25', 'Indefinite');

-- SELECT * FROM Product



            --The following adds Saleorderstatus

-- Creating the available statuses
-- INSERT INTO SaleOrderStatus (ID, name)
-- VALUES ('1', 'None');
-- INSERT INTO SaleOrderStatus (ID, name)
-- VALUES ('2', 'Created');
-- INSERT INTO SaleOrderStatus (ID, name)
-- VALUES ('3', 'Confirmed');
-- INSERT INTO SaleOrderStatus (ID, name)
-- VALUES ('4', 'Packed');



            --The following adds saleorder, saleorderlineproduct and saleorderline
--Creating the order with timestamps
INSERT INTO SaleOrder (PersonID, Status, TimeOfCreation, TimeOfAcceptance)
VALUES ('1', '2', GETDATE(), GETDATE());

INSERT INTO SaleOrder (PersonID, Status, TimeOfCreation, TimeOfAcceptance)
VALUES ('2', '3', GETDATE(), GETDATE());

SELECT * FROM SaleOrder WHERE OrderNumber = '5'

            --The following creates 3 lineproducts and 3 orderlines, adding them to the saleorders
INSERT INTO SalesOrderLineProduct (ItemName, ItemDescription, SellingPrice, PurchasePrice, StorageID, QTY, UNIT)
VALUES ('Bacon', 'Sprødt svin', '19.99', '2', '3', '4', 'Indefinite')

SELECT CAST(SCOPE_IDENTITY() AS INT)

SELECT * FROM Product


SELECT SalesOrderLineProductID FROM SaleOrderLine WHERE SaleOrder = 22
SELECT * FROM SalesOrderLineProduct WHERE ID = 13


SELECT * FROM Product
SELECT * FROM SaleOrder
SELECT * FROM SaleOrderLine
SELECT * FROM SalesOrderLineProduct


INSERT INTO SaleOrderLine (SaleOrder, SalesOrderLineProductID)
VALUES ('5', '1');

INSERT INTO SalesOrderLineProduct (ItemName, ItemDescription, SellingPrice, PurchasePrice, StorageID, QTY, UNIT)
VALUES ('Æble', 'Røde Pink Lady', '59.99', '38', '3', '4', 'Indefinite');

INSERT INTO SalesOrderLineProduct (ItemName, ItemDescription, SellingPrice, PurchasePrice, StorageID, QTY, UNIT)
VALUES ('Maleri', 'Ægte fake picasso', '599.99', '5', '1', '2', 'Indefinite');

INSERT INTO SaleOrderLine (SaleOrder, SalesOrderLineProductID)
VALUES ('6', '2');

SELECT SCOPE_IDENTITY()


INSERT INTO SaleOrderLine (SaleOrder, SalesOrderLineProductID)
VALUES ('6', '3');

-- SELECT * FROM SaleOrderLine
-- SELECT * FROM SalesOrderLineProduct

SELECT * FROM Addresse

SELECT ID FROM Addresse WHERE BuildingNumber = 'A13'