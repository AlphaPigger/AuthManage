using AuthManage.Domain.RelationModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthManage.Domain.IRepositories
{
    //角色用户
    public interface IRoleUserRepository:IRepository<RoleUser>
    {
        //根据用户获取角色
        List<RoleUser> GetRolesByUser(int userID);
    }
}
