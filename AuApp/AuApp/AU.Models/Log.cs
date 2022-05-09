using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AU.Models
{
    /// <summary>
    /// Model class for application Logs.
    /// </summary>
    public class Log
    {
        public int idLog { get; set; }
        public DateTime date { get; set; }
        public Organization Organization { get; set; }
        public string Level { get; set; }
        public string Message { get; set; }
        public string Exception { get; set; }
    }
}
