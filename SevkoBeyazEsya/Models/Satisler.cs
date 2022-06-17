using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SevkoBeyazEsya.Models
{
    public class Satisler
    {
        [Key]
        public int Satis_id { get; set; }
        public virtual Urunler Urunler { get; set; }
        public virtual Subeler Subeler { get; set; }
        public virtual Personel Personel { get; set; }
        public virtual Kategori Kategori { get; set; }



        public int Urun_id { get; set; }
        public int Personel_id { get; set; }
        public int Sube_id { get; set; }
        public int Kategori_id { get; set; }
        public DateTime Tarih { get; set; }
        public string Adet { get; set; }
        public decimal Fiyat { get; set; }
        public decimal ToplamTutar { get; set; }
    }
}
