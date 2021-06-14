-- As Client
INSERT INTO Person(RelationWithCompany, FirstName, SecondName, PassportData, PhoneNumber) 
VALUES('Client', 'Ala', 'Kota', '231AD', '+48921415');
 SELECT * FROM Person;
-- ALTER TABLE KnowedLanguage ALTER COLUMN Name varchar(100);
-- SELECT * FROM KnowedLanguage;
-- KnowedLanguage
INSERT INTO KnowedLanguage (Name)
VALUES('English'),
( 'Polish'),
( 'Japan'),
( 'Germany');



-- AS employee, Recepcjonist.
INSERT INTO Person( RelationWithCompany, FirstName, SecondName, InternshipDaysInCurentHotel, HourRate, LastDateChangeRate, WorkShift)
VALUES('Employee', 'Szyza', 'Kolin', 100, 13.5, GETDATE(), 'day-night');
--
-- ALTER TABLE PlaceWork  ALTER COLUMN name VARCHAR(120);
INSERT INTO PlaceWork (name, Employee_IdPerson)
VALUES('Samsung Company', 11);

INSERT INTO Language_Employee(KnowedLanguage_IdLanguage, Osoba_IdOsoba)
values(11,11),
(12,11);


SELECT * FROM Person;

-- CREATE VIEW Client AS SELECT IdOsoba, RelationWithCompany, FirstName, SecondName, PassportData, PhoneNumber FROM Person WHERE RelationWithCompany = 'Client';
-- DROP VIEW Client ;
-- SELECT * FROM Client;