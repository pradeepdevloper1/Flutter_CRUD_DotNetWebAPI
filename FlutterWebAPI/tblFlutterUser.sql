create table tblFlutterUser(
id int identity(1,1) primary key ,
name nvarchar(20) null,
email nvarchar(30) null,
password nvarchar(30)null 
)

insert into tblFlutterUser values('Pradeep Kumar','pradeep@gmail.com','pradeep1234');
insert into tblFlutterUser values('Sonu Mittal','sonu@gmail.com','sonu1234');
insert into tblFlutterUser values('Monu Chaudhary','monu@gmail.com','monu1234');
insert into tblFlutterUser values('Ajay Devgun','ajay@gmail.com','ajay1234');

select * from tblFlutterUser 