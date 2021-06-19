-- Created by Vertabelo (http://vertabelo.com)
-- Last modification date: 2021-06-19 18:37:38.463

-- foreign keys
ALTER TABLE ConnectionItemPage DROP CONSTRAINT Table_18_MenuBarItem;

ALTER TABLE ConnectionItemPage DROP CONSTRAINT Table_18_WebPage;

-- tables
DROP TABLE ConnectionItemPage;

DROP TABLE MenuBarItem;

DROP TABLE WebPage;

-- End of file.

