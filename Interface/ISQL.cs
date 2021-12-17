using System.Collections.Generic;
using System.Data;

namespace Interface
{
    public interface ISQL
    {
        DataRow ExecuteSqlProcedureSingleRow(string procedureName, IEnumerable<Parameter> procedureParameters, int? timeoutInSeconds);
        DataRow ExecuteSqlProcedureSingleRow(string procedureName, params Parameter[] procedureParameters);
        DataTable ExecuteSqlProcedureTable(string ProcedureName, params Parameter[] procedureParameters);
        DataTable ExecuteSqlProcedureTable(string procedureName, IEnumerable<Parameter> procedureParameters, int? timeoutInSeconds);
        DataTable ExecuteSqlProcedureTable(string procedureName, ref IEnumerable<Parameter> procedureParametersOut, IEnumerable<Parameter> procedureParameters, int? timeoutInSeconds);
        Dictionary<int, string> ExecuteSqlProcedureDictionary(string procedureName, IEnumerable<Parameter> procedureParameters, int? timeoutInSeconds);
        Dictionary<int, string> ExecuteSqlProcedureDictionary(string procedureName, IEnumerable<Parameter> procedureParameters = null);
        int ExecuteModData(string procedureName, out string UserMsg, params Parameter[] procedureParameters);
        int ExecuteModData(string procedureName, out string UserMsg, IEnumerable<Parameter> procedureParameters, int? timeoutInSeconds);
        int ExecuteModData(string procedureName, out string UserMsg, IEnumerable<Parameter> procedureParameters);
        int ExecuteModData(string procedureName, out string UserMsg, ref IEnumerable<Parameter> procedureParametersOut, IEnumerable<Parameter> procedureParameters, int? timeoutInSeconds);
        int ExecuteModData(string procedureName, out string UserMsg, ref IEnumerable<Parameter> procedureParametersOut, IEnumerable<Parameter> procedureParameters);
        DataTable ExecuteModDataTable(string procedureName, out string UserMsg, out int retVal, ref IEnumerable<Parameter> procedureParametersOut, IEnumerable<Parameter> procedureParameters, int? timeoutInSeconds);
        DataTable ExecuteModDataTable(string procedureName, ref IEnumerable<Parameter> procedureParametersOut, IEnumerable<Parameter> procedureParameters);
        bool GetUserPermission(string procedureName, string userRole);

    }
}