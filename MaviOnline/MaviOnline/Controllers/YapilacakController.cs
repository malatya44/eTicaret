using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MaviOnline.Models.Sinif;
namespace MaviOnline.Controllers
{
    public class YapilacakController : Controller
    {
        // GET: Yapilacak
        Context c = new Context();
        public ActionResult Index()
        {
            //Müşteri toplam sayısını döndür
            var deger1 = c.Carilers.Count().ToString();
            ViewBag.d1 = deger1;
            //Ürün toplam sayısını döndür
            var deger2 = c.Uruns.Count().ToString();
            ViewBag.d2 = deger2;
            //KAtegori toplam sayısı
            var deger3 = c.Kategoris.Count().ToString();
            ViewBag.d3 = deger3;
            //Toplam Carilerin Şehirlerinin sayısı
            var deger4 = (from x in c.Carilers select x.CariSehir).Distinct().Count().ToString();
            ViewBag.d4 = deger4;
            //Yapılacaklar Listesi
            var yapilacaklar = c.Yapilacaks.ToList();
            return View(yapilacaklar);
        }
    }
}