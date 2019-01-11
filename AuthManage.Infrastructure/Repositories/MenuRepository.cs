using AuthManage.Domain.DomainModel;
using AuthManage.Domain.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthManage.Infrastructure.Repositories
{
    public class MenuRepository:Repository<Menu>,IMenuRepository
    {
        private DataContext _dataContext;
        public MenuRepository(DataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }
    }
}
