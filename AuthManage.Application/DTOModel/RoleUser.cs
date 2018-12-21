using System;
using System.Collections.Generic;
using System.Text;

namespace AuthManage.Application.DTOModel
{
    public class RoleUserDto
    {
        public int RoleID { get; set; }
        public int UserID { get; set; }
        public RoleDto RoleDto { get; set; }
        public UserDto UserDto { get; set; }
    }
}
