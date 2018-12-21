using System;
using System.Collections.Generic;
using System.Text;

namespace AuthManage.Application.DTOModel
{
    public class RoleMenuDto
    {
        public int RoleID { get; set; }
        public int MenuID { get; set; }
        public RoleDto RoleDto { get; set; }
        public MenuDto MenuDto { get; set; }
    }
}
