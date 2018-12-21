using AuthManage.Application.DTOModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthManage.Application.IAppServices
{
    public interface IRoleMenuAppService
    {
        //通过RoleID获得所有MenuID
        List<int> GetAllMenuIDByRoleID(int RoleID);
        //保存角色功能关系
        bool UpdateRoleMenu(int roleId, List<RoleMenuDto> roleMenuDtos);
        //根据角色获取功能
        List<RoleMenuDto> GetMenusByRole(int roleID);
    }
}
