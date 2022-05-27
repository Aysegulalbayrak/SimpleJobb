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
    public class IsMap: EntityTypeConfiguration<Is>
    {
        public IsMap()
        {
            this.ToTable("tblIs");
            this.Property(p => p.IsId).HasColumnType("int");
            this.Property(p => p.IsId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            

            this.Property(p => p.IsBaslik).HasColumnType("nvarchar").HasMaxLength(100);
            this.Property(p => p.IsAciklama).HasColumnType("nvarchar").HasMaxLength(4000);
            this.Property(p => p.SonTeslimTarihi).HasColumnType("date");
            this.Property(p => p.IlerlemeDurumu).HasColumnType("int");
            this.Property(p => p.DosyaAdresi).HasColumnType("nvarchar").HasMaxLength(4000);

            
            this.Property(p => p.IsDurumu).HasColumnType("bit");
            

            this.HasRequired(p => p.IsKategori).WithMany(p => p.Ises).HasForeignKey(p => p.IsKategoriId);
            
           // this.HasRequired(p => p.Dosya).WithMany(p => p.Ises).HasForeignKey(p => p.DosyaId);

            this.HasRequired(p => p.Uye).WithMany(p => p.Ises).HasForeignKey(p => p.UslenenUyeId);



        }

    }
}
