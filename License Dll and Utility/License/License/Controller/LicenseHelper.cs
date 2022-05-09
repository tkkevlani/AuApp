using License.Controller.Encryption;
using License.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace License.Controller
{
    public class LicenseHelper
    {
        private DBConnect db;
        public LicenseHelper(string server, string database, string userid, string password)
        {
            db = new DBConnect(server, database, userid, password);
        }

        public void CreateLicense(LicenseInfo license, string publicKey)
        {
            try
            {
                license.LicenseFile = Cipher.Encrypt(license, publicKey);
                license.LicenseHash = Hashing.GenerateSHA256String(license.LicenseFile);
                license.ActivationKey = (Cipher.GenerateLicenseKey()).ToUpper();
                license.IsActivated = false;
                license.IsTampered = false;
                license.IsExpired = false;
                license.CreatedDate = DateTime.Now;

                db.CreateLicnse(license);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateLicense(LicenseInfo license, string publicKey)
        {
            try
            {
                license.LicenseFile = Cipher.Encrypt(license, publicKey);
                license.LicenseHash = Hashing.GenerateSHA256String(license.LicenseFile);
                db.UpdateLicense(license);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ExpireLicense(int licenseId)
        {
            try
            {
                db.ExpireLicense(licenseId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void TamperLicense(int licenseId)
        {
            try
            {
                db.TamperLicense(licenseId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<LicenseInfo> GetFullLicense(int? organizationId, int? licenseId)
        {
            try
            {
                var licenses = db.SearchLicense(organizationId, licenseId);

                if (licenses != null)
                {
                    /*
                     * Call Encryption
                     */
                }

                return licenses;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ClientLicenseInfo ValidateLicense(int? organizationId, int? licenseId, string privateKey)
        {
            ClientLicenseInfo clientLicense = new ClientLicenseInfo();
            try
            {
                var license = db.GetClientLicense(organizationId, licenseId);

                if (license != null)
                {
                    clientLicense.ActivationDate = license.ActivationDate;
                    clientLicense.idLicense = license.idLicense;
                    clientLicense.IsActivated = license.IsActivated;
                    clientLicense.IsExpired = license.IsExpired;
                    clientLicense.IsTampered = license.IsTampered;
                    clientLicense.OrganizationId = license.OrganizationId;
                    clientLicense.ValidFrom = license.ValidFrom;
                    clientLicense.ValidTo = license.ValidTo;

                    clientLicense.IsValidLicense = true;


                    if (clientLicense.IsActivated == false)
                    {
                        clientLicense.IsValidLicense = false;
                        clientLicense.Message = "License is not activated";
                    }

                    if (clientLicense.IsExpired)
                    {
                        clientLicense.IsValidLicense = false;
                        clientLicense.Message = "License is expired";
                    }

                    if (clientLicense.IsTampered)
                    {
                        clientLicense.IsValidLicense = false;
                        clientLicense.Message = "License is tampered";
                    }

                    if (clientLicense.IsValidLicense)
                    {
                        if (Hashing.GenerateSHA256String(license.LicenseFile) == license.LicenseHash)
                        {
                            license = Cipher.Decrypt(license.LicenseFile, license, privateKey);
                            if (license.IsTampered == false)
                            {
                                if (license.ValidTo.Date > DateTime.Now.Date)
                                {
                                    clientLicense.IsValidLicense = true;
                                    clientLicense.Message = "License is valid";
                                }
                                else
                                {
                                    license.IsExpired = true;
                                    clientLicense.IsExpired = true;
                                    clientLicense.IsValidLicense = false;
                                    clientLicense.Message = "License is expired";

                                    db.ExpireLicense(license.idLicense);
                                }

                            }
                            else
                            {
                                license.IsTampered = true;
                                clientLicense.IsTampered = true;
                                clientLicense.IsValidLicense = false;
                                clientLicense.Message = "License is tampered";

                                db.TamperLicense(license.idLicense);
                            }

                        }
                        else
                        {
                            license.IsTampered = true;
                            clientLicense.IsTampered = true;
                            clientLicense.IsValidLicense = false;
                            clientLicense.Message = "License is tampered";

                            db.TamperLicense(license.idLicense);
                        }
                    }

                }
                else
                {
                    clientLicense.IsValidLicense = false;
                    clientLicense.Message = "Invalid License";
                }
            }
            catch (Exception ex)
            {
                //throw ex;
                clientLicense.IsValidLicense = false;
                clientLicense.Message = ex.Message;
            }

            return clientLicense;
        }

        public Dictionary<int, string> GetOrganizations()
        {
            try
            {
                var organization = db.GetOrganizations();

                return organization;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Dictionary<string, string> GetEncryptionKeys(int orgId)
        {
            return db.GetEncryptionKeys(orgId);
        }

        public bool SaveLicense(string fullPath, LicenseInfo license)
        {
            try
            {
                string licenseText = Serialization.Serialize<LicenseInfo>(license);

                System.IO.File.WriteAllText(fullPath, licenseText);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public LicenseInfo ReadLicenseFile(string fullPath)
        {
            try
            {
                string text = System.IO.File.ReadAllText(fullPath);

                var license = Serialization.Deserialize<LicenseInfo>(text);

                return license;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ActivateWithFile(string fullPath)
        {
            try
            {
                var license = ReadLicenseFile(fullPath);

                if (license != null)
                {
                    db.CreateLicnse(license);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
