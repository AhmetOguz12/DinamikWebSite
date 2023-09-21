using DinamikWebSite.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DinamikWebSite.Controllers
{
    public class UrunlerController : Controller
    {
        // GET: Urunler

        DinamikWebSiteEntities5 db = new DinamikWebSiteEntities5();
        public ActionResult Index()
        {
            var urunler = db.Urunler.ToList();
            return View(urunler);
        }

        [HttpGet]
        public ActionResult UrunEkle()
        {
            List<SelectListItem> urn = (from i in db.Kategori.ToList()
                                        select new SelectListItem
                                        {
                                            Text = i.KategoriAd,
                                            Value = i.Id.ToString()
                                        }).ToList();
            ViewBag.urun = urn;
            return View();
        }

        [HttpPost]
        public ActionResult UrunEkle(Urunler p1)
        {
            var ktgr = db.Kategori.Where(m => m.Id == p1.Kategori.Id).FirstOrDefault();
            p1.Kategori= ktgr;
           db.Urunler.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunGetir(int id) {
            var urn = db.Urunler.Find(id);

            List<SelectListItem> urunn = (from i in db.Kategori.ToList()
                                        select new SelectListItem
                                        {
                                            Text = i.KategoriAd,
                                            Value = i.Id.ToString()
                                        }).ToList();
            ViewBag.urun= urunn;
            return View("UrunGetir", urn);
        }

        public ActionResult Guncelle(Urunler p1)
        {
            var urun = db.Urunler.Find(p1.Id);
            urun.UrunAd = p1.UrunAd;
            var ktgr = db.Kategori.Where(m => m.Id == p1.Kategori.Id).FirstOrDefault();
            p1.UrunKategori = ktgr.Id;
            urun.UrunMarka = p1.UrunMarka;
            urun.UrunFiyat =    p1.UrunFiyat;
            urun.Stok = p1.Stok;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Sıl(int id) {
            var urn = db.Urunler.Find(id);
            db.Urunler.Remove(urn);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}