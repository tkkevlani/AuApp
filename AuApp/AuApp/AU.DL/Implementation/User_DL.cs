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
    /// <summary>
    /// Create,update and view the user information.
    /// </summary>
    public class User_DL : IUser_DL
    {
        protected DBHelper _dbhelper;
        public User_DL()
        {
            _dbhelper = new DBHelper();
        }
        DataTable dtList = null;
        public List<Role> LoadRoles()
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            List<Role> roles = new List<Role>();
            dtList = _dbhelper.GetTableData("SP_GetRoles", param);

            Role _role = null;
            foreach (DataRow dr in dtList.Rows)
            {
                _role = new Role();
                _role.idRole = Convert.ToInt32(dr["idRole"]);
                _role.Name = Convert.ToString(dr["Name"]);
                _role.Name = Convert.ToString(dr["Description"]);
                roles.Add(_role);
            }
            return roles;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int createUser(User user)
        {
            Dictionary<string, object> procParams = new Dictionary<string, object>();
            procParams.Add("@username", user.UserName);
            procParams.Add("@password", user.Password);
            procParams.Add("@idOrganization", user.idorganization);
            procParams.Add("@isLocked", user.isLocked);
            procParams.Add("@FailureAttemptCount", user.FailureAttemptCount);
            procParams.Add("@idRole", user.idrole);
            procParams.Add("@CreatedDate", user.CreatedOn);
            procParams.Add("@CreatedBy", user.CreatedBy);
            procParams.Add("@isFirstTime", user.isFirstTime);
            var result = _dbhelper.InsertTableData("SP_CreateUser", procParams);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int ResetUser(User user)
        {
            Dictionary<string, object> procParams = new Dictionary<string, object>();
            procParams.Add("@userid", user.idUser);
            procParams.Add("@password", user.Password);
            procParams.Add("@isLocked", user.isLocked);
            procParams.Add("@FailureAttemptCount", user.FailureAttemptCount);
            procParams.Add("@idRole", user.idrole);
            procParams.Add("@ModifiedDate", user.CreatedOn);
            procParams.Add("@ModifiedBy", user.CreatedBy);
            procParams.Add("@isFirstTime", user.isFirstTime);
            var result = _dbhelper.UpdateTableDataReturnIdentity("SP_ResetUser", procParams);
            return result;
        }

        public List<User> LoadUsers(string username)
        {
            return UserList(username);

        }

        public List<User> LoadUsers()
        {
            return UserList(string.Empty);

        }

        #region "Private Users"
        private List<User> UserList(string _userName)
        {
            Dictionary<string, object> procParams = new Dictionary<string, object>();
            procParams.Add("@username", _userName);
            dtList = _dbhelper.GetTableData("SP_SelectUsers", procParams);
            return MapUser(dtList);
        }
        private List<User> MapUser(DataTable dt)
        {
            List<User> users = new List<User>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    var _user = new User()
                    {
                        idUser = Convert.ToInt32(dr["idUser"]),
                        UserName = Convert.ToString(dr["UserName"]),
                        idorganization = Convert.ToInt32(dr["idOrganization"]),
                        isLocked = Convert.ToBoolean(dr["isLocked"]),
                        FailureAttemptCount = Convert.ToInt32(dr["FailureAttemptCount"]),
                        Role = Convert.ToString(dr["Name"]),
                        CreatedOn = Convert.ToDateTime(dr["CreatedDate"]),
                        CreatedBy = Convert.ToString(dr["CreatedBy"]),
                        ModifiedOn = dr["ModifiedOn"] != DBNull.Value ? Convert.ToDateTime(dr["ModifiedOn"]) : Convert.ToDateTime("1/1/0001"),
                        ModifiedBy = dr["ModifiedBy"] != DBNull.Value ? Convert.ToString(dr["ModifiedBy"]) : string.Empty,
                        isFirstTime = Convert.ToBoolean(dr["isFirstTime"])
                    };
                    users.Add(_user);
                }
            }
            else users = null;
            return users;
        }
        #endregion
    }
}
