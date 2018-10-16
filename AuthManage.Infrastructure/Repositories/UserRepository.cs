using AuthManage.Domain;
using AuthManage.Domain.DomainModel;
using AuthManage.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthManage.Infrastructure.Repositories
{
    public class UserRepository:Repository<User>,IUserRepository
    {
        public UserRepository(DataContext dataContext):base(dataContext)
        {

        }


        public User CheckUser(string username,string password)
        {
            return null;
        }
    }
}
