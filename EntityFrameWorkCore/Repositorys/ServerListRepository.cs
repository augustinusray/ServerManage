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
    public class ServerListRepository : Repository<ServerList, string>, IServerListRepository
    {
        public ServerListRepository(ServerManageDbContext dbcontext) : base(dbcontext)
        {

        }

        /// <summary>
        /// 服务器列表分页
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public async Task<PaginatedItemsVM<ServerListDTO>> GetServerList(PagePara para)
        {
            var query =_dbContext.ServerList.AsQueryable();

            if (!string.IsNullOrEmpty(para.Search_Name))
                query.Where(m=>m.ServerName.Contains(para.Search_Name));

            if (!string.IsNullOrEmpty(para.Search_Description))
                query.Where(m => m.Description.Contains(para.Search_Description));

            var totalCount = query.Count();

            if (totalCount == 0)
                return new PaginatedItemsVM<ServerListDTO>(totalCount, new List<ServerListDTO>());

            var list = await query.Skip(para.Limit)
                .Take(para.Offset)
                .Select(x=>new ServerListDTO {
                    ServerName=x.ServerName,
                    ServerAuthority=x.ServerAuthority,
                    ServerId=x.ServerId,
                    Description=x.Description
                }).ToListAsync();

            return new PaginatedItemsVM<ServerListDTO>(totalCount, list);
        }
    }
}
