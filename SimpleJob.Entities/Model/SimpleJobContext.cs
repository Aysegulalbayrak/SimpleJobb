using SimpleJob.Entities.Mapping;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleJob.Entities.Model
{
    public class SimpleJobContext: DbContext
    {
        public SimpleJobContext() : base("name=SimpleJobEntities")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;

        }
       

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            modelBuilder.Configurations.Add(new IsKategoriMap());
    
            modelBuilder.Configurations.Add(new IsMap());
            modelBuilder.Configurations.Add(new DosyaMap());
            modelBuilder.Configurations.Add(new MailMap());
            modelBuilder.Configurations.Add(new UyeMap());
            modelBuilder.Configurations.Add(new RaporMap());
            modelBuilder.Configurations.Add(new TakvimMap());
            modelBuilder.Configurations.Add(new UnvanMap());
           




        }

        
        public DbSet<IsKategori> IsKategori { get; set; }
        
        public DbSet<Is> Is { get; set; }
        public DbSet<Dosya> Dosya { get; set; }
        public DbSet<Mail> Mail { get; set; }
        public DbSet<Uye> Uye { get; set; }
        public DbSet<Rapor> Rapor { get; set; }
        public DbSet<Takvim> Takvim { get; set; }
        public DbSet<Unvan> Unvan { get; set; }
        
    }
}
