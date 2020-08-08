using GLOG_BLOG.Dal;
using GLOG_BLOG.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLOG_BLOG.Bll
{
    public class BLL_Rol_Islemleri
    {
        Rol_Islemleri x = new Rol_Islemleri();
        public string[] BLL_KullaniciRolListesi(string kullaniciAdi)
        {
            return x.KullaniciRolListesi(kullaniciAdi);

        }
        public List<Roller> BLL_RolListesi()
        {
            return x.RolListesi();
        }
    }
}
