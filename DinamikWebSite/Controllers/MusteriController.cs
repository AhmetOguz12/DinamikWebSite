using DinamikWebSite.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DinamikWebSite.Controllers
{
    public class MusteriController : Controller
    {
        DinamikWebSiteEntities5 db = new DinamikWebSiteEntities5();
        public ActionResult Index()
        {
            var mus = db.Musteri.ToList();
            return View(mus);
        }

        public ActionResult Sıl(int id) {
           var mus = db.Musteri.Find(id);
            db.Musteri.Remove(mus);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult MusteriEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult MusteriEkle(Musteri p1) {
            db.Musteri.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MusteriGetir(int id)
        {
            var mus = db.Musteri.Find(id);
            return View("MusteriGetir", mus);
        }

        public ActionResult Guncelle(Musteri p1)
        {
            var mus = db.Musteri.Find(p1.Id);
            mus.MusteriAd = p1.MusteriAd;
            mus.MusteriSoyad = p1.MusteriSoyad;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}