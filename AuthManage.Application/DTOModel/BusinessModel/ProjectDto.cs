using AuthManage.Application.BaseModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AuthManage.Application.DTOModel.BusinessModel
{
    public class ProjectDto:BasicModel<int>
    {
        [Display(Name ="项目名称")]
        [Required(ErrorMessage ="项目名称不能为空")]
        public string Name { get; set; }
        [Display(Name ="创建时间")]
        public string CreateTime { get; set; }
        [Display(Name ="创建人")]
        public string CreateUser { get; set; }
        //描述
        [Display(Name ="项目描述")]
        [Required(ErrorMessage ="项目描述不能为空")]
        public string Description { get; set; }
    }
}
