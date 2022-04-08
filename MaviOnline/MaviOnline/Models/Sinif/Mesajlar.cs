using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MaviOnline.Models.Sinif
{
    public class Mesajlar
    {
        [Key]
        public int MesajID { get; set; }

        [Display(Name = ("Gönderici"))]
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string Gonderici { get; set; }

        [Display(Name = ("Alıcı"))]
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string Alici { get; set; }

        [Display(Name = ("Mesajın Konusu"))]
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string Konu { get; set; }

        [Display(Name = ("Mesajın İçeriği"))]
        [Column(TypeName = "Varchar")]
        [StringLength(2000)]
        public string icerik { get; set; }

        [Display(Name = ("Mesaj Tarihi"))]
        [Column(TypeName = "Smalldatetime")]
        public DateTime Tarih { get; set; }
    }
}