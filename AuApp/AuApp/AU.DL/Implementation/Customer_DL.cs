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
    public class Customer_DL : ICustomer_DL
    {
        protected DBHelper _dbhelper;
        public Customer_DL()
        {
            _dbhelper = new DBHelper();
        }
        DataTable dtList = null;

        public int CreateCustomer(Customer _customer)
        {
            Dictionary<string, object> procParams = new Dictionary<string, object>();
            procParams.Add("@CFirstName",_customer.Person.FirstName );
            procParams.Add("@CLastName", _customer.Person.LastName);
            procParams.Add("@CDOB", _customer.Person.DoB);
            procParams.Add("@CcNIC", _customer.Person.cNIC);
            procParams.Add("@CPhone", _customer.Person.phone);
            procParams.Add("@Cmobile", _customer.Person.Mobile);
            procParams.Add("@CAddress1", _customer.Person.address.Address1);
            procParams.Add("@CAddress2", _customer.Person.address.Address2);
            procParams.Add("@CCity", _customer.Person.address.City);
            procParams.Add("@CProvince", _customer.Person.address.Province);
            procParams.Add("@CCountry", _customer.Person.address.Country);
            procParams.Add("@CPostalCode", _customer.Person.address.PostalCode);
            procParams.Add("@orgid", _customer.Organization.idOrganization);

            procParams.Add("@W1FirstName", _customer.Witness1.person.FirstName);
            procParams.Add("@W1LastName", _customer.Witness1.person.LastName);
            procParams.Add("@W1DOB", _customer.Witness1.person.DoB);
            procParams.Add("@W1cNIC", _customer.Witness1.person.cNIC);
            procParams.Add("@W1Phone", _customer.Witness1.person.phone);
            procParams.Add("@W1mobile", _customer.Witness1.person.Mobile);
            procParams.Add("@W1Address1", _customer.Witness1.person.address.Address1);
            procParams.Add("@W1Address2", _customer.Witness1.person.address.Address2);
            procParams.Add("@W1City", _customer.Witness1.person.address.City);
            procParams.Add("@W1Province", _customer.Witness1.person.address.Province);
            procParams.Add("@W1Country", _customer.Witness1.person.address.Country);
            procParams.Add("@W1PostalCode", _customer.Witness1.person.address.PostalCode);

            procParams.Add("@W2FirstName", _customer.Witness2.person.FirstName);
            procParams.Add("@W2LastName", _customer.Witness2.person.LastName);
            procParams.Add("@W2DOB", _customer.Witness2.person.DoB);
            procParams.Add("@W2cNIC", _customer.Witness2.person.cNIC);
            procParams.Add("@W2Phone", _customer.Witness2.person.phone);
            procParams.Add("@W2mobile", _customer.Witness2.person.Mobile);
            procParams.Add("@W2Address1", _customer.Witness2.person.address.Address1);
            procParams.Add("@W2Address2", _customer.Witness2.person.address.Address2);
            procParams.Add("@W2City", _customer.Witness2.person.address.City);
            procParams.Add("@W2Province", _customer.Witness2.person.address.Province);
            procParams.Add("@W2Country", _customer.Witness2.person.address.Country);
            procParams.Add("@W2PostalCode", _customer.Witness2.person.address.PostalCode);

            procParams.Add("@CreatedOn", _customer.CreatedOn);
            procParams.Add("@CreatedBy", _customer.CreatedBy.idUser);

            var result = _dbhelper.InsertTableData("SP_CreateCustomer", procParams);
            return result;
        }
    }
}
