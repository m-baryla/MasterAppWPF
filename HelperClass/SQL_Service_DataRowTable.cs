using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace HelperClass
{
    public class SQL_Service_DataRowTable
    {
        private string _sqlConnectionString = Config.GetSqlConnectionString();

        public DataRow ExecuteSqlProcedureSingleRow(string procedureName, IEnumerable<Parameter> procedureParameters, int? timeoutInSeconds)
        {
            DataTable dataTable = this.ExecuteSqlProcedureTable(procedureName, procedureParameters, timeoutInSeconds);
            if (dataTable.Rows.Count != 1)
                throw new ArgumentException(procedureName);
            return dataTable.Rows[0];
        }
        public DataRow ExecuteSqlProcedureSingleRow(string procedureName, params Parameter[] procedureParameters)
        {
            return this.ExecuteSqlProcedureSingleRow(procedureName, (IEnumerable<Parameter>)procedureParameters, new int?());
        }
        public DataTable ExecuteSqlProcedureTable(string ProcedureName, params Parameter[] procedureParameters)
        {
            return this.ExecuteSqlProcedureTable(ProcedureName, (IEnumerable<Parameter>)procedureParameters, new int?());
        }
        public DataTable ExecuteSqlProcedureTable(string procedureName, IEnumerable<Parameter> procedureParameters, int? timeoutInSeconds)
        {
            IEnumerable<Parameter> procedureParametersOut = (IEnumerable<Parameter>)null;
            return this.ExecuteSqlProcedureTable(procedureName, ref procedureParametersOut, procedureParameters, timeoutInSeconds);
        }
        public DataTable ExecuteSqlProcedureTable(string procedureName, ref IEnumerable<Parameter> procedureParametersOut, IEnumerable<Parameter> procedureParameters, int? timeoutInSeconds)
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
                        foreach (Parameter procedureParameter in procedureParameters)
                        {
                            if (procedureParameter.Value == null)
                                command.Parameters[procedureParameter.Name].Value = (object)DBNull.Value;
                            else
                                command.Parameters[procedureParameter.Name].Value = procedureParameter.Value;
                        }
                    }
                    if (procedureParametersOut != null)
                    {
                        foreach (Parameter parameter in procedureParametersOut)
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
                        foreach (Parameter parameter in procedureParametersOut)
                        {
                            if (command.Parameters.Contains(parameter.Name))
                                parameter.Value = command.Parameters[parameter.Name].Value;
                        }
                    }
                }
            }
            return dataTable;
        }
        public Dictionary<int, string> ExecuteSqlProcedureDictionary(string procedureName, IEnumerable<Parameter> procedureParameters, int? timeoutInSeconds)
        {
            DataTable dataTable = this.ExecuteSqlProcedureTable(procedureName, procedureParameters, timeoutInSeconds);
            Dictionary<int, string> dictionary = new Dictionary<int, string>();
            foreach (DataRow row in (InternalDataCollectionBase)dataTable.Rows)
                dictionary.Add(int.Parse(row[0].ToString()), row[1].ToString());
            return dictionary;
        }
        public Dictionary<int, string> ExecuteSqlProcedureDictionary(string procedureName, IEnumerable<Parameter> procedureParameters = null)
        {
            DataTable dataTable = this.ExecuteSqlProcedureTable(procedureName, procedureParameters, null);
            Dictionary<int, string> dictionary = new Dictionary<int, string>();
            foreach (DataRow row in (InternalDataCollectionBase)dataTable.Rows)
                dictionary.Add(int.Parse(row[0].ToString()), row[1].ToString());
            return dictionary;
        }
        public int ExecuteModData(string procedureName, out string UserMsg, params Parameter[] procedureParameters)
        {
            IEnumerable<Parameter> procedureParametersOut = (IEnumerable<Parameter>)null;
            return this.ExecuteModData(procedureName, out UserMsg, ref procedureParametersOut, (IEnumerable<Parameter>)procedureParameters, new int?());
        }
        public int ExecuteModData(string procedureName, out string UserMsg, IEnumerable<Parameter> procedureParameters, int? timeoutInSeconds)
        {
            IEnumerable<Parameter> procedureParametersOut = (IEnumerable<Parameter>)null;
            return this.ExecuteModData(procedureName, out UserMsg, ref procedureParametersOut, procedureParameters, timeoutInSeconds);
        }
        public int ExecuteModData(string procedureName, out string UserMsg, IEnumerable<Parameter> procedureParameters)
        {
            IEnumerable<Parameter> procedureParametersOut = (IEnumerable<Parameter>)null;
            return this.ExecuteModData(procedureName, out UserMsg, ref procedureParametersOut, procedureParameters,null);
        }
        public int ExecuteModData(string procedureName, out string UserMsg, ref IEnumerable<Parameter> procedureParametersOut, IEnumerable<Parameter> procedureParameters, int? timeoutInSeconds)
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
                        foreach (Parameter procedureParameter in procedureParameters)
                        {
                            if (procedureParameter.Value == null)
                                command.Parameters[procedureParameter.Name].Value = (object)DBNull.Value;
                            else
                                command.Parameters[procedureParameter.Name].Value = procedureParameter.Value;
                        }
                    }
                    if (procedureParametersOut != null)
                    {
                        foreach (Parameter parameter in procedureParametersOut)
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
                        foreach (Parameter parameter in procedureParametersOut)
                        {
                            if (command.Parameters.Contains(parameter.Name))
                                parameter.Value = command.Parameters[parameter.Name].Value;
                        }
                    }
                }
            }
            return num;
        }
        public int ExecuteModData(string procedureName, out string UserMsg, ref IEnumerable<Parameter> procedureParametersOut, IEnumerable<Parameter> procedureParameters)
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
                        foreach (Parameter procedureParameter in procedureParameters)
                        {
                            if (procedureParameter.Value == null)
                                command.Parameters[procedureParameter.Name].Value = (object)DBNull.Value;
                            else
                                command.Parameters[procedureParameter.Name].Value = procedureParameter.Value;
                        }
                    }
                    if (procedureParametersOut != null)
                    {
                        foreach (Parameter parameter in procedureParametersOut)
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
                        foreach (Parameter parameter in procedureParametersOut)
                        {
                            if (command.Parameters.Contains(parameter.Name))
                                parameter.Value = command.Parameters[parameter.Name].Value;
                        }
                    }
                }
            }
            return num;
        }
        public DataTable ExecuteModDataTable(string procedureName, out string UserMsg, out int retVal, ref IEnumerable<Parameter> procedureParametersOut, IEnumerable<Parameter> procedureParameters, int? timeoutInSeconds)
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
                        foreach (Parameter procedureParameter in procedureParameters)
                        {
                            if (procedureParameter.Value == null)
                                command.Parameters[procedureParameter.Name].Value = (object)DBNull.Value;
                            else
                                command.Parameters[procedureParameter.Name].Value = procedureParameter.Value;
                        }
                    }
                    if (procedureParametersOut != null)
                    {
                        foreach (Parameter parameter in procedureParametersOut)
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
                        foreach (Parameter parameter in procedureParametersOut)
                        {
                            if (command.Parameters.Contains(parameter.Name))
                                parameter.Value = command.Parameters[parameter.Name].Value;
                        }
                    }
                }
            }
            return dataTable;
        }
        public DataTable ExecuteModDataTable(string procedureName, ref IEnumerable<Parameter> procedureParametersOut, IEnumerable<Parameter> procedureParameters)
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


        //private bool CheckGroupMembership(string userID, string groupName)
        //{
        //    PrincipalContext context = new PrincipalContext(ContextType.Domain);
        //    UserPrincipal byIdentity1 = UserPrincipal.FindByIdentity(context, userID);
        //    GroupPrincipal byIdentity2 = GroupPrincipal.FindByIdentity(context, groupName);
        //    return byIdentity1 != null && byIdentity2 != null && byIdentity2.GetMembers(true).Contains<System.DirectoryServices.AccountMament.Principal>((System.DirectoryServices.AccountMament.Principal)byIdentity1);
        //}

        //public bool GetUserPermission(string procedureName, string userRole)
        //{
        //    List<string> source = new List<string>();
        //    WindowsIdentity userLoginName = WindowsIdentity.GetCurrent();
        //    if (userLoginName == null)
        //        return false;
        //    foreach (DataRow row in (InternalDataCollectionBase)this.ExecuteSqlProcedureTable(procedureName, new Parameter[1]
        //    {
        //new Parameter("@UserRole", (object) userRole)
        //    }).Rows)
        //        source.Add(row[0].ToString());
        //    WindowsPrincipal principal = new WindowsPrincipal(userLoginName);
        //    return source.Any<string>((Func<string, bool>)(g => principal.IsInRole(g))) || source.Any<string>((Func<string, bool>)(g => this.CheckGroupMembership(userLoginName.Name, g)));
        //}

        //public bool GetUserPermission(string groupName)
        //{
        //    WindowsIdentity current = WindowsIdentity.GetCurrent();
        //    return current != null && (new WindowsPrincipal(current).IsInRole(groupName) || this.CheckGroupMembership(current.Name, groupName));
        //}
    }
    public class Parameter
    {
        public string Name { get; }

        public object Value { get; set; }

        public Parameter(string name, object value)
        {
            this.Name = name;
            this.Value = value;
        }

        public override string ToString() => string.Format("{0}: {1}", (object)this.Name, this.Value);
    }
}
