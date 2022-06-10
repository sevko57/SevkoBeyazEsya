using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SevkoBeyazEsya.Models
{
    public class Departman
    {
        [Key]
        public int Departman_id { get; set; }
        [Column(TypeName ="varchar")]
        [StringLength(30)]
        public string Departman_adi { get; set; }
        

    }
}