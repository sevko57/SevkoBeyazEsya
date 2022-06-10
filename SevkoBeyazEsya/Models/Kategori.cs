using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SevkoBeyazEsya.Models
{
    public class Kategori
    {
        [Key]
        public int Kategori_id { get; set; }
        [Column(TypeName ="varchar")
         [StringLength(30)]   ]
        public string Kategori_Adi { get; set; }
    }
}