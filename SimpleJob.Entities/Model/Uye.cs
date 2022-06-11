using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleJob.Entities.Model
{
    public class Uye
    {
        public int UyeId { get; set; }
        public string UyeAdi { get; set; }
        public string UyeSoyadi { get; set; }
        public string UyeEmail { get; set; }
        public string UyeKAdi { get; set; }
        public string TelefonKodu { get; set; }
        public string TelefonNo { get; set; }

        public string UyeSifre { get; set; }

        public bool UyeDurumu { get; set; }
        public virtual Unvan Unvan { get; set; }
        public int UyeUnvanId { get; set; }
        

        public string UyeCinsiyet { get; set; }
        //public virtual Dosya Dosya { get; set; }
        //public int DosyaId { get; set; }
        
        public DateTime UyeIseBaslamaTarihi { get; set; }


        public string github { get; set; }
        public string linkedln { get; set; }
        public string Fotograf { get; set; }

        
        
        public virtual ICollection<Rapor> Rapors { get; set; }
        public virtual ICollection<Is> Ises { get; set; }
        public virtual ICollection<Mail> Mails { get; set; }
        

    }
}
