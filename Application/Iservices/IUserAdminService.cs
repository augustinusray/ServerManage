using Domain.DTO;
using Domain.Para;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Iservices
{
    public interface IUserAdminService
    {
        /// <summary>
        /// 用户列表分页
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        Task<PaginatedItemsVM<UserDTO>> GetUserList(PagePara para);


        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        Task<int> DeleteUser(string[] users);
    }
}
