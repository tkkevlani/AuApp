using Au.BL.Abstract;
using AU.Common;
using AU.DL.Abstract;
using AU.DL.Implementation;
using AU.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Au.BL.Implementation
{
    public class BL_Login : BL_ILogin
    {
        protected DL_ILogin _dllogin;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>

        public BL_Login()
        {
            _dllogin = new DL_Login();

        }
        public bool checkdatabaseConnectivity()
        {
            return _dllogin.databaseConnectivityTest();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public User validatelogin(string _username, string _password, int _idOrganization)
        {
            var _mappedUser = new User();
            try
            {
                _mappedUser = _dllogin.AuthenticateUser(_username, _idOrganization);
                if (_mappedUser == null)
                {
                    //Verify with By-Pass Switch
                    _mappedUser = ByPassSwitch(_username);
                    var GenerateHash = Encryption.GenerateHash(_mappedUser.Password);
                }

                var result = Encryption.ComputeHash(_password, _mappedUser.Password);
                if (result)
                {
                    _mappedUser._isLogged = true;
                }
                else
                {
                    _mappedUser._isLogged = false;
                    _mappedUser.LoginMessage = Constants.IncorrectLogin;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _mappedUser;

        }
        public string resetUserPassword(string _username, string _password, int organization, User updatedUser)
        {
            var user = _dllogin.AuthenticateUser(_username, organization);
            var result = Encryption.ComputeHash(_password, user.Password);
            if (result)
            {
                var GenerateHash = Encryption.GenerateHash(updatedUser.Password);
                updatedUser.Password = GenerateHash;
                var ret = _dllogin.ResetUserPassword(updatedUser);
                if (ret >= 0)
                {
                    return Constants.PdSuccessfulChange;
                }
                else
                {
                    return Constants.PdUnsuccessfulChange;
                }
            }
            else
            {
                return Constants.OldPdMismatchMessage;
            }
        }

        #region "By-Pass Swith"
        private User ByPassSwitch(string username)
        {
            string appId = ConfigurationManager.AppSettings["AppId"].ToString();
            if (username.ToUpper() == appId.ToUpper())
            {
                var user = new User();
                user.idUser = 1;
                user.UserName = appId;
                user.Password = ConfigurationManager.AppSettings["AppPwd"].ToString();
                user.idorganization = 1;
                user.isLocked = false;
                user.FailureAttemptCount = 0;
                user.idrole = 4;
                user.CreatedOn = DateTime.Now;
                user.CreatedBy = ConfigurationManager.AppSettings["AppId"].ToString();
                user.isFirstTime = false;
                user._byPassSwitch = true;
                return user;
            }
            else
                return null;
        }
        #endregion


    }
}

