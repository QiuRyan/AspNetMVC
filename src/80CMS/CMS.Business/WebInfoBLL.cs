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
    public class WebInfoBLL
    {
        SqlServer DB = SqlServer.Instance;
        public List<WebInfo> GetWebInfo(string systemid)
        {
            string sqltext = string.Format("SELECT * FROM {0} t WHERE t.SYSTEMID='{1}'", CommonFunc.GetTableNameAttr<WebInfo>(), systemid);
            return CommonFunc.CovertTableToList<WebInfo>(DB.ExecuteDataTable(sqltext));
        }

        public bool UpdateWebInfo(string systemid, WebInfo model)
        {
            var sqltext = DB.CreateUpdateSqlText(model);
            return DB.ExecuteNonQuery(sqltext);
        }

        public bool DeleteWebInfoByID(string systemid, string menuid)
        {
            var sqltext = string.Format("DELETE FROM {0} t WHERE t.ID='{1}'", CommonFunc.GetTableNameAttr<WebInfo>(), menuid);
            return DB.ExecuteNonQuery(sqltext);
        }

        public bool CreateWebInfo(string systemid, WebInfo model)
        {
            return DB.ExecuteNonQuery(DB.CreateInsertSqlText(model));
        }

        public List<Navigation> GetNavigation(string systemid)
        {
            string sqltext = string.Format("SELECT * FROM {0} t WHERE t.SYSTEMID='{1}'", CommonFunc.GetTableNameAttr<Navigation>(), systemid);
            return CommonFunc.CovertTableToList<Navigation>(DB.ExecuteDataTable(sqltext));
        }

        public bool UpdateNavigation(string systemid, Navigation model)
        {
            var sqltext = DB.CreateUpdateSqlText(model);
            return DB.ExecuteNonQuery(sqltext);
        }

        public bool DeleteNavigationByID(string systemid, string nvgid)
        {
            var sqltext = string.Format("DELETE FROM {0} t WHERE t.ID='{1}'", CommonFunc.GetTableNameAttr<Navigation>(), nvgid);
            return DB.ExecuteNonQuery(sqltext);
        }

        public bool CreateNavigation(string systemid, Navigation model)
        {
            return DB.ExecuteNonQuery(DB.CreateInsertSqlText(model));
        }
    }
}
