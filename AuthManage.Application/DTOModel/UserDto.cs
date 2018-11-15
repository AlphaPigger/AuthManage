using AuthManage.Application.BaseModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AuthManage.Application.DTOModel
{
    public class UserDto:BasicModel<int>
    {
        //用户名
        [Display(Name ="用户名")]
        [Required(ErrorMessage ="用户名不能为空")]
        public string Username { get; set; }
        //密码
        [Display(Name ="密码")]
        [Required(ErrorMessage ="密码不能为空")]
        public string Password { get; set; }
        //技术类别
        [Display(Name = "技术类别")]
        public string PostType { get; set; }
        //创建时间
        [Display(Name ="创建时间")]
        public string CreateTime { get; set; }
        //创建人
        [Display(Name ="创建人")]
        public string CreateUser { get; set; }
        //部门
        [Display(Name ="所属部门")]
        public string Department { get; set; }
        //角色
        [Display(Name ="角色")]
        public List<string> Roles { get; set; }
    }
}
