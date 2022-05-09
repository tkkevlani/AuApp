using AU.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Au.BL.Abstract
{
    public interface IUser_BL
    {
        List<Role> getRoles();
        int createUser(User user);
        int ResetUser(User user);
        List<User> LoadUser(string username);
        List<User> LoadUser();
    }
}
