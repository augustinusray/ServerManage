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
        /// <summary>
        /// 检查用户是存在
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="password">密码</param>
        /// <returns>存在返回用户实体，否则返回NULL</returns>
        public UserRole CheckUser(string userName, string password)
        {
            return _dbContext.Set<UserRole>().FirstOrDefault(it => it.UserName == userName && it.UserPass == password);
        }
    }
}
