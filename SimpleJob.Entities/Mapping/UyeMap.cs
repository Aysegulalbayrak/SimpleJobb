using SimpleJob.Entities.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleJob.Entities.Mapping
{
    class UyeMap : EntityTypeConfiguration<Uye>
    {
        public UyeMap()
        {
            this.ToTable("tblUye");
            this.Property(p => p.UyeId).HasColumnType("int");
            this.Property(p => p.UyeId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(p => p.UyeAdi).HasColumnType("nvarchar").HasMaxLength(100);
            this.Property(p => p.UyeSoyadi).HasColumnType("nvarchar").HasMaxLength(100);
            this.Property(p => p.UyeEmail).HasColumnType("nvarchar").HasMaxLength(500);
            this.Property(p => p.UyeKAdi).HasColumnType("nvarchar").HasMaxLength(500);
            this.Property(p => p.UyeSifre).HasColumnType("nvarchar").HasMaxLength(500);
            this.Property(p => p.UyeDurumu).HasColumnType("bit");
            this.Property(p => p.UyeCinsiyet).HasColumnType("nvarchar").HasMaxLength(50);
            
            this.Property(p => p.UyeIseBaslamaTarihi).HasColumnType("date");
            this.Property(p => p.github).HasColumnType("nvarchar").HasMaxLength(1500);
            this.Property(p => p.linkedln).HasColumnType("nvarchar").HasMaxLength(1500);
            this.Property(p => p.Fotograf).HasColumnType("nvarchar").HasMaxLength(4000);
            this.HasRequired(p => p.Unvan).WithMany(p => p.Uyes).HasForeignKey(p => p.UyeUnvanId);
            //this.HasRequired(p => p.Dosya).WithMany(p => p.Uyes).HasForeignKey(p => p.DosyaId);


        }
    }
}
