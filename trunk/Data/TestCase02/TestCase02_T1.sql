BEGIN TRAN
	declare @MaMonHoc varchar(20)
	select @MaMonHoc=MaMonHoc
	from MONHOC
	where TenMonHoc=N'Hệ quản trị CSDL'
	--
	update DOAN
	set ThoiHanNop='08/07/2012'
	where TenDoAn=N'Đăng ký đồ án môn học' and MaMonHoc=@MaMonHoc
	--
	WAITFOR DELAY '00:00:06'
	declare @KetThuc datetime
	select @KetThuc=ThoiGianKetThuc
	from MONHOC 
	where TenMonHoc=N'Hệ quản trị CSDL'
	IF('08/07/2012'>@KetThuc)
		BEGIN
			ROLLBACK
			RETURN
		END
COMMIT TRAN
GO