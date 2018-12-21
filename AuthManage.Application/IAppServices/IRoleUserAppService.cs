using AuthManage.Application.DTOModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthManage.Application.IAppServices
{
    public interface IRoleUserAppService
    {
        //根据用户获取角色
        List<RoleUserDto> GetRolesByUser(int userID);
    }
}
