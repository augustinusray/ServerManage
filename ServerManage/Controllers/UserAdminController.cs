﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Iservices;
using AutoMapper;
using Domain.Entitys;
using Domain.Para;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ServerManage.ViewModels.UserAdmin;

namespace ServerManage.Controllers
{
    public class UserAdminController : BaseController
    {
        private readonly IUserAdminService _userAdminService;

        private UserManager<User> _userManager;

        private readonly IMapper _imapper;

        public UserAdminController(UserManager<User> userManager, IUserAdminService userAdminService, IMapper imapper)
        {
            _userAdminService = userAdminService;
            _userManager = userManager;
            _imapper = imapper;
        }

        [HttpGet]
        public IActionResult UserList()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GetUserList(PagePara para)
        {
            var model = await _userAdminService.GetUserList(para);

            return Json(new { total = model.Count, rows = model.Data });
        }


        [HttpGet]
        public IActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddUser(AddUserVM model)
        {
            var user = _imapper.Map<AddUserVM, User>(model);
            var result = await _userManager.CreateAsync(user, model.UserPass);
            if (result.Succeeded)
                return RedirectToAction("UserList");
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteUser(string[] users)
        {
            var result=await _userAdminService.DeleteUser(users);

            return Json(result);
        }

        [HttpGet]
        public async Task<IActionResult> EditUser(string userId)
        {
            _userManager.pas
            var user = await _userAdminService.GetUser(userId);
            var model = _imapper.Map<User, EditUserVM>(user);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditUser(EditUserVM model)
        {
            var user = _imapper.Map<EditUserVM, User>(model);

            var result = await _userAdminService.UpdateUser(user);

            return RedirectToAction("UserList");
        }
    }
}