using AuthManage.Domain.BaseModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthManage.Domain.DomainModel
{
    //部门
    public class Department:BasicModel<int>
    {
        //部门名称
        public string Name { get; set; }
        //创建时间
        public string CreateTime { get; set; }
        //创建人
        public string CreateUser { get; set; }
        //用户(导航属性)
        public ICollection<User> Users { get; set; }
    }
}
