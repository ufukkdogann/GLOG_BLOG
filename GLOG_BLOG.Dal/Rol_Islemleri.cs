using GLOG_BLOG.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLOG_BLOG.Dal
{
    public class Rol_Islemleri
    {
        public string[] KullaniciRolListesi(string kullaniciAdi)
        {
            string _RolAdi;
            SqlCommand cmd = new SqlCommand("SELECT R.Rol_Adi FROM Roller R INNER JOIN Kullanıcılar K ON K.Rol_ID=R.ID WHERE Kullanici_Adi=@p1", SqlBaglantisi.baglanti);
            if (cmd.Connection.State == ConnectionState.Open)
            {
                cmd.Connection.Close();
            }
            if (SqlBaglantisi.baglanti.State != ConnectionState.Open)
            {
                SqlBaglantisi.baglanti.Open();
            }
            cmd.Parameters.AddWithValue("@p1",kullaniciAdi);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            int no = dt.Rows.Count;
            string[] _RolAdlari = new string[no];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                _RolAdi = dt.Rows[i]["Rol_Adi"].ToString();
                _RolAdlari[i] = _RolAdi;
            }
            da.Dispose();
            if (cmd.Connection.State == ConnectionState.Open)
            {
                cmd.Connection.Close();
            }
            return _RolAdlari;
        }

        public List<Roller> RolListesi()
        {
            DataTable dt = new DataTable();
            Roller rol;
            List<Roller> liste = new List<Roller>();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Roller", SqlBaglantisi.baglanti);
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
                    rol = new Roller()
                    {
                        ID = Convert.ToInt32(dr["ID"]),
                        Rol_Adi = dr["Rol_Adi"].ToString()

                    };
                    liste.Add(rol);
                }
                cmd.Connection.Close();
                return liste;
            }
            catch (Exception)
            {
                throw;
            }


        }

    }
}
