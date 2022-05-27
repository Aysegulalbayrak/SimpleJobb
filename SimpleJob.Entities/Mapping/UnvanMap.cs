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
    class UnvanMap : EntityTypeConfiguration<Unvan>
    {
        public UnvanMap()
        {
            this.ToTable("tblUnvan");
            this.Property(p => p.UnvanId).HasColumnType("int");
            this.Property(p => p.UnvanId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            
            this.Property(p => p.UnvanAdi).HasColumnType("nvarchar").HasMaxLength(100);
            this.Property(p => p.UnvanAciklama).HasColumnType("nvarchar").HasMaxLength(4000);
            this.Property(p => p.UnvanDurumu).HasColumnType("bit");

        }
    }
}
