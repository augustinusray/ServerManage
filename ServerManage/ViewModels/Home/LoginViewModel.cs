using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServerManage.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "用户名不能为空")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "密码不能为空")]
        [DataType(DataType.Password)]
        public string PassWord { get; set; }
    }
}
