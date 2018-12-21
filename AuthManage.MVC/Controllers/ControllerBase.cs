using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AuthManage.MVC.Controllers
{
    //控制器拦截（验证是否登录，未登录则跳转到登录界面）
    public abstract class ControllerBase : Controller//不能实例化
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string loginUser=context.HttpContext.Session.GetString("CurrentUser");
            if (loginUser == ""|| loginUser==null)
            {
                context.Result = new RedirectResult("/Login/Index");
                return;
            }
            base.OnActionExecuting(context);
        }
    }
}