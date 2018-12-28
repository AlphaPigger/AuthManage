using AuthManage.Domain.DomainModel.BusinessModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthManage.Domain.IRepositories
{
    public interface IItemBaseOnHardwareRepository:IRepository<ItemBaseOnHardware>
    {
        //通过ProjectID获取ItemBaseOnHardwares
        List<ItemBaseOnHardware> GetItemBaseOnHardwareByHardwareID(int HardwareID);
        //获取单个实例
        ItemBaseOnHardware GetEntityByIDNoTrack(int id);
    }
}
