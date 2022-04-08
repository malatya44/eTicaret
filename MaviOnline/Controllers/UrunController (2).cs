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
    public class UrunController : Controller
    { // GET: Urun
        Context c = new Context();
        //sayfalamayla beraber
        /*
        public ActionResult Index(int sayfa = 1)
        {
            //kayıtları tam silmeden ilişkileri bozmadan gizleme yapmak
            //için sayfa yuklendiğinde durumu 1 olanları ekrana getir linq sorgum
            var urunler = c.Uruns.Where(x => x.Durum == true).ToList().ToPagedList(sayfa, 10);
            if (!string.IsNullOrEmpty(p))
            {
                urunler = urunler.Where(y => y.UrunAd.Contains(p));
            }
            return View(urunler.ToList());
        }
        */
        //arama kısmı
        public ActionResult Index(string p)
        {
            var urunler = from x in c.Uruns select x;
            if (!string.IsNullOrEmpty(p))
            {
                urunler = urunler.Where(y => y.UrunAd.Contains(p));
            }
            return View(urunler.ToList());
        }

        [HttpGet]
        public ActionResult YeniUrun()
        {
            //Açılır menü dropdown yada checkbox mantığım
            List<SelectListItem> deger1 = (from x in c.Kategoris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KategoriAd,
                                               Value = x.KategoriID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;

            return View();
        }
        [HttpPost]
        public ActionResult YeniUrun(Urun p)
        {
            c.Uruns.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunSil(int id)
        {
            var deger = c.Uruns.Find(id);
            deger.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Kategoris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KategoriAd,
                                               Value = x.KategoriID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            var urundeger = c.Uruns.Find(id);
            return View("UrunGetir", urundeger);

        }
        public ActionResult UrunGuncelle(Urun p)
        {

            var urn = c.Uruns.Find(p.Urunid);
            urn.Marka = p.Marka;
            urn.Kategoriid = p.Kategoriid;
            urn.SatisFiyat = p.SatisFiyat;
            urn.Stok = p.Stok;
            urn.UrunAd = p.UrunAd;
            urn.Durum = p.Durum;
            urn.AlisFiyat = p.AlisFiyat;
            urn.UrunGorsel = p.UrunGorsel;
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult UrunListesi()
        {
            var degerler = c.Uruns.ToList();
            return View(degerler);

        }

        [HttpGet]
        public ActionResult SatisYap(int id)
        {
            //Personel Listesini combobox olarak getirme
            List<SelectListItem> deger1 = (from x in c.Personels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PersonelAd + " " + x.PersonelSoyad,
                                               Value = x.Personelid.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            //Ürün getirme
            var deger2 = c.Uruns.Find(id);
            ViewBag.dgr2 = deger2.Urunid;
            //Fiyat Getirme
            ViewBag.dgr3 = deger2.SatisFiyat;


            return View();
        }
        [HttpPost]
        public ActionResult SatisYap(SatisHareket p)
        {
            p.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.SatisHarekets.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index","Satis");
        }
    }
}