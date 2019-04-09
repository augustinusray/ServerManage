using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServerManage.ViewModels.UserAdmin
{
    public class EditUserVM
    {
        [HiddenInput]
        [MaxLength(450)]
        public string Id { get; set; }

        [MaxLength(50)]
        [Display(Name = "账号")]
        [Required]
        [RegularExpression("^[a-zA-Z0-9_]{6,20}$", ErrorMessage = "用户名由6位至20位字母或数字组成。")]
        [ReadOnly(true)]
        public string UserName { get; set; }

        [StringLength(20, ErrorMessage = "{0} 必须至少包含 {2} 个字符,最多20个字符。", MinimumLength = 6)]
        [Display(Name = "密码")]
        [Required(ErrorMessage = "请输入密码")]
        [DataType(DataType.Password)]
        public string UserPass { get; set; }

        /// <summary>
        /// 授权
        /// </summary>
        [Range(1, 10, ErrorMessage = "权限必须在1和10之间")]
        [Display(Name = "权限")]
        [Required(ErrorMessage = "请输入权限")]
        public int UserAuthority { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        [MaxLength(256)]
        [Display(Name = "描述")]
        public string Description { get; set; }
    }
}
