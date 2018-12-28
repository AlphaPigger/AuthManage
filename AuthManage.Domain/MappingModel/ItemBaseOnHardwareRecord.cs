using AuthManage.Domain.DomainModel.BusinessModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthManage.Domain.MappingModel
{
    public class ItemBaseOnHardwareRecord: IEntityTypeConfiguration<Record>
    {
        public void Configure(EntityTypeBuilder<Record> builder)
        {
            builder.HasOne(p => p.ItemBaseOnHardware).WithMany(i => i.Records).HasForeignKey(t => t.ItemBaseOnHardwareID);
        }
    }
}
