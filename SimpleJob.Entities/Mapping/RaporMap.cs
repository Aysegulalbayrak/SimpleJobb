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
    public class RaporMap: EntityTypeConfiguration<Rapor>
    {
        public RaporMap()
        {
            this.ToTable("tblRapor");
            this.Property(p => p.RaporId).HasColumnType("int");
            this.Property(p => p.RaporId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.HasRequired(p => p.Is).WithMany(p => p.Rapors).HasForeignKey(p => p.IsId);

            
            
            this.HasRequired(p => p.Uye).WithMany(p => p.Rapors).HasForeignKey(p => p.UyeId);
            
        }
    }
}
