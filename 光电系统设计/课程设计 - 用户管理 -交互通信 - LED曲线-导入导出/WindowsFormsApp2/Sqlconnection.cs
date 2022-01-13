using System;
using System.Data.Sql;
using System.Data;
using System.Data.SqlClient;

namespace WindowsFormsApp2
{
    public class OptDB
    {
        public static string ConnectionString = @"Data Source=LAPTOP-3KELG2HB\SQL_SERVER;Initial Catalog=Student;User ID=sa;Password=123456";


        public static DataTable SelectDT(string sql)
        {
            using (SqlConnection connec = new SqlConnection(ConnectionString))
            {
                connec.Open();
                SqlCommand cmd = new SqlCommand(sql, connec);
                DataTable table = new DataTable();
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                adap.Fill(table);
                return table;
            }
        }
        public static int AdapDB(string sql)
        {
            using (SqlConnection connec = new SqlConnection(ConnectionString))
            {
                connec.Open();
                SqlCommand cmd = new SqlCommand(sql, connec);
                return cmd.ExecuteNonQuery();
            }
        }


    }
}