using AuthManage.Application.DTOModel;
using AuthManage.Application.IAppServices;
using AuthManage.Domain.IRepositories;
using AuthManage.Domain.RelationModel;
using AuthManage.Infrastructure;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AuthManage.Application.AppServices
{
    public class RoleMenuAppService:IRoleMenuAppService
    {
        //依赖注入
        private IRoleMenuRepository _roleMenuRepository;
        private IMenuRepository _menuRepository;
        private DataContext _dataContext;
        public RoleMenuAppService(IRoleMenuRepository roleMenuRepository,IMenuRepository menuRepository,DataContext dataContext)
        {
            _roleMenuRepository = roleMenuRepository;
            _menuRepository = menuRepository;
            _dataContext = dataContext;
        }
        //根据RoleID获取功能ID表
        public List<int> GetAllMenuIDByRoleID(int RoleID)
        {
            return _roleMenuRepository.GetAllMenuIDByRoleID(RoleID);
        }
        //保存角色功能关系
        public bool UpdateRoleMenu(int roleId,List<RoleMenuDto> roleMenuDtos)
        {
            //整合界面过来的数据（因为界面在选择增加删除而未选择管理功能时默认是没有加入管理功能，界面不好加，这里加上）
            //获取全部的MenuID
            List<int> MenuIDs = new List<int>();
            for (int i=0; i < roleMenuDtos.Count; i++)
            {
                MenuIDs.Add(roleMenuDtos[i].MenuID);
            }
            //获取全部的Menu对象
            var Menus = _menuRepository.GetAllEntities();
            foreach (var tem in Menus)
            {
                for (int i = 0; i < MenuIDs.Count; i++)
                {
                    if (tem.ID == MenuIDs[i]&&tem.ParentID!=0)//有子级功能
                    {
                        //判断是否没有对应的父级功能
                        var tems = from r in _dataContext.Menus where r.ID == tem.ParentID select r;//获取父级
                        foreach(var tem2 in tems)
                        {
                            var flag = false;
                            for(int j=0; j < MenuIDs.Count; j++)
                            {
                                if (tem2.ID != MenuIDs[j])//没有父级功能
                                {
                                    flag = true;
                                }
                                else
                                {
                                    flag = false;
                                    break;
                                }
                            }
                            if (flag)
                            {
                                //添加对应父级功能ID到对象集合
                                roleMenuDtos.Add(new RoleMenuDto() { RoleID = roleId, MenuID = tem2.ID });
                                //添加到本地使用集合
                                MenuIDs.Add(tem2.ID);
                            }
                        }
                    }
                }
            }
            //调用接口
            return _roleMenuRepository.UpdateRoleMenu(roleId,Mapper.Map<List<RoleMenu>>(roleMenuDtos));
        }
        //根据角色获取功能
        public List<RoleMenuDto> GetMenusByRole(int roleID)
        {
            List<RoleMenuDto> roleMenuDtos = new List<RoleMenuDto>();
            var roleMenus = _roleMenuRepository.GetMenusByRole(roleID);
            foreach (var roleMenu in roleMenus)
            {
                RoleMenuDto roleMenuDto = new RoleMenuDto();
                roleMenuDto.RoleID = roleMenu.RoleID;
                roleMenuDto.MenuID = roleMenu.MenuID;
                roleMenuDtos.Add(roleMenuDto);
            }
            return roleMenuDtos;
        }
    }
}
