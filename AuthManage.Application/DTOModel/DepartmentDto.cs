using AuthManage.Application.BaseModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AuthManage.Application.DTOModel
{
    public class DepartmentDto:BasicModel<int>
    {
        //部门名称
        [Required(ErrorMessage ="名字不能为空")]
        [Display(Name ="部门名")]
        public string Name { get; set; }
        //创建时间
        [Display(Name ="创建时间")]
        public string CreateTime { get; set; }
        //创建人
        [Display(Name ="创建人")]
        public string CreateUser { get; set; }
    }
}
