using AuthManage.Domain.DomainModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthManage.Domain.IRepositories
{
    public interface IUserRepository:IRepository<User>
    {
        //检测用户是否存在，如果存在则返回用户，否则返回空
        User CheckUser(string username,string password);
    }
}
