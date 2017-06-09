using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using killerAppSemester2.Models;




namespace Dal_Laag
{
    public class UserDal
    {
        private static string connectionstring = "Server=STIJNCOMPUTER;Database=carconfigurator;Trusted_Connection=True;";
        private static SqlConnection conn = new SqlConnection(connectionstring);

        public Auto geefAllesVanAuto(int autoid)
        {
            Auto auto = new Auto();
            string query = "geefauto";
            SqlParameter pm1 = new SqlParameter("@id", autoid);
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(pm1);
            Openconn();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                auto.Kleur = reader.GetString(reader.GetOrdinal("kleur"));
                auto.merk.Naam = reader.GetString(reader.GetOrdinal("merk"));
                auto.merk.Filenaam = reader.GetString(reader.GetOrdinal("merkfilenaam"));
                auto.Model.Naam = reader.GetString(reader.GetOrdinal("model"));
                auto.Model.Filenaam = reader.GetString(reader.GetOrdinal("modelfilenaam"));
                auto.Model.Prijs = reader.GetDecimal(reader.GetOrdinal("modelprijs"));
                auto.Model.Beschrijving = reader.GetString(reader.GetOrdinal("modelbeschrijving"));
                auto.Uitvoering.Naam = reader.GetString(reader.GetOrdinal("uitvoering"));
                auto.Uitvoering.Prijs = reader.GetDecimal(reader.GetOrdinal("uitvoeringprijs"));
                auto.Uitvoering.Beschrijving = reader.GetString(reader.GetOrdinal("uitvoeringbeschrijving"));
                auto.Naam = reader.GetString(reader.GetOrdinal("naam"));
                auto.MotorTransmissie.Naam = reader.GetString(reader.GetOrdinal("motortransmissie"));
                auto.MotorTransmissie.Prijs = reader.GetDecimal(reader.GetOrdinal("motortransmissieprijs"));
                auto.MotorTransmissie.Paardenkracht = reader.GetInt32(reader.GetOrdinal("paardenkracht"));
                auto.MotorTransmissie.LiterPer100 = reader.GetDecimal(reader.GetOrdinal("literper100"));
                auto.Prijs = (reader.GetDecimal(reader.GetOrdinal("prijs")));
            }
            Closeconn();
            return auto;
        }

        public void VerwijderOptie(int optieid, int autoid)
        {
            string query = "delete from auto_optie where optie_id = @oid and auto_id = @aid";
            SqlParameter[] pms =
            {
                new SqlParameter("@oid",optieid),
                new SqlParameter("@aid",autoid)
            };
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddRange(pms);
            Openconn();
            cmd.ExecuteNonQuery();
            Closeconn();
            
        }


