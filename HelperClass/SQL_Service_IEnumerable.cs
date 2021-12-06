using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HelperClass
{
    public static class SQL_Service_IEnumerable<T>
    {
        public static string ConnectionString()
        {
            return Config.GetSqlConnectionString();
        }

        public static IEnumerable<T> View(string view)
        {
            var results = new List<T>();

            using (var conn = new SqlConnection(ConnectionString()))
            {
                conn.Open();
                var query = "SELECT * FROM " + view;
                var cmd = new SqlCommand(query, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var item = Activator.CreateInstance<T>();
                        foreach (var property in typeof(T).GetProperties())
                        {
                            if (!reader.IsDBNull(reader.GetOrdinal(property.Name)))
                            {
                                Type convertTo = Nullable.GetUnderlyingType(property.PropertyType) ??
                                                 property.PropertyType;
                                property.SetValue(item, Convert.ChangeType(reader[property.Name], convertTo), null);
                            }
                        }
                        results.Add(item);
                    }
                    reader.Close();
                }
                conn.Close();
                return results;

            }
        }
        public static IEnumerable<T> StoredProcedure<T>(string storedProcedure) where T : new()
        {
            var data = new List<T>();

            using (var conn = new SqlConnection(ConnectionString()))
            {
                var com = new SqlCommand();
                com.Connection = conn;
                com.CommandType = CommandType.StoredProcedure;

                com.CommandText = storedProcedure;
                var adapt = new SqlDataAdapter();
                adapt.SelectCommand = com;
                var dataset = new DataSet();
                adapt.Fill(dataset);

                foreach (DataRow row in dataset.Tables[0].Rows)
                {
                    var newT = new T();

                    foreach (DataColumn col in dataset.Tables[0].Columns)
                    {
                        var property = newT.GetType().GetProperty(col.ColumnName);
                        property.SetValue(newT, row[col.ColumnName]);
                    }
                    data.Add(newT);
                }

                return data;
            }
        }
        public static IEnumerable<T> StoredProcedureWithParameters<T>(string storedProcedure, T model) where T : new()
        {
            var data = new List<T>();

            using (var con = new SqlConnection(ConnectionString()))
            {
                using (var cmd = new SqlCommand(storedProcedure, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = storedProcedure;

                    foreach (var prop in model.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
                    {
                        cmd.Parameters.AddWithValue("@" + prop.Name, prop.GetValue(model, null));
                    }

                    var adapt = new SqlDataAdapter();
                    adapt.SelectCommand = cmd;
                    var dataset = new DataSet();
                    adapt.Fill(dataset);

                    foreach (DataRow row in dataset.Tables[0].Rows)
                    {
                        var newT = new T();

                        foreach (DataColumn col in dataset.Tables[0].Columns)
                        {
                            var property = newT.GetType().GetProperty(col.ColumnName);
                            property.SetValue(newT, row[col.ColumnName]);
                        }
                        data.Add(newT);
                    }
                    return data;
                }
            }
        }
        public static void StoredProcedureWithParameters(string storedProcedure, T model)
        {
            using (var con = new SqlConnection(ConnectionString()))
            {
                using (var cmd = new SqlCommand(storedProcedure, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    foreach (var prop in model.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
                    {
                        cmd.Parameters.AddWithValue("@" + prop.Name, prop.GetValue(model, null));
                    }
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
    }
}
