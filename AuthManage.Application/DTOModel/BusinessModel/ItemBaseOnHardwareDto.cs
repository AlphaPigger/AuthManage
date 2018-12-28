using AuthManage.Application.BaseModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AuthManage.Application.DTOModel.BusinessModel
{
    public class ItemBaseOnHardwareDto:BasicModel<int>
    {
        [Display(Name="名称")]
        public string Name { get; set; }
        //状态
        [Display(Name ="状态")]
        public string Status { get; set; }
        [Display(Name ="更新时间")]
        public string UpdateTime { get; set; }
        [Display(Name="更新用户")]
        public string UpdateUser { get; set; }
        //记录
        [Display(Name ="备注")]
        [MaxLength(20,ErrorMessage ="输入最大长度为20")]
        public string Remark { get; set; }
    }
}
