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

            if (!string.IsNullOrEmpty(para.Name))
                query.Where(m=>m.ServerName.Contains(para.Name));

            if (!string.IsNullOrEmpty(para.Description))
                query.Where(m => m.Description.Contains(para.Description));

            var totalCount = query.Count();

            if (totalCount == 0)
                return new PaginatedItemsVM<ServerListDTO>(para.PageIndex, para.PageSize, totalCount, new List<ServerListDTO>());

            var list = await query.Skip(para.PageSize * (para.PageIndex - 1))
                .Take(para.PageSize)
                .Select(x=>new ServerListDTO {
                    ServerName=x.ServerName,
                    ServerAuthority=x.ServerAuthority,
                    ServerId=x.ServerId,
                    Description=x.Description
                }).ToListAsync();

            return new PaginatedItemsVM<ServerListDTO>(para.PageIndex, para.PageSize, totalCount, list);
        }
    }
}
