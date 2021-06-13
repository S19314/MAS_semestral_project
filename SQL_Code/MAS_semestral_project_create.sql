-- Created by Vertabelo (http://vertabelo.com)
-- Last modification date: 2021-06-10 08:58:22.338

-- tables
-- Table: CleaningGroup
CREATE TABLE CleaningGroup (
    IdGroup int  NOT NULL,
    StartWorkTime datetime  NOT NULL,
    EndWorkTime datetime  NOT NULL,
    CONSTRAINT CleaningGroup_pk PRIMARY KEY  (IdGroup)
);

-- Table: CleaningTools
CREATE TABLE CleaningTools (
    IdTool int  NOT NULL,
    Name varchar(100)  NOT NULL,
    Osoba_IdOsoba int  NOT NULL,
    CONSTRAINT CleaningTools_pk PRIMARY KEY  (IdTool)
);

-- Table: CustomerConversation
CREATE TABLE CustomerConversation (
    Client_IdOsoba int  NOT NULL,
    Employee_IdOsoba int  NOT NULL,
    MarkServiceQuality int  NOT NULL,
    StartDateTime datetime  NOT NULL,
    EndDateTime datetime  NOT NULL,
    ConversationDurationInSeconds int  NOT NULL,
    CONSTRAINT CustomerConversation_pk PRIMARY KEY  (Client_IdOsoba,Employee_IdOsoba)
);

-- Table: KnowedLanguage
CREATE TABLE KnowedLanguage (
    IdLanguage int  NOT NULL,
    Name int  NOT NULL,
    CONSTRAINT KnowedLanguage_pk PRIMARY KEY  (IdLanguage)
);

-- Table: Language_Employee
CREATE TABLE Language_Employee (
    KnowedLanguage_IdLanguage int  NOT NULL,
    Osoba_IdOsoba int  NOT NULL,
    CONSTRAINT Language_Employee_pk PRIMARY KEY  (Osoba_IdOsoba,KnowedLanguage_IdLanguage)
);

-- Table: LastCleanedRoom
CREATE TABLE LastCleanedRoom (
    IdLastCleanedRoom int  NOT NULL,
    DurationCleanedTime datetime  NOT NULL,
    CleaningGroup_IdGroup int  NOT NULL,
    Room_IdRoom int  NOT NULL,
    CONSTRAINT LastCleanedRoom_pk PRIMARY KEY  (IdLastCleanedRoom)
);

-- Table: Offer
CREATE TABLE Offer (
    Id int  NOT NULL,
    OfferStatus varchar(80)  NOT NULL,
    RoomPrice decimal(10,2)  NOT NULL,
    AvailableTo datetime  NOT NULL,
    AvailableFrom datetime  NOT NULL,
    Room_IdRoom int  NOT NULL,
    CONSTRAINT Offer_pk PRIMARY KEY  (Id)
);

-- Table: Order
CREATE TABLE "Order" (
    IdOrder int  NOT NULL,
    CreationDate datetime  NOT NULL,
    Offer_Id int  NOT NULL,
    Osoba_IdOsoba int  NOT NULL,
    Osoba_2_IdOsoba int  NOT NULL,
    CONSTRAINT Order_pk PRIMARY KEY  (IdOrder)
);

-- Table: Person
CREATE TABLE Person (
    IdOsoba int  NOT NULL,
    RelationWithCompany varchar(100)  NOT NULL,
    EmployeeType varchar(100)  NULL,
    EmployeeExperienceType varchar(100)  NULL,
    FirstName varchar(100)  NOT NULL,
    SecondName varchar(100)  NOT NULL,
    PassportData varchar(120)  NULL,
    PhoneNumber varchar(50)  NULL,
    FirstLastPlaceWork varchar(100)  NULL,
    SecondLastPlaceWork varchar(100)  NULL,
    ThirdLastPlaceWork varchar(100)  NULL,
    InternshipDaysInCurentHotel int  NULL,
    HourRate decimal(10,2)  NULL,
    LastDateChangeRate datetime  NULL,
    WorkShift varchar(60)  NULL,
    CleaningGroup_IdGroup int  NULL,
    CONSTRAINT Person_pk PRIMARY KEY  (IdOsoba)
);

-- Table: Room
CREATE TABLE Room (
    IdRoom int  NOT NULL,
    SeatQuantity int  NOT NULL,
    RoomDescription varchar(1000)  NOT NULL,
    RoomType varchar(60)  NOT NULL,
    CONSTRAINT Room_pk PRIMARY KEY  (IdRoom)
);

-- foreign keys
-- Reference: CleaningTools_Osoba (table: CleaningTools)
ALTER TABLE CleaningTools ADD CONSTRAINT CleaningTools_Osoba
    FOREIGN KEY (Osoba_IdOsoba)
    REFERENCES Person (IdOsoba);

-- Reference: CustomerConversation_Client (table: CustomerConversation)
ALTER TABLE CustomerConversation ADD CONSTRAINT CustomerConversation_Client
    FOREIGN KEY (Client_IdOsoba)
    REFERENCES Person (IdOsoba);

-- Reference: CustomerConversation_Employee (table: CustomerConversation)
ALTER TABLE CustomerConversation ADD CONSTRAINT CustomerConversation_Employee
    FOREIGN KEY (Employee_IdOsoba)
    REFERENCES Person (IdOsoba);

-- Reference: Language_Employee_KnowedLanguage (table: Language_Employee)
ALTER TABLE Language_Employee ADD CONSTRAINT Language_Employee_KnowedLanguage
    FOREIGN KEY (KnowedLanguage_IdLanguage)
    REFERENCES KnowedLanguage (IdLanguage);

-- Reference: Language_Employee_Osoba (table: Language_Employee)
ALTER TABLE Language_Employee ADD CONSTRAINT Language_Employee_Osoba
    FOREIGN KEY (Osoba_IdOsoba)
    REFERENCES Person (IdOsoba);

-- Reference: LastCleanedRoom_CleaningGroup (table: LastCleanedRoom)
ALTER TABLE LastCleanedRoom ADD CONSTRAINT LastCleanedRoom_CleaningGroup
    FOREIGN KEY (CleaningGroup_IdGroup)
    REFERENCES CleaningGroup (IdGroup);

-- Reference: LastCleanedRoom_Room (table: LastCleanedRoom)
ALTER TABLE LastCleanedRoom ADD CONSTRAINT LastCleanedRoom_Room
    FOREIGN KEY (Room_IdRoom)
    REFERENCES Room (IdRoom);

-- Reference: Offer_Room (table: Offer)
ALTER TABLE Offer ADD CONSTRAINT Offer_Room
    FOREIGN KEY (Room_IdRoom)
    REFERENCES Room (IdRoom);

-- Reference: Order_Client (table: Order)
ALTER TABLE "Order" ADD CONSTRAINT Order_Client
    FOREIGN KEY (Osoba_2_IdOsoba)
    REFERENCES Person (IdOsoba);

-- Reference: Order_Employee (table: Order)
ALTER TABLE "Order" ADD CONSTRAINT Order_Employee
    FOREIGN KEY (Osoba_IdOsoba)
    REFERENCES Person (IdOsoba);

-- Reference: Order_Offer (table: Order)
ALTER TABLE "Order" ADD CONSTRAINT Order_Offer
    FOREIGN KEY (Offer_Id)
    REFERENCES Offer (Id);

-- Reference: Osoba_CleaningGroup (table: Person)
ALTER TABLE Person ADD CONSTRAINT Osoba_CleaningGroup
    FOREIGN KEY (CleaningGroup_IdGroup)
    REFERENCES CleaningGroup (IdGroup);

-- End of file.

