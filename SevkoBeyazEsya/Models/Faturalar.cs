using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SevkoBeyazEsya.Models
{
    public class Faturalar
    {
        [Key]
        public int Fatura_id { get; set; }
        [Column(TypeName ="char")]
        [StringLength(1)]
        public string FaturaSeri_no { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(6)]
        public string FaturaSira_no { get; set; }
        public DateTime Tarih { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(60)]
        public string Vergi_dairesi { get; set; }
        [Column(TypeName = "char")]
        [StringLength(5)]
        public String saat { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(30)]
        public string Teslim_eden  { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(30)]
        public string Teslim_alan { get; set; }
        
        public decimal ToplamFiyat { get; set; }

    }
}