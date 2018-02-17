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
        [Required(ErrorMessage ="请输入账号")]
        [RegularExpression("^[a-zA-Z0-9_]{6,20}$", ErrorMessage = "用户名由6位至20位字母或数字组成。")]
        public string UserName { get; set; }

        [StringLength(20, ErrorMessage = "{0} 必须至少包含 {2} 个字符,最多20个字符。", MinimumLength = 6)]
        [Display(Name = "密码")]
        [Required(ErrorMessage = "请输入密码")]
        [DataType(DataType.Password)]
        public string UserPass { get; set; }

        [StringLength(20, ErrorMessage = "{0} 必须至少包含 {2} 个字符,最多20个字符。", MinimumLength = 6)]
        [Display(Name = "确认密码")]
        [DataType(DataType.Password)]
        [Compare("UserPass",ErrorMessage = "两次密码输入不一致")]
        public string ConfirmUserPass { get; set; }
        /// <summary>
        /// 授权
        /// </summary>
        [Range(1, 10)]
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
