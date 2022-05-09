using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using AU.Common;
using AU.Models;

namespace AuApp
{
    static class Program
    {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            int idOrganization = Convert.ToInt32(ConfigurationManager.AppSettings["OrgId"]);

            ConfigurationManager.RefreshSection("appsettings");
            ConfigurationManager.RefreshSection("connectionStrings");
            log4net.Config.XmlConfigurator.Configure();
            log4net.ThreadContext.Properties["OrgIdKey"] = idOrganization;
            LogWriter.Info("Application intiated");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new VehPaymentIntake(_customer()));
        }

        private static Customer _customer()
        {
            int idOrganization = Convert.ToInt32(ConfigurationManager.AppSettings["OrgId"]);
            var _cust = new Customer()
            {


                Organization = new Organization()
                {
                    idOrganization = idOrganization
                },
                Person = new Person()
                {
                    FirstName = "Abdullah",
                    LastName = "Shah Ghazi",
                    DoB = DateTime.Now.AddYears(-45),
                    cNIC = "11111-101-1043556",
                    phone = "02112345678",
                    Mobile = "0345-1234567",
                    address = new Address()
                    {
                        Address1 = "Flat# 3/341, Block A, Naz Plaza",
                        Address2 = "M.A Jinnah Rd, Saddar",
                        City = "Karachi",
                        Province = "Sindh",
                        Country = "Pakistan",
                        PostalCode = 12345
                    }
                },

                CreatedOn = DateTime.Now

            };
            return _cust;
        }

    }
}
