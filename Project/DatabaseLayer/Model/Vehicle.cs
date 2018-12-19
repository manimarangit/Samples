using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer
{
    [Serializable()]
   public class Vehicle
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string STName { get; set; }

        public string Number { get; set; }
    }
}
