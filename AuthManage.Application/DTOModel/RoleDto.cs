using AuthManage.Application.BaseModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AuthManage.Application.DTOModel
{
    public class RoleDto:BasicModel<int>
    {
        //角色名
        [Required(ErrorMessage = "角色名不能为空")]
        [Display(Name ="角色名")]
        public string Name { get; set; }
        //创建时间
        [Display(Name ="创建时间")]
        public string CreateTime { get; set; }
        //创建人
        [Display(Name ="创建人")]
        public string CreateUser { get; set; }
    }
}
