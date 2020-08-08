using GLOG_BLOG.Dal;
using GLOG_BLOG.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLOG_BLOG.Bll
{
    public class BLL_BlogYazilari_Islemleri
    {
        BlogYazilari_Islemleri t = new BlogYazilari_Islemleri();
        public List<BlogYazilari> BLL_BlogYazilari()
        {
            return t.BlogYazilariListesi();
        }
        public int BLL_BlogYazisiEkle(BlogYazilari by)
        {
            return t.BlogYazisiEkle(by);
        }
        public BlogYazilari BLL_BlogYazilariBul(int ID)
        {
            return t.BlogYazilariBul(ID);
        }
    }
}
