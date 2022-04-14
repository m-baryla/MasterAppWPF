using System.Collections.Generic;
using System.Data;

namespace BaseClassApp.Interface
{
    public interface ISQL
    {
        DataRow ExecuteSqlProcedureSingleRow(string procedureName, IEnumerable<SQLParameter> procedureParameters, int? timeoutInSeconds);
        DataRow ExecuteSqlProcedureSingleRow(string procedureName, params SQLParameter[] procedureParameters);
        DataTable ExecuteSqlProcedureTable(string ProcedureName, params SQLParameter[] procedureParameters);
        DataTable ExecuteSqlProcedureTable(string procedureName, IEnumerable<SQLParameter> procedureParameters, int? timeoutInSeconds);
        DataTable ExecuteSqlProcedureTable(string procedureName, ref IEnumerable<SQLParameter> procedureParametersOut, IEnumerable<SQLParameter> procedureParameters, int? timeoutInSeconds);
        Dictionary<int, string> ExecuteSqlProcedureDictionary(string procedureName, IEnumerable<SQLParameter> procedureParameters, int? timeoutInSeconds);
        Dictionary<int, string> ExecuteSqlProcedureDictionary(string procedureName, IEnumerable<SQLParameter> procedureParameters = null);
        int ExecuteModData(string procedureName, out string UserMsg, params SQLParameter[] procedureParameters);
        int ExecuteModData(string procedureName, out string UserMsg, IEnumerable<SQLParameter> procedureParameters, int? timeoutInSeconds);
        int ExecuteModData(string procedureName, out string UserMsg, IEnumerable<SQLParameter> procedureParameters);
        int ExecuteModData(string procedureName, out string UserMsg, ref IEnumerable<SQLParameter> procedureParametersOut, IEnumerable<SQLParameter> procedureParameters, int? timeoutInSeconds);
        int ExecuteModData(string procedureName, out string UserMsg, ref IEnumerable<SQLParameter> procedureParametersOut, IEnumerable<SQLParameter> procedureParameters);
        DataTable ExecuteModDataTable(string procedureName, out string UserMsg, out int retVal, ref IEnumerable<SQLParameter> procedureParametersOut, IEnumerable<SQLParameter> procedureParameters, int? timeoutInSeconds);
        DataTable ExecuteModDataTable(string procedureName, ref IEnumerable<SQLParameter> procedureParametersOut, IEnumerable<SQLParameter> procedureParameters);
        bool GetUserPermissionDomain(string procedureName, string userRole);
        bool GetUserPermissionLogin(string procedureName, string userRole);

    }
}