using AU.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AU.DL.Abstract
{
    public interface IUser_DL
    {
        List<Role> LoadRoles();
       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        int createUser(User user);
        List<User> LoadUsers(string username);
        List<User> LoadUsers();      
        int ResetUser(User _usr);
        //int LockUser(User _usr);

    }
}
