using Application.Iservices;
using Domain.DTO;
using Domain.IRepositorys;
using Domain.Para;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Entitys;
using Microsoft.AspNetCore.Identity;

namespace Application
{
    public class UserAdminService : IUserAdminService
    {
        /// <summary>
        /// 仓储
        /// </summary>
        private readonly IUserRepository _iuserrepository;

        private UserManager<User> _userManager;

        /// <summary>
        /// 注入仓储
        /// </summary>
        /// <param name="iuserrepository"></param>
        public UserAdminService(UserManager<User> userManager, IUserRepository iuserrepository)
        {
            _userManager = userManager;
            _iuserrepository = iuserrepository;
        }

        /// <summary>
        /// 用户列表分页
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public async Task<PaginatedItemsVM<UserDTO>> GetUserList(PagePara para)
        {
            return await _iuserrepository.GetUserList(para);
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        public async Task<int> DeleteUser(string[] users)
        {
            int count=0;
            foreach (var userId in users)
            {
                var user = await GetUser(userId);
                if (user != null)
                {
                    var result=await _userManager.DeleteAsync(user);
                    if (result.Succeeded)
                        ++count;
                }
            }
            return count;
        }

        /// <summary>
        /// 根据主键获取 user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<User> GetUser(string userId)
        {
            var user = await _iuserrepository.FirstOrDefault(m => m.Id.Equals(userId));
            return user;
        }

        /// <summary>
        /// 更新user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<bool> UpdateUser(User user)
        {
            _iuserrepository.Update(user);
            return (await _iuserrepository.Save() > 0) ? true : false;
        }
    }
}
