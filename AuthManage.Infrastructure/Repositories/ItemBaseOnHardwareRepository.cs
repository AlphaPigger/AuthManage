using AuthManage.Domain.DomainModel.BusinessModel;
using AuthManage.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace AuthManage.Infrastructure.Repositories
{
    public class ItemBaseOnHardwareRepository : Repository<ItemBaseOnHardware>,IItemBaseOnHardwareRepository
    {
        //依赖注入
        private DataContext _dataContext;
        public ItemBaseOnHardwareRepository(DataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }

        //通过ProjectID获取ItemBaseOnHardwares
        public List<ItemBaseOnHardware> GetItemBaseOnHardwareByHardwareID(int HardwareID)
        {
            var ItemBaseOnHardwares = (from r in _dataContext.Set<ItemBaseOnHardware>() where r.HardwareID == HardwareID select r).ToList();
            return ItemBaseOnHardwares;
        }
        
        //释放实体（这样便可以同时对实体进行查询和更改操作）
        public ItemBaseOnHardware GetEntityByIDNoTrack(int id)
        {
            return _dataContext.Set<ItemBaseOnHardware>().Where(it => it.ID == id).AsNoTracking().FirstOrDefault();
        }
    }
}
