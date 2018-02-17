using Domain.DTO;
using Domain.Entitys;
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
        Task<PaginatedItemsVM<ServerListDTO>> GetServerList(PagePara para);

        /// <summary>
        /// 服务器列表分页
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        Task AddServer(ServerList model);
    }
}
