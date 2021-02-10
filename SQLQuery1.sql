USE master;
GO 
   IF DB_ID('KursovaGrinchak') IS NOT NULL
   BEGIN 
    DROP DATABASE KursovaGrinchak;
   END;
   GO

IF DB_ID('KursovaGrinchak') IS NULL
BEGIN 
   CREATE DATABASE KursovaGrinchak
      CONTAINMENT = NONE
	  ON PRIMARY
   (NAME = N'KursovaGrinchak', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLSERVER\MSSQL\DATA\KursovaGrinchak.mdf', SIZE=6096KB, MAXSIZE=UNLIMITED, FILEGROWTH=1024KB)
   LOG ON
   (NAME = N'KursovaGrinchak_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLSERVER\MSSQL\DATA\KursovaGrinchak_log.ldf', SIZE=1024KB, MAXSIZE=2048GB, FILEGROWTH=10%)
    COLLATE Ukrainian_100_CI_AS;
END;
GO

USE KursovaGrinchak;
GO

IF NOT EXISTS(SELECT 1 FROM sys.Tables WHERE Name=N'Product_groups' AND Type=N'U')
BEGIN
      CREATE TABLE [dbo].[Product_groups](
	          [GroupID] INT IDENTITY(1,1) NOT NULL,
			  [GroupName] NVARCHAR(50) NOT NULL
			 

			  CONSTRAINT PK_Group PRIMARY KEY CLUSTERED (GroupID)
			  
		)
END;
DELETE FROM Product_groups
DBCC CHECKIDENT('Product_groups', RESEED ,0)
GO
INSERT INTO Product_groups(GroupName)
VALUES ('Овочі'), ('Фрукти'),('Хлібобулочні вироби'), ('Молочні товари'),('Мясо'), ('Риба'),
('Гастрономія'), ('Бакалія'),('Напої'), ('Побутова хімія'),('Промислові товари'), ('Преса'),
('Сигарети'),('Алкоголь'), ('Кондитерські вироби');

DELETE FROM Products
DBCC CHECKIDENT('Products', RESEED ,0)
IF NOT EXISTS(SELECT 1 FROM sys.Tables WHERE Name=N'Products' AND Type=N'U')
BEGIN
      CREATE TABLE [dbo].[Products](
	          [ProductID] INT IDENTITY(1,1) NOT NULL,
			  [GroupID] INT NOT NULL,
			  [Name] NVARCHAR(50) NOT NULL,
			  [Unit_of_measure] NVARCHAR(50) NOT NULL,
			  [Purchase_price] NVARCHAR(50) NOT NULL,
			  [Selling_price] NVARCHAR(50) NOT NULL

			  CONSTRAINT PK_Product PRIMARY KEY CLUSTERED (ProductID)
			  CONSTRAINT FK_Products_Product_groups FOREIGN KEY (GroupID) REFERENCES Product_groups(GroupID)
		)
END;
GO
INSERT INTO Products(GroupID, [Name], Unit_of_measure, Purchase_price, Selling_price)
VALUES(3,'Батон Сихівський', '10 шт',11.00,16.00),
(3,'Хліб Стрілецький','10 шт', 10.00, 15.50),
(3,'Хліб Карпацький', '10 шт',14.00,18.00),
(1,'Помідори','15 кг', 25.00, 37.00),
(1,'Цибуля', '20 кг',3.00,5.00),
(1,'Огірки','40 кг', 27.00, 39.00),
(2,'Мандарини', '18 кг',30.00,41.00),
(2,'Лимони','30 кг', 29.00, 35.00),
(2,'Банани','15 кг', 26.00, 37.00),
(4,'Галичина 2.5%', '15шт',20.00,26.00),
(4,'Живинка (смак чорниця)','20 шт', 6.00, 12.00),
(4,'Кефір Галичина 400мг','30 шт', 9.00, 12.00),
(5,'Філе куряче', '30 кг',76.00,85.00),
(5,'Фарш асорті','25 кг', 71.00, 80.00),
(5,'Печінка індича','15 кг', 31.00, 45.00),
(6,'Короп живий', '20 кг',91.00,101.00),
(6,'Скумбрія хол. коп.','10 кг', 135.00, 150.00),
(6,'Оселедець слабосол.','12 кг', 49.00, 60.00),
(7,'Сосиски Філейні', '14 кг', 105.00,120.00),
(7,'Сердельки Молочні','20 кг', 117.00, 130.00),
(7,'Сир Сметанковий (Радимо)', '17 кг',124.00,140.00),
(7,'Ковбаса Дрогобицька (Алан)','7 кг', 167.00, 180.00),
(8,'Вермішель Чемпіон 500г', '20 шт',10.00,14.00),
(8,'Консерва сардина в ол. (Море)','15 шт', 24.00, 30.00),
(8,'Олія (Чумак) 900мг', '2 шт',32.00,41.00),
(9,'Кока-Кола 1.5л','25 шт', 18.00, 21.00),
(9,'Моршинська 1.5л','20 шт', 11.00, 15.00),
(9,'Сік (Садочок) 1л', '25 шт',18.00,23.00),
(10,'Порошок (Ушастий нянь) 4.5кг','15 шт', 163.00, 185.00),
(10,'Доместос 1л','12 шт', 63.00, 70.00),
(10,'Миючий засіб до посуду (Галла лимон)', '30 шт',18.00,26.00),
(11,'Колготки жіночі (Конте)','10 шт', 71.00, 80.00),
(11,'Шкарпетки чоловічі (Славія)','10 кг', 21.00, 28.00),
(11,'Чашка 200мг', '6 кг',27.00,32.00),
(12,'Газета (Високий замок)','12 шт', 8.00, 10.00),
(12,'Журнал (Колосок)','12 шт', 48.00, 55.00),
(12,'Газета (Експрес тиждневик)', '12 шт',9.00,11.00),
(13,'Парламент сільвер','10 шт', 51.00, 60.00),
(13,'Бонд компакт','10 шт', 43.00, 50.00),
(13,'Мальборо голд', '10 шт',48.00,60.00);


GO
DELETE FROM Сonsumption
DROP TABLE Сonsumption
DBCC CHECKIDENT('Сonsumption', RESEED ,0)
IF NOT EXISTS(SELECT 1 FROM sys.Tables WHERE Name=N'Сonsumption' AND Type=N'U')
BEGIN
      CREATE TABLE [dbo].[Сonsumption](
	          [CheckID] INT NOT NULL,
			  [ProductID] INT NOT NULL,
			  [Count] INT NOT NULL,
			  [DateOfCheck] datetime 
		
			 
			  CONSTRAINT PK_Consumption_Code PRIMARY KEY CLUSTERED (CheckID),
			  CONSTRAINT FK_Consumption_Products FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
			
		)
END;
INSERT INTO Сonsumption(CheckID,ProductID,[Count])
VALUES(1,2,3),
(2,3,1)


GO
DROP TABLE Storage

IF NOT EXISTS(SELECT 1 FROM sys.Tables WHERE Name=N'Storage' AND Type=N'U')
BEGIN
      CREATE TABLE [dbo].[Storage](
	          [Arrival_CodeID] INT IDENTITY(1,1) NOT NULL,
			  [ProductID] INT NOT NULL,
			  [Purchase_price] INT NOT NULL,
			  [Selling_price] INT NOT NULL,
			  [NumberOfSales] NVARCHAR(50) NOT NULL

			  CONSTRAINT PK_Arrival_Code PRIMARY KEY CLUSTERED (Arrival_CodeID),
			  /*CONSTRAINT FK_Storage_Products FOREIGN KEY (ProductID) REFERENCES Products(ProductID)*/

		)
END;
DELETE FROM Storage
DBCC CHECKIDENT('Storage', RESEED ,0)
GO
INSERT INTO Storage(ProductID,Purchase_price,Selling_price, NumberOfSales)
VALUES(1, 11.00, 16.00,'10 шт'),
(2, 10.00,15.00,'10 шт'),
(3, 14.00, 18.00,'10 шт'),
(4, 25.00, 37.00,'15 кг'),
(5, 3.00, 5.00,'20 кг'),
(6, 27.00, 39.00,'40 кг'),
(7, 30.00, 41.00,'18 кг'),
(8, 29.00, 35.00,'30 кг'),
(9, 26.00, 37.00,'15 кг'),
(10, 20.00, 26.00,'15 шт'),
(11, 6.00, 12.00,'20 шт'),
(12, 9.00, 12.00,'30 шт'),
(13, 76.00, 86.00,'18 кг'),
(14, 71.00, 80.00,'25 кг'),
(15, 91.00, 101.00,'20 кг'),
(16, 76.00, 86.00,'20 кг'),
(17, 135.00, 150.00,'10 кг'),
(18, 49.00, 60.00,'15 кг'),
(19, 105.00, 120.00,'14 кг'),
(20, 117.00, 130.00,'20 кг'),
(21, 124.00, 140.00,'17 кг'),
(22, 167.00, 180.00,'7 кг'),
(23, 10.00, 14.00,'20 шт'),
(24, 24.00, 30.00,'20 шт'),
(25, 32.00, 41.00,'4 шт'),
(26, 6.00, 12.00,'20 шт'),
(27, 11.00, 15.00,'20 шт'),
(28, 18.00, 23.00,'25 шт'),
(29, 163.00, 185.00,'15 шт'),
(30, 63.00, 70.00,'12 шт'),
(31, 18.00, 26.00,'30 шт'),
(32, 71.00, 80.00,'10 шт'),
(33, 21.00, 28.00,'10 шт'),
(34, 27.00, 32.00,'6 шт'),
(35, 8.00, 10.00,'12 шт'),
(36, 48.00, 55.00,'12 шт'),
(37, 9.00, 11.00,'12 шт'),
(38, 51.00, 60.00,'10 шт'),
(39, 43.00, 50.00,'10 шт'),
(40, 48.00, 60.00,'10 шт')