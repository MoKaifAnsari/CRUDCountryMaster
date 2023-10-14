using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using Excel;

namespace CRUDCountryMaster.Models
{
    public class Common
    {
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings.Get("DBConnection"));
        public static DataTable ExecuteProcedure(string Procedure, string[,] param)
        {
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings.Get("DBConnection"));
            SqlCommand cmd = new SqlCommand(Procedure, con);
            cmd.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < param.Length / 2; i++)
            {
                cmd.Parameters.AddWithValue(param[i, 0], param[i, 1]);
            }
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public static DataTable ExecuteProcedure(string Procedure)
        {
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings.Get("DBConnection"));
            SqlCommand cmd = new SqlCommand(Procedure, con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        
    }
}