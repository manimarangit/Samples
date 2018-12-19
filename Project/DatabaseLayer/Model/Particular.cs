using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer
{
    [Serializable()]
   public class Particular
    {
        public int ID { get; set; }
        public string LRNO { get; set; }
        public int SNO { get; set; }
        public string Particulars { get; set; }

        public int Quantity { get; set; }

        public decimal NetRate { get; set; }
        public decimal Amount { get; set; }
    }
}
