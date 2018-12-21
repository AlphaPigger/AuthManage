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
        MenuDto GetDtoByID(int id);
        List<MenuDto> GetAllDtos();
        //获取所有父级对象
        List<MenuDto> GetAllParentDtos();
        //根据用户获取功能
        List<MenuDto> GetMenusByUser(int userID);
    }
}
