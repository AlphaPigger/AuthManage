using AuthManage.Domain.DomainModel.BusinessModel;
using AuthManage.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthManage.Infrastructure.Repositories
{
    public class HardwareRepository:Repository<Hardware>, IHardwareRepository
    {
        public HardwareRepository(DataContext dataContext):base(dataContext)
        {

        }
    }
}
