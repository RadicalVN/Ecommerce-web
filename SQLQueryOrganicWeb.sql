CREATE DATABASE OrganicWeb
GO

USE OrganicWeb

Create table Locations
(
	LocationId	int identity(1,1) primary Key not null,
	Name		nvarchar(150),
	Type		nvarchar(255),
	NameWithType	nvarchar(255),
	PathWithType	nvarchar(255),
	ParentId	int,
	Levels		int,
	constraint	FK_Location_Location foreign key (ParentId)
	references	Locations(LocationId)
)

Create table Categories
(
	CateId		int identity Primary Key not null,
	CateName	nvarchar(250),
	Description	nvarchar(max),
	ParentId	int,
	Levels		int,
	Ordering	int,
	Published	bit not null default 1,
	Thumb		nvarchar(250),
	Title		nvarchar(250),
	Alias		nvarchar(250),
	MetaDesc	nvarchar(250),
	MetaKey		nvarchar(250),
	Cover		nvarchar(255),
	SchemaMarkUp	nvarchar(MAX),

	constraint	FK_Category_Category foreign key (ParentId)
	references	Categories (CateId)
)

CREATE TABLE Products
(
	ProductId	INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	ProductName	NVARCHAR(255) NOT NULL,
	ShortDesc	NVARCHAR(255),
	Description	NVARCHAR(max),
	CateId		INT,
	Price		INT,
	Discount	INT,
	Thumb		NVARCHAR(500),
	Video		NVARCHAR(500),
	CreateDate	DATETIME2,
	ModifiedDate	DATETIME2,
	BestSellers	BIT NOT NULL,
	HomeFlag	BIT NOT NULL,
	Active		BIT NOT NULL,
	Tags		NVARCHAR(500),
	Title		NVARCHAR(255),
	Alias		VARCHAR(255),
	MetaDesc	NVARCHAR(255),
	MetaKey		NVARCHAR(255),
	UnitInStock	INT,

	constraint	FK_Category_Product foreign key (CateId)
	references	Categories (CateId)
)

create table Customers
(
	CustomerId	int identity(1,1) primary key not null,
	FullName	nvarchar(255),
	Birthday	datetime2,
	Avartar		nvarchar(255),
	Address		nvarchar(255),
	Email		nvarchar(255),
	Phone		varchar(12),
	LocationId	int,
	District	int,
	Ward		int,
	CreateDate	datetime2,
	Password	nvarchar(150),
	Salt		nchar(8),
	LastLogin	datetime2,
	Active		bit not null,
	Levels		int,

	constraint FK_Location_Customer foreign key(LocationId)
	references Locations (LocationId)
)

create table OrderStatus
(
	OrderStatusId	int identity(1,1) primary Key not null,
	Status		nvarchar(50),
	Description	nvarchar(max)
)

create table Orders
(
	OrderId		int identity primary Key not null,
	CustomerId	int,
	OrderDate	datetime2,
	ShipDate	datetime2,
	OrderStatusId int,
	Cancelled	bit,
	Paid		bit,
	PaymentDate datetime2,
	PaymentId	int,
	Note		nvarchar(max),

	constraint	FK_Customer foreign key (CustomerId)
	references	Customers (CustomerId),

	constraint	FK_OrderStatus_Order foreign key (OrderStatusId)
	references	OrderStatus (OrderStatusId)
)

create table OrderDetails
(
	OrderDetailId int identity primary key not null,
	OrderId		int,
	ProductId	int,
	OrderNumber int,
	Quantity	int,
	Discount	int,
	Amount		decimal,
	ShipDate	datetime2,

	constraint	FK_Order_OrderDetail foreign key (OrderId)
	references	Orders (OrderId),

	constraint	FK_Product_OrderDetail foreign key (ProductId)
	references	Products (ProductId)
)

Create table Roles
(
	RoleId		int identity primary Key not null,
	RoleName	nvarchar(50),
	Description	nvarchar(255)
)

Create table Accounts
(
	AccountId	int identity primary key not null,
	Phone		varchar(12),
	Email		nvarchar(50),
	Password	nvarchar(50),
	Salt		nchar(6),
	Active		bit default 1,
	FullName	nvarchar(50),
	RoleId		int,
	LastLogin	datetime2,
	CreateDate	datetime2,

	constraint	FK_Role_Account foreign key (RoleId)
	references	Roles (RoleId)
)

create table Pages
(
	PageId		int identity primary Key not null,
	PageName	nvarchar(250),
	Contents	nvarchar(Max),
	Thumb		nvarchar(250),
	Published	bit not null default 1,
	Title		nvarchar(250),
	MetaDesc	nvarchar(250),
	MetaKey		nvarchar(250),
	Alias		nvarchar(250),
	CreateDate	datetime2,
	Ordering	int
)

create table Shippers
(
	ShipperId	int identity(1,1) primary Key not null,
	ShipperName	nvarchar(150),
	Phone		nchar(12),
	Company		nvarchar(150),
	ShipDate	datetime2
)

create table News
(
	PostId		int identity(1,1) primary Key not null,
	Title		nvarchar(255),
	ShortContents	nvarchar(500),
	Contents	nvarchar(max),
	Thumb		nvarchar(255),
	Published	bit not null default 1,
	Alias		nvarchar(255),
	CreateDate	datetime2,
	Author		nvarchar(255),
	AccountId	int,
	Tags		nvarchar(MAX),
	CateId		int,
	isHot		bit default 0,
	isNewFeed	bit default 0,
	MetaKey		nvarchar(255),
	MetaDesc	nvarchar(255),
	Views		int,

	constraint	FK_Account_New foreign key (AccountId)
	references	Accounts (AccountId),

	constraint	FK_Category_New	foreign key (CateId)
	references	Categories (CateId)
)

create table Attributes
(
	AttributeId	int identity(1,1) primary Key not null,
	Name	nvarchar(255)
)

Create table AttributePrices
(
	AttributePriceId int identity(1,1) primary Key not null,
	AttributeId int,
	ProductId	int,
	Price		int,
	Active		bit not null default 1,

	constraint FK_Attribute_AttributePrice foreign key (AttributeId)
	references Attributes (AttributeId),

	constraint	FK_Product_AttributePrice foreign key (ProductId)
	references	Products (ProductId)
)