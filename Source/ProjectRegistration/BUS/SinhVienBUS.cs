using System;
using System.Collections.Generic;
using System.Text;
using DTO;
using DAO;

namespace BUS
{
    public class SinhVienBUS
    {
        //public static List<SinhVienDTO> LayDSSVTheoMaLop(long maLop)
        //{
        //    return SinhVienDAO.LayDSSVTheoMaLop(maLop);
        //}

        //public static bool ThemMoi(SinhVienDTO sv)
        //{
        //    //Kiểm tra các qui định
        //    int tuoi = DateTime.Now.Year - sv.NgaySinh.Year;
        //    if (tuoi < 18)
        //        return false;
        //    if (string.Compare(sv.MSSV,"",true)==0)
        //        return false;
        //    if (string.Compare(sv.HoTen, "", true)==0)
        //        return false;
        //    return SinhVienDAO.ThemMoi(sv);
        //}

        //public static bool CapNhat(SinhVienDTO sv)
        //{
        //    //Kiểm tra các qui định
        //    int tuoi = DateTime.Now.Year - sv.NgaySinh.Year;
        //    if (tuoi < 18)
        //        return false;
        //    if (string.Compare(sv.MSSV, "", true)==0)
        //        return false;
        //    if (string.Compare(sv.HoTen, "", true)==0)
        //        return false;
        //    if (sv.DTB < 0 || sv.DTB > 10)
        //        return false;
        //    return SinhVienDAO.CapNhat(sv);
        //}

        //public static bool Xoa(long maSo)
        //{
        //    return SinhVienDAO.Xoa(maSo);
        //}
    }
}
