using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MaviOnline.Models.Sinif;
//sayfalama yapmak için kodlar
using PagedList;
using PagedList.Mvc;

namespace MaviOnline.Controllers
{
    public class KategoriController : Controller
    {
        // Tablolarım Context sınıfında tutuluyor.
        Context c = new Context();
        public ActionResult Index(int sayfa=1)
        {
            // Tablolardaki verilerede To List Metoduyla ulaşıyorum. 
            var degerler = c.Kategoris.ToList().ToPagedList(sayfa,10);
            return View(degerler);
        }
        //form yüklendiğinde çalışacak kısım
        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }
        //butona tıklayınca burayı çalıştır
        [HttpPost]
        public ActionResult KategoriEkle(Kategori k)
        {
            c.Kategoris.Add(k);
            c.SaveChanges();
            return RedirectToAction("index");
        }
        public ActionResult KategoriSil(int id)
        {
            var ktg = c.Kategoris.Find(id);
            c.Kategoris.Remove(ktg);
            c.SaveChanges();
            return RedirectToAction("index");
        }

        public ActionResult KategoriGetir(int id)
        {
            var kategori = c.Kategoris.Find(id);
            return View("KategoriGetir", kategori);
        }

        public ActionResult KategoriGuncelle(Kategori k)
        {
            var ktgr = c.Kategoris.Find(k.KategoriID);
            ktgr.KategoriAd = k.KategoriAd;
            c.SaveChanges();
            return RedirectToAction("index");
        }

        //Sayfalama Yapmak için nuget paketten pagedList.Mvc yi indiriyoruz

    }
}