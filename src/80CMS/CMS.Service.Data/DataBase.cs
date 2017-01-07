using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace CMS.Service.Data
{
    public abstract class DataBase
    {
        protected string ConnStr = string.Empty;
        protected IDbCommand Cmd = null;
        protected IDbConnection Conn = null;
        protected IDbTransaction Trans = null;

        private void OpenConn()
        {
            if (this.Conn.State != ConnectionState.Open)
                this.Conn.Open();
        }

        private void CloseConn()
        {
            if (this.Conn.State != ConnectionState.Closed)
                this.Conn.Close();
        }

        protected virtual void PrepareConnStr(string connstr)
        {
            this.ConnStr = connstr;
        }

        protected virtual void PrepareCmd(string sqltext, CommandType cmdtype = CommandType.Text, params IDbDataParameter[] sqlparams)
        {
            this.Cmd = this.Conn.CreateCommand();
            this.Cmd.Connection = this.Conn;
            this.Cmd.CommandType = cmdtype;
            this.Cmd.CommandText = sqltext;
            this.OpenConn();
            if (sqlparams != null)
            {
                sqlparams.ToList().ForEach(p => this.Cmd.Parameters.Add(p));
            }
        }

        public virtual bool ExecuteNonQuery(string sqltext)
        {
            return this.ExecuteNonQuery(sqltext);
        }

        public virtual bool ExecuteNonQuery(string sqltext, params IDbDataParameter[] sqlparams)
        {
            this.PrepareCmd(sqltext: sqltext, sqlparams: sqlparams);
            var result = this.Cmd.ExecuteNonQuery();
            this.CloseConn();
            return result > 0;
        }

        public virtual object ExecuteScalar(string sqltext)
        {
            return this.ExecuteScalar(sqltext);
        }

        public virtual object ExecuteScalar(string sqltext, params IDbDataParameter[] sqlparams)
        {
            this.PrepareCmd(sqltext: sqltext, sqlparams: sqlparams);
            var result = this.Cmd.ExecuteScalar();
            this.CloseConn();
            return result;
        }

        public abstract DataSet ExecuteDataSet(string sqltext, params IDbDataParameter[] sqlparams);

        public abstract DataTable ExecuteDataTable(string sqltext, params IDbDataParameter[] sqlparams);


    }
}
