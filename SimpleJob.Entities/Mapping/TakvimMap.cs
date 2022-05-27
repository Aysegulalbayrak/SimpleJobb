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
    public class TakvimMap: EntityTypeConfiguration<Takvim>
    {
        public TakvimMap()
        {
            this.ToTable("tblTakvim");
            this.Property(p => p.TakvimId).HasColumnType("int");
            this.Property(p => p.TakvimId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(p => p.title).HasColumnType("nvarchar").HasMaxLength(100);
            this.Property(p => p.start).HasColumnType("Datetime");
            this.Property(p => p.end).HasColumnType("Datetime");
            this.Property(p => p.color).HasColumnType("nvarchar").HasMaxLength(100);
            this.Property(p => p.textColor).HasColumnType("nvarchar").HasMaxLength(4000);
            this.Property(p => p.takvimDurumu).HasColumnType("bit");

        }
    }
}
