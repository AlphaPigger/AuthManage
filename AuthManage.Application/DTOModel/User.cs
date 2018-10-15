using AuthManage.Application.BaseModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthManage.Application.DTOModel
{
    public class User:BasicModel<int>
    {
        //用户名
        public string Username { get; set; }
        //密码
        public string Password { get; set; }
        //联系号码
        public string ContactNumber { get; set; }
    }
}
