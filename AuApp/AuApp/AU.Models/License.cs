using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AU.Models
{
    public class License
    {
        public int idLicense { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public DateTime ActivationDate { get; set; }
        public  string ActivationKey { get; set; }
        public string LicenseFile { get; set; }
        public string LicenseHash { get; set; }
        public Organization Organization { get; set; }
        public bool isActivated { get; set; }
        public bool isTampred { get; set; }
        public User CreatedBy { get; set; }
        public User  ModifiedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
