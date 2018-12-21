using AuthManage.Application.BaseModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AuthManage.Application.DTOModel
{
    public class MenuDto:BasicModel<int>
    {
        //父级
        [Display(Name ="父级")]
        public string ParentName { get; set; }
        //功能名
        [Display(Name = "功能名")]
        [Required(ErrorMessage ="功能名不能为空")]
        public string Name { get; set; }
        //功能地址
        [Display(Name="功能地址")]
        [Required(ErrorMessage ="功能地址不能为空")]
        public string Address { get; set; }
        //功能类型
        [Display(Name ="功能类型")]
        public string MenuType { get; set; }
        //创建时间
        [Display(Name ="创建时间")]
        public string CreateTime { get; set; }
        //创建人
        [Display(Name="创建人")]
        public string CreateUser { get; set; }
    }
}
