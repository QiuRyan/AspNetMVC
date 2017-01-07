using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Common
{
    public class CommonFunc
    {
        public static List<T> CovertTableToList<T>(DataTable data)
        {
            if (data == null) return null;
            List<T> Result = new List<T>();
            var props = typeof(T).GetProperties(System.Reflection.BindingFlags.DeclaredOnly | System.Reflection.BindingFlags.Public);
            data.Rows.Cast<DataRow>().ToList().ForEach(row =>
            {
                T model = default(T);
                data.Columns.Cast<DataColumn>().ToList().ForEach(col =>
                {
                    props.First(item => item.Name == col.ColumnName).SetValue(model, row[col]);
                });
                Result.Add(model);
            });
            return Result;
        }


        public static string GetTableNameAttr<T>()
        {
            return (Attribute.GetCustomAttribute(typeof(T), typeof(TableNameAttribute)) as TableNameAttribute).TableName;
        }
    }
}
