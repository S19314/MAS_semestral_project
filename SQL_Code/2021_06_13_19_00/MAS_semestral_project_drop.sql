-- Created by Vertabelo (http://vertabelo.com)
-- Last modification date: 2021-06-13 15:59:21.226

-- foreign keys
ALTER TABLE CleaningTools DROP CONSTRAINT CleaningTools_Osoba;

ALTER TABLE CustomerConversation DROP CONSTRAINT CustomerConversation_Client;

ALTER TABLE CustomerConversation DROP CONSTRAINT CustomerConversation_Employee;

ALTER TABLE Language_Employee DROP CONSTRAINT Language_Employee_KnowedLanguage;

ALTER TABLE Language_Employee DROP CONSTRAINT Language_Employee_Osoba;

ALTER TABLE LastCleanedRoom DROP CONSTRAINT LastCleanedRoom_CleaningGroup;

ALTER TABLE LastCleanedRoom DROP CONSTRAINT LastCleanedRoom_Room;

ALTER TABLE Offer DROP CONSTRAINT Offer_Room;

ALTER TABLE "Order" DROP CONSTRAINT Order_Client;

ALTER TABLE "Order" DROP CONSTRAINT Order_Employee;

ALTER TABLE "Order" DROP CONSTRAINT Order_Offer;

ALTER TABLE Person DROP CONSTRAINT Osoba_CleaningGroup;

ALTER TABLE PlaceWork DROP CONSTRAINT PlaceWork_Person;

-- tables
DROP TABLE ClassAttributes;

DROP TABLE CleaningGroup;

DROP TABLE CleaningTools;

DROP TABLE CustomerConversation;

DROP TABLE KnowedLanguage;

DROP TABLE Language_Employee;

DROP TABLE LastCleanedRoom;

DROP TABLE Offer;

DROP TABLE "Order";

DROP TABLE Person;

DROP TABLE PlaceWork;

DROP TABLE Room;

-- End of file.

