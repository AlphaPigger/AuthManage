using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthManage.Application.IAppServices;
using AuthManage.MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthManage.MVC.Controllers
{
    public class LoginController : Controller
    {
        private IUserAppService _userAppService;
        public LoginController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }
        public IActionResult Index()
        {
            HttpContext.Session.SetString("CurrentUser", "");//置空当前Session中登录用户（当执行退出操作时）
            return View();
        }
        [HttpPost]
        public IActionResult Index(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                //验证是否为超级管理员
                if (loginModel.Username == "admin" && loginModel.Password == "admin")
                {
                    HttpContext.Session.SetString("CurrentUser", "admin");
                    return RedirectToAction("Index", "Project");
                }
                //调用接口
                var obj=_userAppService.CheckUser(loginModel.Username,loginModel.Password);
                if (obj==null)//用户名或密码错误
                {
                    ModelState.AddModelError("","用户名或密码错误");
                }
                else
                {
                    HttpContext.Session.SetString("CurrentUser", obj.Username);
                    HttpContext.Session.SetString("CurrentUserID",obj.ID.ToString());
                    return RedirectToAction("Index", "Project");
                }
            }
            return View(loginModel);
        }
    }
}