using AuthManage.Domain.DomainModel.BusinessModel;
using AuthManage.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthManage.Infrastructure.Repositories
{
    public class ItemRepository:Repository<Item>,IItemRepository
    {
        public ItemRepository(DataContext dataContext) : base(dataContext)
        {

        }
    }
}
