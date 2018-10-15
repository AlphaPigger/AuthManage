using AuthManage.Domain.BaseModel;
using AuthManage.Domain.DomainModel;
using AuthManage.Domain.RelationModel;
//EF Core
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthManage.Domain.MappingModel
{
    public class RoleMenuMap: IEntityTypeConfiguration<RoleMenu>
    {
        public void Configure(EntityTypeBuilder<RoleMenu> builder)
        {
            //添加复合主键
            builder.HasKey(t => new { t.RoleID, t.MenuID });

            //配置Role与RoleMenu的一对多关系
            builder.HasOne(t => t.Role).WithMany(p => p.RoleMenus).HasForeignKey(t=>t.RoleID);

            //配置Menu与RoleMenu的一对多关系
            builder.HasOne(t=>t.Menu).WithMany(p=>p.RoleMenus).HasForeignKey(t=>t.MenuID);
            
        }
    }
}
