﻿using AuthManage.Domain.BaseModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthManage.Domain.DomainModel.BusinessModel
{
    public class Project:BasicModel<int>
    {
        //工程名
        public string Name { get; set; }
        //描述
        public string Description { get; set; }
        //创建时间
        public string CreateTime { get; set; }
        //创建人
        public string CreateUser { get; set; }
        //硬件
        public ICollection<Hardware> Hardwares { get; set; }
    }
}
