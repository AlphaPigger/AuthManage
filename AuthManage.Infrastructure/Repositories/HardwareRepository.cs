using AuthManage.Domain.DomainModel.BusinessModel;
using AuthManage.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AuthManage.Infrastructure.Repositories
{
    public class HardwareRepository:Repository<Hardware>, IHardwareRepository
    {
        private DataContext _dataContext;
        public HardwareRepository(DataContext dataContext):base(dataContext)
        {
            _dataContext = dataContext;
        }

        public List<Hardware> GetEntitiesByProjectID(int ProjectID)
        {
            List<Hardware> hardwares = new List<Hardware>();
            var tems = from r in _dataContext.Set<Hardware>() where r.ProjectID == ProjectID select r;
            foreach(var tem in tems)
            {
                hardwares.Add(tem);
            }
            return hardwares;
        }
    }
}
