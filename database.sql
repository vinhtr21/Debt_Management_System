create table Account(
	ID int not null primary key identity(1,1),
	FirstName nvarchar(45) not null,
	LastName nvarchar(45) not null,
	Address nvarchar(max),
	Username varchar(45) not null,
	Password varchar(45) not null,
	Phone varchar(11),
	DOB datetime,
)

create table Admin(
	Username varchar(45) not null,
	Password varchar(45) not null,
)

insert into Admin(Username, Password) values ('admin', 'admin')

insert into Account(Username, Password, FirstName, LastName, Address, Phone, DOB) values
('admin', 'admin','Admin','Admin','company location', '0912181156', '2002-01-21'),
('vinhtran21', '123456','Vinh','Tran','Hanoi', '0912181156', '2002-01-21')

delete from Account where ID = 1

select * from Account


