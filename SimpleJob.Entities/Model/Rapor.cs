using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleJob.Entities.Model
{
    public class Rapor
    {
        public int RaporId { get; set; }

        public virtual Is Is { get; set; }
        public int IsId { get; set; }

        public virtual Uye Uye { get; set; }
        public int UyeId { get; set; }
        
        
        
    }
}
