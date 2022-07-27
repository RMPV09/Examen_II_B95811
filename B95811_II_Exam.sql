--DB

CREATE DATABASE B95811_II_Exam
GO
USE B95811_II_Exam

-- Table
CREATE TABLE Soda(
	Name varchar(255) NOT NULL primary key,
	CansAvailable int NOT NULL,
	PriceOfCan int,
	CurrencySymbol varchar(5) NOT NULL,
);

Insert into Soda
Values
('Coca cola', 10, 500, '₡'), 
('Pepsi', 8, 600, '₡'), 
('Fanta', 10, 550, '₡'), 
('Sprite', 15, 725, '₡')

