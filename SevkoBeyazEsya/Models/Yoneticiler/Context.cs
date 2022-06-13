using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SevkoBeyazEsya.Models.Yoneticiler
{
    public class Context:DbContext
    {
        public DbSet<Departman> Departmans { get; set; }
        public DbSet<Faturalar> Faturalars { get; set; }
        public DbSet<Giderler> Giderlers { get; set; }
        public DbSet <Kategori> Kategoris { get; set; }
        public DbSet <Kullaniciler> Kullanicilers { get; set; }
        public DbSet <Personel> Personels { get; set; }
        public DbSet <Satisler> Satislers { get; set; }
        public DbSet <Subeler> Subelers  { get; set; }
        public DbSet  <Urunler> Urunlers { get; set; }
        public DbSet <Yonetici> Yoneticis { get; set; }
    }
    public class VeritabaniOlustur:CreateDatabaseIfNotExists<Context>
    {
        protected override void Seed(Context context)
        {
            
        }
    }
}