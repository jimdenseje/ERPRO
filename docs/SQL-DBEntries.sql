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

-- FOR TESTING PURPOSES::
-- SELECT * FROM Addresse





--The following adds the corporation data to the DB

-- INSERT INTO Corporation (CorporationName, Currency, AddresseID)
-- VALUES ('Fisketorvet', 'DKK', '5');

-- INSERT INTO Corporation (CorporationName, Currency, AddresseID)
-- VALUES ('Jensens Fiskebiks', 'DKK', '6');

-- INSERT INTO Corporation (CorporationName, Currency, AddresseID)
-- VALUES ('Skabsrokken', 'EUR', '5');

-- SELECT * FROM Corporation

UPDATE Corporation
SET CorporationName = 'Fisketorvet', Currency = 'DKK'
WHERE ID = 1;
