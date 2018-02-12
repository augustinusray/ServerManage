using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Iservices;
using Microsoft.AspNetCore.Mvc;
using Domain.Para;
using ServerManage.ViewModels;

namespace ServerManage.Controllers
{
    public class ServerAdminController : BaseController
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

        [HttpPost]
        public async Task<IActionResult> GetServerList(PagePara para)
        {
            var model = await _serverAdminService.GetServerList(para);

            return Json(new { total = model.Count, rows = model.Data });
        }


        [HttpGet]
        public IActionResult AddServer()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddServer(AddServerVM model)
        {
            return View();
        }
    }
}