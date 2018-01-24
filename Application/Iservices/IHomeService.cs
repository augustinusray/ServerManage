using Application.Enum;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Iservices
{
    public interface IHomeService
    {
        /// <summary>
        /// 登录验证
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        Task<LoginEnum> LoginValidate(string username, string password);

    }
}
