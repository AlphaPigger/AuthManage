using AuthManage.Application.DTOModel;
using AuthManage.Application.IAppServices;
using AuthManage.Domain.DomainModel;
using AuthManage.Domain.IRepositories;
using AuthManage.Domain.RelationModel;
using AuthManage.Infrastructure;
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
        //数据库上下文接口
        private DataContext _dataContext;
        //依赖注入
        public UserAppService(IUserRepository userRepository,DataContext dataContext)
        {
            _userRepository = userRepository;
            _dataContext = dataContext;
        }
        public void AddDto(UserDto dto)
        {
            //将dto转化为对应的domainModel
            //这里做dto和domain之间的映射，由于存在多对多的关系，这里需要整合做映射，不能像一对多简单对应
            User temp = new User();
            temp.ID = dto.ID;
            temp.Username = dto.Username;
            temp.Password = dto.Password;
            temp.PostType = dto.PostType;
            temp.CreateTime = dto.CreateTime;
            temp.CreateUser = dto.CreateUser;
            //转换部门标识DepartmentID
            var departments=_dataContext.Departments;
            foreach (var tem in departments)
            {
                if (tem.Name == dto.Department)
                {
                    temp.DepartmentID = tem.ID;
                }
            }
            //转换角色标识RoleID
            var roleusers = new List<RoleUser>();
            for(int i=0; i < dto.Roles.Count; i++)
            {
                var roles = _dataContext.Roles;
                foreach (var tem in roles)
                {
                    if (tem.Name == dto.Roles[i])
                    {
                        roleusers.Add(new RoleUser(tem.ID,dto.ID));
                    }
                }
            }
            temp.RoleUsers = roleusers;
            _userRepository.AddEntity(temp);
            //_userRepository.AddEntity(Mapper.Map<User>(dto));
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
        public UserDto GetDtoByID(int id)
        {
            return Mapper.Map<UserDto>(_userRepository.GetEntityByID(id));
        }
        public List<UserDto> GetAllDtos()
        {
            //模型转换
            var userDomains = _userRepository.GetAllEntities();
            var userDtos = new List<UserDto>();
            foreach (var userDomain in userDomains)
            {
                UserDto userDto = new UserDto();
                userDto.ID = userDomain.ID;
                userDto.Username = userDomain.Username;
                userDto.Password = userDomain.Password;
                userDto.PostType = userDomain.PostType;
                userDto.CreateTime = userDomain.CreateTime;
                userDto.CreateUser = userDomain.CreateUser;
                var departments=_dataContext.Departments;
                //转换部门ID
                foreach (var tem in departments)
                {
                    if (tem.ID == userDomain.DepartmentID)
                    {
                        userDto.Department = tem.Name;
                    }
                }
                //转换角色ID
                var roleusers = _dataContext.RoleUsers;//userDomain中的RoleUsers为null，因此直接从上下文获取
                foreach (var tem in roleusers)
                {
                    if (tem.UserID == userDomain.ID)
                    {
                        var roles = _dataContext.Roles;
                        foreach(var tem2 in roles)
                        {
                            if (tem.RoleID == tem2.ID)
                            {
                                userDto.Roles.Add(tem2.Name);
                            }
                        }
                    }
                }
                userDtos.Add(userDto);
            }
            return userDtos;
            //return Mapper.Map<List<UserDto>>(_userRepository.GetAllEntities());
        }
        public UserDto CheckUser(string username,string password)
        {
            return Mapper.Map<UserDto>(_userRepository.CheckUser(username, password));   
        }
    }
}
