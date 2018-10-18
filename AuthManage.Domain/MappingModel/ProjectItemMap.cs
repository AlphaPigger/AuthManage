using AuthManage.Domain.DomainModel.BusinessModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthManage.Domain.MappingModel
{
    public class ProjectItemMap: IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.HasOne(p => p.Project).WithMany(i => i.Items).HasForeignKey(t=>t.ProjectID);
        }
    }
}
