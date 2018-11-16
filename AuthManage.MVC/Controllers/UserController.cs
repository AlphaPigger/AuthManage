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
    public class UserController : Controller
    {
        //中间数据
        private static UserDto temp = new UserDto();

        //依赖注入
        private IUserAppService _userAppService;
        private IDepartmentAppService _departmentAppService;
        private IRoleAppService _roleAppService;
        public UserController(IUserAppService userAppService,IDepartmentAppService departmentAppService,IRoleAppService roleAppService)
        {
            _userAppService = userAppService;
            _departmentAppService = departmentAppService;
            _roleAppService = roleAppService;
        }

        //主界面
        public IActionResult Index(int Page=1,int PageSize=5)
        {
            ViewBag.PageSize = PageSize;
            var users = _userAppService.GetAllDtos();
            return View(users.ToPagedList(Page,PageSize));
        }

        //增加
        public IActionResult Add()
        {
            GenerateViewData();
            return View();
        }
        [HttpPost]
        public IActionResult Add(UserDto userDto)
        {
            if (ModelState.IsValid)
            {
                //更新到数据库
                userDto.CreateTime = DateTime.Now.ToString();
                userDto.CreateUser = HttpContext.Session.GetString("CurrentUser");
                _userAppService.AddDto(userDto);
                //重定向
                return RedirectToAction("Index","User");
            }
            return View(userDto);
        }

        //删除
        public IActionResult Delete(int id)
        {
            _userAppService.DeleteDtoById(id);
            return RedirectToAction("Index","User");
        }

        //修改
        public IActionResult Edit(int id)
        {
            UserDto editDto = _userAppService.GetDtoByID(id);
            GenerateTempData(editDto);
            GenerateViewData();
            return View(editDto);
        }
        [HttpPost]
        public IActionResult Edit(UserDto userDto)
        {
            if (ModelState.IsValid)
            {
                //更新到数据库
                userDto.CreateTime = temp.CreateTime;
                userDto.CreateUser = temp.CreateUser;
                _userAppService.UpdateDto(userDto);
                //重定向
                return RedirectToAction("Index","User");
            }
            return View(userDto);
        }

        private void GenerateTempData(UserDto editDto)
        {
            temp.CreateTime = editDto.CreateTime;
            temp.CreateUser = editDto.CreateUser;
        }

        //生成界面显示数据
        private void GenerateViewData()
        {
            //技术类别
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            selectListItems.Add(new SelectListItem("硬件工程师", "硬件工程师"));
            selectListItems.Add(new SelectListItem("基带工程师", "基带工程师"));
            selectListItems.Add(new SelectListItem("信号处理工程师", "信号处理工程师"));
            selectListItems.Add(new SelectListItem("嵌入式工程师", "嵌入式工程师"));
            selectListItems.Add(new SelectListItem("软件工程师", "软件工程师"));
            ViewData["PostTypes"] = selectListItems;
            //部门
            selectListItems = new List<SelectListItem>();
            var departments=_departmentAppService.GetAllDtos();
            foreach (var tem in departments)
            {
                selectListItems.Add(new SelectListItem(tem.Name,tem.Name.ToString()));
            }
            ViewData["Departments"] = selectListItems;
            //角色
            selectListItems = new List<SelectListItem>();
            var roles = _roleAppService.GetAllDtos();
            foreach (var tem in roles)
            {
                selectListItems.Add(new SelectListItem(tem.Name, tem.Name.ToString()));
            }
            ViewData["Roles"] = selectListItems;
        }
    }
}