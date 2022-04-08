using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MaviOnline.Models.Sinif;

namespace MaviOnline.Controllers
{
    public class KargoController : Controller
    {
        // GET: Kargo
        Context c = new Context();

        //Kargo arama kısmı contains i kaldırırsan tam yazman lazım 10 haneyiki  arasın
        public ActionResult Index(string p)
        {
            var kargo = from x in c.KargoDetays select x;
            if (!string.IsNullOrEmpty(p))
            {
                kargo = kargo.Where(y => y.TakipKodu.Contains(p));
            }
            return View(kargo.ToList());
        }

   /*     [HttpGet]
        public ActionResult YeniKargo()
        {
            //Rastgele Kargo Takip Kodu Ürettirtme
            //10 basamaklı olacak karakter sayıları kod kısmında 10--> 3 1 2 1 2 1
            Random rnd = new Random();
            string[] karakterler = { "A", "B", "C", "D" }; //ABCD harflerinden karakter alacak
            int k1, k2, k3;
            k1 = rnd.Next(0, 4); //0 1 2 3 değerlerinden birini alabilir
            k2 = rnd.Next(0, 4); //0 1 2 3 değerlerinden birini alabilir
            k3 = rnd.Next(0, 4); //0 1 2 3 değerlerinden birini alabilir
            int s1, s2, s3;
            s1 = rnd.Next(100, 1000); //3 basamaklı bir kısım
            s2 = rnd.Next(10, 99); //2 basamaklı bir kısım
            s3 = rnd.Next(10, 99); //3 basamaklı bir kısım
            string kod = s1.ToString() + karakterler[k1] + s2 + karakterler[k2] + s3 + karakterler[k3];
            ViewBag.takipkod = kod;
            return View();
        }
   */

        //Biraz uzun ama aynı gelme ihtimali yok. Belki işine yarayan olabilir. 11 haneli.
        [HttpGet]
        public ActionResult YeniKargo()
        {
            Random rnd = new Random();
            int sayi1, sayi2, sayi3, sayi4, sayi5;
            int harf, harf2, harf3, harf4;
            sayi1 = rnd.Next(1, 9);
            sayi2 = rnd.Next(0, 9);
            sayi3 = rnd.Next(0, 9);
            sayi4 = rnd.Next(1, 9);
            harf = rnd.Next(65, 91);
            sayi5 = rnd.Next(65, 91);
            harf2 = rnd.Next(65, 91);
            harf3 = rnd.Next(65, 91);
            harf4 = rnd.Next(65, 91);
            if (harf == harf2) { harf2 = rnd.Next(65, 91); }
            if (harf2 == harf3) { harf3 = rnd.Next(65, 91); }
            if (harf3 == harf4) { harf4 = rnd.Next(65, 91); }
            if (sayi1 == sayi2) { sayi2 = rnd.Next(1, 9); }
            if (sayi2 == sayi3) { sayi3 = rnd.Next(0, 9); }
            if (sayi3 == sayi4) { sayi4 = rnd.Next(1, 9); }
            if (sayi4 == sayi5) { sayi5 = rnd.Next(0, 9); }
            char karakter;
            char karakter2;
            char karakter3;
            char karakter4;
            karakter = Convert.ToChar(harf);
            karakter2 = Convert.ToChar(harf2);
            karakter3 = Convert.ToChar(harf3);
            karakter4 = Convert.ToChar(harf4);
            string kod = sayi1.ToString() + sayi2.ToString() + karakter + sayi3.ToString() + sayi4.ToString() + karakter2 + sayi4.ToString() + karakter3 + sayi5.ToString() + karakter4;
            ViewBag.takipkod = kod;
            return View();
        }
        //kargo ekleme
        [HttpPost]
        public ActionResult YeniKargo(KargoDetay k)
        {
            c.KargoDetays.Add(k);
            c.SaveChanges();
            return RedirectToAction("index");

        }
        //Kargo Takip Detaylar
        public ActionResult KargoTakip(string id) //p diye parametre versek rout configde id diye belirttiğimiz sayfayı açar
        {
            //p = "671A32C96D"; 
            var degerler = c.KargoTakips.Where(x => x.TakipKodu == id).ToList();

            return View(degerler);
        }
    }
}