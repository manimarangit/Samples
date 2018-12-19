using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer
{
    [Serializable()]
    public class Branch
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string STName { get; set; }
        public string Address1{ get; set; }
        public string Address2 { get; set; }

        public string Address3 { get; set; }
        public string Address4 { get; set; }

        public string PhoneNo { get; set; }

        public string Email { get; set; }
        public string Prefix1 { get; set; }
        public string Prefix2 { get; set; }
        public string GSTIN { get; set; }

    }
}
