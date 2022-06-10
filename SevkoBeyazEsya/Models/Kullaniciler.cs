using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SevkoBeyazEsya.Models
{
    public class Kullaniciler
    {
        [Key]
        public int Kullanici_id { get; set; }
        [Column(TypeName ="varchar")]
        [StringLength(50,ErrorMessage ="Maksimum 50 karakter girebilirsiniz.")]
        [Required(ErrorMessage ="Adınızı girmeniz zorunludur.")]


        public string Kullanici_Adi { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(30,ErrorMessage ="Maksimum 30 karakter girebilirsiniz.")]
        [Required(ErrorMessage ="Soyadınızı girmeniz zorunludur.")]
        public string Kullanici_Soyadi { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(100)]
        public string e_mail { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(11)]
        public string telefon_numarasi { get; set; }
       
        public string sifre { get; set; }
    }
}