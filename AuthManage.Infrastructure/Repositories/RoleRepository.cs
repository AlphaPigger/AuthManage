using AuthManage.Domain.DomainModel;
using AuthManage.Domain.IRepositories;
using AuthManage.MVC;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthManage.Infrastructure.Repositories
{
    public class RoleRepository:Repository<Role>,IRoleRepository
    {
        public RoleRepository(DataContext dataContext) : base(dataContext)
        {

        }
    }
}
