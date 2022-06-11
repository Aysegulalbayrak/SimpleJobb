using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleJob.Entities.Model
{
    public class Mail
    {
       
            public int MailId { get; set; }

            
            public int GondericiId { get; set; }
            public string MailBaslik { get; set; }
            public string MailAciklama { get; set; }
            public DateTime MailTarih { get; set; }
            public bool MailDurumu { get; set; }

            public int UyeId { get; set; }
            public virtual Uye Uye { get; set; }




    }
}

