using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Iservices;
using Microsoft.AspNetCore.Mvc;
using Domain.Para;
using ServerManage.ViewModels;
using AutoMapper;
using Domain.Entitys;

namespace ServerManage.Controllers
{
    public class ServerAdminController : BaseController
    {
        private readonly IServerAdminService _serverAdminService;

        private readonly IMapper _imapper;

        public ServerAdminController(IServerAdminService serverAdminService, IMapper mapper)
        {
            _serverAdminService = serverAdminService;
            _imapper = mapper;
        }

        [HttpGet]
        public IActionResult ServerList()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetServerList([FromBody]PagePara para)
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
        public async Task<IActionResult> AddServer(AddServerVM model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var server = _imapper.Map<AddServerVM, ServerList>(model);
            await _serverAdminService.AddServer(server);
            return ModalAlert("", "添加成功", "Success");
        }
    }
}