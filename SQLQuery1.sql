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
VALUES ('�����'), ('������'),('���������� ������'), ('������ ������'),('����'), ('����'),
('����������'), ('������'),('����'), ('�������� ����'),('��������� ������'), ('�����'),
('��������'),('��������'), ('����������� ������');

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
VALUES(3,'����� ����������', '10 ��',11.00,16.00),
(3,'��� ����������','10 ��', 10.00, 15.50),
(3,'��� ����������', '10 ��',14.00,18.00),
(1,'�������','15 ��', 25.00, 37.00),
(1,'������', '20 ��',3.00,5.00),
(1,'�����','40 ��', 27.00, 39.00),
(2,'���������', '18 ��',30.00,41.00),
(2,'������','30 ��', 29.00, 35.00),
(2,'������','15 ��', 26.00, 37.00),
(4,'�������� 2.5%', '15��',20.00,26.00),
(4,'������� (���� �������)','20 ��', 6.00, 12.00),
(4,'����� �������� 400��','30 ��', 9.00, 12.00),
(5,'Գ�� ������', '30 ��',76.00,85.00),
(5,'���� �����','25 ��', 71.00, 80.00),
(5,'������� ������','15 ��', 31.00, 45.00),
(6,'����� �����', '20 ��',91.00,101.00),
(6,'������� ���. ���.','10 ��', 135.00, 150.00),
(6,'��������� ��������.','12 ��', 49.00, 60.00),
(7,'������� Գ����', '14 ��', 105.00,120.00),
(7,'��������� ������','20 ��', 117.00, 130.00),
(7,'��� ����������� (������)', '17 ��',124.00,140.00),
(7,'������� ����������� (����)','7 ��', 167.00, 180.00),
(8,'�������� ������ 500�', '20 ��',10.00,14.00),
(8,'�������� ������� � ��. (����)','15 ��', 24.00, 30.00),
(8,'��� (�����) 900��', '2 ��',32.00,41.00),
(9,'����-���� 1.5�','25 ��', 18.00, 21.00),
(9,'���������� 1.5�','20 ��', 11.00, 15.00),
(9,'ѳ� (�������) 1�', '25 ��',18.00,23.00),
(10,'������� (������� ����) 4.5��','15 ��', 163.00, 185.00),
(10,'�������� 1�','12 ��', 63.00, 70.00),
(10,'������ ���� �� ������ (����� �����)', '30 ��',18.00,26.00),
(11,'�������� ����� (�����)','10 ��', 71.00, 80.00),
(11,'��������� ������� (�����)','10 ��', 21.00, 28.00),
(11,'����� 200��', '6 ��',27.00,32.00),
(12,'������ (������� �����)','12 ��', 8.00, 10.00),
(12,'������ (�������)','12 ��', 48.00, 55.00),
(12,'������ (������� ���������)', '12 ��',9.00,11.00),
(13,'��������� ������','10 ��', 51.00, 60.00),
(13,'���� �������','10 ��', 43.00, 50.00),
(13,'�������� ����', '10 ��',48.00,60.00);


GO
DELETE FROM �onsumption
DROP TABLE �onsumption
DBCC CHECKIDENT('�onsumption', RESEED ,0)
IF NOT EXISTS(SELECT 1 FROM sys.Tables WHERE Name=N'�onsumption' AND Type=N'U')
BEGIN
      CREATE TABLE [dbo].[�onsumption](
	          [CheckID] INT NOT NULL,
			  [ProductID] INT NOT NULL,
			  [Count] INT NOT NULL,
			  [DateOfCheck] datetime 
		
			 
			  CONSTRAINT PK_Consumption_Code PRIMARY KEY CLUSTERED (CheckID),
			  CONSTRAINT FK_Consumption_Products FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
			
		)
END;
INSERT INTO �onsumption(CheckID,ProductID,[Count])
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
VALUES(1, 11.00, 16.00,'10 ��'),
(2, 10.00,15.00,'10 ��'),
(3, 14.00, 18.00,'10 ��'),
(4, 25.00, 37.00,'15 ��'),
(5, 3.00, 5.00,'20 ��'),
(6, 27.00, 39.00,'40 ��'),
(7, 30.00, 41.00,'18 ��'),
(8, 29.00, 35.00,'30 ��'),
(9, 26.00, 37.00,'15 ��'),
(10, 20.00, 26.00,'15 ��'),
(11, 6.00, 12.00,'20 ��'),
(12, 9.00, 12.00,'30 ��'),
(13, 76.00, 86.00,'18 ��'),
(14, 71.00, 80.00,'25 ��'),
(15, 91.00, 101.00,'20 ��'),
(16, 76.00, 86.00,'20 ��'),
(17, 135.00, 150.00,'10 ��'),
(18, 49.00, 60.00,'15 ��'),
(19, 105.00, 120.00,'14 ��'),
(20, 117.00, 130.00,'20 ��'),
(21, 124.00, 140.00,'17 ��'),
(22, 167.00, 180.00,'7 ��'),
(23, 10.00, 14.00,'20 ��'),
(24, 24.00, 30.00,'20 ��'),
(25, 32.00, 41.00,'4 ��'),
(26, 6.00, 12.00,'20 ��'),
(27, 11.00, 15.00,'20 ��'),
(28, 18.00, 23.00,'25 ��'),
(29, 163.00, 185.00,'15 ��'),
(30, 63.00, 70.00,'12 ��'),
(31, 18.00, 26.00,'30 ��'),
(32, 71.00, 80.00,'10 ��'),
(33, 21.00, 28.00,'10 ��'),
(34, 27.00, 32.00,'6 ��'),
(35, 8.00, 10.00,'12 ��'),
(36, 48.00, 55.00,'12 ��'),
(37, 9.00, 11.00,'12 ��'),
(38, 51.00, 60.00,'10 ��'),
(39, 43.00, 50.00,'10 ��'),
(40, 48.00, 60.00,'10 ��')