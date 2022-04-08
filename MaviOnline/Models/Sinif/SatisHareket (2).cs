using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MaviOnline.Models.Sinif
{
    public class SatisHareket
    {
        [Key]
        public int Satisid { get; set; }
        public DateTime Tarih { get; set; }
        public int Adet { get; set; }
        public decimal Fiyat { get; set; }

        [Display(Name = ("Toplam Tutar"))]
        public decimal ToplamTutar { get; set; }

        //virtualdan dolayı update-database -force yapıyoruz. packed managerda
        public int Urunid { get; set; }
        public int Cariid { get; set; }
        public int Personelid { get; set; }
        //ürün virtual yapıyoruz bir çok yerle ilişkili bu nedenle her virtual için id tanımı yapıyoruz.bir satır Üstte
        public virtual Urun Urun { get; set; }
        //cari
        public virtual Cariler Cariler { get; set; }
        //personel
        public virtual Personel Personel { get; set; }
    }
}