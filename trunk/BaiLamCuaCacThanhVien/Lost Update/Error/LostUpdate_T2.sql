BEGIN TRAN
DECLARE @sldk INT
SELECT @sldk = SoLuongDangKy FROM DOAN WHERE MaDoAn = '2'
SET @sldk = @sldk - 10
UPDATE DOAN SET SoLuongDangKy = @sldk WHERE MaDoAn = '2'

COMMIT TRAN