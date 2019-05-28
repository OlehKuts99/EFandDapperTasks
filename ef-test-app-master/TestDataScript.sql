

insert into Licenses(ID, CreatedBy)
select '656f0f0a-d2c1-4472-8ee1-b7167d3ff1ea', 'EPAM'
union all
select '997d5f5f-8df7-4115-9789-0485670d05e1', 'SoftServe'
union all
select '2bf21a87-529f-41ee-9ab9-88971481f2fe', 'Windows'
union all
select '4548b6e7-dc82-4ba6-8b92-13b1e97f383c', null
union all
select '85988a31-a6e3-4f6f-9cdf-5d124415c856', null
union all
select '452bfab7-595d-49c2-8ac3-979236d8f5aa', 'Apple'
union all
select '35b1d9ec-2463-42f7-adaa-15544a38272c', ''
union all
select '3ede1f4a-1148-4816-8ebe-eafbac1f0af6', 'EPAM'
union all
select '4c777d16-5b04-4cec-a8bb-a052fdd4a59b', 'SoftServe'
union all
select '801c62a2-ca62-44ad-95b6-e93a35658922', 'Windows'
union all
select '564c17c4-255c-42e1-b442-82b4b2bca9b2', null
union all
select '647218ab-7a2b-4db0-a89a-5279bf3f20df', null
union all
select '3ce465cd-6695-4a71-85b6-a8e4124f76fe', null
union all
select 'd05f902a-e148-4b99-8acf-ff9986f28ef2', null
GO

SET IDENTITY_INSERT Customers on
insert into Customers(ID, [Name], [Location], LicenseID)
select 1, 'Chase Wetzel', 'Lviv', null
union all
select 2, 'Darcel Dryer', 'Lviv', '656f0f0a-d2c1-4472-8ee1-b7167d3ff1ea'
union all
select 3, 'Melaine Roche', 'Lviv', '997d5f5f-8df7-4115-9789-0485670d05e1'
union all
select 4, 'Clyde Stills', 'Lviv', '2bf21a87-529f-41ee-9ab9-88971481f2fe'
union all
select 5, 'Mui Bryden', 'Lviv', '4548b6e7-dc82-4ba6-8b92-13b1e97f383c'
union all
select 6, 'Tammy Nickle', 'Kyiv', '85988a31-a6e3-4f6f-9cdf-5d124415c856'
union all
select 7, 'Sallie Landreneau', 'Kyiv', '452bfab7-595d-49c2-8ac3-979236d8f5aa'
union all
select 8, 'Jacquelyn Mckey', 'Kyiv', null
union all
select 9, 'Cordell Visitacion', 'Kyiv', '3ede1f4a-1148-4816-8ebe-eafbac1f0af6'
union all
select 10, 'Almeta Cimmino', 'Terlopil',  '801c62a2-ca62-44ad-95b6-e93a35658922'
union all
select 11, 'Adelina Broeckel', 'Terlopil', '647218ab-7a2b-4db0-a89a-5279bf3f20df'
union all
select 12, 'Darell Liebold', 'Terlopil', null
union all
select 13, 'Latoyia Arzola', 'Rivne', null
union all
select 14, 'Demetria Umphrey', 'Rivne', '4c777d16-5b04-4cec-a8bb-a052fdd4a59b'

SET IDENTITY_INSERT Customers off

GO

insert into Orders(CreatedDate, LastChanged, TotalPrice, [Status], CustomerID)
select GETDATE(), GETDATE(), 0, 'Created', 1
union all
select GETDATE(), GETDATE(), 0, 'InProgress', 1
union all
select GETDATE(), GETDATE(), 0, 'Done', 1
union all
select GETDATE(), GETDATE(), 0, 'Created', 2
union all
select GETDATE(), GETDATE(), 0, 'InProgress', 2
union all
select GETDATE(), GETDATE(), 0, 'Done', 2
union all
select GETDATE(), GETDATE(), 0, 'Created', 3
union all
select GETDATE(), GETDATE(), 0, 'InProgress', 3
union all
select GETDATE(), GETDATE(), 0, 'Done', 3
union all
select GETDATE(), GETDATE(), 0, 'Created', 6
union all
select GETDATE(), GETDATE(), 0, 'InProgress', 6
union all
select GETDATE(), GETDATE(), 0, 'Done', 6
union all
select GETDATE(), GETDATE(), 0, 'Created', 7
union all
select GETDATE(), GETDATE(), 0, 'InProgress', 7
union all
select GETDATE(), GETDATE(), 0, 'Done', 7
union all
select GETDATE(), GETDATE(), 0, 'Created', 10
union all
select GETDATE(), GETDATE(), 0, 'InProgress', 10
union all
select GETDATE(), GETDATE(), 0, 'Done', 10
union all
select GETDATE(), GETDATE(), 0, 'Created', 11
union all
select GETDATE(), GETDATE(), 0, 'InProgress', 11
union all
select GETDATE(), GETDATE(), 0, 'Done', 11
union all
select GETDATE(), GETDATE(), 0, 'Created', 13
union all
select GETDATE(), GETDATE(), 0, 'InProgress', 13
union all
select GETDATE(), GETDATE(), 0, 'Done', 13
union all
select GETDATE(), GETDATE(), 0, 'Created', 14
union all
select GETDATE(), GETDATE(), 0, 'InProgress', 14
union all
select GETDATE(), GETDATE(), 0, 'Done', 14
GO

insert into Products([Name],[Desc], Price)
select 'apple', '', 1.5
union all
select 'pear', '', 1.75
union all
select 'orange', '', 5
union all
select 'apple', '', 1.5
union all
select 'plum', '', 2.8
union all
select 'cherry', '', 3.2
union all
select 'pumpkin', '', 10
union all
select 'mango', '', 8.5
go

insert into ProductOrders(OrderID, ProductID, Amount)
select 1, 1, 16
union all
select 1, 8, 2
union all
select 1, 3, 8
union all
select 2, 5, 6
union all
select 3, 1, 5
union all
select 3, 2, 8
union all
select 4, 3, 9
union all
select 5, 4, 9
union all
select 6, 5, 17
union all
select 6, 6, 19
union all
select 7, 7, 9
union all
select 8, 8, 7
union all
select 8, 1, 6
union all
select 8, 2, 5
union all
select 9, 3, 14
union all
select 10, 4, 13
union all
select 11, 5, 12
union all
select 12, 6, 11
union all
select 12, 7, 29
union all
select 13, 8, 27
union all
select 14, 1, 16
union all
select 14, 2, 25
union all
select 14, 3, 26
union all
select 15, 4, 1
union all
select 16, 5, 3
union all
select 17, 6, 12
union all
select 18, 7, 45
union all
select 19, 8, 23
union all
select 20, 2, 25
union all
select 20, 1, 23
union all
select 21, 3, 15
union all
select 22, 4, 16
union all
select 23, 5, 8
union all
select 23, 6, 6
union all
select 24, 7, 5
union all
select 25, 8, 10
union all
select 26, 1, 15
union all
select 26, 3, 8
union all
select 27, 5, 6
go