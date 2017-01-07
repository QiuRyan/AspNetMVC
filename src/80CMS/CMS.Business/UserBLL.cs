using CMS.Common;
using CMS.Model;
using CMS.Service.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Business
{
    public class UserBLL
    {
        SqlServer DB = SqlServer.Instance;
        public List<WebUser> GetWebUserList(string systemid)
        {
            string sqltext = string.Format("SELECT * FROM {0} t WHERE t.SYSTEMID='{1}'", CommonFunc.GetTableNameAttr<WebUser>(), systemid);
            return CommonFunc.CovertTableToList<WebUser>(DB.ExecuteDataTable(sqltext));
        }

        public bool UpdateWebUser(string systemid, WebUser model)
        {
            var sqltext = DB.CreateUpdateSqlText(model);
            return DB.ExecuteNonQuery(sqltext);
        }

        public bool DeleteWebUserByID(string systemid, string userid)
        {
            var sqltext = string.Format("DELETE FROM {0} t WHERE t.ID='{1}'", CommonFunc.GetTableNameAttr<WebUser>(), userid);
            return DB.ExecuteNonQuery(sqltext);
        }

        public bool CreateWebUser(string systemid, WebUser model)
        {
            return DB.ExecuteNonQuery(DB.CreateInsertSqlText(model));
        }
    }
}
