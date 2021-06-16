CREATE TABLE lkpInventoryTypes(
IT_ID int Primary Key Identity(1,1),
IT_Type VARCHAR(50) NOT NULL,
InventoryCode VARCHAR(10) NOT NULL,
)


Insert into lkpInventoryTypes
values('Laptop','AAAA')
,('Personal Computer','AAAB')
,('Mouse','AAAC')
,('Keyboard','AAAD')
,('Table','AAAE')
,('Chair','AAAF')


Create table Inventory(
ID int Primary Key Identity(1,1),
InventoryName VARCHAR(50) NOT NULL,
InventoryType INT NOT NULL,
InventoryDescription VARCHAR(500),
InventoryPrice INT NOT NULL,
IsDeleted BIT NOT NULL,
CreatedOn DATETIME NOT NULL,
CreatedBy INT NOT NULL,
ModifiedOn DATETIME,
ModifiedBy INT,
CONSTRAINT FK_Inventory_InventoryType FOREIGN KEY (InventoryType)
    REFERENCES lkpInventoryTypes(IT_ID)
)

