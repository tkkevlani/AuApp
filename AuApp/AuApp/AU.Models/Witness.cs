using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AU.Models
{
    public class Witness
    {
        public int idWitness { get; set; }
        public Person person { get; set; }
        public Customer customer { get; set; }
        public User CreatedBy { get; set; }
        public User ModifiedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
