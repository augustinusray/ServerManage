using Application.Enum;
using Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Iservices
{
    public interface IHomeService
    {

        /// <summary>
        /// 新增登录日志
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task AddUserLoginLog(string ip, string userId);


        /// <summary>
        /// 获取 服务器/用户 数量
        /// </summary>
        /// <returns></returns>
        Task<int[]> GetServerAndUser();
    }
}
