using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleJob.Entities.Model
{
    public class Takvim
    {
        public int TakvimId { get; set; }
        
        public string title { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        public string color{ get; set; }
        public string textColor { get; set; }
        public bool takvimDurumu { get; set; }









    }
}
