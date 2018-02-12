using Domain.Entitys;
using Domain.IRepositorys;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameWorkCore.Repositorys
{
    public class UserLoginLogRepository : Repository<UserLoginLog, string>, IUserLoginLogRepository
    {
        public UserLoginLogRepository(ServerManageDbContext dbContext) : base(dbContext)
        { }
    }
}
