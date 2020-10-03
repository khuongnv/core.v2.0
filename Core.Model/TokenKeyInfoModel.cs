using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class TokenKeyInfoModel
    {
        public string TokenKey { get; set; }
        /// <summary>
        /// Module cần lấy phân quyền
        /// </summary>
        public int ModuleId { get; set; }
        /// <summary>
        /// Có lấy phân quyền theo hệ thống hay không
        /// </summary>
        public bool IsGetPrivilege { get; set; }
    }
}
