using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace library01
{
    class DBhandling
    {

        private string connectionString;
        public SqlConnection con;

        public DBhandling()
        {
            connectionString = @"Server=DocsPowerPC; Database=Bibliotek; Integrated Security=true;";
            con = new SqlConnection(connectionString);
        }

        public string returnFromSPLoginTjeck(string input)
        {
            SqlDataReader rdr = null;
            string outgoing = "";
            try
            {
                SqlCommand cmd = new SqlCommand("LoginTjeck", con);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@kLog", input));

                rdr = cmd.ExecuteReader();
                outgoing = rdr.ToString();
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
                if (rdr != null)
                {
                    rdr.Close();
                }
            }

            return outgoing;
             
        }

        public List<string> readDBNumUn(string strSql, string cell)
        {
            List<string> fromDB = new List<string>();

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(strSql, con);
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        fromDB.Add(rdr[cell].ToString());
                    }
                }
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
                
            }

            return fromDB;
        }

    }
}
