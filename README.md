create table [user]
(Id int primary key identity(1,1),
Name varchar(50),
Email varchar(50)
);


--inserting record stored procedure
create procedure InsertRecord
	@Name varchar(50),
	@Email varchar(50)
as
begin
	insert into [user](Name,Email)
	values (@Name,@Email);
end;

select * from [user]



--displaying record
create procedure DisplayRecord
as
begin
	select * from [user];
end;


--get record by id
create procedure GetUserById
	@Id int
as
begin
	select * from [user] where Id=@Id;
end;

--update user
create procedure UpdateUser
	@Id bigint,
	@Name varchar(50),
	@Email varchar(50)
as 
begin
	update [user] set Name=@Name,Email=@Email
	where Id=@Id;

end;


--deleting the user
create procedure DeleteUser
	@Id bigint
as
begin
	delete from [user] where Id=@Id;
end;
