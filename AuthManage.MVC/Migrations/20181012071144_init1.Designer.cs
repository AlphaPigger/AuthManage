﻿// <auto-generated />
using System;
using AuthManage.MVC;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AuthManage.MVC.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20181012071144_init1")]
    partial class init1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("AuthManage.Domain.DomainModel.Department", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ContactNumber");

                    b.Property<string>("Manager");

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("AuthManage.Domain.DomainModel.Menu", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("Menus");
                });

            modelBuilder.Entity("AuthManage.Domain.DomainModel.Role", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("AuthManage.Domain.DomainModel.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ContactNumber");

                    b.Property<int?>("DepartmentID");

                    b.Property<string>("Password");

                    b.Property<int?>("RoleID");

                    b.Property<string>("Username");

                    b.HasKey("ID");

                    b.HasIndex("DepartmentID");

                    b.HasIndex("RoleID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("AuthManage.Domain.RelationModel.RoleMenu", b =>
                {
                    b.Property<int>("RoleID");

                    b.Property<int>("MenuID");

                    b.HasKey("RoleID", "MenuID");

                    b.HasIndex("MenuID");

                    b.ToTable("RoleMenu");
                });

            modelBuilder.Entity("AuthManage.Domain.DomainModel.User", b =>
                {
                    b.HasOne("AuthManage.Domain.DomainModel.Department")
                        .WithMany("Users")
                        .HasForeignKey("DepartmentID");

                    b.HasOne("AuthManage.Domain.DomainModel.Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleID");
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
#pragma warning restore 612, 618
        }
    }
}
