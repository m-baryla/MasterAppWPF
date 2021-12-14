using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App_2.T_2.Model;
using HelperClass;

namespace App_2.T_2.ViewModel
{
    public class ValueT2ViewModel
    {
        public List<ValueT2Model> GetValueT2Model_DataTable()
        {
            List<ValueT2Model> logs = new List<ValueT2Model>();
            var ie = SQL_Service_IEnumerable<ValueT2Model>.StoredProcedure<ValueT2Model>("[SQL_].[GetValueT2Model_DataTable]");

            var dt = SQL_Service_IEnumerable<ValueT2Model>.ToDataTable(ie);
            foreach (DataRow row in dt.Rows)
                logs.Add(new ValueT2Model(row));
            return logs;
        }

        public List<string> GetValueT2Model_DataTable_WithParametr(double value)
        {
            List<string> logs = new List<string>();

            var model = new Result();
            model.DoubleVaule = value;
            model.StringValue = "";
            model.IntValue = 0;

            var ie = SQL_Service_IEnumerable<Result>.StoredProcedureWithParameters<Result>("[SQL_].[GetValueT2Model_DataTable_WithParametr]", model);

            var dt = SQL_Service_IEnumerable<ValueT2Model>.ToDataTable(ie);
            foreach (DataRow row in dt.Rows)
            {
                logs.Add(row["IntValue"].ToString()+ row["StringValue"].ToString());
            }
            return logs;
        }
        public void GetValueT2Model_DataTable_WithParametr(Result model)
        {
            List<string> logs = new List<string>();

            var ie = SQL_Service_IEnumerable<Result>.StoredProcedureWithParameters<Result>("[SQL_].[GetValueT2Model_DataTable_WithParametr]", model);

            var dt = SQL_Service_IEnumerable<ValueT2Model>.ToDataTable(ie);
            foreach (DataRow row in dt.Rows)
            {
                logs.Add(row["IntValue"].ToString() + row["StringValue"].ToString());
            }
        }
        public void SetValueT2Model(Result1 model)
        {

            SQL_Service_IEnumerable<Result1>.StoredProcedureWithParameters("[SQL_CRUD].[ModValueT2Model]", model);
        }
    }
}
public class Result
{
    public int IntValue { get; set; }
    public string StringValue { get; set; }
    public double DoubleVaule { get; set; }

}
public class Result1
{
    public int IntValue { get; set; }
    public string StringValue { get; set; }

}