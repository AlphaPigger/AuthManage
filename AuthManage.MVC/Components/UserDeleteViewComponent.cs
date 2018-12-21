﻿using AuthManage.Application.DTOModel;
using AuthManage.Application.IAppServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthManage.MVC.Components
{
    [ViewComponent(Name = "UserDelete")]
    public class UserDeleteViewComponent:ViewComponent
    {
        //依赖注入
        private IMenuAppService _menuAppService;
        //构造函数
        public UserDeleteViewComponent(IMenuAppService menuAppService)
        {
            _menuAppService = menuAppService;
        }
        public IViewComponentResult Invoke(int userID)
        {
            ViewBag.userID = userID;
            List<MenuDto> menuDtos = new List<MenuDto>();
            string currentUser = HttpContext.Session.GetString("CurrentUser");
            if (currentUser == "admin")//如果为超级管理员
            {
                menuDtos = _menuAppService.GetAllDtos();
            }
            else//普通用户
            {
                var currentUserID = HttpContext.Session.GetString("CurrentUserID");
                menuDtos = _menuAppService.GetMenusByUser(int.Parse(currentUserID));
            }
            return View(menuDtos);
        }
    }
}
