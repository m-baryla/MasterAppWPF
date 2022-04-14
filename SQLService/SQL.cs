using BaseClassApp.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Principal;
using BaseClassApp;


namespace SQLService
{
    public class SQL : ISQL
    {       
        private readonly string _sqlConnectionString;

        public SQL(string _sqlConnectionString)
        {
            this._sqlConnectionString = _sqlConnectionString;
        }

        public DataRow ExecuteSqlProcedureSingleRow(string procedureName, IEnumerable<SQLParameter> procedureParameters, int? timeoutInSeconds)
        {
            DataTable dataTable = this.ExecuteSqlProcedureTable(procedureName, procedureParameters, timeoutInSeconds);
            if (dataTable.Rows.Count != 1)
                throw new ArgumentException(procedureName);
            return dataTable.Rows[0];
        }
        public DataRow ExecuteSqlProcedureSingleRow(string procedureName, params SQLParameter[] procedureParameters)
        {
            return this.ExecuteSqlProcedureSingleRow(procedureName, (IEnumerable<SQLParameter>)procedureParameters, new int?());
        }
        public DataTable ExecuteSqlProcedureTable(string ProcedureName, params SQLParameter[] procedureParameters)
        {
            return this.ExecuteSqlProcedureTable(ProcedureName, (IEnumerable<SQLParameter>)procedureParameters, new int?());
        }
        public DataTable ExecuteSqlProcedureTable(string procedureName, IEnumerable<SQLParameter> procedureParameters, int? timeoutInSeconds)
        {
            IEnumerable<SQLParameter> procedureParametersOut = (IEnumerable<SQLParameter>)null;
            return this.ExecuteSqlProcedureTable(procedureName, ref procedureParametersOut, procedureParameters, timeoutInSeconds);
        }
        public DataTable ExecuteSqlProcedureTable(string procedureName, ref IEnumerable<SQLParameter> procedureParametersOut, IEnumerable<SQLParameter> procedureParameters, int? timeoutInSeconds)
        {
            if (string.IsNullOrWhiteSpace(procedureName))
                throw new ArgumentNullException(nameof(procedureName));
            DataTable dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(this._sqlConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(procedureName, connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                using (SqlCommand command = sqlCommand)
                {
                    if (timeoutInSeconds.HasValue)
                        command.CommandTimeout = timeoutInSeconds.Value;
                    if (connection.State != ConnectionState.Open)
                        connection.Open();
                    SqlCommandBuilder.DeriveParameters(command);
                    if (procedureParameters != null)
                    {
                        foreach (SQLParameter procedureParameter in procedureParameters)
                        {
                            if (procedureParameter.Value == null)
                                command.Parameters[procedureParameter.Name].Value = (object)DBNull.Value;
                            else
                                command.Parameters[procedureParameter.Name].Value = procedureParameter.Value;
                        }
                    }
                    if (procedureParametersOut != null)
                    {
                        foreach (SQLParameter parameter in procedureParametersOut)
                        {
                            if (parameter.Value == null)
                                command.Parameters[parameter.Name].Value = (object)DBNull.Value;
                            else
                                command.Parameters[parameter.Name].Value = parameter.Value;
                        }
                    }
                    //if (this._factoryId.HasValue && command.Parameters.Contains("@FactoryIDKey"))
                    //    command.Parameters["@FactoryIDKey"].Value = (object)this._factoryId.Value;
                    //if (!string.IsNullOrWhiteSpace(this._languageCode) && command.Parameters.Contains("@LanguageID"))
                    //    command.Parameters["@LanguageID"].Value = (object)this._languageCode;
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter()
                    {
                        SelectCommand = command
                    })
                        sqlDataAdapter.Fill(dataTable);
                    if (procedureParametersOut != null)
                    {
                        foreach (SQLParameter parameter in procedureParametersOut)
                        {
                            if (command.Parameters.Contains(parameter.Name))
                                parameter.Value = command.Parameters[parameter.Name].Value;
                        }
                    }
                }
            }
            return dataTable;
        }
        public Dictionary<int, string> ExecuteSqlProcedureDictionary(string procedureName, IEnumerable<SQLParameter> procedureParameters, int? timeoutInSeconds)
        {
            DataTable dataTable = this.ExecuteSqlProcedureTable(procedureName, procedureParameters, timeoutInSeconds);
            Dictionary<int, string> dictionary = new Dictionary<int, string>();
            foreach (DataRow row in (InternalDataCollectionBase)dataTable.Rows)
                dictionary.Add(int.Parse(row[0].ToString()), row[1].ToString());
            return dictionary;
        }
        public Dictionary<int, string> ExecuteSqlProcedureDictionary(string procedureName, IEnumerable<SQLParameter> procedureParameters = null)
        {
            DataTable dataTable = this.ExecuteSqlProcedureTable(procedureName, procedureParameters, null);
            Dictionary<int, string> dictionary = new Dictionary<int, string>();
            foreach (DataRow row in (InternalDataCollectionBase)dataTable.Rows)
                dictionary.Add(int.Parse(row[0].ToString()), row[1].ToString());
            return dictionary;
        }
        public int ExecuteModData(string procedureName, out string UserMsg, params SQLParameter[] procedureParameters)
        {
            IEnumerable<SQLParameter> procedureParametersOut = (IEnumerable<SQLParameter>)null;
            return this.ExecuteModData(procedureName, out UserMsg, ref procedureParametersOut, (IEnumerable<SQLParameter>)procedureParameters, new int?());
        }
        public int ExecuteModData(string procedureName, out string UserMsg, IEnumerable<SQLParameter> procedureParameters, int? timeoutInSeconds)
        {
            IEnumerable<SQLParameter> procedureParametersOut = (IEnumerable<SQLParameter>)null;
            return this.ExecuteModData(procedureName, out UserMsg, ref procedureParametersOut, procedureParameters, timeoutInSeconds);
        }
        public int ExecuteModData(string procedureName, out string UserMsg, IEnumerable<SQLParameter> procedureParameters)
        {
            IEnumerable<SQLParameter> procedureParametersOut = (IEnumerable<SQLParameter>)null;
            return this.ExecuteModData(procedureName, out UserMsg, ref procedureParametersOut, procedureParameters,null);
        }
        public int ExecuteModData(string procedureName, out string UserMsg, ref IEnumerable<SQLParameter> procedureParametersOut, IEnumerable<SQLParameter> procedureParameters, int? timeoutInSeconds)
        {
            if (string.IsNullOrWhiteSpace(procedureName))
                throw new ArgumentNullException(nameof(procedureName));
            int num = -1;
            UserMsg = (string)null;
            using (SqlConnection connection = new SqlConnection(this._sqlConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(procedureName, connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                using (SqlCommand command = sqlCommand)
                {
                    if (timeoutInSeconds.HasValue)
                        command.CommandTimeout = timeoutInSeconds.Value;
                    if (connection.State != ConnectionState.Open)
                        connection.Open();
                    SqlCommandBuilder.DeriveParameters(command);
                    if (procedureParameters != null)
                    {
                        foreach (SQLParameter procedureParameter in procedureParameters)
                        {
                            if (procedureParameter.Value == null)
                                command.Parameters[procedureParameter.Name].Value = (object)DBNull.Value;
                            else
                                command.Parameters[procedureParameter.Name].Value = procedureParameter.Value;
                        }
                    }
                    if (procedureParametersOut != null)
                    {
                        foreach (SQLParameter parameter in procedureParametersOut)
                        {
                            if (parameter.Value == null)
                                command.Parameters[parameter.Name].Value = (object)DBNull.Value;
                            else
                                command.Parameters[parameter.Name].Value = parameter.Value;
                        }
                    }
                    //if (this._factoryId.HasValue && command.Parameters.Contains("@FactoryIDKey"))
                    //    command.Parameters["@FactoryIDKey"].Value = (object)this._factoryId.Value;
                    //if (!string.IsNullOrWhiteSpace(this._languageCode) && command.Parameters.Contains("@LanguageID"))
                    //    command.Parameters["@LanguageID"].Value = (object)this._languageCode;
                    if (command.Parameters.Contains("@UserMsg"))
                        command.Parameters["@UserMsg"].Value = (object)DBNull.Value;
                    foreach (SqlParameter sqlParameter in command.Parameters.Cast<SqlParameter>().Where<SqlParameter>((Func<SqlParameter, bool>)(p => p.SqlDbType == SqlDbType.Structured)))
                    {
                        string str = sqlParameter.TypeName.Substring(sqlParameter.TypeName.IndexOf(".") + 1);
                        if (str.Contains("."))
                            sqlParameter.TypeName = str;
                    }
                    command.ExecuteNonQuery();
                    if (command.Parameters.Contains("@UserMsg"))
                        UserMsg = command.Parameters["@UserMsg"].Value.ToString();
                    if (command.Parameters.Contains("@RETURN_VALUE"))
                        num = (int)command.Parameters["@RETURN_VALUE"].Value;
                    if (procedureParametersOut != null)
                    {
                        foreach (SQLParameter parameter in procedureParametersOut)
                        {
                            if (command.Parameters.Contains(parameter.Name))
                                parameter.Value = command.Parameters[parameter.Name].Value;
                        }
                    }
                }
            }
            return num;
        }
        public int ExecuteModData(string procedureName, out string UserMsg, ref IEnumerable<SQLParameter> procedureParametersOut, IEnumerable<SQLParameter> procedureParameters)
        {
            if (string.IsNullOrWhiteSpace(procedureName))
                throw new ArgumentNullException(nameof(procedureName));
            int num = -1;
            UserMsg = (string)null;
            using (SqlConnection connection = new SqlConnection(this._sqlConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(procedureName, connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                using (SqlCommand command = sqlCommand)
                {
                    //if (timeoutInSeconds.HasValue)
                    //    command.CommandTimeout = timeoutInSeconds.Value;
                    if (connection.State != ConnectionState.Open)
                        connection.Open();
                    SqlCommandBuilder.DeriveParameters(command);
                    if (procedureParameters != null)
                    {
                        foreach (SQLParameter procedureParameter in procedureParameters)
                        {
                            if (procedureParameter.Value == null)
                                command.Parameters[procedureParameter.Name].Value = (object)DBNull.Value;
                            else
                                command.Parameters[procedureParameter.Name].Value = procedureParameter.Value;
                        }
                    }
                    if (procedureParametersOut != null)
                    {
                        foreach (SQLParameter parameter in procedureParametersOut)
                        {
                            if (parameter.Value == null)
                                command.Parameters[parameter.Name].Value = (object)DBNull.Value;
                            else
                                command.Parameters[parameter.Name].Value = parameter.Value;
                        }
                    }
                    //if (this._factoryId.HasValue && command.Parameters.Contains("@FactoryIDKey"))
                    //    command.Parameters["@FactoryIDKey"].Value = (object)this._factoryId.Value;
                    //if (!string.IsNullOrWhiteSpace(this._languageCode) && command.Parameters.Contains("@LanguageID"))
                    //    command.Parameters["@LanguageID"].Value = (object)this._languageCode;
                    if (command.Parameters.Contains("@UserMsg"))
                        command.Parameters["@UserMsg"].Value = (object)DBNull.Value;
                    foreach (SqlParameter sqlParameter in command.Parameters.Cast<SqlParameter>().Where<SqlParameter>((Func<SqlParameter, bool>)(p => p.SqlDbType == SqlDbType.Structured)))
                    {
                        string str = sqlParameter.TypeName.Substring(sqlParameter.TypeName.IndexOf(".") + 1);
                        if (str.Contains("."))
                            sqlParameter.TypeName = str;
                    }
                    command.ExecuteNonQuery();
                    if (command.Parameters.Contains("@UserMsg"))
                        UserMsg = command.Parameters["@UserMsg"].Value.ToString();
                    if (command.Parameters.Contains("@return_value"))
                        num = (int)command.Parameters["@return_value"].Value;
                    if (procedureParametersOut != null)
                    {
                        foreach (SQLParameter parameter in procedureParametersOut)
                        {
                            if (command.Parameters.Contains(parameter.Name))
                                parameter.Value = command.Parameters[parameter.Name].Value;
                        }
                    }
                }
            }
            return num;
        }
        public DataTable ExecuteModDataTable(string procedureName, out string UserMsg, out int retVal, ref IEnumerable<SQLParameter> procedureParametersOut, IEnumerable<SQLParameter> procedureParameters, int? timeoutInSeconds)
        {
            if (string.IsNullOrWhiteSpace(procedureName))
                throw new ArgumentNullException(nameof(procedureName));
            retVal = -1;
            UserMsg = (string)null;
            DataTable dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(this._sqlConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(procedureName, connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                using (SqlCommand command = sqlCommand)
                {
                    if (timeoutInSeconds.HasValue)
                        command.CommandTimeout = timeoutInSeconds.Value;
                    if (connection.State != ConnectionState.Open)
                        connection.Open();
                    SqlCommandBuilder.DeriveParameters(command);
                    if (procedureParameters != null)
                    {
                        foreach (SQLParameter procedureParameter in procedureParameters)
                        {
                            if (procedureParameter.Value == null)
                                command.Parameters[procedureParameter.Name].Value = (object)DBNull.Value;
                            else
                                command.Parameters[procedureParameter.Name].Value = procedureParameter.Value;
                        }
                    }
                    if (procedureParametersOut != null)
                    {
                        foreach (SQLParameter parameter in procedureParametersOut)
                        {
                            if (parameter.Value == null)
                                command.Parameters[parameter.Name].Value = (object)DBNull.Value;
                            else
                                command.Parameters[parameter.Name].Value = parameter.Value;
                        }
                    }
                    //if (this._factoryId.HasValue && command.Parameters.Contains("@FactoryIDKey"))
                    //    command.Parameters["@FactoryIDKey"].Value = (object)this._factoryId.Value;
                    //if (!string.IsNullOrWhiteSpace(this._languageCode) && command.Parameters.Contains("@LanguageID"))
                    //    command.Parameters["@LanguageID"].Value = (object)this._languageCode;
                    if (command.Parameters.Contains("@UserMsg"))
                        command.Parameters["@UserMsg"].Value = (object)DBNull.Value;
                    foreach (SqlParameter sqlParameter in command.Parameters.Cast<SqlParameter>().Where<SqlParameter>((Func<SqlParameter, bool>)(p => p.SqlDbType == SqlDbType.Structured)))
                    {
                        string str = sqlParameter.TypeName.Substring(sqlParameter.TypeName.IndexOf(".") + 1);
                        if (str.Contains("."))
                            sqlParameter.TypeName = str;
                    }
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter()
                    {
                        SelectCommand = command
                    })
                        sqlDataAdapter.Fill(dataTable);
                    if (command.Parameters.Contains("@UserMsg"))
                        UserMsg = command.Parameters["@UserMsg"].Value.ToString();
                    if (command.Parameters.Contains("@RETURN_VALUE"))
                        retVal = (int)command.Parameters["@RETURN_VALUE"].Value;
                    if (procedureParametersOut != null)
                    {
                        foreach (SQLParameter parameter in procedureParametersOut)
                        {
                            if (command.Parameters.Contains(parameter.Name))
                                parameter.Value = command.Parameters[parameter.Name].Value;
                        }
                    }
                }
            }
            return dataTable;
        }
        public DataTable ExecuteModDataTable(string procedureName, ref IEnumerable<SQLParameter> procedureParametersOut, IEnumerable<SQLParameter> procedureParameters)
        {
            if (string.IsNullOrWhiteSpace(procedureName))
                throw new ArgumentNullException("procedureName");

            DataTable dataTable = new DataTable();

            using (var sqlConnection = new SqlConnection(_sqlConnectionString))
            {
                using (var sqlCommand = new SqlCommand(procedureName, sqlConnection) { CommandType = CommandType.StoredProcedure })
                {
                    //if (timeoutInSeconds != null)
                    //    sqlCommand.CommandTimeout = (int)timeoutInSeconds;

                    if (sqlConnection.State != ConnectionState.Open)
                        sqlConnection.Open();

                    SqlCommandBuilder.DeriveParameters(sqlCommand);

                    if (procedureParameters != null)
                        foreach (var param in procedureParameters)
                        {
                            if (param.Value == null)
                                sqlCommand.Parameters[param.Name].Value = DBNull.Value;
                            else
                                sqlCommand.Parameters[param.Name].Value = param.Value;
                        }

                    if (procedureParametersOut != null)
                        foreach (var param in procedureParametersOut)
                        {
                            if (param.Value == null)
                                sqlCommand.Parameters[param.Name].Value = DBNull.Value;
                            else
                                sqlCommand.Parameters[param.Name].Value = param.Value;
                        }


                    foreach (var parameter in sqlCommand.Parameters.Cast<SqlParameter>().Where(p => p.SqlDbType == SqlDbType.Structured))
                    {
                        var name = parameter.TypeName.Substring(parameter.TypeName.IndexOf(".") + 1);
                        if (name.Contains("."))
                            parameter.TypeName = name;
                    }

                    sqlCommand.ExecuteNonQuery();

                    if (procedureParametersOut != null)
                        foreach (var param in procedureParametersOut)
                        {
                            if (sqlCommand.Parameters.Contains(param.Name))
                                param.Value = sqlCommand.Parameters[param.Name].Value;
                        }

                    using (var dataAdapter = new SqlDataAdapter { SelectCommand = sqlCommand })
                    {
                        dataAdapter.Fill(dataTable);
                    }
                }
            }
            return dataTable;
        }

        public bool GetUserPermissionDomain(string procedureName, string userRole)
        {
            List<string> source = new List<string>();
            WindowsIdentity userLoginName = WindowsIdentity.GetCurrent();
            if (userLoginName == null)
                return false;
            foreach (DataRow row in (InternalDataCollectionBase)this.ExecuteSqlProcedureTable(procedureName, new SQLParameter[1] {new SQLParameter("@UserRole", (object) userRole)}).Rows)
                source.Add(row[0].ToString());

            WindowsPrincipal principal = new WindowsPrincipal(userLoginName);
            return source.Any<string>((Func<string, bool>)(g => principal.IsInRole(g)));
        }

        public bool GetUserPermissionLogin(string procedureName, string userRole)
        {
            List<string> source = new List<string>();
            WindowsIdentity userLoginName = WindowsIdentity.GetCurrent();
            if (userLoginName == null)
                return false;

            var dbo = this.ExecuteSqlProcedureTable(procedureName,
                new SQLParameter[1] { new SQLParameter("@UserRole", (object)userRole) });

            foreach (DataRow row in dbo.Rows)
                source.Add(row[0].ToString());

            return source.Contains(userLoginName.Name.ToString());
        }
    }
}
