using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServerManage.ViewModels
{
    public class AddServerVM
    {
        [MaxLength(128)]
        public string ServerId { get; set; }

        [MaxLength(50)]
        public string ServerName { get; set; }

        [MaxLength(128)]
        public string ServerPass { get; set; }
        /// <summary>
        /// 授权
        /// </summary>
        [Range(1, 10)]
        public int ServerAuthority { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        [MaxLength(256)]
        public string Description { get; set; }
    }
}
