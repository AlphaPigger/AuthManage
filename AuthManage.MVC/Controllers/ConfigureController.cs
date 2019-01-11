using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AuthManage.MVC.Controllers
{
    //配置管理
    public class ConfigureController : ControllerBase
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}