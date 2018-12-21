using AuthManage.Application.DTOModel;
using AuthManage.Application.DTOModel.BusinessModel;
using AuthManage.Domain.DomainModel;
using AuthManage.Domain.DomainModel.BusinessModel;
using AuthManage.Domain.RelationModel;
using AutoMapper;
using System;

namespace AuthManage.Application
{
    public class AuthManageMapper
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Department, DepartmentDto>();
                cfg.CreateMap<DepartmentDto, Department>();
                cfg.CreateMap<RoleDto, Role>();
                cfg.CreateMap<Role, RoleDto>();
                cfg.CreateMap<UserDto, User>();
                cfg.CreateMap<User, UserDto>();
                cfg.CreateMap<Menu, MenuDto>();
                cfg.CreateMap<MenuDto, Menu>();
                cfg.CreateMap<Project, ProjectDto>();
                cfg.CreateMap<ProjectDto, Project>();
                cfg.CreateMap<Item, ItemDto>();
                cfg.CreateMap<ItemDto, Item>();
                cfg.CreateMap<RoleUser, RoleDto>();
                cfg.CreateMap<RoleUserDto, RoleUser>();
                cfg.CreateMap<RoleMenu,RoleMenuDto>();
                cfg.CreateMap<RoleMenuDto, RoleMenu>();
            });
        }
    }
}
