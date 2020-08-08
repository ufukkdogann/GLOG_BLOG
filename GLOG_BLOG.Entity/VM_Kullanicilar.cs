using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace GLOG_BLOG.Entity
{
    public class VM_Kullanicilar
    {
        public List<Kullanicilar> KullaniciListesi { get; set; }
        public Kullanicilar Kullanici { get; set; }
        public Roller Rol { get; set; }
        public List<Roller> RolListesi {get; set;}

    }
}
