using AuthManage.Application.DTOModel.BusinessModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthManage.Application.IAppServices
{
    public interface IItemAppService
    {
        void AddDto(ItemDto dto);
        void DeleteDto(ItemDto dto);
        void DeleteDtoById(int id);
        void UpdateDto(ItemDto dto);
        List<ItemDto> GetAllDtos();
    }
}
