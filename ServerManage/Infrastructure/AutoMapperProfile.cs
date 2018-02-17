using AutoMapper;
using Domain.Entitys;
using ServerManage.ViewModels;
using ServerManage.ViewModels.UserAdmin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerManage.Infrastructure
{
    /// <summary>
    /// 
    /// </summary>
    public class AutoMapperProfile : Profile
    {
        /// <summary>
        /// 
        /// </summary>
        public AutoMapperProfile()
        {
            CreateMap<AddUserVM, User>();
            CreateMap<AddServerVM, ServerList>();
        }
    }
}
