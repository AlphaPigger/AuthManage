using AuthManage.Application.BaseModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AuthManage.Application.DTOModel.BusinessModel
{
    public class ItemDto:BasicModel<int>
    {
        [Display(Name="条目名称")]
        public string Name { get; set; }
        [Display(Name ="创建时间")]
        public string CreateTime { get; set; }
        [Display(Name ="创建人")]
        public string CreateUser { get; set; }
    }
}
