using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleJob.Entities.Model;

namespace SimpleJob.Entities.Mapping
{
    public class IsKategoriMap : EntityTypeConfiguration<IsKategori>
    {
        public IsKategoriMap()
        {
            this.ToTable("tblIsKategori");
            this.Property(p => p.IsKategoriId).HasColumnType("int");
            this.Property(p => p.IsKategoriId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(p => p.IsKategoriAdi).HasColumnType("nvarchar").HasMaxLength(100);
            this.Property(p => p.IsKategoriDurumu).HasColumnType("bit");
        }

   
    }
}
