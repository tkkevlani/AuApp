using AU.DL.Abstract;
using AU.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AU.DL.Implementation
{
    public class Tenant_DL: ITenant_DL
    {
        protected DBHelper _dbhelper;
        public Tenant_DL()
        {
            _dbhelper = new DBHelper();
        }

        public int CreateTenantDL(Organization _org)
        {
            try
            {
                Dictionary<string, object> procParams = new Dictionary<string, object>();
                procParams.Add("OName", _org.OrganizationName);
                procParams.Add("OPhone",_org.phone);
                procParams.Add("Omobile",_org.Mobile);
                procParams.Add("OAddress1",_org.address.Address1);
                procParams.Add("OAddress2", _org.address.Address2);
                procParams.Add("OCity", _org.address.City);
                procParams.Add("OProvince", _org.address.Province);
                procParams.Add("OCountry", _org.address.Country);
                procParams.Add("OPostalCode", _org.address.PostalCode);
                procParams.Add("CreatedOn",_org.CreatedOn);
                procParams.Add("CreatedBy", _org.CreatedBy.idUser);
                procParams.Add("CFirstName",_org.person.FirstName);
                procParams.Add("CLastName", _org.person.LastName);
                procParams.Add("CDOB", _org.person.DoB);
                procParams.Add("CcNIC", _org.person.cNIC);
                procParams.Add("CPhone", _org.person.phone);
                procParams.Add("Cmobile", _org.person.Mobile);
                procParams.Add("CAddress1", _org.person.address.Address1);
                procParams.Add("CAddress2", _org.person.address.Address2);
                procParams.Add("CCity", _org.person.address.City);
                procParams.Add("CProvince", _org.person.address.Province);
                procParams.Add("CCountry", _org.person.address.Country);
                procParams.Add("CPostalCode", _org.person.address.PostalCode);
                var result = _dbhelper.InsertTableData("Sp_CreateOrganization", procParams);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
