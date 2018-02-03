using Domain.DTO;
using Domain.Para;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Iservices
{
    public interface IServerAdminService
    {
        /// <summary>
        /// 服务器列表分页
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        Task<List<ServerListDTO>> GetServerList(PagePara para);
    }
}
