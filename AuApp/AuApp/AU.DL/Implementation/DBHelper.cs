using AU.Common;
using AU.DL.Abstract;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;

namespace AU.DL.Implementation
{
    /// <summary>
    /// 
    /// </summary>
    public class DBHelper : IDBHelper
    {
        protected MySqlConnection connection;
        public MySqlTransaction transaction;
        static DateTime LastErrorTime = DateTime.MinValue;
        /// <summary>
        /// 
        /// </summary>
        public DBHelper()
        {
        }
        /// <summary>
        /// Method for beginning a transaction. This method will handle the opening of a connection also.
        /// </summary>
        public void BeginTransaction()
        {
            if (connection == null || !(connection.State == ConnectionState.Open))
            {
                string connectionString = ConfigurationManager.ConnectionStrings["AuDBConnection"].ConnectionString;
                connection = new MySqlConnection(connectionString);
                connection.Open();                
            }
        }
        
        /// <summary>
        /// Method for commiting the transactions. If any error happens on the commit, the rollback will be automatically performed. 
        /// </summary>
        public void CommitTransaction()
        {
            try
            {
                //transaction.Commit();
                connection.Dispose();
            }
            catch (Exception ex)
            {
                RollBackTransaction();
                throw ex;
            }
        }

        /// <summary>
        /// Method for performing the rollbackof the transactions
        /// </summary>
        public void RollBackTransaction()
        {
            //transaction.Rollback();
            connection.Dispose();
        }

        /// <summary>
        /// Method for closing the connection
        /// </summary>
        public void CloseConnection()
        {
            if (connection != null && connection.State == ConnectionState.Open)
                connection.Close();
        }

        /// <summary>
        /// Mehtod for fetching data from the database.
        /// </summary>
        /// <param name="procedureName">The name of the procedure needs to be invoked</param>
        /// <param name="parameters">The paramaters as Dictionary object</param>
        /// <returns>Returns the data as a datatable </returns>
        public DataTable GetTableData(string procedureName, Dictionary<String, Object> parameters, Boolean isReadOnly = true)
        {
            return _GetTableData(procedureName, parameters, escapeTicks: true, isReadOnly: isReadOnly);
        }
        /// <summary>
        /// Method to fetch data from the database as a DataSet 
        /// The DataSet may contain one or more tables 
        /// </summary>
        /// <param name="procedureName"></param>
        /// <param name="parameters"></param>
        /// <param name="isReadOnly"></param>
        /// <returns>Returns the data as a DataSet</returns>
        public DataSet GetDataSet(string procedureName, Dictionary<String, Object> parameters, Boolean isReadOnly = true)
        {
            return _GetDataSet(procedureName, parameters, escapeTicks: true, isReadOnly: isReadOnly);
        }

