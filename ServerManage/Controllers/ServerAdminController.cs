using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Iservices;
using Microsoft.AspNetCore.Mvc;
using Domain.Para;

namespace ServerManage.Controllers
{
    public class ServerAdminController : Controller
    {
        private readonly IServerAdminService _serverAdminService;

        public ServerAdminController(IServerAdminService serverAdminService)
        {
            _serverAdminService = serverAdminService;
        }

        [HttpGet]
        public IActionResult ServerList()
        {
            return View();
        }

        
        public async Task<IActionResult> GetServerList(PagePara para)
        {

           var list=await _serverAdminService.GetServerList(para);

            return Json(list);
        }
    }
}