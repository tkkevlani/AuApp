using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AU.Models
{
    public class AuditLog
    {
        public int idAuditLog { get; set; }
        public AuditActions auditActions { get; set; }
        public string Entity { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public User CreatedBy { get; set; }
        public User ModifiedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
