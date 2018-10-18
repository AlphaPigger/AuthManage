using AuthManage.Domain.DomainModel.BusinessModel;
using AuthManage.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthManage.Infrastructure.Repositories
{
    public class ProjectRepository:Repository<Project>,IProjectRepository
    {
        public ProjectRepository(DataContext dataContext) : base(dataContext)
        {

        }
    }
}
