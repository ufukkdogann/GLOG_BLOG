using GLOG_BLOG.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GLOG_BLOG.Dal
{
    public class Kullanici_Islemleri
    {
        public int KullaniciEkle(Kullanicilar kullanici)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO [dbo].[Kullanıcılar] (Kullanici_Adi, Parola, Rol_ID, E_Mail, İsim, Soyisim,isActive) VALUES (@p1,@p2,@p3,@p4,@p5,@p6,@p7)", SqlBaglantisi.baglanti);
            if (cmd.Connection.State == ConnectionState.Open)
            {
                cmd.Connection.Close();
            }
            if (SqlBaglantisi.baglanti.State != ConnectionState.Open)
            {
                SqlBaglantisi.baglanti.Open();
            }
            cmd.Parameters.AddWithValue("@p1", kullanici.Kullanici_Adi);
            cmd.Parameters.AddWithValue("@p2", kullanici.Parola);
            cmd.Parameters.AddWithValue("@p3", kullanici.Rol_ID);
            cmd.Parameters.AddWithValue("@p4", kullanici.E_Mail);
            cmd.Parameters.AddWithValue("@p5", kullanici.İsim);
            cmd.Parameters.AddWithValue("@p6", kullanici.Soyisim);
            cmd.Parameters.AddWithValue("@p7", kullanici.IsActive);
            

            return cmd.ExecuteNonQuery();
        }
        public int KullaniciSil(Kullanicilar kullanici)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM [dbo].[Kullanıcılar] WHERE ID = (@p1)", SqlBaglantisi.baglanti);
            if (cmd.Connection.State == ConnectionState.Open)
            {
                cmd.Connection.Close();
            }
            if (SqlBaglantisi.baglanti.State != ConnectionState.Open)
            {
                SqlBaglantisi.baglanti.Open();
            }
            cmd.Parameters.AddWithValue("@p1", kullanici.ID);

            return cmd.ExecuteNonQuery();
        }
        public int KullaniciGuncelle(Kullanicilar kullanici)
        {
            SqlCommand cmd = new SqlCommand("UPDATE [dbo].[Kullanıcılar] SET Kullanici_Adi = @p1,Parola = @p2, E_Mail = @p3, İsim = @p4, Soyisim = @p5, Rol_ID = @p6, isActive = @p7 WHERE ID='" + kullanici.ID + "'", SqlBaglantisi.baglanti);
            if (cmd.Connection.State == ConnectionState.Open)
            {
                cmd.Connection.Close();
            }
            if (SqlBaglantisi.baglanti.State != ConnectionState.Open)
            {
                SqlBaglantisi.baglanti.Open();
            }
            cmd.Parameters.AddWithValue("@p1", kullanici.Kullanici_Adi);
            cmd.Parameters.AddWithValue("@p2", kullanici.Parola);
            cmd.Parameters.AddWithValue("@p3", kullanici.E_Mail);
            cmd.Parameters.AddWithValue("@p4", kullanici.İsim);
            cmd.Parameters.AddWithValue("@p5", kullanici.Soyisim);
            cmd.Parameters.AddWithValue("@p6", kullanici.Rol_ID);
            cmd.Parameters.AddWithValue("@p7", kullanici.IsActive);

            return cmd.ExecuteNonQuery();
        }
        public List<Kullanicilar> KullaniciListesi()
        {
            DataTable dt = new DataTable();
            Kullanicilar kullanici;
            List<Kullanicilar> liste = new List<Kullanicilar>();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Kullanıcılar K INNER JOIN Roller R ON R.ID = K.Rol_ID ORDER BY İsim ASC ", SqlBaglantisi.baglanti);
            if (cmd.Connection.State == ConnectionState.Open)
            {
                cmd.Connection.Close();
            }
            if (SqlBaglantisi.baglanti.State != ConnectionState.Open)
            {
                SqlBaglantisi.baglanti.Open();
            }
            try
            {
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    kullanici = new Kullanicilar()
                    {
                        ID = Convert.ToInt32(dr["ID"]),
                        Kullanici_Adi = dr["Kullanici_Adi"].ToString(),
                        Parola = dr["Parola"].ToString(),
                        İsim = dr["İsim"].ToString(),
                        Soyisim = dr["Soyisim"].ToString(),
                        E_Mail = dr["E_Mail"].ToString(),
                        Rol_ID = Convert.ToInt32(dr["Rol_ID"]),
                        Rol_Adi = dr["Rol_Adi"].ToString(),
                        IsActive = Convert.ToBoolean(dr["isActive"].ToString())

                    };
                    liste.Add(kullanici);
                }
                cmd.Connection.Close();
                return liste;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public int KullaniciDogrulama(Kullanicilar kullanici)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Kullanıcılar K INNER JOIN Roller R ON R.ID = K.Rol_ID where Kullanici_Adi='" + kullanici.Kullanici_Adi + "'and Parola='" + kullanici.Parola + "'", SqlBaglantisi.baglanti);
            if (cmd.Connection.State == ConnectionState.Open)
            {
                cmd.Connection.Close();
            }
            if (SqlBaglantisi.baglanti.State != ConnectionState.Open)
            {
                SqlBaglantisi.baglanti.Open();
            }
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                kullanici.ID = Convert.ToInt32(dr["ID"]);
                kullanici.Kullanici_Adi = dr["Kullanici_Adi"].ToString();
                kullanici.Parola = dr["Parola"].ToString();
                kullanici.İsim = dr["İsim"].ToString();
                kullanici.Soyisim = dr["Soyisim"].ToString();
                kullanici.E_Mail = dr["E_Mail"].ToString();
                kullanici.Rol_Adi = dr["Rol_Adi"].ToString();
                kullanici.IsActive = Convert.ToBoolean(dr["isActive"].ToString());
                dr.Close();
                return cmd.ExecuteNonQuery();
            }
            return -1;
        }
        public Kullanicilar KullaniciBul(int ID)
        {
            DataTable dt = new DataTable();
            Kullanicilar kullanici = new Kullanicilar();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Kullanıcılar K INNER JOIN Roller R ON R.ID = K.Rol_ID WHERE K.ID = @P1 ORDER BY İsim ASC ", SqlBaglantisi.baglanti);
            cmd.Parameters.AddWithValue("@P1", ID);
            if (cmd.Connection.State == ConnectionState.Open)
            {
                cmd.Connection.Close();
            }
            if (SqlBaglantisi.baglanti.State != ConnectionState.Open)
            {
                SqlBaglantisi.baglanti.Open();
            }
            try
            {
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    kullanici = new Kullanicilar()
                    {
                        ID = Convert.ToInt32(dr["ID"]),
                        Kullanici_Adi = dr["Kullanici_Adi"].ToString(),
                        Parola = dr["Parola"].ToString(),
                        İsim = dr["İsim"].ToString(),
                        Soyisim = dr["Soyisim"].ToString(),
                        E_Mail = dr["E_Mail"].ToString(),
                        Rol_ID = Convert.ToInt32(dr["Rol_ID"]),
                        Rol_Adi = dr["Rol_Adi"].ToString(),
                        IsActive = Convert.ToBoolean(dr["isActive"].ToString())
                    };

                }

                cmd.Connection.Close();
                return kullanici;
            }
            catch (Exception)
            {
                throw;
            }


        }

    }
}
