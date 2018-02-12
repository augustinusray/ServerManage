using Domain.DTO;
using Domain.Entitys;
using Domain.IRepositorys;
using Domain.Para;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameWorkCore.Repositorys
{
    /// <summary>
    /// 用户管理仓储实现
    /// </summary>
    public class UserRepository : Repository<User,string>, IUserRepository
    {
        public UserRepository(ServerManageDbContext dbcontext) : base(dbcontext)
        {

        }

        /// <summary>
        /// 用户列表分页
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public async Task<PaginatedItemsVM<UserDTO>> GetUserList(PagePara para)
        {
            var query = _dbContext.Users.AsQueryable();

            if (!string.IsNullOrEmpty(para.Name))
                query.Where(m => m.UserName.Contains(para.Name));

            if (!string.IsNullOrEmpty(para.Description))
                query.Where(m => m.Description.Contains(para.Description));

            var totalCount = query.Count();

            if (totalCount == 0)
                return new PaginatedItemsVM<UserDTO>(para.PageIndex, para.PageSize, totalCount, new List<UserDTO>());

            var list = await query.Skip(para.PageSize * (para.PageIndex - 1))
                .Take(para.PageSize)
                .Select(x => new UserDTO
                {
                    UserId=x.Id,
                    UserName = x.UserName,
                    UserAuthority = x.UserAuthority,
                    Description = x.Description
                }).ToListAsync();

            return new PaginatedItemsVM<UserDTO>(para.PageIndex, para.PageSize, totalCount, list);
        }
    }
}
