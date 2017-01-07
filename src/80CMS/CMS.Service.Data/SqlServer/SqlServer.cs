using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using CMS.Common;
using System.Reflection;

namespace CMS.Service.Data
{
    public class SqlServer : DataBase
    {
        public static readonly Lazy<SqlServer> lazy = new Lazy<SqlServer>(() => new SqlServer());

        public static SqlServer Instance
        {
            get { return lazy.Value; }
        }
        private SqlServer()
        {
            this.ConnStr = ConfigurationManager.ConnectionStrings[0].ConnectionString;
        }

        public override DataSet ExecuteDataSet(string sqltext, params IDbDataParameter[] sqlparams)
        {
            this.PrepareCmd(sqltext, CommandType.Text, sqlparams);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter((SqlCommand)this.Cmd);
            da.Fill(ds);
            return ds;
        }

        public override DataTable ExecuteDataTable(string sqltext, params IDbDataParameter[] sqlparams)
        {
            return ExecuteDataSet(sqltext, sqlparams).Tables[0];
        }

        public List<SqlParameter> CreateParameter<T>(T model)
        {
            var props = model.GetType().GetProperties(System.Reflection.BindingFlags.DeclaredOnly | System.Reflection.BindingFlags.Public).ToList();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Clear();
            props.ForEach(prop =>
            {
                parameters.Add(new SqlParameter(prop.Name, prop.GetValue(model)));
            });
            return parameters;
        }

        public string CreateUpdateSqlText<T>(T model)
        {
            StringBuilder sqltext = new StringBuilder();
            var props = model.GetType().GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance).ToList();
            var whereprops = props.Where(prop => prop.GetCustomAttributes(typeof(PrimaryKeyAttribute), false).Count() > 0).ToList();
            var updateprops = props.Except(whereprops).ToList();
            var tablename = CommonFunc.GetTableNameAttr<T>();
            sqltext.Append("UPDATE " + tablename + " SET ");
            updateprops.ForEach(prop =>
            {
                sqltext.Append(prop.Name + "='" + prop.GetValue(model) + "', ");
            });
            sqltext.Remove(sqltext.Length - 1, 3);
            sqltext.Append(" WHERE 1=1 ");
            whereprops.ForEach(prop =>
            {
                sqltext.Append(" AND " + prop.Name + "='" + prop.GetValue(model) + "'");
            });
            return sqltext.ToString();
        }

        public string CreateInsertSqlText<T>(T model)
        {
            StringBuilder sqltext = new StringBuilder();

            var props = model.GetType().GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance).ToList();
            var tablename = CommonFunc.GetTableNameAttr<T>();
            var fields = props.ConvertAll<string>((PropertyInfo prop) => { return prop.Name; }).Aggregate((curr, next) => { return curr + "," + next; });
            var values = props.ConvertAll<string>((PropertyInfo prop) => { return "'" + prop.GetValue(model).ToString() + "'"; }).Aggregate((curr, next) => curr + "," + next);
            sqltext.AppendFormat("INSERT INTO {0} ({1}) VALUES ({2}) ", tablename, fields, values);
            return sqltext.ToString();
        }
    }
}
