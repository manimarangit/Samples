using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer
{
    [Serializable]
    public class Party
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Place { get; set; }

        public string PhoneNo { get; set; }

        public string GSTIN { get; set; }
    }
}
