using CMS.Common;
using CMS.Model;
using CMS.Service.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> strs = new List<string>() { "aa", "bb", "cc" };
            var v = strs.Aggregate((curr, next) => { return curr + "," + next; });

            var name = CommonFunc.GetTableNameAttr<Menu>();
            Menu m = new Menu() { ID = "1", Name = "m1", UID = "0" };
            var text = SqlServer.Instance.CreateInsertSqlText<Menu>(m);
            Console.Write(name);
            Console.ReadKey();
        }
    }
}
