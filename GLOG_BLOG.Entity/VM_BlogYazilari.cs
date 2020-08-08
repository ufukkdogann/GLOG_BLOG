using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLOG_BLOG.Entity
{
    public class VM_BlogYazilari
    {
        public List<BlogYazilari> BlogYazilariListesi { get; set; }
        public BlogYazilari BlogYazilari { get; set; }
        public List<Kullanicilar> KullaniciListesi { get; set; }
        public Kullanicilar Kullanici { get; set; }


    }
}
