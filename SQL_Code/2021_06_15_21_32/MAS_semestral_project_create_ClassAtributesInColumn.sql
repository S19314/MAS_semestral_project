-- Created by Vertabelo (http://vertabelo.com)
-- Last modification date: 2021-06-15 18:46:45.199

-- tables
-- Table: ClassAttributesInColumn
CREATE TABLE ClassAttributesInColumn (
    Id int  NOT NULL,
    EmployeeMaxHourRate decimal(10,2)  NULL,
    DirectorMaxHourRate decimal(10,2)  NULL,
    CleanerMaxHourRate decimal(10,2)  NULL,
    ReceptionistMaxHourRate decimal(10,2)  NULL,
    Cleaner_Receptionist__MaxHourRate decimal(10,2)  NULL,
    CleanerMaxToolsQuantity int  NULL,
    CONSTRAINT ClassAttributesInColumn_pk PRIMARY KEY  (Id)
);

-- End of file.

