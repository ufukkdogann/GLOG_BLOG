using GLOG_BLOG.Dal;
using GLOG_BLOG.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLOG_BLOG.Bll
{
    public class BLL_Kullanici_Islemleri
    {
        Kullanici_Islemleri x = new Kullanici_Islemleri();
        public int BLL_KullaniciEkle(Kullanicilar kullanici)
        {
            if (kullanici.ID == 0)
            {
                return x.KullaniciEkle(kullanici);
            }
            return -1;
        }
        public int BLL_KullaniciDogrulama(Kullanicilar kullanici)
        {
            
            if (kullanici != null)
            {
                return x.KullaniciDogrulama(kullanici);
            }
            return -1;
        }
        public List<Kullanicilar> BLL_KullaniciListesi()
        {
            return x.KullaniciListesi();
        }
        public int BLL_KullaniciGüncelleme(Kullanicilar kullanici)
        {
            return x.KullaniciGuncelle(kullanici);
        }
        public Kullanicilar BLL_KullaniciBul(int ID)
        {
            return x.KullaniciBul(ID);
        }
    }
}
