using AuthManage.Domain.BaseModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthManage.Domain.DomainModel.BusinessModel
{
    public class Item : BasicModel<int>
    {
        /**组件属性**/
        //组件名
        public string Name { get; set; }
        //标识
        public string Number { get; set; }
        //硬件
        public string Hardware { get; set; }
        //硬件状态
        public bool Hardware_Status { get; set; }
        //硬件描述
        public string Hardware_Detail { get; set; }
        //高低温
        public string TempterTest { get; set; }
        //高低温状态
        public bool TempterTest_Status { get; set; }
        //高低温描述
        public string TempterTest_Detail { get; set; }
        //软件
        public string Software { get; set; }
        //软件状态
        public bool Software_Status { get; set; }
        //软件描述
        public string Software_Detail { get; set; }
        //测试
        public string Test { get; set; }
        //测试状态
        public bool Test_Status { get; set; }
        //测试描述
        public string Test_Detail { get; set; }

        //外键
        public int ProjectID { get; set; }
        //引用属性
        public Project Project { get; set; }
    }
}
