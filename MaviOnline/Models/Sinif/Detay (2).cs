using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MaviOnline.Models.Sinif
{
    public class Detay
    {
        [Key]
        public int DetayID { get; set; }

        [Display(Name = ("Ürün Adı"))]
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string urunad { get; set; }

        [Display(Name = ("Ürün Bilgisi"))]
        [Column(TypeName = "Varchar")]
        [StringLength(2000)]
        public string urunbilgi { get; set; }
    }
}