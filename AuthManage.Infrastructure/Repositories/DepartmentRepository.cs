using AuthManage.Domain.DomainModel;
using AuthManage.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthManage.Infrastructure.Repositories
{
    public class DepartmentRepository:Repository<Department>,IDepartmentRepository
    {
        public DepartmentRepository(DataContext dataContext) : base(dataContext)
        {

        }
    }
}
