SELECT * FROM Person WHERE RelationWithCompany != 'Client';
SELECT * FROM Person WHERE RelationWithCompany = 'Client';
UPDATE Person 
SET EmployeeExperienceType = 'Apprentice',
 EmployeeType = 'Receptionist'
WHERE RelationWithCompany != 'Client';

SELECT * FROM CustomerConversation ;
INSERT INTO CustomerConversation (Client_IdOsoba, Employee_IdOsoba, MarkServiceQuality, StartDateTime, EndDateTime, ConversationDurationInSeconds)
VALUES(10,11, 3, convert(datetime,'13-06-21 10:34:09 PM',5), convert(datetime,'13-06-21 10:54:09 PM',5), 1200);
