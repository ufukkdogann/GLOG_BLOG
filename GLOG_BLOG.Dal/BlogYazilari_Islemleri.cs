using GLOG_BLOG.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GLOG_BLOG.Dal
{
    public class BlogYazilari_Islemleri
    {
        public List<BlogYazilari> BlogYazilariListesi()
        {
            BlogYazilari blogYazilari;
            List<BlogYazilari> liste = new List<BlogYazilari>();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Blog_Yazilari B INNER JOIN Kategoriler K on K.ID = B.Kategori_ID INNER JOIN Kullanıcılar KUL on KUL.ID = B.Kullanıcı_ID  ORDER BY Eklenme_Tarihi DESC", SqlBaglantisi.baglanti);
            if (cmd.Connection.State == ConnectionState.Open)
            {
                cmd.Connection.Close();
            }
            if (SqlBaglantisi.baglanti.State != ConnectionState.Open)
            {
                SqlBaglantisi.baglanti.Open();
            }

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                blogYazilari = new BlogYazilari()
                {
                    ID = Convert.ToInt32(dr["ID"]),
                    Yazi_Basligi = dr["Yazi_Basligi"].ToString(),
                    Yazi_İcerigi = dr["Yazi_Icerigi"].ToString(),
                    Eklenme_Tarihi = Convert.ToDateTime(dr["Eklenme_Tarihi"].ToString()),
                    Kategori_ID = Convert.ToInt32(dr["Kategori_ID"].ToString()),
                    Kullanici_ID = Convert.ToInt32(dr["Kullanıcı_ID"].ToString()),
                    Kategori_Adi = dr["Kategori_Adi"].ToString(),
                    Kullanici_Adi = dr["Kullanici_Adi"].ToString()

                };
                liste.Add(blogYazilari);
            }
            cmd.Connection.Close();
            return liste;
        }

        public int BlogYazisiEkle(BlogYazilari by)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO [dbo].[Blog_Yazilari] (Kullanıcı_ID, Kategori_ID, Yazi_Basligi, Yazi_Icerigi, Eklenme_Tarihi) VALUES (@p1,@p2,@p3,@p4,@p5)", SqlBaglantisi.baglanti);
            if (cmd.Connection.State == ConnectionState.Open)
            {
                cmd.Connection.Close();
            }
            if (SqlBaglantisi.baglanti.State != ConnectionState.Open)
            {
                SqlBaglantisi.baglanti.Open();
            }
            cmd.Parameters.AddWithValue("@p1", by.Kullanici_ID);
            cmd.Parameters.AddWithValue("@p2", by.Kategori_ID);
            cmd.Parameters.AddWithValue("@p3", by.Yazi_Basligi);
            cmd.Parameters.AddWithValue("@p4", by.Yazi_İcerigi);
            cmd.Parameters.AddWithValue("@p5", by.Eklenme_Tarihi);

            return cmd.ExecuteNonQuery();

        }
        public BlogYazilari BlogYazilariBul(int ID)
        {
            DataTable dt = new DataTable();
            BlogYazilari blogYazilari = new BlogYazilari();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Blog_Yazilari B INNER JOIN Kullanıcılar K ON K.ID = B.Kullanıcı_ID WHERE B.ID = @P1", SqlBaglantisi.baglanti);
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
                    blogYazilari = new BlogYazilari()
                    {
                        ID = Convert.ToInt32(dr["ID"]),
                        Kullanici_Adi = dr["Kullanici_Adi"].ToString(),
                        Kategori_ID = Convert.ToInt32(dr["Kategori_ID"]),
                        Kullanici_ID = Convert.ToInt32(dr["Kullanıcı_ID"]),
                        Eklenme_Tarihi = Convert.ToDateTime(dr["Eklenme_Tarihi"].ToString()),
                        Yazi_Basligi = dr["Yazi_Basligi"].ToString(),
                        Yazi_İcerigi = WebUtility.HtmlDecode(dr["Yazi_Icerigi"].ToString())

                    };

                }

                cmd.Connection.Close();
                return blogYazilari;
            }
            catch (Exception)
            {
                throw;
            }


        }
    }
}
