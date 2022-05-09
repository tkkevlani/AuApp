using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AU.Models
{
    public class User
    {
        public int idUser { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int idorganization { get; set; }
        public bool isLocked { get; set; }
        public int FailureAttemptCount { get; set; }
        public int idrole { get; set; }
        public string Role { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public bool isFirstTime { get; set; }
        public bool _isLogged { get; set; }
        public string LoginMessage { get; set; }
        public bool _byPassSwitch { get; set; }
    }
}
