﻿using Application.Iservices;
using Domain.DTO;
using Domain.Entitys;
using Domain.IRepositorys;
using Domain.Para;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace Application
{
    public class ServerAdminService : IServerAdminService
    {
        /// <summary>
        /// 仓储
        /// </summary>
        private readonly IServerListRepository _iserverlistrepository;

        /// <summary>
        /// 注入仓储
        /// </summary>
        /// <param name="iserverlistrepository"></param>
        public ServerAdminService(IServerListRepository iserverlistrepository)
        {
            _iserverlistrepository = iserverlistrepository;
        }

        /// <summary>
        /// 服务器列表分页
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public async Task<PaginatedItemsVM<ServerListDTO>> GetServerList(PagePara para)
        {
            return await _iserverlistrepository.GetServerList(para);
        }

        /// <summary>
        /// 服务器列表分页
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public async Task AddServer(ServerList model)
        {
            model.ServerPass = AESDEncrypt.Encrypt(model.ServerPass);
            await _iserverlistrepository.Insert(model);
            await _iserverlistrepository.Save();
        }

    }
}
