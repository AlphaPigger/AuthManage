using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AuthManage.MVC.Controllers
{
    //工具栏管理
    public class ToolController : ControllerBase
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}