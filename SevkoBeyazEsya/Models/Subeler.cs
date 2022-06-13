using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SevkoBeyazEsya.Models
{
    public class Subeler
    {
        [Key]

        public int Sube_id { get; set; }
        [Column(TypeName ="varchar")]
        [StringLength(30)]
        public string Sube_Adi { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(13)]
        public string sehir { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(100)]
        public string e_mail { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(11)]
        public string Telefon_Numarasi  { get; set; }
        public ICollection<Satisler> Satislers { get; set; }

    }

    }
