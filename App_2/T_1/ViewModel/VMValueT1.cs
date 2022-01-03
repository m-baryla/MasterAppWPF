using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using App_2.T_1.Model;
using BaseAppClass;
using Interface;

namespace App_2.T_1.ViewModel
{
    public class VMValueT1 : ViewModelBaseService
    {
        public ICommand ListBoxCommand { get; set; }

        private string selectedFileObject;
        public string SelectedFileObject
        {
            get { return selectedFileObject; }
            set { if (selectedFileObject == value) return; selectedFileObject = value; OnPropertyChanged("SelectedFileObject"); }
        }

        private List<MValueT1> list_AAAA;
        public List<MValueT1> List_AAAA
        {
            get { return list_AAAA; }
            set { if (list_AAAA == value) return; list_AAAA = value; OnPropertyChanged("List_AAAA"); }
        }
        
        private ISQL _sql;
        public VMValueT1(ISQL _sql)
        {
            this._sql = _sql;
            list_AAAA = GetValueT1Model_DataTable();
            ListBoxCommand = new RelayCommandService(_ => _ListBoxCommand());
        }
        private void _ListBoxCommand()
        {
            MessageBox.Show(selectedFileObject);
        }

        #region SQL
        public List<MValueT1> GetValueT1Model_DataTable()
        {
            List<MValueT1> logs = new List<MValueT1>();
            var dt = _sql.ExecuteSqlProcedureTable("[SQL_].[GetValueT1Model_DataTable]");
            foreach (DataRow row in dt.Rows)
                logs.Add(new MValueT1(row));
            return logs;
        }
        public List<string> GetValueT1Model_DataTable_WithParametr(int IntValue)
        {
            List<string> logs = new List<string>();
            var dt = _sql.ExecuteSqlProcedureTable("[SQL_].[GetValueT1Model_DataTable_WithParametr]", new Parameter("@IntValue", IntValue));
            foreach (DataRow row in dt.Rows)
                logs.Add(row["StringValue"].ToString());
            return logs;
        }
        public MValueT1 GetValueT1Model_DataTable_SingleRow(string StringValue)
        {
            var tb = _sql.ExecuteSqlProcedureTable("[SQL_].[GetValueT1Model_DataTable_SingleRow]", new Parameter("@StringValue", StringValue));
            if (tb.Rows.Count < 1)
                return new MValueT1();
            return new MValueT1(tb.Rows[0]);
        }
        public string GetValueT1ModelLabel()
        {
            var tb = _sql.ExecuteSqlProcedureSingleRow("[SQL_].[GetValueT1ModelLabel]");
            var result =  tb[0].ToString();
            return result;
        }
        public bool ModValueT1Model(string StringValue, MValueT1 item)
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

            var ret = _sql.ExecuteModData("[SQL_CRUD].[ModValueT1Model]", out Msg, par);
            MessageBox.Show(Msg + ret.ToString());
            return ret >= 0;
        }
        public bool ModDeleteValueT1Model(int IntValue, MValueT1 item)
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

            var ret = _sql.ExecuteModData("[SQL_CRUD].[ModDeleteValueT1Model]", out Msg, par);
            MessageBox.Show(Msg + ret.ToString());
            return ret == 0;
        }
        public MValueT1[] GetValueT1ModelWithParametr(int IntValue)
        {
            List<MValueT1> list = new List<MValueT1>();
            var dt = _sql.ExecuteSqlProcedureTable("[SQL_].[GetValueT1ModelWithParametr]", new Parameter("@IntValue", IntValue));
            foreach (DataRow row in dt.Rows)
                list.Add(new MValueT1(row));
            return list.ToArray();
        }
        public string GetValueT1ModelLabel_v2()
        {
            var result = _sql.ExecuteSqlProcedureSingleRow("[SQL_].[GetValueT1ModelLabel]")["LABELTest"].ToString();
            return result;
        }
        public void ModValueT1ModelWithOutParametr(string StringValue, MValueT1 item)
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

            var ret = _sql.ExecuteModData("[SQL_CRUD].[ModValueT1ModelWithOutParametr]", out Msg, ref ieO, ie);
            MessageBox.Show(Msg + ret.ToString());
        }
        public Dictionary<int, string> GetValueT1Model_Dictionary()
        {
            var result = _sql.ExecuteSqlProcedureDictionary("[SQL_].[GetValueT1Model_Dictionary]");
            return result;
        }
        public bool ModValueT1ModelAddTable(MValueT1 mo, List<MValueT1> qtys, out List<MValueT1> cvs)
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

            var ret = _sql.ExecuteModDataTable("[SQL_CRUD].[ModValueT1ModelAddTable]", ref parO, par);
            var intRet = int.Parse(parO.Where(x => x.Name == "@ReturnCode").First().Value.ToString());
            var strOut = parO.Where(x => x.Name == "@UserMsg").First().Value.ToString();

            cvs = new List<MValueT1>();

            foreach (DataRow row in ret.Rows)
                cvs.Add(new MValueT1(row));

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

            var ret = _sql.ExecuteModData("[SQL_CRUD].[ModValueT1ModelParameters]", out Msg, par);
            MessageBox.Show(Msg + ret.ToString());
        }
        public  MValueT1 GetValueT1Model_OneRow(int IntValue)
        {
            string Msg = null;

            var List = new List<Parameter>();
            var outList = new List<Parameter>();

            List.Add(new Parameter("@IntValue", IntValue));
            outList.Add(new Parameter("@UserMsg", Msg));

            IEnumerable<Parameter> ListIE = List;
            IEnumerable<Parameter> outListIE = outList;

            var dt = _sql.ExecuteSqlProcedureTable("[SQL_].[GetValueT1Model_OneRow]", ref outListIE, ListIE,null);

            Msg = outListIE.Where(x => x.Name == "@UserMsg").First().Value.ToString();
            if (!string.IsNullOrWhiteSpace(Msg))
                    MessageBox.Show(Msg);

            return new MValueT1(dt.Rows[0], IntValue);
        }
        public bool ModValueT1ModelParametersOneRow(int IntValue, string StringValue)
        {
            string Msg;
            var ret = _sql.ExecuteModData("[SQL_CRUD].[ModValueT1ModelParametersOneRow]", out Msg, new Parameter("@IntValue", IntValue), new Parameter("@StringValue", StringValue));
            MessageBox.Show(Msg + ret);
            return ret >= 0;
        }
        #endregion

    }
}

