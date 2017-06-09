using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using killerAppSemester2.Models;
using System.Data.SqlClient;

namespace Dal_Laag
{
    public class AanpassingDal
    {
        private static string connectionstring = "Server=STIJNCOMPUTER;Database=carconfigurator;Trusted_Connection=True;";
        private static SqlConnection conn = new SqlConnection(connectionstring);

        public List<MotorTransmissie> GeefMtsVorAanpassing(int autoid)
        {
            Openconn();
            List<MotorTransmissie> mts = new List<MotorTransmissie>();
            string query1 = "select * from motortransmissie where uitvoering_id = (select uitvoering_id from motortransmissie mt " +
                "inner join[auto] a on mt.id = a.motortransmissie_id " +
                "where a.id = @autoid)";
            string query2 = "select * from motortransmissie mt " +
                "inner join[auto] a on mt.id = a.motortransmissie_id " +
                "where a.id = @autoid";
            SqlCommand cmd1 = new SqlCommand(query2, conn);
            cmd1.Parameters.Add(new SqlParameter("@autoid", autoid));
            Openconn();
            SqlDataReader reader = cmd1.ExecuteReader();
            while (reader.Read())
            {
                MotorTransmissie mt = new MotorTransmissie();
                mt.Id = reader.GetInt32(reader.GetOrdinal("id"));
                mt.LiterPer100 = reader.GetDecimal(reader.GetOrdinal("literper100"));
                mt.Paardenkracht = reader.GetInt32(reader.GetOrdinal("paardenkracht"));
                mt.Naam = reader.GetString(reader.GetOrdinal("naam"));
                mt.Prijs = reader.GetDecimal(reader.GetOrdinal("prijs"));
                mts.Add(mt);

            }

            Closeconn();

            SqlCommand cmd2 = new SqlCommand(query1, conn);
            cmd2.Parameters.Add(new SqlParameter("@autoid", autoid));
            Openconn();
            SqlDataReader reader1 = cmd2.ExecuteReader();
            while (reader1.Read())
            {
                MotorTransmissie mt = new MotorTransmissie();
                mt.Id = reader1.GetInt32(reader1.GetOrdinal("id"));
                mt.LiterPer100 = reader1.GetDecimal(reader1.GetOrdinal("literper100"));
                mt.Paardenkracht = reader1.GetInt32(reader1.GetOrdinal("paardenkracht"));
                mt.Naam = reader1.GetString(reader1.GetOrdinal("naam"));
                mt.Prijs = reader1.GetDecimal(reader1.GetOrdinal("prijs"));
                mts.Add(mt);

            }
            Closeconn();
            return mts;



        }

        public List<Model> GeefMsVoorAanpassing(int v)
        {
            List<Model> Ms = new List<Model>();
            string geefhuidige = "select * from model where id = (select model_id from uitvoering where id = (select uitvoering_id from motortransmissie where id = (select motortransmissie_id from auto where id =@autoid)))";
            SqlCommand gh = new SqlCommand(geefhuidige, conn);
            gh.Parameters.Add(new SqlParameter("@autoid", v));
            Openconn();
            SqlDataReader reader = gh.ExecuteReader();
            while (reader.Read())
            {
                Model m = new Model();
                m.Id = reader.GetInt32(reader.GetOrdinal("id"));
                m.Prijs = reader.GetDecimal(reader.GetOrdinal("prijs"));
                m.Naam = reader.GetString(reader.GetOrdinal("naam"));
                m.Beschrijving = reader.GetString(reader.GetOrdinal("beschrijving"));
                m.Filenaam = reader.GetString(reader.GetOrdinal("filenaam"));
                Ms.Add(m);
            }
            Closeconn();
            string geefbeschikbare = "select * from model where merk_id = (select merk_id from model where id = (select model_id from uitvoering where id = (select uitvoering_id from motortransmissie where id = (select motortransmissie_id from auto where id =@autoid))))";
            SqlCommand gb = new SqlCommand(geefbeschikbare,conn);
            gb.Parameters.Add(new SqlParameter("@autoid", v));
            Openconn();
            SqlDataReader breader = gb.ExecuteReader();
            while (breader.Read())
            {
                Model m = new Model();
                m.Id = breader.GetInt32(breader.GetOrdinal("id"));
                m.Prijs = breader.GetDecimal(breader.GetOrdinal("prijs"));
                m.Naam = breader.GetString(breader.GetOrdinal("naam"));
                m.Beschrijving = breader.GetString(breader.GetOrdinal("beschrijving"));
                m.Filenaam = breader.GetString(breader.GetOrdinal("filenaam"));
                Ms.Add(m);
            }
            return Ms;

        }

        public List<Uitvoering> GeefUvsVoorUitvoering(int v)
        {
            List<Uitvoering> uvs = new List<Uitvoering>();
            string geefhuidige = "select * from uitvoering where id = (select uitvoering_id from motortransmissie where id = (select motortransmissie_id from auto where id = @autoid))";
            SqlCommand ghu = new SqlCommand(geefhuidige, conn);
            ghu.Parameters.Add(new SqlParameter("@autoid", v));
            Openconn();
            
            SqlDataReader reader = ghu.ExecuteReader();
            while (reader.Read())
            {
                Uitvoering u = new Uitvoering();
                u.Id = reader.GetInt32(reader.GetOrdinal("id"));
                u.Naam = reader.GetString(reader.GetOrdinal("naam"));
                u.Prijs = reader.GetDecimal(reader.GetOrdinal("prijs"));
                u.Beschrijving = reader.GetString(reader.GetOrdinal("beschrijving"));
                uvs.Add(u);

            }
            reader.Close();
            Closeconn();
            string geefbeschikbare = "select * from uitvoering where model_id = (select model_id from uitvoering where id = (select uitvoering_id from motortransmissie where id = (select motortransmissie_id from auto where id = @autoid)))";
            SqlCommand gbu = new SqlCommand(geefbeschikbare, conn);
            gbu.Parameters.Add(new SqlParameter("@autoid", v));
            Openconn();
            SqlDataReader reader1 = gbu.ExecuteReader();
            while (reader1.Read())
            {
                Uitvoering u = new Uitvoering();
                u.Id = reader1.GetInt32(reader1.GetOrdinal("id"));
                u.Naam = reader1.GetString(reader1.GetOrdinal("naam"));
                u.Prijs = reader1.GetDecimal(reader1.GetOrdinal("prijs"));
                u.Beschrijving = reader1.GetString(reader1.GetOrdinal("beschrijving"));
                uvs.Add(u);
            }
            reader1.Close();
            Closeconn();
            gbu.Dispose();
            ghu.Dispose();
            

            return uvs;

             
            
        }

        public void VervangMt(int MTID, int v)
        {
            string query = "VeranderMT";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlParameter[] pms =
            {
                new SqlParameter("@MTID",MTID),
                new SqlParameter("@autoid",v)
            };
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddRange(pms);
            Openconn();
            cmd.ExecuteNonQuery();
            Closeconn();
            
        }

        private void Openconn()
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
        private void Closeconn()
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
