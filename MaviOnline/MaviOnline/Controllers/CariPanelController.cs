using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MaviOnline.Models.Sinif;
namespace MaviOnline.Controllers
{
    public class CariPanelController : Controller
    {
        // GET: CariPanel
        Context c = new Context();
        [Authorize]
        public ActionResult Index()
        {
            //sessionda carimailden gelen değeri aldım
            var mail = (string)Session["CariMail"];
            var degerler = c.Carilers.FirstOrDefault(x => x.CariMail == mail);
            ViewBag.m = mail;

            return View(degerler);
        }
        public ActionResult Siparislerim()
        {
            //sessionda carimailden gelen değeri aldım
            var mail = (string)Session["CariMail"];
            //sisteme giriş yapan mail adresinin idisini aldık
            var id = c.Carilers.Where(x => x.CariMail == mail.ToString()).Select(y => y.Cariid).FirstOrDefault();
            //degerlere satışhareket tablosundan cari değikeni benim aldığım id nosuna karşılık gelen listesini dçndür
            var degerler = c.SatisHarekets.Where(x => x.Cariid == id).ToList();
            return View(degerler);
        }
        //Mesajlar Kısmı
        public ActionResult GelenMesajlar()
        {
            var mail = (string)Session["CariMail"];
            //Gelen Mesajları orderby ile idye göre sıraladık
            var mesajlar = c.Mesajlars.Where(x => x.Alici == mail).OrderByDescending(x=>x.MesajID).ToList();
            //maile gelen mesaj sayisini viewbag d1 ile view e yolladık
            var gelensayisi = c.Mesajlars.Count(x => x.Alici == mail).ToString();
            ViewBag.d1 = gelensayisi;
            //maile giden mesaj sayisini viewbag d2 ile view e yolladık
            var gidensayisi = c.Mesajlars.Count(x => x.Gonderici == mail).ToString();
            ViewBag.d2 = gidensayisi;

            return View(mesajlar);
        }
        public ActionResult GidenMesajlar()
        {
            var mail = (string)Session["CariMail"];
            var mesajlar = c.Mesajlars.Where(x => x.Gonderici == mail).OrderByDescending(x => x.MesajID).ToList();
            //maile gelen mesaj sayisini viewbag d1 ile view e yolladık
            var gelensayisi = c.Mesajlars.Count(x => x.Alici == mail).ToString();
            ViewBag.d1 = gelensayisi;
            //maile giden mesaj sayisini viewbag d2 ile view e yolladık
            var gidensayisi = c.Mesajlars.Count(x => x.Gonderici == mail).ToString();
            ViewBag.d2 = gidensayisi;

            return View(mesajlar);
        }
        public ActionResult MesajDetay(int id)
        {
            var degerler = c.Mesajlars.Where(x => x.MesajID == id).ToList();
            var mail = (string)Session["CariMail"];
            //maile gelen mesaj sayisini viewbag d1 ile view e yolladık
            var gelensayisi = c.Mesajlars.Count(x => x.Alici == mail).ToString();
            ViewBag.d1 = gelensayisi;
            //maile giden mesaj sayisini viewbag d2 ile view e yolladık
            var gidensayisi = c.Mesajlars.Count(x => x.Gonderici == mail).ToString();
            ViewBag.d2 = gidensayisi;
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniMesaj()
        {
            var mail = (string)Session["CariMail"];
            //maile gelen mesaj sayisini viewbag d1 ile view e yolladık
            var gelensayisi = c.Mesajlars.Count(x => x.Alici == mail).ToString();
            ViewBag.d1 = gelensayisi;
            //maile giden mesaj sayisini viewbag d2 ile view e yolladık
            var gidensayisi = c.Mesajlars.Count(x => x.Gonderici == mail).ToString();
            ViewBag.d2 = gidensayisi;
            return View();
        }
        [HttpPost]
        public ActionResult YeniMesaj(Mesajlar m)
        {
            var mail = (string)Session["CariMail"];
            m.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            m.Gonderici = mail;
            //Mesaj yazarken gelen değeri gönderdik
            c.Mesajlars.Add(m);
            c.SaveChanges();
            return View();
        }
    }
}