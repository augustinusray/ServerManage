using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Iservices;
using Domain.Para;
using Microsoft.AspNetCore.Mvc;

namespace ServerManage.Controllers
{
    public class UserAdminController : BaseController
    {
        private readonly IUserAdminService _userAdminService;

        public UserAdminController(IUserAdminService userAdminService)
        {
            _userAdminService = userAdminService;
        }

        [HttpGet]
        public IActionResult UserList()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetUserList(PagePara para)
        {
            var model = await _userAdminService.GetUserList(para);

            return Json(new { total = model.Count, rows = model.Data });
        }
    }
}