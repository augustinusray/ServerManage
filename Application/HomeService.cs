using Application.Enum;
using Application.Iservices;
using Domain.Entitys;
using Domain.IRepositorys;
using System;
using System.Threading.Tasks;
using Utility;

namespace Application
{
    public class HomeService:IHomeService
    {
        private readonly IUserRoleRepository _iuserrolerepository;

        public HomeService(IUserRoleRepository iuserrolerepository)
        {
            _iuserrolerepository = iuserrolerepository;
        }

        /// <summary>
        /// 登录验证
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        public async Task<LoginEnum> LoginValidate(string username,string password)
        {
            var user= await _iuserrolerepository.FirstOrDefault(m=>m.UserName.Equals(username));

            if (user == null)
                return LoginEnum.用户名错误;
            else if (!AESDEncrypt.Decrypt(user.UserPass).Equals(password))
                return LoginEnum.密码错误;
            else
                return LoginEnum.登录成功;
        }
    }
}
