using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Data;

namespace DAO
{
    public class AbstractDAO
    {
        /// <summary>
        /// Chuỗi kết nối đến CSDL
        /// Mỗi loại CSDL sẽ có 1 chuỗi kết nối khác nhau
        /// Tham khảo: lên google search keyword: connection string sẽ có trang list danh sách các chuỗi kết nối
        /// </summary>
        private static string chuoiKetNoi = "Data Source=n_m_t178-pc;Initial Catalog=QLDoAn;Integrated Security=SSPI;User ID=users;Password=;";

        /// <summary>
        /// Tạo 1 kết nối và mở nó lên
        /// </summary>
        /// <returns>Một kết nối đang mở</returns>
        protected static SqlConnection MoKetNoi()
        {
            SqlConnection ketNoi = new SqlConnection(chuoiKetNoi);
            ketNoi.Open();
            return ketNoi;
        }

        public void DongKetNoi(SqlConnection sqlCn)
        {
            if (sqlCn != null)
            {
                if (sqlCn.State == ConnectionState.Open)
                    sqlCn.Close();
                sqlCn.Dispose();
            }
        }

        public int ThucThiSPLogin(string TenStoreProcedure, string username, string password)
        {
            int retunvalue = -1;
            SqlConnection sqlCn = null;
            DataTable dtbTmp = new DataTable();
            SqlCommand sqlCmd = new SqlCommand();
            try
            {
                
                sqlCmd.CommandTimeout = 2000;
                sqlCn = MoKetNoi();
                sqlCmd.Connection = sqlCn;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = TenStoreProcedure;
                sqlCmd.Parameters.Add(new SqlParameter("@username", username));
                sqlCmd.Parameters.Add(new SqlParameter("@password", password));
                sqlCmd.Parameters.Add(new SqlParameter("@result", retunvalue));
                sqlCmd.Parameters["@result"].Direction = ParameterDirection.Output;
                //sqlCmd.Parameters.Direction = ParameterDirection.ReturnValue;
                sqlCmd.ExecuteNonQuery();
                retunvalue = (int)sqlCmd.Parameters["@result"].Value;

                DongKetNoi(sqlCn);
            }
            catch (SqlException sqlEx)
            {
                
            }
            finally
            {
                if (sqlCn.State == ConnectionState.Open)
                    sqlCn.Close();
                sqlCn.Dispose();
            }
            return retunvalue;

        }
    }
}
