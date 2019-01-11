using AuthManage.Domain.DomainModel.BusinessModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthManage.Domain.IRepositories
{
    public interface IHardwareRepository:IRepository<Hardware>
    {
        //通过项目名获取所有硬件
        List<Hardware> GetEntitiesByProjectID(int ProjectID);
    }
}
