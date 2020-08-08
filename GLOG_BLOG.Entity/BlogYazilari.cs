using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace GLOG_BLOG.Entity
{
    public class BlogYazilari
    {
        private int _ID;
        private string _Yazi_Basligi;
        private string _Yazi_İcerigi;
        private int _Kategori_ID;
        private int _Kullanici_ID;
        private DateTime _Eklenme_Tarihi;
        private string _Kategori_Adi;
        private string _Kullanici_Adi;

        public int ID { get => _ID; set => _ID = value; }
        public string Yazi_Basligi { get => _Yazi_Basligi; set => _Yazi_Basligi = value; }
        [AllowHtml]

        public string Yazi_İcerigi { get => _Yazi_İcerigi; set => _Yazi_İcerigi = value; }
        public int Kategori_ID { get => _Kategori_ID; set => _Kategori_ID = value; }
        public int Kullanici_ID { get => _Kullanici_ID; set => _Kullanici_ID = value; }
        public DateTime Eklenme_Tarihi { get => _Eklenme_Tarihi; set => _Eklenme_Tarihi = value; }
        public string Kategori_Adi { get => _Kategori_Adi; set => _Kategori_Adi = value; }
        public string Kullanici_Adi { get => _Kullanici_Adi; set => _Kullanici_Adi = value; }
    }
}
