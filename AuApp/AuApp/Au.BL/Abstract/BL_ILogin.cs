using AU.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Au.BL.Abstract
{
    public interface BL_ILogin
    {
        bool checkdatabaseConnectivity();
        User validatelogin(string _username, string _password, int _idOrganization);
        string resetUserPassword(string _username, string _password, int organization, User updatedUser);
       
    }

}
