using AuthManage.Domain;
using AuthManage.Domain.DomainModel;
using AuthManage.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AuthManage.Infrastructure.Repositories
{
    public class UserRepository:Repository<User>,IUserRepository
    {
        private DataContext _dataContext;
        public UserRepository(DataContext dataContext):base(dataContext)
        {
            _dataContext = dataContext;
        }


        public User CheckUser(string username,string password)
        {
            var obj = from r in _dataContext.Set<User>() where r.Username == username && r.Password == password select r;
            foreach (var tem in obj)
            {
                return _dataContext.Set<User>().Find(tem.ID);
            }
            return null;

        }
    }
}
