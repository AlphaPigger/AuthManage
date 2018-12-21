using AuthManage.Domain.DomainModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthManage.Domain.RelationModel
{
    //Role和User的关联表
    public class RoleUser
    {
        public int RoleID { get; set; }
        public int UserID { get; set; }
        public Role Role { get; set; }
        public User User { get; set; }
        public RoleUser(int roleID, int userID)
        {
            RoleID = roleID;
            UserID = userID;
        }
    }
}
