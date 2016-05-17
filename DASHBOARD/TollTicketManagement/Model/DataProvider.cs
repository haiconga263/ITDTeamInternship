using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TollTicketManagement.Model
{
    public class DataProvider
    {
        static string conStr = ConfigurationManager.ConnectionStrings["cnHPE"].ConnectionString;
        static SqlConnection con;

        public static bool OpenConnect()
        {
            if (con == null)
            {
                con = new SqlConnection(conStr);
            }
            try
            {
                con.Open();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static DataTable ExecuteQuery(string sql)
        {
            try
            {
                DataTable dt = new DataTable();
                if (OpenConnect())
                {
                    SqlCommand cmd = new SqlCommand(sql, con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    con.Close();
                }
                return dt;
            }
            catch
            {
                return null;
            }

        }
        public static void CloseConnect()
        {
            con.Close();
        }
        public static int ExecuteNonQuery(string sql)
        {
            int rs = -1;
            if (OpenConnect())
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                rs = cmd.ExecuteNonQuery();
                con.Close();
            }
            return rs;
        }

        public static object ExecuteScalar(string sql)
        {
            if (OpenConnect())
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                var rs = cmd.ExecuteScalar();
                con.Close();
                return rs;
            }
            return new object();
        }
    }
}
