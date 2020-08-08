using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLOG_BLOG.Entity
{
    public class Kategoriler
    {
        private int _ID;
        private string _Kategori_Adi;

        public int ID { get => _ID; set => _ID = value; }
        public string Kategori_Adi { get => _Kategori_Adi; set => _Kategori_Adi = value; }
    }
}
