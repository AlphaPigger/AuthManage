using AuthManage.Application.DTOModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthManage.Application.IAppServices
{
    public interface IDepartmentAppService
    {
        void AddDto(DepartmentDto dto);
        void DeleteDto(DepartmentDto dto);
        void DeleteDtoById(int id);
        void UpdateDto(DepartmentDto dto);
        List<DepartmentDto> GetAllDtos();
    }
}
