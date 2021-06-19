-- Created by Vertabelo (http://vertabelo.com)
-- Last modification date: 2021-06-19 18:37:38.463

-- tables
-- Table: ConnectionItemPage
CREATE TABLE ConnectionItemPage (
    "Order" int  NOT NULL,
    MenuBarItem_IdMenuBarItem int  NOT NULL,
    WebPage_IdWebPage int  NOT NULL,
    CONSTRAINT ConnectionItemPage_pk PRIMARY KEY  (MenuBarItem_IdMenuBarItem,WebPage_IdWebPage)
);

-- Table: MenuBarItem
CREATE TABLE MenuBarItem (
    IdMenuBarItem int  NOT NULL,
    Name varchar(100)  NOT NULL,
    CONSTRAINT MenuBarItem_pk PRIMARY KEY  (IdMenuBarItem)
);

-- Table: WebPage
CREATE TABLE WebPage (
    IdWebPage int  NOT NULL,
    Name varchar(100)  NOT NULL,
    CONSTRAINT WebPage_pk PRIMARY KEY  (IdWebPage)
);

-- foreign keys
-- Reference: Table_18_MenuBarItem (table: ConnectionItemPage)
ALTER TABLE ConnectionItemPage ADD CONSTRAINT Table_18_MenuBarItem
    FOREIGN KEY (MenuBarItem_IdMenuBarItem)
    REFERENCES MenuBarItem (IdMenuBarItem);

-- Reference: Table_18_WebPage (table: ConnectionItemPage)
ALTER TABLE ConnectionItemPage ADD CONSTRAINT Table_18_WebPage
    FOREIGN KEY (WebPage_IdWebPage)
    REFERENCES WebPage (IdWebPage);

-- End of file.

