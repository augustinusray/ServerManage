using Domain.DTO;
using Domain.Entitys;
using Domain.Para;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepositorys
{
    public interface IUserRepository:IRepository<User,string>
    {
        /// <summary>
        /// 用户列表分页
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        Task<PaginatedItemsVM<UserDTO>> GetUserList(PagePara para);
    }
}
