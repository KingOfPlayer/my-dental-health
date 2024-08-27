﻿// <auto-generated />
using System;
using EntityRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace my_dental_health.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    partial class RepositoryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Entity.Target.Status.TargetStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Attime")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImgHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Minutes")
                        .HasColumnType("int");

                    b.Property<int>("Second")
                        .HasColumnType("int");

                    b.Property<int>("TargetsId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TargetsId");

                    b.ToTable("TargetStatus");
                });

            modelBuilder.Entity("Entity.Target.TagetPeriodType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Name")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("TagetPeriodTypes");
                });

            modelBuilder.Entity("Entity.Target.Target", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PeriodLength")
                        .HasColumnType("int");

                    b.Property<DateTime>("PeriodTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("TagetPeriodTypeId")
                        .HasColumnType("int");

                    b.Property<int>("TargetPiroityId")
                        .HasColumnType("int");

                    b.Property<int>("UsersId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TagetPeriodTypeId");

                    b.HasIndex("TargetPiroityId");

                    b.HasIndex("UsersId");

                    b.ToTable("Targets");
                });

            modelBuilder.Entity("Entity.Target.TargetPiroity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TargetPiroity");
                });

            modelBuilder.Entity("Entity.User.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("BirthdayDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Entity.User.UserLogin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CookieHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UsersId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsersId");

                    b.ToTable("UserLogins");
                });

            modelBuilder.Entity("Entity.User.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("UserUserRole", b =>
                {
                    b.Property<int>("UserRolesId")
                        .HasColumnType("int");

                    b.Property<int>("UsersId")
                        .HasColumnType("int");

                    b.HasKey("UserRolesId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("UserUserRole");
                });

            modelBuilder.Entity("Entity.Target.Status.TargetStatus", b =>
                {
                    b.HasOne("Entity.Target.Target", "Targets")
                        .WithMany("TargetStatus")
                        .HasForeignKey("TargetsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Targets");
                });

            modelBuilder.Entity("Entity.Target.Target", b =>
                {
                    b.HasOne("Entity.Target.TagetPeriodType", "TagetPeriodType")
                        .WithMany("Targets")
                        .HasForeignKey("TagetPeriodTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entity.Target.TargetPiroity", "TargetPiroity")
                        .WithMany("targets")
                        .HasForeignKey("TargetPiroityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entity.User.User", "Users")
                        .WithMany("Targets")
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TagetPeriodType");

                    b.Navigation("TargetPiroity");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("Entity.User.UserLogin", b =>
                {
                    b.HasOne("Entity.User.User", "Users")
                        .WithMany("UserLogins")
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Users");
                });

            modelBuilder.Entity("UserUserRole", b =>
                {
                    b.HasOne("Entity.User.UserRole", null)
                        .WithMany()
                        .HasForeignKey("UserRolesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entity.User.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Entity.Target.TagetPeriodType", b =>
                {
                    b.Navigation("Targets");
                });

            modelBuilder.Entity("Entity.Target.Target", b =>
                {
                    b.Navigation("TargetStatus");
                });

            modelBuilder.Entity("Entity.Target.TargetPiroity", b =>
                {
                    b.Navigation("targets");
                });

            modelBuilder.Entity("Entity.User.User", b =>
                {
                    b.Navigation("Targets");

                    b.Navigation("UserLogins");
                });
#pragma warning restore 612, 618
        }
    }
}
