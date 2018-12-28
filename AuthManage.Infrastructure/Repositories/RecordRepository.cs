using AuthManage.Domain.DomainModel.BusinessModel;
using AuthManage.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AuthManage.Infrastructure.Repositories
{
    public class RecordRepository:Repository<Record>,IRecordRepository
    {
        //依赖注入
        private DataContext _DataContext;
        public RecordRepository(DataContext dataContext) : base(dataContext)
        {
            _DataContext = dataContext;
        }

        public List<Record> GetRecordsByItemBaseOnHardwareID(int id)
        {
            var records = from r in _DataContext.Set<Record>() where r.ItemBaseOnHardwareID == id select r;
            return records.ToList();
        }
    }
}
