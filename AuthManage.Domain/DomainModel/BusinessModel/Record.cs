using AuthManage.Domain.BaseModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthManage.Domain.DomainModel.BusinessModel
{
    public class Record:BasicModel<int>
    {
        //最新状态
        public int Status { get; set; }
        //更新时间
        public string UpdateTime { get; set; }
        //更新用户
        public string UpdateUser { get; set; }
        //备注
        public string Remark { get; set; }
        public ItemBaseOnHardware ItemBaseOnHardware { get; set; }
        public int ItemBaseOnHardwareID { get; set; }
    }
}
