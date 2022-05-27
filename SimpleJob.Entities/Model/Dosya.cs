using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleJob.Entities.Model
{
    public class Dosya
    {

        public int DosyaId { get; set; }
        public string DosyaAdresi { get; set; }

        public bool DosyaDurumu { get; set; }
        //public virtual ICollection<Uye> Uyes { get; set; }
        //public virtual ICollection<Is> Ises { get; set; }

    }
}
