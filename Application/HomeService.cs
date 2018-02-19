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
        private readonly IUserRepository _userrepository;
        private readonly IServerListRepository _serverListRepository;
        private readonly IUserLoginLogRepository _userLoginLogRepository;

        public HomeService(IUserRepository iuserrepository, IUserLoginLogRepository userLoginLogRepository, IServerListRepository serverListRepository)
        {
            _userrepository = iuserrepository;
            _userLoginLogRepository = userLoginLogRepository;
            _serverListRepository = serverListRepository;
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

        /// <summary>
        /// 获取 服务器/用户 数量
        /// </summary>
        /// <returns></returns>
        public async Task<int[]> GetServerAndUser()
        {
            var serverCount=await _serverListRepository.GetCount();

            var userCount = await _userrepository.GetCount();

            return new int[] { serverCount, userCount };
        }
    }
}
