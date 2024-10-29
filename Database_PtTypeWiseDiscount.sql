create table mst_PtType(
PtTypeId int primary key identity(1,1),
PtType nvarchar(50),
)
ALTER TABLE mst_PtType
ADD IsActive bit

create table mst_PtTypeWiseDiscount(
Id int primary key identity(1,1),
OpIpType bit,
PtTypeId int,
Constraint fk_PtType foreign key(PtTypeId) references mst_PtType(PtTypeId)
)

ALTER TABLE mst_PtTypeWiseDiscount
ADD Discount Int , IsActive BIT;

ALTER TABLE mst_PtType
ADD IsActive bit

select * from mst_PtTypeWiseDiscount
select * from mst_PtType

 

truncate table mst_PtType