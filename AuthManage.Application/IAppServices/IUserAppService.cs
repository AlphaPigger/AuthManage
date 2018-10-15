using AuthManage.Domain.DomainModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthManage.Application.IAppServices
{
    public interface IUserAppService:IAppService<User>
    {
        User CheckUser(string username,string password);
    }
}
