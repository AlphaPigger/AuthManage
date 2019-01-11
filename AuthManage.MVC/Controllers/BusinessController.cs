using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AuthManage.MVC.Controllers
{
    //业务管理
    public class BusinessController : ControllerBase
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}