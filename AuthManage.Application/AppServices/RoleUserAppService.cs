using AuthManage.Application.DTOModel;
using AuthManage.Application.IAppServices;
using AuthManage.Domain.IRepositories;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthManage.Application.AppServices
{
    public class RoleUserAppService:IRoleUserAppService
    {
        //依赖注入
        private IRoleUserRepository _roleUserRepository;
        //构造函数
        public RoleUserAppService(IRoleUserRepository  roleUserRepository)
        {
            _roleUserRepository = roleUserRepository;
        }
        public List<RoleUserDto> GetRolesByUser(int userID)
        {
            List<RoleUserDto> roleUserDtos = new List<RoleUserDto>();
            var roleUsers=_roleUserRepository.GetRolesByUser(userID);
            foreach (var roleUser in roleUsers)
            {
                RoleUserDto roleUserDto = new RoleUserDto();
                roleUserDto.RoleID = roleUser.RoleID;
                roleUserDto.UserID = roleUser.UserID;
                roleUserDtos.Add(roleUserDto);
            }
            return roleUserDtos;
        }
    }
}
