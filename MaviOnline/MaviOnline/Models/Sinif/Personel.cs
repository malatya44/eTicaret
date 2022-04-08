using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MaviOnline.Models.Sinif
{
    public class Personel
    {
        [Key]
        public int Personelid { get; set; }
        [Display(Name =("Personel Adı"))]
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string PersonelAd { get; set; }

        [Display(Name = ("Personel Soyadı"))]
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string PersonelSoyad { get; set; }

        [Display(Name = ("Personel Resmi"))]
        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string PersonelGorsel { get; set; }
        public ICollection<SatisHareket> SatisHarekets { get; set; }
        public int Departmanid { get; set; }
        //virtual yapmazsak çakışıyor departman idi yide oluşturdukki Departman detayı yapalım 
        public virtual Departman Departman { get; set; }
    }
}