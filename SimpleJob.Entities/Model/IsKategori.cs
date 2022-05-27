using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleJob.Entities.Model
{
    public class IsKategori
    {
        public int IsKategoriId { get; set; }
        public string IsKategoriAdi { get; set; }
        public bool IsKategoriDurumu { get; set; }


        public virtual ICollection<Is> Ises { get; set; }
     
    }
}
