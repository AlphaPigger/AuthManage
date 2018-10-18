using AuthManage.Domain.BaseModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthManage.Domain.DomainModel.BusinessModel
{
    public class Project:BasicModel<int>
    {
        //工程名
        public string Name { get; set; }
        //组件
        public ICollection<Item> Items { get; set; }
    }
}
