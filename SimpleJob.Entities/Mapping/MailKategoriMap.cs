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
    public class MailKategoriMap: EntityTypeConfiguration<MailKategori>
    {
        public MailKategoriMap()
        {
            this.ToTable("tblMailKategori");
            this.Property(p => p.MailKategoriId).HasColumnType("int");
            this.Property(p => p.MailKategoriId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(p => p.MailKategoriAdi).HasColumnType("nvarchar").HasMaxLength(100);
            this.Property(p => p.MailKategoriDurumu).HasColumnType("bit");
        }
    }
}
