using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthManage.Application.DTOModel;
using AuthManage.Application.IAppServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace AuthManage.MVC.Controllers
{
    public class UserController : Controller
    {
        //中间数据
        private static UserDto temp = new UserDto();

        //依赖注入
        private IUserAppService _userAppService;
        public UserController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
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
    }
}