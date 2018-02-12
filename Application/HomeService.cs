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
        private readonly IUserRepository _iuserrepository;
        private readonly IUserLoginLogRepository _userLoginLogRepository;

        public HomeService(IUserRepository iuserrepository, IUserLoginLogRepository userLoginLogRepository)
        {
            _iuserrepository = iuserrepository;
            _userLoginLogRepository = userLoginLogRepository;
        }

        /// <summary>
        /// 新增登录日志
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task AddUserLoginLog(string ip,string userId)
        {
            var entity = new UserLoginLog
            {
                Ip = ip,
                LoginTime = DateTime.Now,
                UserId = userId
            };
            await _userLoginLogRepository.Insert(entity);

            await _userLoginLogRepository.Save();
        }
    }
}
