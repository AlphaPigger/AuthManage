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
        //密码（默认密码123456）
        public string Password { get; set; }
        //技术类别
        public string PostType { get; set; }
        //创建时间
        public string CreateTime { get; set; }
        //创建人
        public string CreateUser { get; set; }
        //导航属性
        public int DepartmentID { get; set; }
        public Department Department { get; set; }
        public ICollection<RoleUser> RoleUsers { get; set; }
    }
}
