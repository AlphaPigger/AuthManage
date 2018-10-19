using AuthManage.Application.DTOModel;
using AuthManage.Domain.DomainModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthManage.Application.IAppServices
{
    public interface IUserAppService
    {
        void AddDto(UserDto dto);
        void DeleteDto(UserDto dto);
        void DeleteDtoById(int id);
        void UpdateDto(UserDto dto);
        List<UserDto> GetAllDtos();
        UserDto CheckUser(string username,string password);
    }
}
