using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MaviOnline.Models.Sinif
{
    public class FaturaKalem
    {
        [Key]
        public int FaturaKalemid { get; set; }

        [Display(Name = ("Açıklama"))]
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string Aciklama { get; set; }

        public int Miktar { get; set; }

        [Display(Name = ("Birim Fiyat"))]
        public decimal BirimFiyat { get; set; }
        public decimal Tutar { get; set; }

        public int Faturaid { get; set; }
        // Bir fatura kalemininde sadece bir tane faturası olabilir. Faturalardan ürettim.
        public virtual Faturalar Faturalar { get; set; }
    }
}