        /// <summary>
        /// Method for fetching data from the database.
        /// Does not escape ticks into double ticks.
        /// </summary>
        /// <param name="procedureName">The name of the procedure needs to be invoked</param>
        /// <param name="parameters">The paramaters as Dictionary object</param>
        /// <returns>Returns the data as a datatable </returns>
        public DataTable GetTableDataNoEscape(string procedureName, Dictionary<String, Object> parameters)
        {
            return _GetTableData(procedureName, parameters, escapeTicks: false);
        }
            
       
        /// <summary>
        /// Mehtod for fetching data from the database.
        /// </summary>
        /// <param name="procedureName">The name of the procedure needs to be invoked</param>
        /// <param name="parameters">The paramaters as Dictionary object</param>
        /// <returns>Returns the data as a datatable </returns>
        public DataTable GetTableDataForStatic(string procedureName, Dictionary<String, Object> parameters)
        {
            try
            {
                using (MySqlConnection connection = getConnection())
                {
                    try
                    {
                        using (MySqlCommand command = new MySqlCommand(procedureName, connection))
                        {
                            //command.Transaction = transaction;
                            command.CommandType = System.Data.CommandType.StoredProcedure;
                            if (parameters != null)
                            {
                                List<String> paramsList = new List<string>(parameters.Keys);
                                foreach (String key in paramsList)
                                {
                                    if (parameters[key] != null)
                                    {
                                        command.Parameters.AddWithValue(key, parameters[key]);

                                    }
                                    else
                                        command.Parameters.AddWithValue(key, DBNull.Value);
                                }
                            }
                            DataTable table = new DataTable();
                            using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                            {
                                adapter.Fill(table);
                            }
                            connection.Close();
                            ParseOutputData(table);
                            return table;
                        }
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }
        /// <summary>
        /// Mehtod for inserting data to the database.
        /// </summary>
        /// <param name="procedureName">The name of the procedure needs to be invoked</param>
        /// <param name="parameters">The paramaters as Dictionary object</param>
        /// <returns>Returns the primary key (identity column value) </returns>
        public Int32 InsertTableData(string procedureName, Dictionary<String, Object> parameters)
        {
            Int32 result = 0;
            
            ParseInputParams(parameters);
            try
            {
                using (MySqlConnection connection = getConnection())
                {
                    try
                    {

                        using (MySqlCommand command = new MySqlCommand(procedureName, connection))
                        {
                            
                            command.CommandType = System.Data.CommandType.StoredProcedure;
                            List<String> paramsList = new List<string>(parameters.Keys);
                            foreach (String key in paramsList)
                            {
                                command.Parameters.AddWithValue(key, parameters[key]);
                            }
                            result = command.ExecuteNonQuery();
                        }
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        /// <summary>
        /// Mehtod for updating the data in the database.
        /// </summary>
        /// <param name="procedureName">The name of the procedure needs to be invoked</param>
        /// <param name="parameters">The paramaters as Dictionary object</param>
        /// <returns>Returns the primary key (identity column value) </returns>
        public Int32 InsertTableDataReturnIdentity(string procedureName, Dictionary<String, Object> parameters)
        {
            Int32 result = 0;
            ParseInputParams(parameters);
            try
            {
                //MySqlConnection connection = getConnection();
                using (MySqlConnection connection = getConnection())
                {
                    try
                    {
                        using (MySqlCommand command = new MySqlCommand(procedureName, connection))
                        {
                            //command.Transaction = transaction; s
                            command.CommandType = System.Data.CommandType.StoredProcedure;
                            List<String> paramsList = new List<string>(parameters.Keys);
                            foreach (String key in paramsList)
                            {
                                command.Parameters.AddWithValue(key, parameters[key]);
                            }
                            result = Convert.ToInt32(command.ExecuteScalar());
                        }
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        /// <summary>
        /// Mehtod for updating the data in the database.
        /// </summary>
        /// <param name="procedureName">The name of the procedure needs to be invoked</param>
        /// <param name="parameters">The paramaters as Dictionary object</param>
        /// <returns>Returns the primary key (identity column value) </returns>
        public Int32 UpdateTableDataReturnIdentity(string procedureName, Dictionary<String, Object> parameters)
        {
            Int32 result = 0;
            ParseInputParams(parameters);
            try
            {
                using (MySqlConnection connection = getConnection())
                {
                    try
                    {

                        using (MySqlCommand command = new MySqlCommand(procedureName, connection))
                        {
                            //command.Transaction = transaction; s
                            command.CommandType = System.Data.CommandType.StoredProcedure;
                            List<String> paramsList = new List<string>(parameters.Keys);
                            foreach (String key in paramsList)
                            {
                                command.Parameters.AddWithValue(key, parameters[key]);
                            }
                            result = Convert.ToInt32(command.ExecuteScalar());
                        }
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        /// <summary>
        /// Mehtod for updating the data in the database.
        /// </summary>
        /// <param name="procedureName">The name of the procedure needs to be invoked</param>
        /// <param name="parameters">The paramaters as Dictionary object</param>
        /// <returns>On success it returns true. otherwise false </returns>
        public bool UpdateTableDataReturnStatus(string procedureName, Dictionary<String, Object> parameters)
        {
            bool result = false;
            ParseInputParams(parameters);
            try
            {
                //MySqlConnection connection = getConnection();
                using (MySqlConnection connection = getConnection())
                {
                    try
                    {
                        using (MySqlCommand command = new MySqlCommand(procedureName, connection))
                        {
                            //command.Transaction = transaction;
                            command.CommandType = System.Data.CommandType.StoredProcedure;
                            List<String> paramsList = new List<string>(parameters.Keys);
                            foreach (String key in paramsList)
                            {
                                command.Parameters.AddWithValue(key, parameters[key]);
                            }

                            // Return 'true' if the number of rows affected is greater then 0, else return 'false'
                            result = (command.ExecuteNonQuery() > 0) ? true : false;
                        }
                    }
                    finally
                    {
                        connection.Close();
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }
        /// <summary>
        /// Mehtod for fetching a single value from the database.
        /// </summary>
        /// <param name="procedureName">The name of the procedure needs to be invoked</param>
        /// <param name="parameters">The paramaters as Dictionary object</param>
        /// <returns>Returns the value in the first cell of the result </returns>
        public object GetScalarValue(string procedureName, Dictionary<String, Object> parameters)
        {
            object result = false;
            try
            {
                //MySqlConnection connection = getConnection();
                using (MySqlConnection connection = getConnection())
                {
                    try
                    {

                        using (MySqlCommand command = new MySqlCommand(procedureName, connection))
                        {
                            //command.Transaction = transaction;
                            command.CommandType = System.Data.CommandType.StoredProcedure;
                            List<String> paramsList = new List<string>(parameters.Keys);
                            foreach (String key in paramsList)
                            {

                                if (parameters[key] != null)
                                {
                                    if (parameters[key] is string)
                                    {
                                        String paramValue = parameters[key].ToString().Replace("'", "''");
                                        command.Parameters.AddWithValue(key, paramValue);
                                    }
                                    else
                                    {
                                        command.Parameters.AddWithValue(key, parameters[key]);
                                    }
                                }
                                else
                                {
                                    command.Parameters.AddWithValue(key, DBNull.Value);
                                }

                                //command.Parameters.AddWithValue(key, parameters[key]);
                            }
                            result = command.ExecuteScalar();
                        }
                    }
                    finally
                    {
                        connection.Close();
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            if (result != null && result is string)
            {
                result = ReplaceInvalidSpecialCharsFromList((string)result);
                result = result.ToString().Replace('`', '\'').Replace('’', '\'');
            }
            return result;
        }
        /// <summary>
        /// Mehtod for fetching a single value from the database.
        /// </summary>
        /// <param name="procedureName">The name of the procedure needs to be invoked</param>
        /// <param name="parameters">The paramaters as Dictionary object</param>
        /// <returns>Returns the value in the first cell of the result </returns>
        public object GetScalarValueStatic(string procedureName, Dictionary<String, Object> parameters)
        {
            object result = false;
            try
            {
                using (MySqlConnection connection = getConnection())
                {
                    try
                    {

                        using (MySqlCommand command = new MySqlCommand(procedureName, connection))
                        {
                            //command.Transaction = transaction;
                            command.CommandType = CommandType.StoredProcedure;
                            List<String> paramsList = new List<string>(parameters.Keys);
                            foreach (String key in paramsList)
                            {

                                if (parameters[key] != null)
                                {
                                    if (parameters[key] is string)
                                    {
                                        String paramValue = parameters[key].ToString();
                                        command.Parameters.AddWithValue(key, paramValue);
                                    }
                                    else
                                    {
                                        command.Parameters.AddWithValue(key, parameters[key]);
                                    }
                                }
                                else
                                {
                                    command.Parameters.AddWithValue(key, DBNull.Value);
                                }

                                //command.Parameters.AddWithValue(key, parameters[key]);
                            }
                            result = command.ExecuteScalar();
                        }
                    }
                    finally
                    {
                        connection.Close();
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            if (result != null && result is string)
            {
                result = ReplaceInvalidSpecialCharsFromList((string)result);
                result = result.ToString().Replace('`', '\'').Replace('’', '\'');
            }
            return result;
        }
        /// <summary>
        /// Mehtod for deleting data from the database.
        /// </summary>
        /// <param name="procedureName">The name of the procedure needs to be invoked</param>
        /// <param name="parameters">The paramaters as Dictionary object</param>
        /// <returns>On success it returns true. otherwise false</returns>
        public bool DeleteTableData(string procedureName, Dictionary<String, Object> parameters)
        {
            using (MySqlConnection connection = getConnection())
            {

                bool result = false;
                try
                {

                    using (MySqlCommand command = new MySqlCommand(procedureName, connection))
                    {
                        //command.Transaction = transaction;
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        List<String> paramsList = new List<string>(parameters.Keys);
                        foreach (String key in paramsList)
                        {
                            command.Parameters.AddWithValue(key, parameters[key]);
                        }

                        // Return 'true' if the number of rows affected is greater then 0, else return 'false'
                        result = (command.ExecuteNonQuery() > 0) ? true : false;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                finally
                {
                    connection.Close();
                }


                return result;
            }
        }
        
        /// <summary>
        /// Mehtod for inserting more than one data row in to the database.
        /// </summary>
        /// <param name="procedureName">The name of the procedure needs to be invoked</param>
        /// <param name="parameters">The paramaters as Dictionary object</param>
        /// <returns>Returns the primary key (identity column value) </returns>
        public Int32 InsertTableDataRows(string procedureName, List<Dictionary<String, Object>> parameters)
        {
            Int32 result = 0;

            try
            {
                using (MySqlConnection connection = getConnection())
                {
                    try
                    {
                        using (MySqlCommand command = new MySqlCommand(procedureName, connection))
                        {

                            command.CommandType = System.Data.CommandType.StoredProcedure;

                            foreach (Dictionary<String, Object> param in parameters)
                            {
                                ParseInputParams(param);
                                command.Parameters.Clear();
                                List<String> paramsList = new List<string>(param.Keys);
                                foreach (String key in paramsList)
                                {
                                    command.Parameters.AddWithValue(key, param[key]);
                                }
                                result = command.ExecuteNonQuery();
                            }
                        }
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public MySqlConnection TestConnection()
        {
            return getConnection((true ? ConnectOption.dbReadOnly : ConnectOption.dbReadWrite));
        }
        #region "Private Methods and Enums"
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectOption"></param>
        /// <returns></returns>
        private MySqlConnection getConnection(ConnectOption connectOption)
        {
            MySqlConnection objConnection = null;
            try
            {
                if (objConnection == null)
                {
                    string connectionString = ConfigurationManager.ConnectionStrings["AuDBConnection"].ConnectionString;
                    objConnection = new MySqlConnection(connectionString);
                    objConnection.Open();
                }
            }
            catch (Exception ex)
            {
                LogWriter.WriteIntoFile(ex);
            }
            return objConnection;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="procedureName"></param>
        /// <param name="parameters"></param>
        /// <param name="escapeTicks"></param>
        /// <param name="isReadOnly"></param>
        /// <returns></returns>
        private DataSet _GetDataSet(string procedureName, Dictionary<String, Object> parameters, bool escapeTicks = true, Boolean isReadOnly = true)
        {
            try
            {
                using (MySqlConnection connection = getConnection((isReadOnly ? ConnectOption.dbReadOnly : ConnectOption.dbReadWrite)))
                {
                    try
                    {
                        using (MySqlCommand command = new MySqlCommand(procedureName, connection))
                        {
                            //command.Transaction = transaction;
                            command.CommandType = System.Data.CommandType.StoredProcedure;
                            if (parameters != null)
                            {
                                List<String> paramsList = new List<string>(parameters.Keys);
                                foreach (String key in paramsList)
                                {
                                    if (parameters[key] != null)
                                    {
                                        if (escapeTicks && parameters[key] is string && parameters[key].ToString().Contains("'"))
                                        {
                                            String paramValue = parameters[key].ToString().Replace("'", "''");
                                            command.Parameters.AddWithValue(key, paramValue);
                                        }
                                        else
                                        {
                                            command.Parameters.AddWithValue(key, parameters[key]);
                                        }
                                    }
                                    else
                                        command.Parameters.AddWithValue(key, DBNull.Value);
                                }
                            }
                            DataSet dataSet = new DataSet();


                            using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                            {
                                adapter.Fill(dataSet);
                            }
                            connection.Close();

                            foreach (DataTable table in dataSet.Tables)
                            {
                                ParseOutputData(table);
                            }

                            return dataSet;
                        }
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private enum ConnectOption
        {
            dbReadWrite,
            dbReadOnly
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="procedureName"></param>
        /// <param name="parameters"></param>
        /// <param name="escapeTicks"></param>
        /// <param name="isReadOnly"></param>
        /// <returns></returns>
        private DataTable _GetTableData(string procedureName, Dictionary<String, Object> parameters, bool escapeTicks = true, Boolean isReadOnly = true)
        {
            try
            {
                using (MySqlConnection connection = getConnection((isReadOnly ? ConnectOption.dbReadOnly : ConnectOption.dbReadWrite)))
                {
                    try
                    {
                        using (MySqlCommand command = new MySqlCommand(procedureName, connection))
                        {
                            //command.Transaction = transaction;
                            command.CommandType = System.Data.CommandType.StoredProcedure;
                            if (parameters != null)
                            {
                                List<String> paramsList = new List<string>(parameters.Keys);
                                foreach (String key in paramsList)
                                {
                                    if (parameters[key] != null)
                                    {
                                        if (escapeTicks && parameters[key] is string && parameters[key].ToString().Contains("'"))
                                        {
                                            String paramValue = parameters[key].ToString().Replace("'", "''");
                                            command.Parameters.AddWithValue(key, paramValue);
                                        }
                                        else
                                        {
                                            command.Parameters.AddWithValue(key, parameters[key]);
                                        }
                                    }
                                    else
                                        command.Parameters.AddWithValue(key, DBNull.Value);
                                }
                            }
                            DataTable table = new DataTable();


                            using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                            {
                                adapter.Fill(table);
                            }
                            connection.Close();

                            ParseOutputData(table);

                            return table;
                        }
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="parms"></param>
        private void ParseInputParams(Dictionary<string, object> parms)
        {
            List<string> keys = new List<string>(parms.Keys);
            foreach (string key in keys)
            {
                if (parms[key] != null && parms[key] is string)
                {
                    string value = parms[key].ToString();

                    if (value.Contains("’") || value.Contains("`"))
                    {
                        value = value.Replace('`', '\'').Replace('’', '\'');
                        parms[key] = value;
                    }
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="table"></param>
        private void ParseOutputData(DataTable table)
        {
            foreach (DataRow row in table.Rows)
            {
                foreach (DataColumn column in table.Columns)
                {
                    if (row[column] != null && row[column] is string)
                    {
                        string value = row[column].ToString();
                        value = ReplaceInvalidSpecialCharsFromList(value);
                        row[column] = value;

                        if (value.Contains("’") || value.Contains("`"))
                        {
                            value = value.Replace('`', '\'').Replace('’', '\'');
                            row[column] = value;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        private static string ReplaceInvalidSpecialCharsFromList(string source)
        {
            //\x26 to support the & used to seperate the request parameters in the Image Link
            const string charList = "[\x00-\x08\x0B\x0C\x0E-\x1F]";
            return System.Text.RegularExpressions.Regex.Replace(source, charList, "", System.Text.RegularExpressions.RegexOptions.Compiled);

        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private MySqlConnection getConnection()
        {
            return getConnection(ConnectOption.dbReadWrite);
        }
        #endregion
    }
}
