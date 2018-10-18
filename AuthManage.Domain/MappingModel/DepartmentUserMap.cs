using AuthManage.Domain.DomainModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthManage.Domain.MappingModel
{
    public class DepartmentUserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasOne(u => u.Department).WithMany(d => d.Users).HasForeignKey(t => t.DepartmentID);
        }
    }
}