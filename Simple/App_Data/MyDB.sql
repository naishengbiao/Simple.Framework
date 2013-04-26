if exists (select name from master..sysdatabases where name in ('MyDB')) 
drop database MyDB;
CREATE DATABASE MyDB;
go 
use MyDB


if exists(select * from sysobjects where objectproperty(object_id('dbo.adctab'), 'isusertable') = 1)
DROP TABLE adctab
CREATE TABLE adctab(
	[adcName] varchar(50) ,
	[adcSex] char(2) NOT NULL,
	[adcAge] int NULL, 
	[adcStatus] int NULL,
	[aid] int PRIMARY KEY IDENTITY(1,1))



insert into adctab(adcName,adcSex,adcAge,adcStatus) values('小三','男',20,2);
insert into adctab(adcName,adcSex,adcAge,adcStatus) values('小四','男',20,2);
insert into adctab(adcName,adcSex,adcAge,adcStatus) values('小五','男',20,2);
insert into adctab(adcName,adcSex,adcAge,adcStatus) values('小六','男',20,2);
go

declare @i int 
set @i=1;

while @i<100
if @i>0 and @i<20
begin
insert into adctab(adcName,adcSex,adcAge,adcStatus) values('小二','男',20,2);
set @i=@i+1;
print '完成';
end
else  

begin
insert into adctab(adcName,adcSex,adcAge,adcStatus) values('小美','女',22,2);
set @i=@i+1;
print '完成';

end



