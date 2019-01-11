using AuthManage.Application.DTOModel;
using AuthManage.Application.IAppServices;
using AuthManage.Domain.DomainModel;
using AuthManage.Domain.IRepositories;
using AuthManage.Infrastructure;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AuthManage.Application.AppServices
{
    public class MenuAppService:IMenuAppService
    {
        //依赖注入
        private IMenuRepository _menuRepository;
        private IRoleUserAppService _roleUserAppService;
        private IRoleMenuAppService _roleMenuAppService;
        private DataContext _dataContext;
        public MenuAppService(IMenuRepository menuRepository,IRoleUserAppService roleUserAppService,IRoleMenuAppService roleMenuAppService,DataContext dataContext)
        {
            _menuRepository = menuRepository;
            _roleUserAppService = roleUserAppService;
            _roleMenuAppService = roleMenuAppService;
            _dataContext = dataContext;
        }

        public void AddDto(MenuDto menuDto)
        {
            var menuDomain = new Menu();
            menuDomain.ID = menuDto.ID;
            //转换父级名为父级ID
            if (menuDto.ParentName != "")
            {
                var menus=_menuRepository.GetAllEntities();
                foreach (var menu in menus)
                {
                    if (menu.Name == menuDto.ParentName)
                    {
                        menuDomain.ParentID = menu.ID;
                    }
                }
            }
            menuDomain.Name = menuDto.Name;
            menuDomain.Address = menuDto.Address;
            if (menuDto.MenuType == "导航菜单")
            {
                menuDomain.MenuType = 0;
            }
            else if (menuDto.MenuType == "功能按钮")
            {
                menuDomain.MenuType = 1;
            }
            menuDomain.CreateTime = menuDto.CreateTime;
            menuDomain.CreateUser = menuDto.CreateUser;
            //添加实体
            _menuRepository.AddEntity(menuDomain);
        }
        public void DeleteDto(MenuDto dto)
        {

        }
        public void DeleteDtoById(int id)
        {
            _menuRepository.DeleteEntityById(id);
        }
        public void UpdateDto(MenuDto menuDto)
        {
            Menu menuDomain = new Menu();
            menuDomain.ID = menuDto.ID;
            //转换父级名为父级ID号
            if (menuDto.ParentName != "")
            {
                var menus = _menuRepository.GetAllEntities();
                foreach (var menu in menus)
                {
                    if (menuDto.ParentName == menu.Name)
                    {
                        menuDomain.ParentID = menu.ID;
                    }
                }
            }
            menuDomain.Name = menuDto.Name;
            menuDomain.Address = menuDto.Address;
            if (menuDto.MenuType == "导航菜单")
            {
                menuDomain.MenuType = 0;
            }
            else if (menuDto.MenuType == "功能按钮")
            {
                menuDomain.MenuType = 1;
            }
            menuDomain.CreateTime = menuDto.CreateTime;
            menuDomain.CreateUser = menuDto.CreateUser;
            //更新实体
            _menuRepository.DeleteEntityById(menuDto.ID);
            _menuRepository.AddEntity(menuDomain);
            //_menuRepository.UpdateEntity(menuDomain);
        }
        public MenuDto GetDtoByID(int id)
        {
            var menuDomain=_menuRepository.GetEntityByID(id);
            //转化
            var menuDto = new MenuDto();
            menuDto.ID = menuDomain.ID;
            //转换父级ID
            if (menuDomain.ParentID == 0)
            {
                menuDto.ParentName = "";
            }
            else//如果有父级
            {
                var menus = from r in _dataContext.Set<Menu>() where r.ID==menuDomain.ParentID select r;
                foreach (var menu in menus)
                {
                    menuDto.ParentName = menu.Name;
                }
            }
            menuDto.Name = menuDomain.Name;
            menuDto.Address = menuDomain.Address;
            if (menuDomain.MenuType == 0)
            {
                menuDto.MenuType = "导航菜单";
            }
            else if (menuDomain.MenuType == 1)
            {
                menuDto.MenuType = "功能按钮";
            }
            menuDto.CreateTime = menuDomain.CreateTime;
            menuDto.CreateUser = menuDomain.CreateUser;
            return menuDto;
        }
        public List<MenuDto> GetAllDtos()
        {
            //获取所有实体
            var menuDoamins = _menuRepository.GetAllEntities();
            //Domain转化为Dto
            var menuDtos = new List<MenuDto>();
            foreach (var tem in menuDoamins)
            {
                MenuDto menuDto = new MenuDto();
                menuDto.ID = tem.ID;
                if (tem.ParentID != 0)
                {
                    //转换父级ID
                    var tems = _menuRepository.GetAllEntities();
                    foreach (var tem2 in tems)
                    {
                        if (tem2.ID == tem.ParentID)
                        {
                            menuDto.ParentName = tem2.Name;
                        }
                    }
                }
                menuDto.Name = tem.Name;
                menuDto.Address = tem.Address;
                if (tem.MenuType == 0)
                {
                    menuDto.MenuType = "导航菜单";
                }
                else if(tem.MenuType==1)
                {
                    menuDto.MenuType = "功能按钮";
                }
                menuDto.CreateTime = tem.CreateTime;
                menuDto.CreateUser = tem.CreateUser;
                menuDtos.Add(menuDto);
            }
            //返回
            return menuDtos;
        }
        //获取所有父级对象
        public List<MenuDto> GetAllParentDtos()
        {
            List<MenuDto> menuDtos = new List<MenuDto>();
            var tems=_menuRepository.GetAllEntities();
            foreach(var tem in tems)
            {
                if (tem.ParentID == 0)//判断是否为父级，等于0为父级
                {
                    MenuDto menuDto = new MenuDto();
                    menuDto.ID = tem.ID;
                    menuDto.ParentName = "";//如果为父级，则为空
                    menuDto.Name = tem.Name;
                    menuDto.Address = tem.Address;
                    if (tem.MenuType == 0)
                    {
                        menuDto.MenuType = "导航菜单";
                    }
                    else
                    {
                        menuDto.MenuType = "功能按钮";
                    }
                    menuDto.CreateTime = tem.CreateTime;
                    menuDto.CreateUser = tem.CreateUser;
                    menuDtos.Add(menuDto);
                }
            }
            return menuDtos;
        }
        //根据用户获取功能
        public List<MenuDto> GetMenusByUser(int userID)
        {
            //通过用户获取用户角色集合
            var roleUserDtos=_roleUserAppService.GetRolesByUser(userID);
            //通过角色获取角色功能集合
            List<RoleMenuDto> RoleMenuDtos = new List<RoleMenuDto>();
            foreach(var roleUserDto in roleUserDtos)
            {
                var roleMenuDtos=_roleMenuAppService.GetMenusByRole(roleUserDto.RoleID);
                foreach(var roleMenuDto in roleMenuDtos)
                {
                    RoleMenuDtos.Add(roleMenuDto);
                }
            }
            //通过MenuID获得功能集合
            List<MenuDto> menuDtos = new List<MenuDto>();
            foreach (var RoleMenuDto in RoleMenuDtos)
            {
                menuDtos.Add(GetDtoByID(RoleMenuDto.MenuID));
            }
            //功能去重
            menuDtos=menuDtos.Distinct(new Compare()).ToList();
            return menuDtos;
        }
    }

    //比较去重
    public class Compare : IEqualityComparer<MenuDto>
    {
        public bool Equals(MenuDto x, MenuDto y)
        {
            return x.Name == y.Name;//可以自定义去重规则，此处将name相同的就作为重复记录
        }
        public int GetHashCode(MenuDto obj)
        {
            return obj.Name.GetHashCode();
        }
    }
}
