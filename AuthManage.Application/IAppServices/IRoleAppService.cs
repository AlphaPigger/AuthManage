using AuthManage.Application.DTOModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthManage.Application.IAppServices
{
    public interface IRoleAppService
    {
        void AddDto(RoleDto dto);
        void DeleteDto(RoleDto dto);
        void DeleteDtoById(int id);
        void UpdateDto(RoleDto dto);
        List<RoleDto> GetAllDtos();
    }
}
