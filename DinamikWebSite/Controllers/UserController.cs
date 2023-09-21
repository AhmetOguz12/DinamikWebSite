using DinamikWebSite.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace DinamikWebSite.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        DinamikWebSiteEntities5 db = new DinamikWebSiteEntities5();
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Login(Kayıt ad)
        {
            var bilgiler = db.Kayıt.FirstOrDefault(x => x.KullanıcıAdı == ad.KullanıcıAdı && x.Parola == ad.Parola);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.KullanıcıAdı, false);
                Session["KullanıcıAdı"] = bilgiler.KullanıcıAdı.ToString();
                Session["Parola"] = bilgiler.Parola.ToString();
                return RedirectToAction("Index", "Urunler");
            }
            else
            {
                ViewBag.hata = "Kullanıcı Adı veya Şifre Hatalı";

            }
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Kayıt p1)
        {
            db.Kayıt.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Login","User");
        }

    }
}