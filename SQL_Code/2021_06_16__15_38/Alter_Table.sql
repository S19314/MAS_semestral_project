-- Created by Vertabelo (http://vertabelo.com)
-- Last modification date: 2021-06-16 12:38:08.77

-- tables
-- Table: ClassAttributesInColumn
ALTER TABLE ClassAttributesInColumn ADD 
    EpmloyeeMaxPlaceWorkQuantity int   NULL,
    ReceptionistMaxKnowedLanguages int   NULL,
    ReceptionistMinKnowedLanguages int  NULL
; 

-- End of file.


SELECT * FROM ClassAttributesInColumn ;
UPDATE ClassAttributesInColumn
SET EpmloyeeMaxPlaceWorkQuantity = 3,
	CleanerMaxToolsQuantity = 5,
    ReceptionistMaxKnowedLanguages = 2147483647,
    ReceptionistMinKnowedLanguages = 1
WHERE id = 1;