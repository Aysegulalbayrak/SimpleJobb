using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleJob.Entities.Model
{
    public class Is
    {
        public int IsId { get; set; }

        public virtual IsKategori IsKategori { get; set; }
        public int IsKategoriId { get; set; }

        public string IsBaslik { get; set; }
        public string IsAciklama { get; set; }
        public DateTime SonTeslimTarihi { get; set; }
        public int IlerlemeDurumu { get; set; }
     
        public string DosyaAdresi { get; set; }
        public bool IsDurumu { get; set; }

        public virtual Uye Uye { get; set; }
        public int UslenenUyeId { get; set; }
        
        

        

        


        public virtual ICollection<Rapor> Rapors { get; set; }

   


    }
}
