﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;
using App_2.T_1.Model;
using HelperClass;

namespace App_2.T_1.ViewModel
{
    public class ValueT1ViewModel 
    { 
        private SQL_Service_DataRowTable _sqlServiceDataRowTable = new SQL_Service_DataRowTable();
        public List<ValueT1Model> GetValueT1Model_DataTable()
        {
            List<ValueT1Model> logs = new List<ValueT1Model>();
            var dt = _sqlServiceDataRowTable.ExecuteSqlProcedureTable("[SQL_].[GetValueT1Model_DataTable]");
            foreach (DataRow row in dt.Rows)
                logs.Add(new ValueT1Model(row));
            return logs;
        }
        public List<string> GetValueT1Model_DataTable_WithParametr(int IntValue)
        {
            List<string> logs = new List<string>();
            var dt = _sqlServiceDataRowTable.ExecuteSqlProcedureTable("[SQL_].[GetValueT1Model_DataTable_WithParametr]", new Parameter("@IntValue", IntValue));
            foreach (DataRow row in dt.Rows)
                logs.Add(row["StringValue"].ToString());
            return logs;
        }
        public ValueT1Model GetValueT1Model_DataTable_SingleRow(string StringValue)
        {
            var tb = _sqlServiceDataRowTable.ExecuteSqlProcedureTable("[SQL_].[GetValueT1Model_DataTable_SingleRow]", new Parameter("@StringValue", StringValue));
            if (tb.Rows.Count < 1)
                return new ValueT1Model();
            return new ValueT1Model(tb.Rows[0]);
        }
        public string GetValueT1ModelLabel()
        {
            var tb = _sqlServiceDataRowTable.ExecuteSqlProcedureSingleRow("[SQL_].[GetValueT1ModelLabel]");
            var result =  tb[0].ToString();
            return result;
        }
        public bool ModValueT1Model(string StringValue, ValueT1Model item)
        {
            string Msg;
            List<Parameter> par = new List<Parameter>();

            if (item == null)
            {
                MessageBox.Show("item is null");
                return false;
            }

            par.Add(new Parameter("@StringValue", StringValue));
            par.Add(new Parameter("@DateTimeValue", item.DateTimeValue));
            par.Add(new Parameter("@IntValue", item.IntValue));

            var ret = _sqlServiceDataRowTable.ExecuteModData("[SQL_CRUD].[ModValueT1Model]", out Msg, par);
            MessageBox.Show(Msg + ret.ToString());
            return ret >= 0;
        }
        public bool ModDeleteValueT1Model(int IntValue, ValueT1Model item)
        {
            string Msg;
            List<Parameter> par = new List<Parameter>();

            if (item == null)
            {
                MessageBox.Show("item is null");
                return false;
            }

            par.Add(new Parameter("@IntValue", IntValue));
            par.Add(new Parameter("@StringValue", item.StringValue));

            var ret = _sqlServiceDataRowTable.ExecuteModData("[SQL_CRUD].[ModDeleteValueT1Model]", out Msg, par);
            MessageBox.Show(Msg + ret.ToString());
            return ret == 0;
        }
        public ValueT1Model[] GetValueT1ModelWithParametr(int IntValue)
        {
            List<ValueT1Model> list = new List<ValueT1Model>();
            var dt = _sqlServiceDataRowTable.ExecuteSqlProcedureTable("[SQL_].[GetValueT1ModelWithParametr]", new Parameter("@IntValue", IntValue));
            foreach (DataRow row in dt.Rows)
                list.Add(new ValueT1Model(row));
            return list.ToArray();
        }
        public string GetValueT1ModelLabel_v2()
        {
            var result = _sqlServiceDataRowTable.ExecuteSqlProcedureSingleRow("[SQL_].[GetValueT1ModelLabel]")["LABELTest"].ToString();
            return result;
        }
        public void ModValueT1ModelWithOutParametr(string StringValue, ValueT1Model item)
        {
            string Msg;
            List<Parameter> par = new List<Parameter>();
            List<Parameter> parO = new List<Parameter>();

            par.Add(new Parameter("@StringValue", StringValue));
            par.Add(new Parameter("@DoubleVaule", item.DoubleVaule));
            par.Add(new Parameter("@DateTimeValue", item.DateTimeValue));
            par.Add(new Parameter("@NewRowId", null));

            IEnumerable<Parameter> ie = par;
            IEnumerable<Parameter> ieO = parO;

            var ret = _sqlServiceDataRowTable.ExecuteModData("[SQL_CRUD].[ModValueT1ModelWithOutParametr]", out Msg, ref ieO, ie);
            MessageBox.Show(Msg + ret.ToString());
        }
        public Dictionary<int, string> GetValueT1Model_Dictionary()
        {
            var result = _sqlServiceDataRowTable.ExecuteSqlProcedureDictionary("[SQL_].[GetValueT1Model_Dictionary]");
            return result;
        }
        public bool ModValueT1ModelAddTable(ValueT1Model mo, List<ValueT1Model> qtys, out List<ValueT1Model> cvs)
        {
            DataTable AddTable = new DataTable();
            AddTable.Columns.Add("DoubleVaule", typeof(double));
            AddTable.Columns.Add("StringValue", typeof(string));

            foreach (var k in qtys)
            {
                var row = AddTable.NewRow();
                row["DoubleVaule"] = k.DoubleVaule;
                row["StringValue"] = k.StringValue;
                AddTable.Rows.Add(row);
            }

            IEnumerable<Parameter> par = new List<Parameter>
            {
                new Parameter("@DateTimeValue", mo.DateTimeValue),
                new Parameter("@AddTable", AddTable)
            };

            IEnumerable<Parameter> parO = new List<Parameter>
            {
                new Parameter("@UserMsg", null),
                new Parameter("@ReturnCode", null)
            };

            var ret = _sqlServiceDataRowTable.ExecuteModDataTable("[SQL_CRUD].[ModValueT1ModelAddTable]", ref parO, par);
            var intRet = int.Parse(parO.Where(x => x.Name == "@ReturnCode").First().Value.ToString());
            var strOut = parO.Where(x => x.Name == "@UserMsg").First().Value.ToString();

            cvs = new List<ValueT1Model>();

            foreach (DataRow row in ret.Rows)
                cvs.Add(new ValueT1Model(row));

            return intRet == 0;
        }
        public void ModValueT1ModelParameters(string StringValue, DateTime DateTimeValue, float DoubleVaule)
        {
            string Msg;
            var par = new List<Parameter>
            {
                new Parameter("@StringValue", StringValue),
                new Parameter("@DateTimeValue", DateTimeValue),
                new Parameter("@DoubleVaule", DoubleVaule),
            };

            var ret = _sqlServiceDataRowTable.ExecuteModData("[SQL_CRUD].[ModValueT1ModelParameters]", out Msg, par);
            MessageBox.Show(Msg + ret.ToString());
        }
        public  ValueT1Model GetValueT1Model_OneRow(int IntValue)
        {
            string Msg = null;

            var List = new List<Parameter>();
            var outList = new List<Parameter>();

            List.Add(new Parameter("@IntValue", IntValue));
            outList.Add(new Parameter("@UserMsg", Msg));

            IEnumerable<Parameter> ListIE = List;
            IEnumerable<Parameter> outListIE = outList;

            var dt = _sqlServiceDataRowTable.ExecuteSqlProcedureTable("[SQL_].[GetValueT1Model_OneRow]", ref outListIE, ListIE,null);

            Msg = outListIE.Where(x => x.Name == "@UserMsg").First().Value.ToString();
            if (!string.IsNullOrWhiteSpace(Msg))
                    MessageBox.Show(Msg);

            return new ValueT1Model(dt.Rows[0], IntValue);
        }
        public bool ModValueT1ModelParametersOneRow(int IntValue, string StringValue)
        {
            string Msg;
            var ret = _sqlServiceDataRowTable.ExecuteModData("[SQL_CRUD].[ModValueT1ModelParametersOneRow]", out Msg, new Parameter("@IntValue", IntValue), new Parameter("@StringValue", StringValue));
            MessageBox.Show(Msg + ret);
            return ret >= 0;
        }
    }
}
