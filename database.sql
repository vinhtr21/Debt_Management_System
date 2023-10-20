create table Account(
	ID int not null primary key identity(1,1),
	Name nvarchar(45) not null,
	Address nvarchar(max),
	Username varchar(45) not null,
	Password varchar(45) not null,
	Phone varchar(11),
	DOB varchar(45),
)

create table Product(
	ID int not null primary key identity(1,1),
	ProductName nvarchar(45) not null,
	Price float,
	Weight float
)

create table Admin(
	Username varchar(45) not null,
	Password varchar(45) not null,
)

create table AdminRequire(
	RequireId int primary key identity(1,1) not null,
	SupplierName nvarchar(45),
	ProductName nvarchar(45),
	Weight float,
	Cost float,
	Date varchar(45),
	Status int,
)


insert into Account(Username, Password, Name, Address, Phone, DOB) values
('a', 'a','Vinh Tran','viet tri', '0912181156', '2002-01-21'),
('b', 'b','hong Tran','viet tri', '0913308696', '1998-10-31'),
('c', 'c','ha Tran','viet tri', '0977414858', '1972-11-26')

insert into Product(ProductName, Price, Weight) values
('Grass', 10, 1),
('Bran', 20, 1),
('Corn', 30, 1)

insert into AdminRequire(SupplierName, ProductName, Weight, Cost, Date, Status) values
('Vinh Tran', 'Grass', 100,100 * 10, '2023-10-20', 'Pending'),
('hong Tran', 'Bran', 200,200 * 20, '2023-10-20', 'Accepted'),
('ha Tran', 'Corn', 300,300 * 30, '2023-10-20', 'Pending')

DBCC CHECKIDENT(Account, RESEED, 0)
DBCC CHECKIDENT(AdminRequire, RESEED, 0)

delete from Account 
delete from AdminRequire 

drop table Account
drop table AdminRequire


ALTER TABLE Account ADD Available FLOAT;
ALTER TABLE Account ADD Debt FLOAT;
ALTER TABLE AdminRequire ALTER COLUMN Status varchar(20)
ALTER TABLE AdminRequire ALTER COLUMN Date varchar(45)
ALTER TABLE Account ALTER COLUMN DOB varchar(45)

update Account set Available = 0 where Username = 'c'
update Account set Debt = 0 where Username = 'c'

select * from Admin
select * from Account
select * from Product
select * from AdminRequire


