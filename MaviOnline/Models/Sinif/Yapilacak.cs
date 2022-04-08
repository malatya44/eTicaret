using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MaviOnline.Models.Sinif
{
    public class Yapilacak
    {
        [Key]
        public int Yapilacakid { get; set; }

        [Display(Name = ("Başlık"))]
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string Baslik { get; set; }

        [Column(TypeName = "bit")]
        public bool Durum { get; set; }


    }
}