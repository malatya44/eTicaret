using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MaviOnline.Models.Sinif
{
    public class KargoTakip
    {
        [Key]
        public int KargoTakipid { get; set; }
        [Display(Name = ("Takip Kodu"))]
        [Column(TypeName = "Varchar")]
        [StringLength(11)]
        public string TakipKodu { get; set; }
        [Display(Name = ("Açıklama"))]
        [Column(TypeName = "Varchar")]
        [StringLength(300)]
        public string Aciklama { get; set; }
        public DateTime TarihZaman { get; set; }
    }
}