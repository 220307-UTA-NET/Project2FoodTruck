--CREATE SCHEMA FoodTruck;

CREATE TABLE FoodTruck.Employee (
    [Employee ID] INT IDENTITY (1000,1) NOT NULL PRIMARY KEY,
    [Employee First Name] VARCHAR (255) NOT NULL,
    [Employee Last Name] VARCHAR (255) NOT NULL
)

CREATE TABLE FoodTruck.Schedule (
    [Shift ID] INT IDENTITY (100000,1) NOT NULL PRIMARY KEY,
    [Shift Date] DATE, 
    [Truck] INT CHECK (Truck <= 3 AND Truck > 0),
    [Start Time] TIME,
    [End Time] TIME,
    [Employee ID] INT FOREIGN KEY REFERENCES FoodTruck.Employee ([Employee ID]) ON UPDATE CASCADE ON DELETE CASCADE 
    )

CREATE TABLE FoodTruck.Inventory (
    [Inventory ID] INT IDENTITY (10000,1) NOT NULL PRIMARY KEY,
    [Item Name] VARCHAR (255) NOT NULL,
    [Quantity] INT CHECK (Quantity>=0),
    [Cost] DECIMAL (19,2) CHECK (Cost>0),
)

CREATE TABLE FoodTruck.Menu (
    [Menu ID] INT IDENTITY (1,1) NOT NULL PRIMARY KEY,
    [Menu Item] VARCHAR (255) NOT NULL,
    [Price] DECIMAL (19,2),
    [Quantity] INT CHECK (Quantity>=0),
    [Item Description] VARCHAR (255),
    [Allergens] VARCHAR (255)
)

CREATE TABLE FoodTruck.Truck (
    [Truck ID] INT IDENTITY (1,1) NOT NULL PRIMARY KEY,


)
