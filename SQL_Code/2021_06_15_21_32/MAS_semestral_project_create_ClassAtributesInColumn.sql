-- Created by Vertabelo (http://vertabelo.com)
-- Last modification date: 2021-06-15 18:36:37.207

-- tables
-- Table: ClassAttributesInColumn
CREATE TABLE ClassAttributesInColumn (
    Id int  NOT NULL,
    EmployeeMaxHourRate decimal(10,2)  NOT NULL,
    DirectorMaxHourRate decimal(10,2)  NOT NULL,
    CleanerMaxHourRate decimal(10,2)  NOT NULL,
    ReceptionistMaxHourRate decimal(10,2)  NOT NULL,
    Cleaner_Receptionist__MaxHourRate decimal(10,2)  NOT NULL,
    CleanerMaxToolsQuantity int  NOT NULL,
    CONSTRAINT ClassAttributesInColumn_pk PRIMARY KEY  (Id)
);

-- End of file.

