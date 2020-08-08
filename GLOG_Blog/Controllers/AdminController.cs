using GLOG_BLOG.Bll;
using System.Web.Mvc;
using GLOG_BLOG.Entity;
using System;
using System.IO;

namespace GLOG_Blog.Controllers
{
    public class AdminController : Controller
    {
        BLL_Kullanici_Islemleri kullanici = new BLL_Kullanici_Islemleri();
        BLL_Rol_Islemleri rol = new BLL_Rol_Islemleri();
        BLL_BlogYazilari_Islemleri blog = new BLL_BlogYazilari_Islemleri();
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult KullaniciListesi()
        {
            return View(kullanici.BLL_KullaniciListesi());
        }
        [HttpGet]
        public ActionResult KullaniciIslemleri()
        {
            var model = new VM_Kullanicilar()
            {
                KullaniciListesi = kullanici.BLL_KullaniciListesi(),
                RolListesi = rol.BLL_RolListesi()
            };

            return View(model);
        }
        [HttpPost]
        public ActionResult KullaniciIslemleri(VM_Kullanicilar k)
        {
            if (k.Kullanici.ID == 0)
            {
                kullanici.BLL_KullaniciEkle(k.Kullanici);            
            }
            else
            {
                kullanici.BLL_KullaniciGüncelleme(k.Kullanici);
            }
            var model = new VM_Kullanicilar()
            {
                KullaniciListesi = kullanici.BLL_KullaniciListesi(),
                RolListesi = rol.BLL_RolListesi()
            };
            return RedirectToAction("KullaniciListesi", model);
        }
        public ActionResult KullaniciGuncelle(Kullanicilar k)
        {

            var model = new VM_Kullanicilar()
            {
                Kullanici = kullanici.BLL_KullaniciBul(k.ID),
                RolListesi = rol.BLL_RolListesi()
            };
            return View("KullaniciIslemleri", model);
        }
        [HttpGet]
        public ActionResult IcerikIslemleri()
        {
            return View();
        }
        [HttpPost]
        public ActionResult IcerikIslemleri(VM_BlogYazilari by)
        {
            if (by.BlogYazilari.ID == 0)
            {
                by.BlogYazilari.Eklenme_Tarihi = DateTime.Now;
                by.BlogYazilari.Kullanici_ID = (int)Session["Kullanici_ID"];
                by.BlogYazilari.Kategori_ID = 1;
                blog.BLL_BlogYazisiEkle(by.BlogYazilari);
                return View("IcerikListesi", blog.BLL_BlogYazilari());
            }
            else
            {
                blog.BLL_BlogYazisiEkle(by.BlogYazilari);
                return View("IcerikListesi", blog.BLL_BlogYazilari());
            }

        }
        public ActionResult IcerikListesi()
        {
            return View(blog.BLL_BlogYazilari());
        }
        public ActionResult IcerikGuncelle(int ID)
        {
            var model = new VM_BlogYazilari()
            {
                KullaniciListesi = kullanici.BLL_KullaniciListesi(),
                BlogYazilari = blog.BLL_BlogYazilariBul(ID)
            };
            return View("IcerikIslemleri", model);
        }
        public ActionResult IcerikOnizleme(int ID)
        {
            var model = new VM_BlogYazilari()
            {
                BlogYazilari = blog.BLL_BlogYazilariBul(ID)
            };
            return View("IcerikOnizleme", model);
        }

    }
}