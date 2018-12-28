using AuthManage.Application.BaseModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthManage.Application.DTOModel.BusinessModel
{
    public class RecordDto:BasicModel<int>
    {
        public string UpdateTime { get; set; }
        public string UpdateUser { get; set; }
        public string Remark { get; set; }
    }
}
