using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthManage.Application.DTOModel;
using AuthManage.Application.IAppServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;

namespace AuthManage.MVC.Controllers
{
    public class MenuController : ControllerBase
    {
        //中间数据
        private static MenuDto temp = new MenuDto();
        //依赖注入
        private IMenuAppService _menuAppService;
        public MenuController(IMenuAppService menuAppService)
        {
            _menuAppService = menuAppService;
        }
        //查询
        public IActionResult Index(int Page=1,int PageSize = 5)
        {
            //保存每页记录数
            ViewBag.PageSize = PageSize;
            var menuDtos=_menuAppService.GetAllDtos();
            return View(menuDtos.ToPagedList(Page,PageSize));
        }
        //新增顶级
        public IActionResult AddParent()
        {
            GenerateViewDatas();
            return View();
        }
        [HttpPost]
        public IActionResult AddParent(MenuDto menuDto)
        {
            if (ModelState.IsValid)
            {
                //获取当前创建时间和创建人
                menuDto.CreateTime = DateTime.Now.ToString();
                menuDto.CreateUser = HttpContext.Session.GetString("CurrentUser");
                _menuAppService.AddDto(menuDto);
                return RedirectToAction("Index", "Menu");
            }
            GenerateViewDatas();
            return View(menuDto);
        }
        //增加子级
        public IActionResult Add()
        {
            GenerateViewDatas();
            return View();
        }
        [HttpPost]
        public IActionResult Add(MenuDto menuDto)
        {
            if (ModelState.IsValid)
            {
                //获取当前创建时间和创建人
                menuDto.CreateTime = DateTime.Now.ToString();
                menuDto.CreateUser = HttpContext.Session.GetString("CurrentUser");
                _menuAppService.AddDto(menuDto);
                return RedirectToAction("Index","Menu");
            }
            GenerateViewDatas();
            return View(menuDto);
        }
        //删除
        public IActionResult Delete(int id)
        {
            _menuAppService.DeleteDtoById(id);
            return RedirectToAction("Index","Menu");
        }
        //修改
        public IActionResult Edit(int id)
        {
            var menuDto = _menuAppService.GetDtoByID(id);
            GenerateTempDatas(ref menuDto);//保存中间数据
            GenerateViewDatas();
            return View(menuDto);
        }
        [HttpPost]
        public IActionResult Edit(MenuDto menuDto)
        {
            if (ModelState.IsValid)
            {
                //取出中间数据
                menuDto.CreateTime = temp.CreateTime;
                menuDto.CreateUser = temp.CreateUser;
                _menuAppService.UpdateDto(menuDto);
                return RedirectToAction("Index","Menu");
            }
            GenerateViewDatas();
            return View(menuDto);
        }
        //中间数据保存（创建时间和创建人）
        private void GenerateTempDatas(ref MenuDto menuDto)
        {
            temp.CreateTime = menuDto.CreateTime;
            temp.CreateUser = menuDto.CreateUser;
        }
        //初始化界面呈现数据
        private void GenerateViewDatas()
        {
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            //获取为父级的对象
            var tems=_menuAppService.GetAllParentDtos();
            foreach (var tem in tems)
            {
                selectListItems.Add(new SelectListItem(tem.Name,tem.Name));//将父级对象加入ViewData中
            }
            ViewData["Parents"] = selectListItems;
            //功能类型
            selectListItems = new List<SelectListItem>();
            selectListItems.Add(new SelectListItem("导航菜单","导航菜单"));
            selectListItems.Add(new SelectListItem("功能按钮", "功能按钮"));
            ViewData["MenuTypes"] = selectListItems;
        }
    }
}