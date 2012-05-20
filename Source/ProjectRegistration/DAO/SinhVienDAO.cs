using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using DTO;

namespace DAO
{
    public class SinhVienDAO: AbstractDAO
    {
        /// <summary>
        /// Lấy ds sv theo mã lớp
        /// </summary>
        /// <param name="maLop">mã lớp</param>
        /// <returns>Danh sách sv theo mã lớp</returns>
        //public static List<SinhVienDTO> LayDSSVTheoMaLop(long maLop)
        //{
        //    OleDbConnection ketNoi = null;
        //    List<SinhVienDTO> dsSinhVien = new List<SinhVienDTO>();
        //    try
        //    {
        //        ketNoi = MoKetNoi();
        //        string chuoiLenh = "SELECT MaSo,MSSV,HoTen,GioiTinh,NgaySinh,DTB,SV.MaLop,TenLop FROM SinhVien SV, LopHoc LH WHERE SV.MaLop=LH.MaLop AND SV.MaLop=@MaLop";
        //        OleDbCommand lenh = new OleDbCommand(chuoiLenh, ketNoi);
                
        //        OleDbParameter thamSo = new OleDbParameter("@MaLop", OleDbType.Integer);
        //        thamSo.Value = maLop;

        //        lenh.Parameters.Add(thamSo);

        //        OleDbDataReader boDoc = lenh.ExecuteReader();

        //        while (boDoc.Read())
        //        {
        //            SinhVienDTO sv = new SinhVienDTO();
        //            sv.MaSo = boDoc.GetInt32(0);
        //            if (!boDoc.IsDBNull(1))
        //                sv.MSSV = boDoc.GetString(1);
        //            if (!boDoc.IsDBNull(2)) //Kiểm tra xem dữ liệu tại ô thứ 2 có null ko. Nếu ko kiểm tra mà DL thật sự là null thì khi gọi GetXXX sẽ sinh exception
        //                sv.HoTen = boDoc.GetString(2);
        //            if (!boDoc.IsDBNull(3))
        //                sv.GioiTinh = boDoc.GetBoolean(3);
        //            if (!boDoc.IsDBNull(4))
        //                sv.NgaySinh = boDoc.GetDateTime(4);
        //            if (!boDoc.IsDBNull(5))
        //                sv.DTB = boDoc.GetDouble(5);
        //            MonHocDTO lop = new MonHocDTO();
        //            lop.MaLop = boDoc.GetInt32(6);
        //            lop.TenLop = boDoc.GetString(7);
        //            sv.LopHoc = lop;
        //            dsSinhVien.Add(sv);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        dsSinhVien = new List<SinhVienDTO>();
        //    }
        //    finally
        //    {
        //        if (ketNoi != null && ketNoi.State == System.Data.ConnectionState.Open)
        //            ketNoi.Close();
        //    }
        //    return dsSinhVien;
        //}

    }
}
