using AuthManage.Domain.BaseModel;
using AuthManage.Domain.RelationModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthManage.Domain.DomainModel
{
    public class Role:BasicModel<int>
    {
        //角色名
        public string Name { get; set; }
        //用户
        public ICollection<User> Users { get; set; }
       
        public ICollection<RoleMenu> RoleMenus { get; set; }
    }
}
