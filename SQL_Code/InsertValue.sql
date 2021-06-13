-- As Client
INSERT INTO Person(IdOsoba, RelationWithCompany, FirstName, SecondName, PassportData, PhoneNumber) 
VALUES(1, 'Client', 'Ala', 'Kota', '231AD', '+48921415');

-- ALTER TABLE KnowedLanguage ALTER COLUMN Name varchar(100);
-- SELECT * FROM KnowedLanguage;
-- KnowedLanguage
INSERT INTO KnowedLanguage (IdLanguage, Name)
VALUES(1,'English'),
(2, 'Polish'),
(3, 'Japan'),
(4, 'Germany');



-- AS employee, Recepcjonist.
INSERT INTO Person(IdOsoba, RelationWithCompany, FirstName, SecondName, InternshipDaysInCurentHotel, HourRate, LastDateChangeRate, WorkShift)
VALUES(2, 'Employee', 'Szyza', 'Kolin', 100, 13.5, GETDATE(), 'day-night');
--
INSERT INTO PlaceWork (IdPlaceWork, name, Employee_IdPerson)
VALUES(1, 'Samsung Company', 2);

INSERT INTO Language_Employee(KnowedLanguage_IdLanguage, Osoba_IdOsoba)
values(1,2),
(2,2);;


SELECT * FROM Person;

CREATE VIEW Client AS SELECT IdOsoba, RelationWithCompany, FirstName, SecondName, PassportData, PhoneNumber FROM Person WHERE RelationWithCompany = 'Client';
-- DROP VIEW Client ;
SELECT * FROM Client;