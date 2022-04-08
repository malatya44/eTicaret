using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MaviOnline.Models.Sinif;

namespace MaviOnline.Controllers
{
    public class IstatistikController : Controller
    {
        // GET: istatistik
        Context c = new Context();
        public ActionResult Index()
        {
            //Carilerin Sayısı
            var deger1 = c.Carilers.Count().ToString();
            ViewBag.d1 = deger1;

            //Ürün Sayısı
            var deger2 = c.Uruns.Count().ToString();
            ViewBag.d2 = deger2;

            //Personel Sayısı
            var deger3 = c.Personels.Count().ToString();
            ViewBag.d3 = deger3;

            //Kategori Sayısı
            var deger4 = c.Kategoris.Count().ToString();
            ViewBag.d4 = deger4;

            //Toplam Stok Sayısı
            var deger5 = c.Uruns.Sum(x => x.Stok).ToString();
            ViewBag.d5 = deger5;

            //Marka Sayısı Ürünler içerisinden bu markayı seç tekrarsız olarak say
            var deger6 = (from x in c.Uruns select x.Marka).Distinct().Count().ToString();
            ViewBag.d6 = deger6;

            // Kritik Seviye Stok Sayısı 20 ye eşit veya altına düşen olanların sayısını yazacak
            var deger7 = c.Uruns.Count(x => x.Stok <= 20).ToString();
            ViewBag.d7 = deger7;

            //Maksimum Fiyatlı ürün Satış fiyatına göre büyükten küçüğe sırala ilkini seç yazdır
            var deger8 = (from x in c.Uruns orderby x.SatisFiyat descending select x.UrunAd).FirstOrDefault();
            ViewBag.d8 = deger8;

            //Minumum Fiyatlı ürün Satış fiyatına göre küçükten büyüğe sırala ilkini seç yazdır
            var deger9 = (from x in c.Uruns orderby x.SatisFiyat ascending select x.UrunAd).FirstOrDefault();
            ViewBag.d9 = deger9;

            //Maksimum marka  Markaya Göre Gruplandır Sayısına Göre sonra sırala en fazla olan üstte oluyor seç 
            var deger12 = c.Uruns.GroupBy(x => x.Marka).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault();
            ViewBag.d12 = deger12;


            // Satılan Buzdolabı toplam sayısını yazacak
            var deger10 = c.Uruns.Count(x => x.UrunAd == "Buzdolabı").ToString();
            ViewBag.d10 = deger10;

            // Satılan Laptop toplam sayısını yazacak
            var deger11 = c.Uruns.Count(x => x.UrunAd == "Laptop").ToString();
            ViewBag.d11 = deger11;

            // En Çok Satan Ürünü Bulmak Satış hareket tablosunda urun id e göre gruplandır bu urun id i sayısını büyükten
            //küçüğe doğru sırala en üstekini al ve bu idinin urun adını seç ve onu bana yazdır
            var deger13 = c.Uruns.Where(u => u.Urunid == (c.SatisHarekets.GroupBy(x => x.Urunid).OrderByDescending
            (z => z.Count()).Select(y => y.Key).FirstOrDefault())).Select(k => k.UrunAd).FirstOrDefault();
            ViewBag.d13 = deger13;

            //Kasadaki Toplam Tutar 
            var deger14 = c.SatisHarekets.Sum(x => x.ToplamTutar).ToString();
            ViewBag.d14 = deger14;

            // Bugünkü satış sayısı
            DateTime bugun = DateTime.Today;
            var deger15 = c.SatisHarekets.Count(x => x.Tarih == bugun).ToString();
            ViewBag.d15 = deger15;

            // Bugünkü satışların toplamı bugünün tarihine eşit olanları getir ve toplam tutarları topla
            if (Convert.ToInt32(deger15) != 0)
            {
                var deger16 = c.SatisHarekets.Where(x => x.Tarih == bugun).Sum(y => y.ToplamTutar).ToString();
                ViewBag.d16 = deger16;
            }
            else { ViewBag.d16 = deger15; }

            return View();
        }
        public ActionResult KolayTablolar()
        {
            var sorgu = (from x in c.Carilers
                         group x by x.CariSehir into g
                         select new SinifGrup
                         {
                             Sehir = g.Key,
                             Sayi = g.Count()
                         });
            return View(sorgu.ToList());
        }
        // Benim istediğim herhangi bir yere istediğim yazıyı partialviev le yazdırıyorum
        //ilgili sayfaya  @Html.Action("Partial1","istatistik")
        //bunu yazarsam istediğim yerde bunun içindeki değer yazı html görünür
        public PartialViewResult Partial1()
        {
            //her departmanda kaçtane personel var sorgusu Modelde sınıfgrup2 classı gerekiyor
            var sorgu2 = from x in c.Personels
                                   group x by x.Departman.DepartmanAd into g
                                   select new SinifGrup2
                                   {
                                       Departman = g.Key, //departmanid 
                                       Sayi = g.Count()
                                   };
            return PartialView(sorgu2.ToList());
        }

        public PartialViewResult Partial2()
        {
            //Cari Listesini getiren sorgu
            var sorgu = c.Carilers.ToList();
            return PartialView(sorgu);
        }
        public PartialViewResult Partial3()
        {
            //bana Ürünleri Listele
            var sorgu = c.Uruns.ToList();
            return PartialView(sorgu);
        }
        public PartialViewResult Partial4()
        {
            //her her markanın kaç ürünü var sorgusu Modelde sınıfgrup3 classı gerekiyor
            var sorgu3 = from x in c.Uruns
                         group x by x.Marka into g
                         select new SinifGrup3
                         {
                             marka = g.Key, //marka 
                             sayi = g.Count()
                         };
            return PartialView(sorgu3.ToList());
        }

    }
}
