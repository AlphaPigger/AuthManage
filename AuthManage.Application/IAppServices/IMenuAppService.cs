using AuthManage.Application.DTOModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthManage.Application.IAppServices
{
    public interface IMenuAppService
    {
        void AddDto(MenuDto dto);
        void DeleteDto(MenuDto dto);
        void DeleteDtoById(int id);
        void UpdateDto(MenuDto dto);
        List<MenuDto> GetAllDtos();
    }
}