        public List<Optie> GeefOptiesVan(int autoid)
        {
            List<Optie> ops = new List<Optie>();
            string query = "geefoptiesvan";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlParameter pm = new SqlParameter("@auto_id", autoid);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(pm);
            Openconn();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Optie op = new Optie();
                op.Beschrijving = reader.GetString(reader.GetOrdinal("beschrijving"));
                op.Filepath = reader.GetString(reader.GetOrdinal("filenaam"));
                op.Naam = reader.GetString(reader.GetOrdinal("naam"));
                op.Prijs = reader.GetDecimal(reader.GetOrdinal("prijs"));
                op.Id = reader.GetInt32(reader.GetOrdinal("id"));
                ops.Add(op);
            }
            Closeconn();
            return ops;
        }

        public void VoegAccesoireToe(int idaccesoire, int autoid)
        {
            string query = "voegactoe";
            SqlParameter[] pms = {new SqlParameter("@idac",idaccesoire),
            new SqlParameter("@auto_id",autoid)};
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddRange(pms);
            Openconn();
            cmd.ExecuteNonQuery();
            Closeconn();

        }

        public void VoegOptieToe(int idoptie, int autoid)
        {
            string query = "voegoptietoe";
            SqlParameter[] pms = {new SqlParameter("@idoptie",idoptie),
            new SqlParameter("@auto_id",autoid)};
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddRange(pms);
            Openconn();
            cmd.ExecuteNonQuery();
            Closeconn();
        }


        public List<Optie> GeefAlleOptiesVoor(int autoid)
        {
            List<Optie> opties = new List<Optie>();
            string query = "alleoptiesvoor";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlParameter pm = new SqlParameter("@auto_id", autoid);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(pm);
            Openconn();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Optie o = new Optie();
                o.Id = reader.GetInt32(reader.GetOrdinal("id"));
                o.Naam = reader.GetString(reader.GetOrdinal("naam"));
                o.Filepath = reader.GetString(reader.GetOrdinal("filenaam"));
                o.Beschrijving = reader.GetString(reader.GetOrdinal("beschrijving"));
                o.Prijs = reader.GetDecimal(reader.GetOrdinal("prijs"));
                opties.Add(o);
            }
            Closeconn();
            return opties;



        }
        public List<Optie> GeefAlleOptiesVan(int autoid)
        {
            List<Optie> opties = new List<Optie>();
            string query = "geefoptiesvan";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlParameter pm = new SqlParameter("@auto_id", autoid);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(pm);
            Openconn();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Optie o = new Optie();
                o.Id = reader.GetInt32(reader.GetOrdinal("id"));
                o.Naam = reader.GetString(reader.GetOrdinal("naam"));
                o.Filepath = reader.GetString(reader.GetOrdinal("filenaam"));
                o.Beschrijving = reader.GetString(reader.GetOrdinal("beschrijving"));
                o.Prijs = reader.GetDecimal(reader.GetOrdinal("prijs"));
                opties.Add(o);
            }
            Closeconn();
            return opties;



        }
        public List<Optie> GeefAlleOptiesVanUitvoering(int uid)
        {
            List<Optie> opties = new List<Optie>();
            string query = "select * from optie o " +
                "inner join Optie_Uitvoering ou on o.id = ou.optie_id " +
                "where ou.uitvoering_id = @uid";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlParameter pm1 = new SqlParameter("@uid", uid);
            cmd.Parameters.Add(pm1);
            Openconn();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Optie o = new Optie();
                o.Id = reader.GetInt32(reader.GetOrdinal("id"));
                o.Naam = reader.GetString(reader.GetOrdinal("naam"));
                o.Filepath = reader.GetString(reader.GetOrdinal("filenaam"));
                o.Beschrijving = reader.GetString(reader.GetOrdinal("beschrijving"));
                o.Prijs = reader.GetDecimal(reader.GetOrdinal("prijs"));
                opties.Add(o);

            }
            Closeconn();
            return opties;
            
        }

        public List<string> GeefAlleKleuren()
        {
            List<string> kleuren = new List<string>();
            string query = "Select naam from Kleur";
            SqlCommand cmd = new SqlCommand(query, conn);
            Openconn();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                kleuren.Add(reader.GetString(0));
            }
            Closeconn();
            return kleuren;

        }

        public List<MotorTransmissie> GeefAlleMTS(string naam)
        {
            List<MotorTransmissie> uitvs = new List<MotorTransmissie>();
            string query = "geefallemtvan";
            SqlParameter pm1 = new SqlParameter("@uitvoering_naam", naam);
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(pm1);
            Openconn();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                MotorTransmissie u = new MotorTransmissie();
                u.Naam = reader.GetString(reader.GetOrdinal("naam"));
                u.Prijs = reader.GetDecimal(reader.GetOrdinal("prijs"));
                
                u.Id = reader.GetInt32(reader.GetOrdinal("id"));
                u.LiterPer100 = reader.GetDecimal(reader.GetOrdinal("literper100"));
                u.Paardenkracht = reader.GetInt32(reader.GetOrdinal("paardenkracht"));
                uitvs.Add(u);
            }
            Closeconn();
            return uitvs;
        }


        public List<Uitvoering> GeefAlleUivoeringen(string naam)
        {
            List<Uitvoering> uitvs = new List<Uitvoering>();
            string query = "geefalleuitvoeringenvan";
            SqlParameter pm1 = new SqlParameter("@model_naam", naam);
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(pm1);
            Openconn();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Uitvoering u = new Uitvoering();
                u.Naam = reader.GetString(reader.GetOrdinal("naam"));
                u.Prijs = reader.GetDecimal(reader.GetOrdinal("prijs"));
                u.Beschrijving = reader.GetString(reader.GetOrdinal("beschrijving"));
                uitvs.Add(u);
            }
            Closeconn();
            return uitvs;
        }

        public List<Model> GeefModellenvan(string mnaam)
        {
            List<Model> modellen = new List<Model>();
            string query = "geefallemodellenvan";
            SqlParameter pm1 = new SqlParameter("@merk_naam", mnaam);
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(pm1);
            Openconn();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Model model = new Model();
                model.Naam = reader.GetString(reader.GetOrdinal("naam"));
                model.Prijs = reader.GetDecimal(reader.GetOrdinal("prijs"));
                model.Filenaam = reader.GetString(reader.GetOrdinal("filenaam"));
                model.Beschrijving = reader.GetString(reader.GetOrdinal("beschrijving"));
                modellen.Add(model);
            }
            Closeconn();
            return modellen;
        }

        public List<Merk> GeefAlleMerken()
        {
            List<Merk> merken = new List<Merk>();
            string query = "select * from merk";
            SqlCommand cmd = new SqlCommand(query, conn);
            Openconn();
            SqlDataReader reader = cmd.ExecuteReader();
            
            while (reader.Read())
            {
                Merk merk = new Merk();
                merk.Id = reader.GetInt32(reader.GetOrdinal("id"));
                merk.Naam = reader.GetString(reader.GetOrdinal("naam"));
                merk.Filenaam = reader.GetString(reader.GetOrdinal("filenaam"));
                merken.Add(merk);
            }
            Closeconn();
            return merken;
        }

        //geeft de naam en id van de autos mee
        public List<Auto> geefAlleAutosVan(int userid)
        {
            List<Auto> autos = new List<Auto>();
            string query = "geefautosvan";
            SqlParameter pm1 = new SqlParameter("@id", userid);
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(pm1);
            Openconn();
            
            SqlDataReader reader = cmd.ExecuteReader();
            
            
            while (reader.Read())
            {
                Auto auto = new Auto();
                auto.Id = reader.GetInt32(reader.GetOrdinal("id"));
                auto.Naam = reader.GetString(reader.GetOrdinal("naam"));
                autos.Add(auto);

            }
            
            Closeconn();
            return autos;
        }
        //Moet nog gebeuren
        public void PasAutoAan(Auto oudeauto, Auto aangepast)
        {
            throw new NotImplementedException();
        }
        //...
        public void VerwijderAuto(int id)
        {
            string query ="vauto";
            SqlParameter pm1 = new SqlParameter("@id", id);
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(pm1);
            Openconn();
            cmd.ExecuteNonQuery();
            Closeconn();
        }

        public void VoegNieuweAutoToe(Auto auto)
        {
            string query = "voegautotoe";
            SqlCommand nieuweauto = new SqlCommand(query, conn);
            nieuweauto.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter[] pms ={ new SqlParameter("@user_id", auto.User.Id),
                new SqlParameter("@merk_naam", auto.merk.Naam),
                new SqlParameter("@model_naam", auto.Model.Naam),
                new SqlParameter("@uitvoering_naam", auto.Uitvoering.Naam),
                new SqlParameter("@mt_naam", auto.MotorTransmissie.Naam),
                new SqlParameter("@kleur", auto.Kleur),
                new SqlParameter("@autonaam", auto.Naam)};
            
            nieuweauto.Parameters.AddRange(pms);
            Openconn();
            nieuweauto.ExecuteNonQuery();
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
