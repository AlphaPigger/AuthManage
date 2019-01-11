using AuthManage.Application.DTOModel.BusinessModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthManage.Application.IAppServices
{
    public interface IItemBaseOnHardwareAppService
    {
        void AddDto(ItemBaseOnHardwareDto dto,int HardwareID);
        void DeleteDto(ItemBaseOnHardwareDto dto);
        void DeleteDtoById(int id);
        void UpdateDto(ItemBaseOnHardwareDto dto,string CurrentUser,int HardwareID);
        ItemBaseOnHardwareDto GetDtoByID(int id);
        List<ItemBaseOnHardwareDto> GetAllDtos();
        //通过HardwareID获取对应ItemBaseOnHardwares
        List<ItemBaseOnHardwareDto> GetDtosByHardwareID(int HarewareID);
    }
}
