using Domain.DTO;
using Domain.Entitys;
using Domain.IRepositorys;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using Domain.Para;
using System.Threading.Tasks;

namespace EntityFrameWorkCore.Repositorys
{
    public class ServerListRepository:Repository<ServerList,string>, IServerListRepository
    {
        public ServerListRepository(ServerManageDbContext dbcontext) : base(dbcontext)
        {

        }

        /// <summary>
        /// 服务器列表分页
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public async Task<List<ServerListDTO>> GetServerList(PagePara para)
        {
            var q = from s in _dbContext.ServerList
                    orderby s.ServerName ascending
                    select new ServerListDTO
                    {
                        ServerName = s.ServerName,
                        ServerAuthority = s.ServerAuthority,
                        ServerId = s.ServerId
                    };

            var list = await q.Skip(para.PageSize * (para.PageIndex - 1)).Take(para.PageSize)
                .ToListAsync();

            return list;
        }
    }
}
