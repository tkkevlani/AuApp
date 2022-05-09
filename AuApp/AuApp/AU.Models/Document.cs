using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AU.Models
{
    public class Document
    {
        public int idDocument { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }
        public string URL { get; set; }
        public User CreatedBy { get; set; }
        public User ModifiedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public Registration registration { get; set; }
    }
}
