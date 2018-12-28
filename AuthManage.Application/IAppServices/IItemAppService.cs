using AuthManage.Application.DTOModel.BusinessModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthManage.Application.IAppServices
{
    public interface IItemAppService
    {
        void AddDto(ItemDto itemDto);
        void DeleteDtoByID(int id);
        void Update(ItemDto itemDto);
        ItemDto GetDtoByID(int id);
        List<ItemDto> GetAllDtos();
    }
}
