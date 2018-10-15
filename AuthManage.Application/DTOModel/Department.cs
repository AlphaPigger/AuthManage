using AuthManage.Application.BaseModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthManage.Application.DTOModel
{
    public class Department:BasicModel<int>
    {
        //部门名称
        public string Name { get; set; }
        //负责人
        public string Manager { get; set; }
        //联系电话
        public string ContactNumber { get; set; }
    }
}
