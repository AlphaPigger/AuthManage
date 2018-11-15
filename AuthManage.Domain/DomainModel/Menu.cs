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
        //功能地址
        public string Address { get; set; }
        //功能类型（0表示导航菜单，1表示具体按钮）
        public int MenuType { get; set; }
        //创建时间
        public string CreateTime { get; set; }
        //创建人
        public string CreateUser { get; set; }
        //导航属性
        public ICollection<RoleMenu> RoleMenus { get; set; }
    }
}
