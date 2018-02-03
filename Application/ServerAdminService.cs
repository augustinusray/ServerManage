using Application.Iservices;
using Domain.DTO;
using Domain.IRepositorys;
using Domain.Para;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class ServerAdminService:IServerAdminService
    {
        /// <summary>
        /// 仓储
        /// </summary>
        private readonly IServerListRepository _iserverlistrepository;

        /// <summary>
        /// 注入仓储
        /// </summary>
        /// <param name="iserverlistrepository"></param>
        public ServerAdminService(IServerListRepository iserverlistrepository)
        {
            _iserverlistrepository = iserverlistrepository;
        }

        /// <summary>
        /// 服务器列表分页
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public async Task<List<ServerListDTO>> GetServerList(PagePara para)
        {
            return await _iserverlistrepository.GetServerList(para);
        }
    }
}
