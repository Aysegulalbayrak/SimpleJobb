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
    public class DosyaMap: EntityTypeConfiguration<Dosya>
    {
        public DosyaMap()
        {
            this.ToTable("tblDosya");
            this.Property(p => p.DosyaId).HasColumnType("int");
            this.Property(p => p.DosyaId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(p => p.DosyaAdresi).HasColumnType("nvarchar").HasMaxLength(4000);
            this.Property(p => p.DosyaDurumu).HasColumnType("bit");



        }
    }
}
