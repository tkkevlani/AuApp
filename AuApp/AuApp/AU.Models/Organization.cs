using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AU.Models
{
    public class Organization
    {
        public int idOrganization { get; set; }
        public string OrganizationName { get; set; }
        public Person person { get; set; }
        public string phone { get; set; }
        public string Mobile { get; set; }
        public Address address { get; set; }
        public User CreatedBy { get; set; }
        public User ModifiedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
