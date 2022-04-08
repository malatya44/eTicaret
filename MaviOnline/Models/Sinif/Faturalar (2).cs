using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MaviOnline.Models.Sinif
{
    public class Faturalar
    {
        [Key]
        public int Faturaid { get; set; }

        [Display(Name = ("Fatura Seri Numarası"))]
        [Column(TypeName = "Char")]
        [StringLength(1)]
        public string FaturaSeriNo { get; set; }

        [Display(Name = ("Fatura Sıra Numarası"))]
        [Column(TypeName = "Varchar")]
        [StringLength(6)]
        public string FaturaSiraNo { get; set; }

        public DateTime Tarih { get; set; }

        [Display(Name = ("Vergi Dairesi"))]
        [Column(TypeName = "Varchar")]
        [StringLength(60)]
        public string VergiDairesi { get; set; }

        [Column(TypeName = "char")]
        [StringLength(5)]
        public string Saat { get; set; }

        [Display(Name = ("Teslim Eden"))]
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string TeslimEden { get; set; }

        [Display(Name = ("Teslim Alan"))]
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string TeslimAlan { get; set; }
        public decimal Toplam { get; set; }

        //Bir Faturanın birden fazla kalemi olabilir. Ondan Dolayı Icollection 

        public ICollection<FaturaKalem> FaturaKalems { get; set; }

    }
}