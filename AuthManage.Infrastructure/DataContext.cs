using AuthManage.Domain.DomainModel;
using AuthManage.Domain.DomainModel.BusinessModel;
using AuthManage.Domain.MappingModel;
using AuthManage.Domain.RelationModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthManage.Infrastructure
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Menu> Menus { get; set; }
        //两个第三方关联表集合
        public DbSet<RoleUser> RoleUsers { get; set; }
        public DbSet<RoleMenu> RoleMenus { get; set; }
        //业务表
        public DbSet<Project> Projects { get; set; }
        public DbSet<Hardware> Hardwares { get; set; }
        public DbSet<ItemBaseOnHardware> ItemBaseOnHardwares { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Record> Records { get; set; } 

        //模型映射关系
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //这种表映射关系的添加方式为Fluent API
            modelBuilder.ApplyConfiguration(new DepartmentUserMap());
            modelBuilder.ApplyConfiguration(new RoleUserMap());
            modelBuilder.ApplyConfiguration(new RoleMenuMap());
            modelBuilder.ApplyConfiguration(new ProjectHardwareMap());
            modelBuilder.ApplyConfiguration(new HardwareItemBaseOnHardwareMap());
            modelBuilder.ApplyConfiguration(new ItemBaseOnHardwareRecord());
            base.OnModelCreating(modelBuilder);
        }
    }
}
