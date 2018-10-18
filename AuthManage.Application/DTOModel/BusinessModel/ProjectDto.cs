using AuthManage.Application.BaseModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthManage.Application.DTOModel.BusinessModel
{
    public class ProjectDto:BasicModel<int>
    {
        public string Name { get; set; }
    }
}
