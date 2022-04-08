using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MaviOnline.Models.Sinif
{
    public class KargoDetay
    {
        [Key]
        public int KargoDetayid { get; set; }
        [Display(Name = ("Açıklama"))]
        [Column(TypeName = "Varchar")]
        [StringLength(300)]
        public string Aciklama { get; set; }
        [Display(Name = ("Takip Kodu"))]
        [Column(TypeName = "Varchar")]
        [StringLength(11)]
        public string TakipKodu { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(40)]
        public string Personel { get; set; }
        [Display(Name = ("Alıcı"))]
        [Column(TypeName = "Varchar")]
        [StringLength(40)]
        public string Alici { get; set; }
        public DateTime Tarih { get; set; }
    }
}