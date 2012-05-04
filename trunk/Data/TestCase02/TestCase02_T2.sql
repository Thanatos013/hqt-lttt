BEGIN TRAN
	SET TRAN ISOLATION LEVEL READ UNCOMMITTED
	declare @HanNop datetime
	select @HanNop=ThoiHanNop
	from DOAN da, DE d
	where da.MaDoAn= d.MaDoAn and d.MaDe='1'
	IF(@HanNop>getdate())
		BEGIN
			delete from DE_SINHVIEN
			where MaDe='1' and MaSinhVien='0812001'
		END
COMMIT TRAN
GO
