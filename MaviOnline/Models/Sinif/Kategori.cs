using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MaviOnline.Models.Sinif
{
    public class Kategori
    {
        [Key]
        public int KategoriID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string KategoriAd { get; set; }

        //Her kategorinin içerisinde birden fazla ürün vardır bire çok ilişki
        //Icollection veritabanında uruns olarak oluşturacak
        public ICollection<Urun> Uruns { get; set; }
    }
}