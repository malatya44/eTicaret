using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MaviOnline.Models.Sinif
{
    public class Admin
    {
        [Key]
        public int Adminid { get; set; }

        [Column(TypeName = "Varchar")] //Değişken Kısıtlama veri tabanında çok yer kaplamasın diye
        [StringLength(10)] //Karakter Sayısı Kısıtlama
        public string KullaniciAd { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string Sifre { get; set; }

        [Column(TypeName = "Char")]
        [StringLength(1)]
        public string Yetki { get; set; }
    }
}