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
            //sessionda carimailkden gelen değeri aldım
            var mail = (string)Session["CariMail"];
            var degerler = c.Carilers.FirstOrDefault(x => x.CariMail == mail);
            ViewBag.m = mail;

            return View(degerler);
        }
        public ActionResult Siparislerim()
        {
            //sessionda carimailkden gelen değeri aldım
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
            var mesajlar = c.Mesajlars.ToList();
            return View(mesajlar);
        } 
        [HttpGet]
        public ActionResult YeniMesaj()
        {
            return View();
        }
        //[HttpPost]
        //public ActionResult YeniMesaj()
        //{
        //    return View();
        //}
    }
}