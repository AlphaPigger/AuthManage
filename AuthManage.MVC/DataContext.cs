using AuthManage.Domain.DomainModel;
using AuthManage.Domain.MappingModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthManage.MVC
{
    public class DataContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Menu> Menus { get; set; }

        //连接数据库
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var ConnectString = "server=localhost;port=3306;database=AuthManage;user=root;password=123456";
            optionsBuilder.UseMySql(ConnectString);
            base.OnConfiguring(optionsBuilder);
        }

        //模型映射关系
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RoleMenuMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
