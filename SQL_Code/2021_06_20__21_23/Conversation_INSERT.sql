use MAS_semestral;
SELECT * FROM Person WHERE RelationWithCompany != 'Client';
SELECT * FROM Person WHERE IdOsoba in (10,11);
SELECT * FROM Person WHERE RelationWithCompany = 'Client';
UPDATE Person 
SET EmployeeExperienceType = 'Apprentice',
 EmployeeType = 'Receptionist'
WHERE RelationWithCompany != 'Client';

SELECT * FROM CustomerConversation ;
INSERT INTO CustomerConversation (Client_IdOsoba, Employee_IdOsoba, MarkServiceQuality, StartDateTime, EndDateTime, ConversationDurationInSeconds)
VALUES(10,11, 3, convert(datetime,'13-06-21 10:34:09 PM',5), convert(datetime,'13-06-21 10:54:09 PM',5), 1200);

/*
Добавить/вставить данные: Комната, оффер, заказ.
*/
SELECT * FROM [MAS_semestral].[dbo].[Room];
INSERT INTO [MAS_semestral].[dbo].[Room] ( SeatQuantity, RoomDescription, RoomType)
VALUES( 2, 'Obok morza', 'Standard');	
SELECT * FROM [MAS_semestral].[dbo].[Offer];
INSERT INTO [MAS_semestral].[dbo].[Offer] (OfferStatus, AvailableTo, AvailableFrom, Room_IdRoom, RoomPrice)
VALUES( 'Completed', convert(datetime,'13-08-21 10:34:09 PM',5), convert(datetime,'13-09-21 10:54:09 PM',5), 10, 3000 );

-- Tut DOWN
SELECT * FROM [MAS_semestral].[dbo].[Offer];
/*
INSERT INTO [MAS_semestral].[dbo].[Offer] (Id, OfferStatus, AvailableTo, AvailableFrom, Room_IdRoom)
VALUES;
*/
SELECT * FROM [MAS_semestral].[dbo].[Order];
INSERT INTO [MAS_semestral].[dbo].[Order] ( CreationDate, Offer_Id, Osoba_IdOsoba, Osoba_2_IdOsoba)
VALUES(convert(datetime,'13-08-21 10:54:09 PM',5), 11, 10, 11);

SELECT * FROM [MAS_semestral].[dbo].[Order]
INNNER JOIN Person AS Client
ON Client.IdOsoba = Osoba_IdOsoba;