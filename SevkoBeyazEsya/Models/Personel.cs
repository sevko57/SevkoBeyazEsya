using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SevkoBeyazEsya.Models
{
    public class Personel
    {
        [Key]
        public int Personel_id { get; set; }

        [Column(TypeName ="varchar")]
        [StringLength(30)]
        public string Personel_adi { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(30)]
        public string Personel_Soyadi { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(250)]
        public string Personel_Gorsel { get; set; }
        public int Departman_id { get; set; }
        public virtual Departman Departman { get; set; }
    }
}