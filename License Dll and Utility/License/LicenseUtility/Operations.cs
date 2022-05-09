using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using License.Controller;
using License.Model;

namespace LicenseUtility
{
    public class Operations
    {
        public static LicenseHelper licensedll;
        public static string publicKey;
        public static string privateKey;

        internal static bool CheckConnection()
        {
            if (licensedll != null)
                return true; //licensedll.CheckConnection();
            else
                return false;
        }

        internal static bool Connect(string server, string database, string userid, string password)
        {
            bool result = false;

            if (string.IsNullOrWhiteSpace(server) || string.IsNullOrWhiteSpace(database)
                || string.IsNullOrWhiteSpace(userid) || string.IsNullOrWhiteSpace(password))
            {
                result = false;
                licensedll = null;
            }
            else
            {
                if (licensedll == null)
                {
                    licensedll = new LicenseHelper(server, database, userid, password);
                    result = true;
                }
                else
                    result = true;
            }

            return result;
        }

        internal static void Disconnect()
        {
            licensedll = null;
        }

        internal static void loadEncryptionKeys(int orgId)
        {
            if (string.IsNullOrWhiteSpace(publicKey) && string.IsNullOrWhiteSpace(privateKey) && licensedll != null)
            {
                var sd = licensedll.GetEncryptionKeys(orgId);
                if (sd != null)
                {
                    sd.TryGetValue("PublicKey", out publicKey);
                    sd.TryGetValue("PrivateKey", out privateKey);
                }
            }
        }

        internal static List<LicenseInfo> GetLicenses(int? orgId, int? licenseId)
        {
            List<LicenseInfo> licenses = null;
            if (licensedll != null)
            {
                //if(privateKey==null)
                //{
                //    loadEncryptionKeys(license.OrganizationId);
                //}
                licenses = licensedll.GetFullLicense(orgId, licenseId);
            }

            return licenses;
        }

        internal static void AddLicense(int orgId, DateTime fromDate, DateTime toDate)
        {
            if (licensedll != null)
            {
                LicenseInfo license = new LicenseInfo()
                {
                    OrganizationId = orgId,
                    ValidFrom = fromDate,
                    ValidTo = toDate
                };

                loadEncryptionKeys(license.OrganizationId);
                licensedll.CreateLicense(license, publicKey);
            }
        }

        internal static void UpdateLicense(LicenseInfo license)
        {
            if (licensedll != null)
            {
                loadEncryptionKeys(license.OrganizationId);
                licensedll.UpdateLicense(license, publicKey);
            }
        }

        internal static string ValidateLicense(int organizationId, int licenseId)
        {
            string validateMessage = "";
            if (licensedll != null)
            {
                loadEncryptionKeys(organizationId);
                var result = licensedll.ValidateLicense(null, licenseId, privateKey);
                if (result != null)
                {
                    validateMessage = result.Message;
                }
            }

            return validateMessage;
        }

        internal static Dictionary<int, string> GetOrganizations()
        {
            try
            {
                if (licensedll != null)
                    return licensedll.GetOrganizations();
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal static void SaveFile(string fullPath, LicenseInfo license)
        {
            try
            {
                if (licensedll != null)
                    licensedll.SaveLicense(fullPath, license);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal static void ActivateLicenseFromFile(string fullPath)
        {
            try
            {
                if (licensedll != null)
                    licensedll.ActivateWithFile(fullPath);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
