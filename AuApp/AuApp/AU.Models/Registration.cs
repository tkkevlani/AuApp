using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AU.Models
{
    
    public class Registration
    {
        public int idRegistrationDetails { get; set; }
        public string RegistrationNumb { get; set; }
        public int Vehicle { get; set; }
        public Deal Deal { get; set; }
        public User CreatedBy { get; set; }
        public User ModifiedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
