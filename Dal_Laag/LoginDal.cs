using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using killerAppSemester2.Models;

namespace Dal_Laag
{
    public class LoginDal
    {
        private static string connectionstring = "Server=STIJNCOMPUTER;Database=carconfigurator;Trusted_Connection=True;";
        private static SqlConnection conn = new SqlConnection(connectionstring);
        public int Login(string gebruikersnaam, string wachtwoord)
        {
            int userid = 0;
            string query = "select id from [user] where naam = @gebruikersnaam and wachtwoord = @wachtwoord";
            SqlParameter[] pm1 = { new SqlParameter("@gebruikersnaam", gebruikersnaam)
                                  ,new SqlParameter("@wachtwoord", wachtwoord)};
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddRange(pm1);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                userid = reader.GetInt32(0);
            }
            conn.Close();
            return userid;


            
        }

        public Boolean MaakAccount(User u)
        {
            string query = "maakaccount";
            SqlParameter[] pms =
            {
                new SqlParameter("@naam",u.Gebruikersnaam),
                new SqlParameter("@wactwoord",u.Wachtwoord)
            };
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddRange(pms);
            openconn();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (System.Data.SqlClient.SqlException)
            {
                closeconn();
                return false;
            }
            closeconn();
            return true;
                
        }

        public Boolean Registreer(User u)
        {
            List<string> namen = new List<string>();
            string query = "select naam from [user]";
            SqlCommand cmd = new SqlCommand(query, conn);
            openconn();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                namen.Add(reader.GetString(0));
            }
            closeconn();
            if (namen.Contains(u.Gebruikersnaam))
            {
                return false;
            }

            return true;
            
        }
        private void openconn()
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                return;
            }
            else
            {
                conn.Open();
            }
        }
        private void closeconn()
        {
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                return;
            }
            else
            {
                conn.Close();
            }
        }
    }
}
