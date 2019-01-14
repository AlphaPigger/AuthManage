using AuthManage.Application.BaseModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AuthManage.Application.DTOModel.BusinessModel
{
    public class HardwareDto:BasicModel<int>
    {
        [Display(Name ="硬件名称")]
        [Required(ErrorMessage ="硬件名称不能为空")]
        public string Name { get; set; }
        [Display(Name ="编号")]
        [Required(ErrorMessage = "硬件编号不能为空")]
        public string Number { get; set; }
        [Display(Name ="创建时间")]
        public string CreateTime { get; set; }
        [Display(Name ="创建人")]
        public string CreateUser { get; set; }
        //所属工程
        [Display(Name ="所属项目")]
        public string Project { get; set; }
        //包含条目
        [Display(Name ="条目")]
        public List<string> Items { get; set; }
    }
}
