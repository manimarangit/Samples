using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DatabaseLayer
{
    [Serializable]
    public class Users
    {

        public int ID { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public bool IsDefaultPassword { get; set; }

        public string Role { get; set; }

        public string Permission { get; set; }
   
        public int? BranchID { get; set; }

        public string prefix { get; set; }
        public string prefix1 { get; set; }
       
    }
}
