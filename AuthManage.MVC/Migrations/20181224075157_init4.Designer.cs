﻿// <auto-generated />
using AuthManage.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AuthManage.MVC.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20181224075157_init4")]
    partial class init4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("AuthManage.Domain.DomainModel.BusinessModel.Hardware", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreateTime");

                    b.Property<string>("CreateUser");

                    b.Property<string>("Name");

                    b.Property<int>("ProjectID");

                    b.HasKey("ID");

                    b.HasIndex("ProjectID");

                    b.ToTable("Hardwares");
                });

            modelBuilder.Entity("AuthManage.Domain.DomainModel.BusinessModel.Item", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreateTime");

                    b.Property<string>("CreateUser");

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("AuthManage.Domain.DomainModel.BusinessModel.ItemBaseOnHardware", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("HardwareID");

                    b.Property<string>("Name");

                    b.Property<string>("Record");

                    b.Property<int>("Status");

                    b.HasKey("ID");

                    b.HasIndex("HardwareID");

                    b.ToTable("ItemBaseOnHardwares");
                });

            modelBuilder.Entity("AuthManage.Domain.DomainModel.BusinessModel.Project", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreateTime");

                    b.Property<string>("CreateUser");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("AuthManage.Domain.DomainModel.Department", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreateTime");

                    b.Property<string>("CreateUser");

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("AuthManage.Domain.DomainModel.Menu", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("CreateTime");

                    b.Property<string>("CreateUser");

                    b.Property<int>("MenuType");

                    b.Property<string>("Name");

                    b.Property<int>("ParentID");

                    b.HasKey("ID");

                    b.ToTable("Menus");
                });

            modelBuilder.Entity("AuthManage.Domain.DomainModel.Role", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreateTime");

                    b.Property<string>("CreateUser");

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("AuthManage.Domain.DomainModel.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreateTime");

                    b.Property<string>("CreateUser");

                    b.Property<int>("DepartmentID");

                    b.Property<string>("Password");

                    b.Property<string>("PostType");

                    b.Property<string>("Username");

                    b.HasKey("ID");

                    b.HasIndex("DepartmentID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("AuthManage.Domain.RelationModel.RoleMenu", b =>
                {
                    b.Property<int>("RoleID");

                    b.Property<int>("MenuID");

                    b.HasKey("RoleID", "MenuID");

                    b.HasIndex("MenuID");

                    b.ToTable("RoleMenus");
                });

            modelBuilder.Entity("AuthManage.Domain.RelationModel.RoleUser", b =>
                {
                    b.Property<int>("RoleID");

                    b.Property<int>("UserID");

                    b.HasKey("RoleID", "UserID");

                    b.HasIndex("UserID");

                    b.ToTable("RoleUsers");
                });

            modelBuilder.Entity("AuthManage.Domain.DomainModel.BusinessModel.Hardware", b =>
                {
                    b.HasOne("AuthManage.Domain.DomainModel.BusinessModel.Project", "Project")
                        .WithMany("Hardwares")
                        .HasForeignKey("ProjectID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AuthManage.Domain.DomainModel.BusinessModel.ItemBaseOnHardware", b =>
                {
                    b.HasOne("AuthManage.Domain.DomainModel.BusinessModel.Hardware", "Hardware")
                        .WithMany("ItemBaseOnHardwares")
                        .HasForeignKey("HardwareID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AuthManage.Domain.DomainModel.User", b =>
                {
                    b.HasOne("AuthManage.Domain.DomainModel.Department", "Department")
                        .WithMany("Users")
                        .HasForeignKey("DepartmentID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AuthManage.Domain.RelationModel.RoleMenu", b =>
                {
                    b.HasOne("AuthManage.Domain.DomainModel.Menu", "Menu")
                        .WithMany("RoleMenus")
                        .HasForeignKey("MenuID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AuthManage.Domain.DomainModel.Role", "Role")
                        .WithMany("RoleMenus")
                        .HasForeignKey("RoleID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AuthManage.Domain.RelationModel.RoleUser", b =>
                {
                    b.HasOne("AuthManage.Domain.DomainModel.Role", "Role")
                        .WithMany("RoleUsers")
                        .HasForeignKey("RoleID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AuthManage.Domain.DomainModel.User", "User")
                        .WithMany("RoleUsers")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
