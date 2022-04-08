using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MaviOnline.Controllers
{
    public class QRController : Controller
    {
        // GET: QR
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string kod)
        {
            //Dosya akışlarında kullanılan resim oluşturma resim çizme resme yazı yazma sınıfıdır
            //MemoryStream system.io ile kullanılır.
            using (MemoryStream ms=new MemoryStream())
            {
                // Eklediğimiz QRcode.dll dosyası kütüphanesi kullanılır.
                QRCodeGenerator koduret = new QRCodeGenerator();
                //QR Kodu Oluşturduk
                QRCodeGenerator.QRCode karekod = koduret.CreateQrCode(kod,QRCodeGenerator.ECCLevel.Q);
                //bitmap oluşturcaz drawing kütüphanesini kullanıyoruz 10 kaliteli bitmap veriyor.
                using (Bitmap resim=karekod.GetGraphic(10))
                {
                    resim.Save(ms, ImageFormat.Png);
                    ViewBag.karekodimage = "data:image/png;base64," + Convert.ToBase64String(ms.ToArray());
                }
            }
            return View();
        }
    }
}