using System;
using System.Collections.Generic;
using System.Text;
using DTO;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Data;

namespace DAO
{
    public class MonHocDAO:AbstractDAO  //Để sử dụng hàm TaoKetNoi()
    {
        /// <summary>
        /// Lấy danh sách lớp
        /// Khuyến cáo: Ko được dùng ArrayList => ko rõ nghĩa + phải ép kiểu
        /// </summary>
        /// <returns>Danh sách lớp</returns>
        //public static List<MonHocDTO> LayDSMon()
        //{
        //    OleDbConnection ketNoi = null;
        //    List<MonHocDTO> dsMon = new List<MonHocDTO>();
        //    try
        //    {
        //        ketNoi = MoKetNoi();
        //        string chuoiLenh = "SELECT MaMonHoc,TenMonHoc FROM MONHOC";
        //        OleDbCommand lenh = new OleDbCommand(chuoiLenh, ketNoi);
        //        OleDbDataReader boDoc = lenh.ExecuteReader();
        //        while (boDoc.Read())
        //        {
        //            MonHocDTO mon = new MonHocDTO();
        //            mon.MaMonHoc = boDoc.GetInt32(0);
        //            if(!boDoc.IsDBNull(1))
        //                mon.TenMonHoc = boDoc.GetString(1);
        //            dsMon.Add(mon);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        dsMon = new List<MonHocDTO>();
        //    }
        //    finally 
        //    {
        //        // khối lệnh finally là 1 phần của try catch finally
        //        // nó luôn luôn được gọi thực hiện
        //        // ko được return trong finally


        //        // Thứ tự 2 biểu thức điều kiện ở đâu là quan trọng
        //        // Nếu bạn đổi ngược, thì sẽ sinh exception khi ketNoi=null
        //        // Thứ tự kiểm tra: Kiểm tra null trước. Nếu khác null thì kt tiếp. Nếu là null thì ko kiểm tra tiếp đk 2
        //        if (ketNoi != null && ketNoi.State == System.Data.ConnectionState.Open)
        //            ketNoi.Close(); // sau khi làm xong phải đóng kết nối
        //    }
        //    return dsMon;
        //}
        public static int CapNhatSLSVNhom(string MaGV, string TenMonHoc, int Count, string WaitingTime, bool Loi)
        {
            int kq = -2;
            string s;
            SqlConnection sqlCn = null;
            DataTable dtbTmp = new DataTable();
            SqlCommand sqlCmd = new SqlCommand();
            try
            {

                sqlCmd.CommandTimeout = 2000;
                sqlCn = AbstractDAO.MoKetNoi();
                sqlCmd.Connection = sqlCn;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                if (Loi)
                {
                    sqlCmd.CommandText = MyStored.CapNhatSoLuongSVNhom_Error;
                }
                else
                {
                    sqlCmd.CommandText = MyStored.CapNhatSoLuongSVNhom_Fix;
                }
                sqlCmd.Parameters.Add(new SqlParameter("@MaGiaoVien", MaGV));
                sqlCmd.Parameters.Add(new SqlParameter("@TenMonHoc", TenMonHoc));
                sqlCmd.Parameters.Add(new SqlParameter("@Count", Count));
                sqlCmd.Parameters.Add(new SqlParameter("@WaitingTime", WaitingTime));
                sqlCmd.Parameters.Add(new SqlParameter("@KetQua", kq));
                sqlCmd.Parameters["@KetQua"].Direction = ParameterDirection.Output;
                sqlCmd.ExecuteNonQuery();
                s = (string)sqlCmd.Parameters["@KetQua"].Value;

                AbstractDAO.DongKetNoi(sqlCn);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                AbstractDAO.DongKetNoi(sqlCn);
            }
            return kq;
        }
    }
}
