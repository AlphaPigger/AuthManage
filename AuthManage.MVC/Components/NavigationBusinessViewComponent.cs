using AuthManage.Application.DTOModel;
using AuthManage.Application.IAppServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AuthManage.MVC.Components
{
    [ViewComponent(Name="NavigationBusiness")]
    public class NavigationBusinessViewComponent:ViewComponent
    {
        //依赖注入
        private IMenuAppService _menuAppService;
        //构造函数
        public NavigationBusinessViewComponent(IMenuAppService menuAppService)
        {
            _menuAppService = menuAppService;
        }
        //调用
        public IViewComponentResult Invoke()
        {
            List<MenuDto> menuDtos = new List<MenuDto>();
            string onlineUser = HttpContext.Session.GetString("CurrentUser");
            if (onlineUser == "admin")//如果是admin用户
            {
                menuDtos = _menuAppService.GetAllDtos();//获取全部功能
            }
            else
            {
                string onlineUserID = HttpContext.Session.GetString("CurrentUserID");
                menuDtos = _menuAppService.GetMenusByUser(int.Parse(onlineUserID));
            }
            //返回到界面
            return View(menuDtos);
        }
    }
}
