using AuthManage.Domain.BaseModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthManage.Domain.DomainModel.BusinessModel
{
    public class Hardware : BasicModel<int>
    {
        //名称
        public string Name { get; set; }
        //编号（唯一标识号）
        public string Number { get; set; }
        //创建时间
        public string CreateTime { get; set; }
        //创建人
        public string CreateUser { get; set; }
        //外键
        public int ProjectID { get; set; }
        //引用属性
        public Project Project { get; set; }
        public ICollection<ItemBaseOnHardware> ItemBaseOnHardwares { get; set; }
    }
}
