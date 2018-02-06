using Domain.DTO;
using Domain.Entitys;
using Domain.Para;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepositorys
{
    public interface IServerListRepository : IRepository<ServerList, string>
    {
        /// <summary>
        /// 服务器列表分页
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        Task<PaginatedItemsVM<ServerListDTO>> GetServerList(PagePara para);
    }
}
