using DinamikWebSite.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DinamikWebSite.Controllers
{
    public class KategorilerController : Controller
    {
        // GET: Kategoriler
        DinamikWebSiteEntities5 db = new DinamikWebSiteEntities5(); 
        public ActionResult Index()
        {
            var ktgr = db.Kategori.ToList();
            return View(ktgr);
        }

        [HttpGet]
        public ActionResult Ekle() {
            return View();
        }

        [HttpPost]
        public ActionResult Ekle(Kategori p1)
        {
            db.Kategori.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Sıl(int id)
        {
            var ktgr = db.Kategori.Find(id);
            db.Kategori.Remove(ktgr);
            db.SaveChanges(); 
            return RedirectToAction("Index");   
        }

        public ActionResult KategoriGetir(int id)
        {
            var ktgr = db.Kategori.Find(id);
            return View("KategoriGetir", ktgr);
        }

        public ActionResult Guncelle(Kategori p1)
        {
            var ktgr = db.Kategori.Find(p1.Id);
            ktgr.KategoriAd = p1.KategoriAd;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}