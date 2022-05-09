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
    public class Customer_BL : ICustomer_BL
    {
        protected ICustomer_DL _customerDL;
        public Customer_BL()
        {
            _customerDL = new Customer_DL();
        }

        public int CreateCustomerBL(Customer customer)
        {
            customer.Person.cNIC = Encryption.Encrypt(customer.Person.cNIC);
            customer.Witness1.person.cNIC = Encryption.Encrypt(customer.Witness1.person.cNIC);
            customer.Witness2.person.cNIC = Encryption.Encrypt(customer.Witness2.person.cNIC);
            return _customerDL.CreateCustomer(customer);
        }
    }
}
