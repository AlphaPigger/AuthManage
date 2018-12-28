using AuthManage.Domain.BaseModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthManage.Domain.DomainModel.BusinessModel
{
    public class Item:BasicModel<int>
    {
        public string Name { get; set; }
        public string CreateTime { get; set; }
        public string CreateUser { get; set; }
    }
}
