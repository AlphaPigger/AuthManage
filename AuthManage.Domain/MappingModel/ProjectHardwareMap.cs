using AuthManage.Domain.DomainModel.BusinessModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthManage.Domain.MappingModel
{
    public class ProjectHardwareMap: IEntityTypeConfiguration<Hardware>
    {
        public void Configure(EntityTypeBuilder<Hardware> builder)
        {
            builder.HasOne(h => h.Project).WithMany(p => p.Hardwares).HasForeignKey(f=>f.ProjectID);
        }
    }
}
