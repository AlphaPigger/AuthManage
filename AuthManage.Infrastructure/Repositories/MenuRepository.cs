using AuthManage.Domain.DomainModel;
using AuthManage.Domain.IRepositories;
using AuthManage.MVC;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthManage.Infrastructure.Repositories
{
    public class MenuRepository:Repository<Menu>,IMenuRepository
    {
        public MenuRepository(DataContext dataContext) : base(dataContext)
        {

        }
    }
}
