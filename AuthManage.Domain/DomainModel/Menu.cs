using AuthManage.Domain.BaseModel;
using AuthManage.Domain.RelationModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthManage.Domain.DomainModel
{
    public class Menu:BasicModel<int>
    {
        //功能名
        public string Name { get; set; }

        public ICollection<RoleMenu> RoleMenus { get; set; }
    }
}
