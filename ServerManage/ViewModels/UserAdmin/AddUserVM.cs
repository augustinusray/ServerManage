using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServerManage.ViewModels.UserAdmin
{
    public class AddUserVM
    {
        [MaxLength(50)]
        [Display(Name ="账号")]
        public string UserName { get; set; }

        [MaxLength(128)]
        [Display(Name = "密码")]
        public string UserPass { get; set; }

        [MaxLength(128)]
        [Display(Name = "确认密码")]
        [Compare("UserPass",ErrorMessage = "两次密码输入不一致")]
        public string ConfirmUserPass { get; set; }
        /// <summary>
        /// 授权
        /// </summary>
        [Range(1, 10)]
        [Display(Name = "权限")]
        public int UserAuthority { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        [MaxLength(256)]
        [Display(Name = "描述")]
        public string Description { get; set; }
    }
}
