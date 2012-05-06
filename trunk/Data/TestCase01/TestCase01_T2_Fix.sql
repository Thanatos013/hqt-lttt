--Giao viên muốn cập nhật số lượng sinh viên nhóm
BEGIN TRAN	
	--Kiểm tra giáo viên có dạy môn đó hay không.
	DECLARE @MonHoc NVARCHAR(50),
			@slsv	INT
	SELECT @MonHoc = mh.TenMonHoc FROM MONHOC mh, PHANCONG pc, GIAOVIEN gv WHERE mh.MaMonHoc = pc.MaMonHoc AND pc.MaGiaoVien = gv.MaGiaoVien AND gv.MaGiaoVien = 'tmtriet'
	IF(@MonHoc = N'Mô hình hóa phần mềm')
		BEGIN	
			--Bắt đầu đọc số lượng sinh viên nhóm và tính toán		
			SET TRANSACTION ISOLATION LEVEL REPEATABLE READ		
			SELECT @slsv = mh.SoLuongSVNhom FROM MONHOC mh WITH (UPDLOCK) WHERE mh.TenMonHoc = N'Mô hình hóa phần mềm'
			SET @slsv = @slsv - 1
		END
	--Chờ 5 giây để demo lỗi lost update trong truy xuất đồng thời
	WAITFOR DELAY '00:00:05'
	--Update số lượng sinh viên nhóm
	UPDATE MONHOC SET SoLuongSVNhom = @slsv WHERE TenMonHoc = N'Mô hình hóa phần mềm '
COMMIT TRAN