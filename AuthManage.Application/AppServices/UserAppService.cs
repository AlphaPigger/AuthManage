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
    public class UserAppService:IUserAppService
    {
        //用户管理仓储接口
        private IUserRepository _userRepository;
        //依赖注入
        public UserAppService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public void AddDto(UserDto dto)
        {
            //将dto转化为对应的domainModel
            _userRepository.AddEntity(Mapper.Map<User>(dto));
        }
        public void DeleteDto(UserDto dto)
        {
            _userRepository.DeleteEntity(Mapper.Map<User>(dto));
        }
        public void DeleteDtoById(int id)
        {
            _userRepository.DeleteEntityById(id);
        }
        public void UpdateDto(UserDto dto)
        {
            _userRepository.UpdateEntity(Mapper.Map<User>(dto));
        }
        public List<UserDto> GetAllDtos()
        {
            return Mapper.Map<List<UserDto>>(_userRepository.GetAllEntities());
        }
        public UserDto CheckUser(string username,string password)
        {
            return Mapper.Map<UserDto>(_userRepository.CheckUser(username, password));   
        }
    }
}
