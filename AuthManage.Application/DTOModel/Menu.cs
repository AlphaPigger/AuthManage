using AuthManage.Application.BaseModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthManage.Application.DTOModel
{
    public class Menu:BasicModel<int>
    {
        //功能名
        public string Name { get; set; }
    }
}
