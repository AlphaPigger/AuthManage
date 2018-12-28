using AuthManage.Domain.DomainModel.BusinessModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthManage.Domain.IRepositories
{
    public interface IRecordRepository:IRepository<Record>
    {
        //根据外键获取所有Record
        List<Record> GetRecordsByItemBaseOnHardwareID(int id);
    }
}
