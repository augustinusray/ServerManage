using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Application.Enum;
using Application.Iservices;
using Microsoft.AspNetCore.Mvc;
using ServerManage.Models;
using ServerManage.ViewModels;

namespace ServerManage.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeService _ihomeService;

        public HomeController(IHomeService ihomeService)
        {
            _ihomeService = ihomeService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var result= await _ihomeService.LoginValidate(model.UserName,model.PassWord);

            if (result == LoginEnum.用户名错误 || result == LoginEnum.密码错误)
                ModelState.AddModelError("","用户名或密码错误");
            else if (result == LoginEnum.登录成功)
                return RedirectToAction("Index");
            return View(model);
        }     
    }
}
