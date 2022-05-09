using AU.DL.Abstract;
using AU.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AU.DL.Implementation
{
    public class DL_Login : DL_ILogin

    {
        protected DBHelper _dbhelper;
        public DL_Login()
        {
            _dbhelper = new DBHelper();
        }
        DataTable dtList = null;
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool databaseConnectivityTest()
        {
            try
            {
                _dbhelper.TestConnection();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
                //_dbhelper.CloseConnection();

            }
            finally
            {
                _dbhelper.CloseConnection();
            }
        }
        public int ResetUserPassword(User user)
        {
            Dictionary<string, object> procParams = new Dictionary<string, object>();
            procParams.Add("@userid", user.idUser);
            procParams.Add("@password", user.Password);           
            procParams.Add("@ModifiedOn", user.ModifiedOn);
            procParams.Add("@ModifiedBy", user.ModifiedBy);
            procParams.Add("@isFirstTime", user.isFirstTime);
            var result = _dbhelper.UpdateTableDataReturnIdentity("SP_ChangePassword", procParams);
            return result;
        }

        public User AuthenticateUser(string _userName, int _organizationid)
        {
            Dictionary<string, object> procParams = new Dictionary<string, object>();
            User _loggedUser = new User();
            procParams.Add("@username", _userName);
            procParams.Add("@idOrganization", _organizationid);
            dtList = _dbhelper.GetTableData("Sp_AuthenticateUser", procParams);
            _loggedUser = MapUser(dtList, _userName);
            return _loggedUser;
        }
        #region "Private methods"
        private User MapUser(DataTable dt, string _username)
        {
            User _user = new User();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    var username = Convert.ToString(dr["UserName"]);
                    if (username.ToUpper() == _username.ToUpper())
                    {
                        _user.idUser = Convert.ToInt32(dr["idUser"]);
                        _user.UserName = Convert.ToString(dr["UserName"]);
                        _user.Password = Convert.ToString(dr["Password"]);
                        _user.idorganization = Convert.ToInt32(dr["idOrganization"]);
                        _user.isLocked = Convert.ToBoolean(dr["isLocked"]);
                        _user.FailureAttemptCount = Convert.ToInt32(dr["FailureAttemptCount"]);
                        _user.idrole = Convert.ToInt32(dr["idRole"]);
                        _user.CreatedOn = Convert.ToDateTime(dr["CreatedDate"]);
                        _user.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                        _user.ModifiedOn = dr["ModifiedOn"] != DBNull.Value ? Convert.ToDateTime(dr["ModifiedOn"]) : DateTime.Now;
                        _user.ModifiedBy = dr["ModifiedBy"] != DBNull.Value ? Convert.ToString(dr["ModifiedBy"]) : string.Empty;
                        _user.isFirstTime = Convert.ToBoolean(dr["isFirstTime"]);
                    }
                }
            }
            else _user = null;
            return _user;
        }
        #endregion
    }

}