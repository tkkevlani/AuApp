using Au.BL.Abstract;
using AU.Common;
using AU.DL.Abstract;
using AU.DL.Implementation;
using AU.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Au.BL.Implementation
{
    public class User_BL : IUser_BL
    {
        IUser_DL _userDL = null;
        public User_BL()
        {
            _userDL = new User_DL();
        }
        public List<Role> getRoles()
        {
           
            try
            {
                var result = _userDL.LoadRoles();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int createUser(User user)
        {
            try
            {
                var _user = new User();
                _user = user;
                _user.Password = Encryption.GenerateHash(user.Password);
                return _userDL.createUser(user);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int ResetUser(User user)
        {
            try
            {
                var _user = new User();
                _user = user;
                _user.Password = Encryption.GenerateHash(user.Password);
                return _userDL.ResetUser(user);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<User> LoadUser(string username)
        {
            try {
                return _userDL.LoadUsers(username);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<User> LoadUser()
        {
            try
            {
                return _userDL.LoadUsers();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
