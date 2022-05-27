using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleJob.Entities.Model
{
    public class MailKategori
    {
        public int MailKategoriId { get; set; }
        public string MailKategoriAdi { get; set; }
        public bool MailKategoriDurumu { get; set; }


        public virtual ICollection<Mail> Mails { get; set; }
    }
}
