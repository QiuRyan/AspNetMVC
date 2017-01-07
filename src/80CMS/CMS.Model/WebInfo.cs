using CMS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Model
{
    /// <summary>
    /// 网站信息
    /// </summary>
    [TableName("T_WEBINFO")]
    public class WebInfo
    {
        /// <summary>
        /// 网站编号
        /// </summary>
        [PrimaryKey]
        public string SystemID { get; set; }

        /// <summary>
        /// 网站名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 网站Logo
        /// </summary>
        public string Logo { get; set; }

        /// <summary>
        /// 网址
        /// </summary>
        public string WebSite { get; set; }

        /// <summary>
        /// 公司地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 电子邮件
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        public string TelePhone { get; set; }

        /// <summary>
        /// 手机
        /// </summary>
        public string MobilePhone { get; set; }

        /// <summary>
        /// 传真
        /// </summary>
        public string Fax { get; set; }

        /// <summary>
        /// 其他描述
        /// </summary>
        public string Description { get; set; }

    }

    /// <summary>
    /// 前台首页导航
    /// </summary>
    [TableName("T_NAVIGATIONS")]
    public class Navigation
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
