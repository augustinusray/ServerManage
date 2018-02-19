using Application.Iservices;
using Domain.Entitys;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ServerManage.ViewModels;
using System.Threading.Tasks;

namespace ServerManage.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IHomeService _ihomeService;

        private SignInManager<User> _signInManager;
        private UserManager<User> _userManager;

        public HomeController(UserManager<User> userManager, SignInManager<User> signInManager,IHomeService ihomeService)
        {
            _ihomeService = ihomeService;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user == null)  
                ModelState.AddModelError(string.Empty, "账号或密码错误!");

            var result = await _signInManager.PasswordSignInAsync(model.UserName, model.PassWord, isPersistent: false, lockoutOnFailure: true);

            if (result.Succeeded)
            {
                await _ihomeService.AddUserLoginLog(Request.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString(),user.Id);
                return RedirectToAction("Index");
            }
            if (result.RequiresTwoFactor)
            {
               
            }
            if (result.IsLockedOut)
            {
                ModelState.AddModelError(string.Empty, "登录失败多次,账号已被锁定!");
                return View();
            }
            else
            {
                ModelState.AddModelError(string.Empty, "账号或密码错误!");
                return View(model);
            }
        }


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetServerAndUser()
        {
            var counts=await _ihomeService.GetServerAndUser();
            return Json(counts);
        }


        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(HomeController.Login), "Home");
        }

        [HttpGet]
        public IActionResult AccessDenied()
        {
            return Content("访问被拒绝");
        }
    }
}
