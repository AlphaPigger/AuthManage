using AuthManage.Domain.RelationModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthManage.Domain.MappingModel
{
    public class RoleUserMap: IEntityTypeConfiguration<RoleUser>
    {
        public void Configure(EntityTypeBuilder<RoleUser> builder)
        {
            //添加复合主键
            builder.HasKey(t=>new { t.RoleID,t.UserID});
            //role表和rolemenu表的一对多关系
            builder.HasOne(r => r.Role).WithMany(u => u.RoleUsers).HasForeignKey(t=>t.RoleID);
            //user表和rolemenu表的一对多关系
            builder.HasOne(u => u.User).WithMany(r => r.RoleUsers).HasForeignKey(t => t.UserID);
        }
    }
}
