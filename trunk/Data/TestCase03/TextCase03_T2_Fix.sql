--Giáo viên muốn thay đổi thời gian nộp của một đồ án
BEGIN TRAN
	UPDATE DOAN SET ThoiHanNop='05/25/2012' WHERE MaDoAn=2
COMMIT TRAN