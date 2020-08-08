using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace GLOG_BLOG.Entity
{
    public class Kullanicilar
    {
        private int _ID;
        private string _Kullanici_Adi;
        private string _Parola;
        private string _E_Mail;
        private bool _isActive;
        private string _İsim;
        private string _Soyisim;
        private int _Rol_ID;
        private string rol_Adi;
       

        public int ID { get => _ID; set => _ID = value; }
        public string Kullanici_Adi { get => _Kullanici_Adi; set => _Kullanici_Adi = value; }
        public string Parola { get => _Parola; set => _Parola = value; }
        public string E_Mail { get => _E_Mail; set => _E_Mail = value; }
        public bool IsActive { get => _isActive; set => _isActive = value; }
        public string İsim { get => _İsim; set => _İsim = value; }
        public string Soyisim { get => _Soyisim; set => _Soyisim = value; }
        public int Rol_ID { get => _Rol_ID; set => _Rol_ID = value; }
        public string Rol_Adi { get => rol_Adi; set => rol_Adi = value; }
       
       
    }
}
