-- As Client
INSERT INTO Person(IdOsoba, RelationWithCompany, FirstName, SecondName, PassportData, PhoneNumber) 
VALUES(1, 'Client', 'Ala', 'Kota', '231AD', '+48921415');
 SELECT * FROM Person;
-- ALTER TABLE KnowedLanguage ALTER COLUMN Name varchar(100);
-- SELECT * FROM KnowedLanguage;
-- KnowedLanguage
INSERT INTO KnowedLanguage (IdLanguage, Name)
VALUES(1,'English'),
(2,'Polish'),
(3,'Japan'),
(4,'Germany');



-- AS employee, Recepcjonist.
INSERT INTO Person(IdOsoba, RelationWithCompany, FirstName, SecondName, InternshipDaysInCurentHotel, HourRate, LastDateChangeRate, WorkShift)
VALUES(11, 'Employee', 'Szyza', 'Kolin', 100, 13.5, GETDATE(), 'day-night');
--
-- ALTER TABLE PlaceWork  ALTER COLUMN name VARCHAR(120);
INSERT INTO PlaceWork (IdPlaceWork, name, Employee_IdPerson)
VALUES(1, 'Samsung Company', 11);
-- SELECT * FROM PlaceWork;

INSERT INTO Language_Employee(KnowedLanguage_IdLanguage, Osoba_IdOsoba)
values(1,11),
(2,11);


SELECT * FROM Person;

-- CREATE VIEW Client AS SELECT IdOsoba, RelationWithCompany, FirstName, SecondName, PassportData, PhoneNumber FROM Person WHERE RelationWithCompany = 'Client';
-- DROP VIEW Client ;
-- SELECT * FROM Client;