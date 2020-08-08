using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLOG_BLOG.Entity
{
    public class Roller
    {

        private int _ID;
        private string _Rol_Adi;

        public int ID { get => _ID; set => _ID = value; }
        public string Rol_Adi { get => _Rol_Adi; set => _Rol_Adi = value; }
    }
}
