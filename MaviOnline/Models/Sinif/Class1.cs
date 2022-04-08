using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MaviOnline.Models.Sinif
{ //birden fazla tablodan veri çekmek için ienumerable kullanıyoruz
    //UrunDetay Controllerda class1 den nesne türetimi yapacağız.
    public class Class1
    {
        public IEnumerable<Urun> Deger1 { get; set; }
        public IEnumerable<Detay> Deger2 { get; set; }
    }
}