using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MaviOnline.Models.Sinif
{
    public class KategoriUrunListele
    {
        public IEnumerable <SelectListItem> Kategoriler { get; set; }
        public IEnumerable <SelectListItem> Urunler { get; set; }
    }
}