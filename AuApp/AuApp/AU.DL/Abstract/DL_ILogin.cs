using AU.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AU.DL.Abstract
{
    /// <summary>
    /// 
    /// </summary>
    public interface DL_ILogin
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        bool databaseConnectivityTest();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        int ResetUserPassword(User user);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_userName"></param>
        /// <param name="_organizationid"></param>
        /// <returns></returns>
        User AuthenticateUser(string _userName, int _organizationid);
    }
}
