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
                cfg.CreateMap<DepartmentDto, Department>();
                cfg.CreateMap<Department, DepartmentDto>();
                cfg.CreateMap<RoleDto, Role>();
                cfg.CreateMap<Role, RoleDto>();
                cfg.CreateMap<UserDto, User>();
                cfg.CreateMap<User, UserDto>();
                cfg.CreateMap<MenuDto, Menu>();
                cfg.CreateMap<Menu, MenuDto>();
                cfg.CreateMap<RoleUserDto, RoleUser>();
                cfg.CreateMap<RoleUser, RoleDto>();
                cfg.CreateMap<RoleMenuDto, RoleMenu>();
                cfg.CreateMap<RoleMenu, RoleMenuDto>();
                cfg.CreateMap<ProjectDto, Project>();
                cfg.CreateMap<Project, ProjectDto>();
                cfg.CreateMap<HardwareDto, Hardware>();
                cfg.CreateMap<Hardware, HardwareDto>();
                cfg.CreateMap<ItemBaseOnHardwareDto, ItemBaseOnHardware>();
                cfg.CreateMap<ItemBaseOnHardware, ItemBaseOnHardwareDto>();
                cfg.CreateMap<ItemDto,Item>();
                cfg.CreateMap<Item, ItemDto>();
            });
        }
    }
}
