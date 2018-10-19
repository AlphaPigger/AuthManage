using AuthManage.Application.DTOModel.BusinessModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthManage.Application.IAppServices
{
    public interface IProjectAppService
    {
        void AddDto(ProjectDto dto);
        void DeleteDto(ProjectDto dto);
        void DeleteDtoById(int id);
        void UpdateDto(ProjectDto dto);
        List<ProjectDto> GetAllDtos();
    }
}
