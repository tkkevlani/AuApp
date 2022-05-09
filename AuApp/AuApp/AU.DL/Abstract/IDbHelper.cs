using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;


namespace AU.DL.Abstract
{
    /// <summary>
    /// Interface exposing the DB Helper functions 
    /// </summary>
    public interface IDBHelper
    {
        /// <summary>
        /// Returns the Table Data by calling the given stored procedure 
        /// </summary>
        /// <param name="procedureName">Stored procedure name</param>
        /// <param name="parameters">Parameters to be passed to stored procedure</param>
        /// <param name="isReadOnly">Is the operation readonly</param>
        /// <returns></returns>
        DataTable GetTableData(string procedureName, Dictionary<String, Object> parameters, Boolean isReadOnly = true);


        /// <summary>
        /// Returns DataSet by calling the 
        /// </summary>
        /// <param name="procedureName">Stored procedure name</param>
        /// <param name="parameters">Parameters to be passed to stored procedure</param>
        /// <param name="isReadOnly">Is the operation readonly</param>
        /// <returns></returns>
        DataSet GetDataSet(string procedureName, Dictionary<String, Object> parameters, Boolean isReadOnly = true);

        /// <summary>
        /// This is used to insert new record using stored procedure  
        /// </summary>
        /// <param name="procedureName">Stored procedure name</param>
        /// <param name="parameters">Parameters to be passed to stored procedure</param>
        /// <returns>1 for success, 0 for failure </returns>
        Int32 InsertTableData(string procedureName, Dictionary<String, Object> parameters);


        /// <summary>
        /// Mehtod for updating the data in the database.
        /// </summary>
        /// <param name="procedureName">The name of the procedure needs to be invoked</param>
        /// <param name="parameters">The paramaters as Dictionary object</param>
        /// <returns>Returns the primary key (identity column value) </returns>
        Int32 InsertTableDataReturnIdentity(string procedureName, Dictionary<String, Object> parameters);


        /// <summary>
        /// Mehtod for updating the data in the database.
        /// </summary>
        /// <param name="procedureName">The name of the procedure needs to be invoked</param>
        /// <param name="parameters">The paramaters as Dictionary object</param>
        /// <returns>Returns the primary key (identity column value) </returns>
        Int32 UpdateTableDataReturnIdentity(string procedureName, Dictionary<String, Object> parameters);

        /// <summary>
        /// Mehtod for updating the data in the database.
        /// </summary>
        /// <param name="procedureName">The name of the procedure needs to be invoked</param>
        /// <param name="parameters">The paramaters as Dictionary object</param>
        /// <returns>On success it returns true. otherwise false </returns>
        bool UpdateTableDataReturnStatus(string procedureName, Dictionary<String, Object> parameters);
              
        /// <summary>
        /// Mehtod for deleting data from the database.
        /// </summary>
        /// <param name="procedureName">The name of the procedure needs to be invoked</param>
        /// <param name="parameters">The paramaters as Dictionary object</param>
        /// <returns>On success it returns true. otherwise false</returns>
        bool DeleteTableData(string procedureName, Dictionary<String, Object> parameters);

        /// <summary>
        /// Mehtod for inserting more than one data row in to the database.
        /// </summary>
        /// <param name="procedureName">The name of the procedure needs to be invoked</param>
        /// <param name="parameters">The paramaters as Dictionary object</param>
        /// <returns>Returns the primary key (identity column value) </returns>
        Int32 InsertTableDataRows(string procedureName, List<Dictionary<String, Object>> parameters);
        MySqlConnection TestConnection();
    };
}
