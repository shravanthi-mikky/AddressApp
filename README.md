# AddressApp
3.Create a new Web-API to save splitted address and fetch complete address in one-line and send that to your page and show back fetched address.
CREATE TABLE AddressTable(
	AddressId serial PRIMARY KEY,
	Addressline1 varchar (200),
	Addressline2 varchar (200),
	Addressline3 varchar(200),
	Pincode varchar(150),
	City varchar(150),
	District varchar(150),
	State varchar(150),
	Country varchar(150)
	);
	
Create or replace PROCEDURE Sp_AddAddress
(Addressline1 varchar(200),
Addressline2 varchar(200),Addressline3 varchar(200),Pincode varchar(150),
	City varchar(150),
	District varchar(150),
	State varchar(150),
	Country varchar(150))
language sql
AS
$$
insert into AddressTable(Addressline1,Addressline2,Addressline3,Pincode,City,State,District,Country)
values(Addressline1,Addressline2,Addressline3,Pincode,City,State,District,Country);
SELECT * from AddressTable;
$$

delete from AddressTable where AddressId > 25;
