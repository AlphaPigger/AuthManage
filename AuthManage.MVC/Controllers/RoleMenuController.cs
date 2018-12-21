using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthManage.Application.DTOModel;
using AuthManage.Application.IAppServices;
using AuthManage.Domain.IRepositories;
using AuthManage.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace AuthManage.MVC.Controllers
{
    public class RoleMenuController : ControllerBase
    {
        //依赖注入
        private IRoleAppService _roleAppService;
        private IMenuAppService _menuAppService;
        private IRoleMenuAppService _roleMenuAppService;
        private IMenuRepository _menuRepository;
        public RoleMenuController(IRoleAppService roleAppService,IMenuAppService menuAppService,IRoleMenuAppService roleMenuAppService,IMenuRepository menuRepository)
        {
            _roleAppService = roleAppService;
            _menuAppService = menuAppService;
            _roleMenuAppService = roleMenuAppService;
            _menuRepository = menuRepository;
        }
        //获取所有角色列表
        public IActionResult Index(int Page=1,int PageSize=5)
        {
            //保存中间数据
            ViewBag.PageSize = PageSize;
            var roles = _roleAppService.GetAllDtos();
            return View(roles.ToPagedList(Page,PageSize));
        }
        //获取所有功能
        public IActionResult GetMenuTreeData()
        {
            List<TreeModel> treeModels = new List<TreeModel>();
            var tems = _menuRepository.GetAllEntities();//获取所有实体
            foreach (var tem in tems)
            {
                TreeModel treeModel = new TreeModel();
                treeModel.Id = tem.ID.ToString();
                treeModel.Text = tem.Name;
                if (tem.ParentID == 0)
                {
                    treeModel.Parent = "#";
                }
                else
                {
                    treeModel.Parent = tem.ParentID.ToString();
                }
                treeModels.Add(treeModel);
            }
            return Json(treeModels);
        }
        //根据角色获取权限
        public IActionResult GetPermissionByRole(int RoleID)
        {
            var allMenuID=_roleMenuAppService.GetAllMenuIDByRoleID(RoleID);
            return Json(allMenuID);
        }
        //保存角色和功能关系
        public IActionResult SavePermission(int roleId, List<RoleMenuDto> roleMenus)
        {
            if (_roleMenuAppService.UpdateRoleMenu(roleId, roleMenus))
            {
                return Json(new { Result = "Success" });
            }
            return Json(new { Result = "Faild" });
        }
    }
}