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
    public class DepartmentController : Controller
    {
        //中间数据
        private static DepartmentDto temp = new DepartmentDto();
        //依赖注入
        private IDepartmentAppService _departmentAppService;
        public DepartmentController(IDepartmentAppService departmentAppService)
        {
            _departmentAppService = departmentAppService;
        }

        //主界面
        public IActionResult Index(int Page = 1, int PageSize = 5)
        {
            ViewBag.User = HttpContext.Session.GetString("CurrentUser");
            ViewBag.PageSize = PageSize;//记录每页显示数
            var departmentList = _departmentAppService.GetAllDtos();
            return View(departmentList.ToPagedList(Page, PageSize));
        }

        //增加
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(DepartmentDto model)
        {
            if (ModelState.IsValid)
            {
                model.CreateTime = DateTime.Now.ToString();
                model.CreateUser = HttpContext.Session.GetString("CurrentUser");
                //添加到数据库
                _departmentAppService.AddDto(model);
                //重定向
                return RedirectToAction("Index", "Department");
            }
            return View(model);
        }

        //删除
        public IActionResult Delete(int id)
        {
            _departmentAppService.DeleteDtoById(id);
            return RedirectToAction("Index", "Department");
        }

        //修改
        public IActionResult Edit(int id)
        {
            DepartmentDto editDto = _departmentAppService.GetDtoByID(id);
            GenerateTempData(editDto);
            return View(editDto);
        }
        [HttpPost]
        public IActionResult Edit(DepartmentDto model)
        {
            if (ModelState.IsValid)
            {
                //更新到数据库
                model.CreateTime = temp.CreateTime;
                model.CreateUser = temp.CreateUser;
                _departmentAppService.UpdateDto(model);
                //重定向
                return RedirectToAction("Index", "Department");
            }
            return View(model);
        }

        private void GenerateTempData(DepartmentDto editDto)
        {
            temp.CreateTime = editDto.CreateTime;
            temp.CreateUser = editDto.CreateUser;
        }
    }
}