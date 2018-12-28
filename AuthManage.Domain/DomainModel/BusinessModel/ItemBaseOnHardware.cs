using AuthManage.Domain.BaseModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthManage.Domain.DomainModel.BusinessModel
{
    public class ItemBaseOnHardware:BasicModel<int>
    {
        //条目名称
        public string Name { get; set; }
        //状态
        public int Status { get; set; }
        /**更新时间、更新用户、备注是用来记录最新的一次跟新状态的**/
        //更新时间
        public string UpdateTime { get; set; }
        //更新用户
        public string UpdateUser { get; set; }
        //备注
        public string Remark { get; set; }
        //外键
        public int HardwareID { get; set; }
        public Hardware Hardware { get; set; }
        public ICollection<Record> Records { get; set; }
    }
}
