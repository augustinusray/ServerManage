using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServerManage.ViewModels
{
    public class AddServerVM
    {
        [MaxLength(50)]
        [Display(Name = "服务器IP")]
        [Required(ErrorMessage = "请输入服务器IP")]
        [RegularExpression("^((25[0-5]|2[0-4]\\d|[1]{1}\\d{1}\\d{1}|[1-9]{1}\\d{1}|\\d{1})($|(?!\\.$)\\.)){4}$", ErrorMessage = "请输入正确的IP")]
        public string ServerName { get; set; }

        [StringLength(64, ErrorMessage = "{0} 必须至少包含 {2} 个字符,最多64个字符。", MinimumLength = 8)]
        [Display(Name = "密码")]
        [Required(ErrorMessage = "请输入密码")]
        [DataType(DataType.Password)]
        public string ServerPass { get; set; }
        /// <summary>
        /// 授权
        /// </summary>
        [Range(1, 10)]
        [Display(Name = "权限")]
        [Required(ErrorMessage = "请输入权限")]
        public int ServerAuthority { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        [MaxLength(256)]
        [Display(Name = "描述")]
        public string Description { get; set; }
    }
}
