using Application.Iservices;
using Domain.DTO;
using Domain.IRepositorys;
using Domain.Para;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class UserAdminService:IUserAdminService
    {
        /// <summary>
        /// 仓储
        /// </summary>
        private readonly IUserRepository _iuserrepository;

        /// <summary>
        /// 注入仓储
        /// </summary>
        /// <param name="iuserrepository"></param>
        public UserAdminService(IUserRepository iuserrepository)
        {
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
    }
}
