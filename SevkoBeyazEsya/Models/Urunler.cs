using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SevkoBeyazEsya.Models
{
    public class Urunler
    {
        [Key]
        public int Urun_id { get; set; }
        [Column(TypeName ="varchar")]
        [StringLength(50)]
        public string Urun_adi { get; set; }
        [Column(TypeName ="varchar")]
        [StringLength(30)]

        public string Urun_marka { get; set; }

        
        public short Urun_stok { get; set; }
        public string Urun_alisfiyat { get; set; }
        public string Urun_satisfiyat { get; set; }
        public string Urun_durum { get; set; }
        public string Urun_Gorsel { get; set; }

        public virtual Kategori Kategori { get; set; }

        public ICollection<Satisler> Satislers { get; set; }

    }
}