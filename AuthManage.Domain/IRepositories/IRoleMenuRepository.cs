using AuthManage.Domain.RelationModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthManage.Domain.IRepositories
{
    //角色功能
    public interface IRoleMenuRepository:IRepository<RoleMenu>
    {
        //根据RoleID获取所有MenuID
        List<int> GetAllMenuIDByRoleID(int RoleID);
        //更新角色和功能关系
        bool UpdateRoleMenu(int roleId,List<RoleMenu> roleMenus);
        //根据角色获取功能
        List<RoleMenu> GetMenusByRole(int roleID);
    }
}
