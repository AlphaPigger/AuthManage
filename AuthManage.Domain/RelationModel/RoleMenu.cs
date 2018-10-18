using AuthManage.Domain.BaseModel;
using AuthManage.Domain.DomainModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthManage.Domain.RelationModel
{
    //Role和Menu的关联表
    public class RoleMenu
    {
        public int RoleID { get; set; }
        public int MenuID { get; set; }
        public Role Role { get; set; }
        public Menu Menu { get; set; }
    }
}
