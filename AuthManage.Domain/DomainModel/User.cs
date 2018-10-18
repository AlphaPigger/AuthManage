using AuthManage.Domain.BaseModel;
using AuthManage.Domain.RelationModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthManage.Domain.DomainModel
{
    public class User:BasicModel<int>
    {
        //用户名
        public string Username { get; set; }
        //密码
        public string Password { get; set; }
        //联系号码
        public string ContactNumber { get; set; }
        //外键（指向部门）
        public int DepartmentID { get; set; }
        //部门(引用属性)
        public Department Department { get; set; }

        public ICollection<RoleUser> RoleUsers { get; set; }
    }
}
