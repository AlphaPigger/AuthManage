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
    public class RoleController : ControllerBase
    {
        //中间数据
        private static RoleDto temp=new RoleDto();
        //依赖注入
        private IRoleAppService _roleAppService;
        public RoleController(IRoleAppService roleAppService)
        {
            _roleAppService = roleAppService;
        }

        //主界面
        public IActionResult Index(int Page=1,int PageSize=5)
        {
            ViewBag.PageSize = PageSize;
            var roleDtos=_roleAppService.GetAllDtos();
            return View(roleDtos.ToPagedList(Page,PageSize));
        }

        //增加
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(RoleDto model)
        {
            if (ModelState.IsValid)
            {
                //更新数据库
                model.CreateTime = DateTime.Now.ToString();
                model.CreateUser = HttpContext.Session.GetString("CurrentUser");
                _roleAppService.AddDto(model);
                //重定向
                return RedirectToAction("Index", "Role");
            }
            return View(model);
        }

        //删除
        public IActionResult Delete(int id)
        {
            //更新数据库
            _roleAppService.DeleteDtoById(id);
            //重定向
            return RedirectToAction("Index","Role");
        }

        //修改
        public IActionResult Edit(int id)
        {
            RoleDto editDto = _roleAppService.GetDtoByID(id);
            GenerateTempData(editDto);
            return View(editDto);
        }
        [HttpPost]
        public IActionResult Edit(RoleDto model)
        {
            if (ModelState.IsValid)
            {
                //更新数据库
                model.CreateTime = temp.CreateTime;
                model.CreateUser = temp.CreateUser;
                _roleAppService.UpdateDto(model);
                //重定向
                return RedirectToAction("Index","Role");
            }
            return View(model);
        }

        private void GenerateTempData(RoleDto editDto)
        {
            temp.CreateTime = editDto.CreateTime;
            temp.CreateUser = editDto.CreateUser;
        }
    }
}