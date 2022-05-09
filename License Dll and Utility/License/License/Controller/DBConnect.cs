using License.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace License.Controller
{
    public class DBConnect
    {
        private MySqlConnection connection = null;
        private string server;
        private string database;
        private string uid;
        private string password;
        private bool isAdminAccess;

        //Constructor
        public DBConnect(MySqlConnection conn)
        {
            Initialize(conn);
        }

        public DBConnect(string server, string database, string userid, string password)
        {
            this.server = server;
            this.database = database;
            this.uid = userid;
            this.password = password;

            Initialize(null);
        }

        //Initialize values
        private void Initialize(MySqlConnection conn)
        {
            if (conn == null)
            {
                //server = "localhost";
                //database = "connectcsharptomysql";
                //uid = "username";
                //password = "password";
                string connectionString;
                connectionString = "SERVER=" + server + ";" + "DATABASE=" +
                database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

                connection = new MySqlConnection(connectionString);

                isAdminAccess = true;
            }
            else
            {
                connection = conn;
                isAdminAccess = false;
            }
        }

        //open connection to database
        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        throw new Exception("Cannot connect to server.  Contact administrator", ex);
                        //MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        throw new Exception("Invalid username/password, please try again", ex);
                        //MessageBox.Show("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        //Close connection
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                //MessageBox.Show(ex.Message);
                return false;
            }
        }

        // Check Connection
        public bool CheckConnection()
        {
            if (connection != null)
                return true;
            else
                return false;
        }

        //Insert statement
        public void CreateLicnse(LicenseInfo licenseInfo)
        {
            try
            {

                MySqlCommand cmd = new MySqlCommand("CreateLicense", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("ValidFrom", licenseInfo.ValidFrom));
                cmd.Parameters.Add(new MySqlParameter("ValidTo", licenseInfo.ValidTo));
                cmd.Parameters.Add(new MySqlParameter("ActivationDate", licenseInfo.ActivationDate));
                cmd.Parameters.Add(new MySqlParameter("ActivationKey", licenseInfo.ActivationKey));
                cmd.Parameters.Add(new MySqlParameter("LicenseFile", licenseInfo.LicenseFile));
                cmd.Parameters.Add(new MySqlParameter("LicenseHash", licenseInfo.LicenseHash));
                cmd.Parameters.Add(new MySqlParameter("OrganizationId", licenseInfo.OrganizationId));
                cmd.Parameters.Add(new MySqlParameter("CreatedBy", licenseInfo.CreatedById));

                //cmd.Connection.Open();

                //open connection
                if (this.OpenConnection() == true)
                {
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //close connection
                this.CloseConnection();
            }
        }

        //Update statement
        public void UpdateLicense(LicenseInfo licenseInfo)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("UpdateLicense", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("ValidFrom", licenseInfo.ValidFrom));
                cmd.Parameters.Add(new MySqlParameter("ValidTo", licenseInfo.ValidTo));
                cmd.Parameters.Add(new MySqlParameter("LicenseFile", licenseInfo.LicenseFile));
                cmd.Parameters.Add(new MySqlParameter("LicenseHash", licenseInfo.LicenseHash));
                cmd.Parameters.Add(new MySqlParameter("LicenseId", licenseInfo.idLicense));
                cmd.Parameters.Add(new MySqlParameter("ModifiedBy", licenseInfo.ModifiedById));
                cmd.Parameters.Add(new MySqlParameter("IsActivated", licenseInfo.IsActivated));
                cmd.Parameters.Add(new MySqlParameter("IsExpired", licenseInfo.IsExpired));
                cmd.Parameters.Add(new MySqlParameter("IsTampered", licenseInfo.IsTampered));

                //open connection
                if (this.OpenConnection() == true)
                {
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //close connection
                this.CloseConnection();
            }
        }

        public List<LicenseInfo> SearchLicense(int? organizationId, int? licenseId)
        {
            List<LicenseInfo> licenses = new List<LicenseInfo>();
            try
            {
                if (organizationId == null || organizationId <= 0)
                    organizationId = -1;
                MySqlCommand cmd = new MySqlCommand("GetFullLicense", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("OrganizationId", organizationId));
                cmd.Parameters.Add(new MySqlParameter("LicenseId", licenseId));

                //open connection
                if (this.OpenConnection() == true)
                {
                    MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                    while (dr.Read())
                    {
                        LicenseInfo li = new LicenseInfo();

                        if (dr["ActivationDate"] != DBNull.Value)
                            li.ActivationDate = Convert.ToDateTime(dr["ActivationDate"]);
                        if (dr["ActivationKey"] != DBNull.Value)
                            li.ActivationKey = Convert.ToString(dr["ActivationKey"]);
                        if (dr["CreatedBy"] != DBNull.Value)
                            li.CreatedById = Convert.ToInt32(dr["CreatedBy"]);
                        if (dr["CreatedDate"] != DBNull.Value)
                            li.CreatedDate = Convert.ToDateTime(dr["CreatedDate"]);
                        if (dr["idLicense"] != DBNull.Value)
                            li.idLicense = Convert.ToInt32(dr["idLicense"]);
                        if (dr["IsActivated"] != DBNull.Value)
                            li.IsActivated = Convert.ToBoolean(dr["IsActivated"]);
                        if (dr["IsExpired"] != DBNull.Value)
                            li.IsExpired = Convert.ToBoolean(dr["IsExpired"]);
                        if (dr["IsTampered"] != DBNull.Value)
                            li.IsTampered = Convert.ToBoolean(dr["IsTampered"]);
                        if (dr["LicenseFile"] != DBNull.Value)
                            li.LicenseFile = Convert.ToString(dr["LicenseFile"]);
                        if (dr["LicenseHash"] != DBNull.Value)
                            li.LicenseHash = Convert.ToString(dr["LicenseHash"]);
                        if (dr["ModifiedBy"] != DBNull.Value)
                            li.ModifiedById = Convert.ToInt32(dr["ModifiedBy"]);
                        if (dr["ModifiedDate"] != DBNull.Value)
                            li.ModifiedDate = Convert.ToDateTime(dr["ModifiedDate"]);
                        if (dr["Organization_idOrganization"] != DBNull.Value)
                            li.OrganizationId = Convert.ToInt32(dr["Organization_idOrganization"]);
                        if (dr["OrganizationName"] != DBNull.Value)
                            li.OrganizationName = Convert.ToString(dr["OrganizationName"]);
                        if (dr["ValidFrom"] != DBNull.Value)
                            li.ValidFrom = Convert.ToDateTime(dr["ValidFrom"]);
                        if (dr["ValidTo"] != DBNull.Value)
                            li.ValidTo = Convert.ToDateTime(dr["ValidTo"]);

                        licenses.Add(li);
                    }

                    dr.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Method : SearchLicense", ex);
            }
            finally
            {
                //close connection
                this.CloseConnection();
            }

            return licenses;
        }

        public LicenseInfo GetClientLicense(int? organizationId,int? LicenseId)
        {
            LicenseInfo license = null;
            try
            {
                MySqlCommand cmd = new MySqlCommand("GetClientLicense", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("OrganizationId", organizationId));
                cmd.Parameters.Add(new MySqlParameter("LicenseId", LicenseId));
                

                //open connection
                if (this.OpenConnection() == true)
                {
                    MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                    while (dr.Read())
                    {
                        license = new LicenseInfo();

                        if (dr["ActivationDate"] != DBNull.Value)
                            license.ActivationDate = Convert.ToDateTime(dr["ActivationDate"]);
                        if (dr["idLicense"] != DBNull.Value)
                            license.idLicense = Convert.ToInt32(dr["idLicense"]);
                        if (dr["IsActivated"] != DBNull.Value)
                            license.IsActivated = Convert.ToBoolean(dr["IsActivated"]);
                        if (dr["IsExpired"] != DBNull.Value)
                            license.IsExpired = Convert.ToBoolean(dr["IsExpired"]);
                        if (dr["IsTampered"] != DBNull.Value)
                            license.IsTampered = Convert.ToBoolean(dr["IsTampered"]);
                        if (dr["LicenseFile"] != DBNull.Value)
                            license.LicenseFile = Convert.ToString(dr["LicenseFile"]);
                        if (dr["LicenseHash"] != DBNull.Value)
                            license.LicenseHash = Convert.ToString(dr["LicenseHash"]);
                        if (dr["Organization_idOrganization"] != DBNull.Value)
                            license.OrganizationId = Convert.ToInt32(dr["Organization_idOrganization"]);
                        if (dr["ValidFrom"] != DBNull.Value)
                            license.ValidFrom = Convert.ToDateTime(dr["ValidFrom"]);
                        if (dr["ValidTo"] != DBNull.Value)
                            license.ValidTo = Convert.ToDateTime(dr["ValidTo"]);
                    }

                    dr.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Method : SearchLicense", ex);
            }
            finally
            {
                //close connection
                this.CloseConnection();
            }
            return license;
        }

        //Delete statement
        public Dictionary<int, string> GetOrganizations()
        {
            Dictionary<int, string> org = new Dictionary<int, string>();
            try
            {
                MySqlCommand cmd = new MySqlCommand("GetOrganizations", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                //open connection
                if (this.OpenConnection() == true)
                {
                    MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                    while (dr.Read())
                    {
                        org.Add(Convert.ToInt32(dr["idOrganization"]), Convert.ToString(dr["OrganizationName"]));
                    }

                    dr.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Method : GetOrganizations", ex);
            }
            finally
            {
                //close connection
                this.CloseConnection();
            }
            return org;
        }

        public Dictionary<string, string> GetEncryptionKeys(int orgId)
        {
            Dictionary<string, string> org = new Dictionary<string, string>();
            try
            {
                MySqlCommand cmd = new MySqlCommand("GetEncryptionKeys", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("orgId", orgId));

                //open connection
                if (this.OpenConnection() == true)
                {
                    MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                    while (dr.Read())
                    {
                        org.Add("PublicKey", Convert.ToString(dr["PublicKey"]));
                        org.Add("PrivateKey", Convert.ToString(dr["PrivateKey"]));
                    }

                    dr.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Method : GetEncryptionKeys", ex);
            }
            finally
            {
                //close connection
                this.CloseConnection();
            }

            return org;
        }


        //Expire License
        public void ExpireLicense(int licenseId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("ExpireLicense", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("LicenseId", licenseId));

                //open connection
                if (this.OpenConnection() == true)
                {
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //close connection
                this.CloseConnection();
            }
        }

        //Tamper statement
        public void TamperLicense(int licenseId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("TamperLicense", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("LicenseId", licenseId));

                //open connection
                if (this.OpenConnection() == true)
                {
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //close connection
                this.CloseConnection();
            }
        }


        //Delete statement
        public void Delete()
        {
        }

        //Backup
        public void Backup()
        {
        }

        //Restore
        public void Restore()
        {
        }
    }
}
