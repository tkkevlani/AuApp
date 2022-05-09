using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AU.Models
{
    public class EMI
    {
        public int idEMI { get; set; }
        public Deal Deal { get; set; }
        public int Duration { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TotalEmi { get; set; }
        public int PaidEmi { get; set; }
        public int TotalDealAmount { get; set; }
        public int PrePayment { get; set; }
        public int OTC { get; set; }
        public int MRC { get; set; }
        public int PaidAmount { get; set; }
        public int OutStandingAmount { get; set; }
        public DateTime NextEMIDueDate { get; set; }
        public DateTime NextEMIAmount { get; set; }
        public User CreatedBy { get; set; }
        public User ModifiedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
