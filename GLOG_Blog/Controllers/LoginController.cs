using GLOG_BLOG.Bll;
using GLOG_BLOG.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;
using System.Web.Security;

namespace GLOG_Blog.Controllers
{
    public class LoginController : Controller
    {
        BLL_Kullanici_Islemleri x = new BLL_Kullanici_Islemleri();

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Kullanicilar kullanici)
        {
            x.BLL_KullaniciDogrulama(kullanici);
            if (kullanici.ID == 0)
            {
                ViewBag.HataMesaji = "Kullanıcı adı veya parola hatalı! Lütfen tekrar deneyiniz.";
                return View();
            }
            else if (kullanici.ID > 0 && kullanici.IsActive == false)
            {
                ViewBag.HataMesaji = "Kullanıcı hesabınız deaktif. Lütfen info@glog.com.tr adresinden konuyla ilgili destek alınız!";
                return View();
            }
            else
            {
                Session["Kullanici_ID"] = kullanici.ID;
                Session["İsim"] = kullanici.İsim;
                Session["Soyisim"] = kullanici.Soyisim;
                Session["E-Mail"] = kullanici.E_Mail;
                Session["Rol_Adi"] = kullanici.Rol_Adi;

                FormsAuthentication.SetAuthCookie(kullanici.Kullanici_Adi, false); //Giriş yapan kullanıcının rolünü Security/UserRoleProvider sınıfından çekiyor.
                return RedirectToAction("Index", "Admin");
            }


        }
    }
}