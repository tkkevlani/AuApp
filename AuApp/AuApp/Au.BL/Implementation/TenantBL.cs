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
    public class TenantBL: ITenantBL
    {
        protected ITenant_DL _tenant;
        public TenantBL()
        {
            _tenant = new Tenant_DL();
        }
        /// <summary>
        /// 
        /// </summary>
        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_org"></param>
        /// <returns></returns>
        public bool CreateOrganization(Organization _org)
        {
            var OrgData = _org;
            var encryptedCNic = Encryption.Encrypt(_org.person.cNIC);
            OrgData.person.cNIC = encryptedCNic;
            var result = _tenant.CreateTenantDL(OrgData);

            if (result >= 1)
                return true;
            else
                return false;
        }
    }
}
