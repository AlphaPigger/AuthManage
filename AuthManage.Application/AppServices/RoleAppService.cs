using AuthManage.Application.DTOModel;
using AuthManage.Application.IAppServices;
using AuthManage.Domain.DomainModel;
using AuthManage.Domain.IRepositories;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthManage.Application.AppServices
{
    public class RoleAppService:IRoleAppService
    {
        //依赖注入
        private IRoleRepository _roleRepository;
        public RoleAppService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public void AddDto(RoleDto dto)
        {
            _roleRepository.AddEntity(Mapper.Map<Role>(dto));
        }
        public void DeleteDto(RoleDto dto)
        {
            _roleRepository.DeleteEntity(Mapper.Map<Role>(dto));
        }
        public void DeleteDtoById(int id)
        {
            _roleRepository.DeleteEntityById(id);
        }
        public void UpdateDto(RoleDto dto)
        {
            _roleRepository.UpdateEntity(Mapper.Map<Role>(dto));
        }
        public RoleDto GetDtoByID(int id)
        {
            return Mapper.Map<RoleDto>(_roleRepository.GetEntityByID(id));
        }
        public List<RoleDto> GetAllDtos()
        {
            return Mapper.Map<List<RoleDto>>(_roleRepository.GetAllEntities());
        }
    }
}
