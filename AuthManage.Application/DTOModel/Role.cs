﻿using AuthManage.Application.BaseModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthManage.Application.DTOModel
{
    public class Role:BasicModel<int>
    {
        //角色名
        public string Name { get; set; }
    }
}
