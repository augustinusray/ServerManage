using Domain.Entitys;
using Domain.IRepositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityFrameWorkCore.Repositorys
{
    /// <summary>
    /// 用户管理仓储实现
    /// </summary>
    public class UserRoleRepository : Repository<UserRole,string>, IUserRoleRepository
    {
        public UserRoleRepository(ServerManageDbContext dbcontext) : base(dbcontext)
        {

        }
    }
}
