using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SevkoBeyazEsya.Models
{
    public class Yonetici
    {
        [Key]
        public int  Yonetici_id { get; set; }
     [Column(TypeName ="varchar")]
     [StringLength(30)]
        public string Yonetici_adi { get; set; }
        [Column(TypeName ="varchar")]

        public string sifre { get; set; }
        [Column(TypeName ="char")]
        [StringLength(1)]
        public string yetki { get; set; }
    }
}