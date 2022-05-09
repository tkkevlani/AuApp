using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AU.Models
{
    public class Customer
    {
        public int idCustomer { get; set; }
        public Organization Organization { get; set; }
        public Person Person { get; set; }
        public User CreatedBy { get; set; }
        public User ModifiedBy { get; set; }
        public Witness Witness1 { get; set; }
        public Witness Witness2 { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
