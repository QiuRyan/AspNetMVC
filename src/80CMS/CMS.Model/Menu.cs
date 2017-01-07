using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.Common;

namespace CMS.Model
{
    /// <summary>
    /// 后台菜单
    /// </summary>
    [TableName("T_MENU")]
    public class Menu
    {
        /// <summary>
        /// ID
        /// </summary>
        [PrimaryKey]
        public string ID { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 父ID
        /// </summary>
        public string UID { get; set; }

        /// <summary>
        /// 系统编号
        /// </summary>
        public string SystemID { get; set; }
    }
}
