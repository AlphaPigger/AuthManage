using AuthManage.Domain.DomainModel.BusinessModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthManage.Domain.MappingModel
{
    public class HardwareItemBaseOnHardwareMap: IEntityTypeConfiguration<ItemBaseOnHardware>
    {
        public void Configure(EntityTypeBuilder<ItemBaseOnHardware> builder)
        {
            builder.HasOne(p => p.Hardware).WithMany(i => i.ItemBaseOnHardwares).HasForeignKey(t=>t.HardwareID);
        }
    }
}
