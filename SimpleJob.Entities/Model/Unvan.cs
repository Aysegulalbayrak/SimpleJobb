using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleJob.Entities.Model
{
    public class Unvan
    {
        public int UnvanId { get; set; }
        public string UnvanAdi { get; set; }
        public string UnvanAciklama { get; set; }
        public bool UnvanDurumu { get; set; }


       
        public virtual ICollection<Uye> Uyes { get; set; }
       
    }
}
