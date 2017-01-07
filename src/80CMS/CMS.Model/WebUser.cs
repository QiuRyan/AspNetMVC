using CMS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Model
{
    /// <summary>
    /// 网站管理员
    /// </summary>
    [TableName("T_USER")]
    public class WebUser
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        [PrimaryKey]
        public string ID { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string PassWord { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        /// 电子邮件
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 手机
        /// </summary>
        public string MobilePhone { get; set; }

        /// <summary>
        /// 系统编号
        /// </summary>
        public string SystemID { get; set; }
    }
}
