using AuthManage.Domain.IRepositories;
using AuthManage.Domain.RelationModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AuthManage.Infrastructure.Repositories
{
    public class RoleUserRepository:Repository<RoleUser>,IRoleUserRepository
    {
        private DataContext _dataContext;
        //构造函数
        public RoleUserRepository(DataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }
        //根据用户获取角色
        public List<RoleUser> GetRolesByUser(int userID)
        {
            List<RoleUser> roleUsers = new List<RoleUser>();
            var tems = from r in _dataContext.Set<RoleUser>() where r.UserID == userID select r;
            foreach (var tem in tems)
            {
                roleUsers.Add(tem);
            }
            return roleUsers;
        }
    }
}
