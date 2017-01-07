using CMS.Common;
using CMS.Model;
using CMS.Service.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Business
{
    public class MenuBll
    {
        SqlServer DB = SqlServer.Instance;
        public List<Menu> GetMenuList(string systemid)
        {
            string sqltext = string.Format("SELECT * FROM {0} t WHERE t.SYSTEMID='{1}'", CommonFunc.GetTableNameAttr<Menu>(), systemid);
            return CommonFunc.CovertTableToList<Menu>(DB.ExecuteDataTable(sqltext));
        }

        public bool UpdateMenu(string systemid, Menu model)
        {
            var sqltext = DB.CreateUpdateSqlText(model);
            return DB.ExecuteNonQuery(sqltext);
        }

        public bool DeleteMenuByID(string systemid, string menuid)
        {
            var sqltext = string.Format("DELETE FROM {0} t WHERE t.ID='{1}'", CommonFunc.GetTableNameAttr<Menu>(), menuid);
            return DB.ExecuteNonQuery(sqltext);
        }

        public bool CreateMenu(string systemid, Menu model)
        {
            return DB.ExecuteNonQuery(DB.CreateInsertSqlText(model));
        }
    }
}
