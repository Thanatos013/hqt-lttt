begin tran
set tran isolation level read committed
declare @HanNop datetime
select @HanNop=ThoiHanNop
from DOAN da, DE d
where da.MaDoAn= d.MaDoAn and d.MaDe='1'
if(@HanNop>getdate())
begin
delete from DE_SINHVIEN
where MaDe='1' and MaSinhVien='0812001'
end
commit tran
go
