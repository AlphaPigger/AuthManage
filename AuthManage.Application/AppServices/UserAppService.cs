using AuthManage.Application.IAppServices;
using AuthManage.Domain.DomainModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthManage.Application.AppServices
{
    public class UserAppService:AppService<User>,IUserAppService
    {
        public User CheckUser(string username,string password)
        {
            return null;
        }
    }
}
