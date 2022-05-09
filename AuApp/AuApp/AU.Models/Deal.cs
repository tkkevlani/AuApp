using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AU.Models
{
    public class Deal
    {
        public int idDeal { get; set; }
        public Vehicle Vehicle { get; set; }
        public Customer customer { get; set; }
        public float price { get; set; }
        public bool isDiscounted { get; set; }
        public bool isEMI { get; set; }
        public int Status { get; set; }
        public User CreatedBy { get; set; }
        public User ModifiedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
