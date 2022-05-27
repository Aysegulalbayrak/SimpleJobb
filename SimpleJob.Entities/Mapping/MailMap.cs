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
   
        public class MailMap : EntityTypeConfiguration<Mail>
        {
            public MailMap()
            {
                this.ToTable("tblMail");
                this.Property(p => p.MailId).HasColumnType("int");
                this.Property(p => p.MailId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
                
                this.Property(p => p.AliciMailAdresi).HasColumnType("nvarchar").HasMaxLength(1000);
                this.Property(p => p.GondericiMailAdresi).HasColumnType("nvarchar").HasMaxLength(1000);
                this.Property(p => p.MailBaslik).HasColumnType("nvarchar").HasMaxLength(200);
                this.Property(p => p.MailAciklama).HasColumnType("nvarchar").HasMaxLength(4000);
                this.Property(p => p.MailTarih).HasColumnType("date");
                this.Property(p => p.MailDurumu).HasColumnType("bit");
                this.Property(p => p.KategoriId).HasColumnType("int");
                this.HasRequired(p => p.Uye).WithMany(p => p.Mails).HasForeignKey(p => p.UyeId);

        }
        }
    
}
