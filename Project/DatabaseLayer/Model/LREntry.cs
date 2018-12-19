using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer
{
    [Serializable()]
    public class LREntry
    {
        public int ID { get; set; }
        public int BrachID { get; set; }
        public string LRNO { get; set; }

       
        public bool GST { get; set; }

        public bool Direct { get; set; }
        public DateTime LRDateTime { get; set; }
        public string FromParty { get; set; }
        public string F_Place { get; set; }
        public string F_GSTIN { get; set; }
        public string F_MobileNo { get; set; }

        public string ToParty { get; set; }
        public string T_Place { get; set; }
        public string T_GSTIN { get; set; }
        public string T_MobileNo { get; set; }

        public int BaleNo { get; set; }
        public string NatureOfGoods { get; set; }

        public string Others { get; set; }
        public List<Particular> Particulars { get; set; }
        public int No_Of_Articles { get; set; }

        public decimal Frieght { get; set; }

        public decimal LoadingCharge { get; set; }
        public decimal UnloadingCharge { get; set; }
        public decimal DDCharge { get; set; }
        public decimal TotalAmount { get; set; }

        public decimal CGST { get; set; }
        public decimal SGST { get; set; }
        public string RoundOf { get; set; }
        public int NetAmount { get; set; }

        public string Weight { get; set; }
        public string Pay { get; set; }
        public string DeliveryType { get; set; }


    }
}
