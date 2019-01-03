using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthManage.Application.DTOModel.BusinessModel;
using AuthManage.Application.IAppServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace AuthManage.MVC.Controllers
{
    public class ProjectController : ControllerBase
    {
        private static ProjectDto _projectDto = new ProjectDto();
        //依赖注入
        private IProjectAppService _projectAppService;
        public ProjectController(IProjectAppService projectAppService)
        {
            _projectAppService = projectAppService;
        }
        //查询
        public IActionResult Index(int Page=1,int PageSize=5)
        {
            ViewBag.PageSize = PageSize;
            var projectDtos=_projectAppService.GetAllDtos();
            return View(projectDtos.ToPagedList(Page,PageSize));
        }
        //添加
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(ProjectDto projectDto)
        {
            if (ModelState.IsValid)
            {
                projectDto.CreateTime = DateTime.Now.ToString();
                string User=HttpContext.Session.GetString("CurrentUser");
                projectDto.CreateUser = User;
                //执行增加操作
                _projectAppService.AddDto(projectDto);
                //重定向
                return RedirectToAction("Index","Project");
            }
            //返回
            return View(projectDto);
        }
        //删除
        public IActionResult Delete(int id)
        {
            //执行删除操作
            _projectAppService.DeleteDtoById(id);
            //重定向
            return RedirectToAction("Index","Project");
        }
        //修改
        public IActionResult Edit(int id)
        {
            //获取查询对象
            ProjectDto projectDto=_projectAppService.GetDtoByID(id);
            GeneteTempDatas(projectDto);
            //返回
            return View(projectDto);
        }
        [HttpPost]
        public IActionResult Edit(ProjectDto projectDto)
        {
            if (ModelState.IsValid)
            {
                projectDto.CreateTime = _projectDto.CreateTime;
                projectDto.CreateUser = _projectDto.CreateUser;
                //执行更新操作
                _projectAppService.UpdateDto(projectDto);
                //重定向
                return RedirectToAction("Index","Project");
            }
            //返回
            return View(projectDto);
        }

        //保存创建时间和创建人
        private void GeneteTempDatas(ProjectDto projectDto)
        {
            _projectDto.CreateTime = projectDto.CreateTime;
            _projectDto.CreateUser = projectDto.CreateUser;
        }
    }
}