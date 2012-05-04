--Sinh viên muốn đăng ký đồ án
BEGIN TRAN	
	--Kiểm tra thời gian đăng ký trước thời gian nộp đồ án, nếu thỏa sẽ chấp nhận đăng ký và thêm vào CSDL.
	DECLARE @ThoiHanNop DATETIME	
	SET @ThoiHanNop = (SELECT ThoiHanNop FROM DOAN da, DE d WHERE da.MaDoAn=d.MaDoAn AND d.MaDe=1)
	PRINT N'Thời hạn nộp đồ án: ' + CAST(@ThoiHanNop AS VARCHAR(12))
	IF(@ThoiHanNop> GETDATE())
		BEGIN				
			INSERT INTO DE_SINHVIEN VALUES(1, '0812008')
		END
	--Chờ 5 giây để demo lỗi unrepeatable read trong truy xuất đồng thời
	WAITFOR DELAY '00:00:05'
	--Xuất thời gian nộp
	SELECT ThoiHanNop FROM DOAN da, DE d WHERE da.MaDoAn=d.MaDoAn AND d.MaDe=1
COMMIT TRAN