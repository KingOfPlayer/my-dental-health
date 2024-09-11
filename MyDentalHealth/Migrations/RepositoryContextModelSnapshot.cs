﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repository;

#nullable disable

namespace MyDentalHealth.Migrations
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

            modelBuilder.Entity("Entity.Models.Advice.Advice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Advices");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "1",
                            Name = "1"
                        },
                        new
                        {
                            Id = 2,
                            Description = "2",
                            Name = "2"
                        },
                        new
                        {
                            Id = 3,
                            Description = "3",
                            Name = "3"
                        },
                        new
                        {
                            Id = 4,
                            Description = "4",
                            Name = "4"
                        },
                        new
                        {
                            Id = 5,
                            Description = "5",
                            Name = "5"
                        },
                        new
                        {
                            Id = 6,
                            Description = "6",
                            Name = "6"
                        },
                        new
                        {
                            Id = 7,
                            Description = "7",
                            Name = "7"
                        },
                        new
                        {
                            Id = 8,
                            Description = "8",
                            Name = "8"
                        });
                });

            modelBuilder.Entity("Entity.Models.Target.Status.TargetStatus", b =>
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

                    b.Property<int>("TargetId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TargetId");

                    b.ToTable("TargetStatus");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Attime = new DateTime(2024, 9, 9, 16, 19, 41, 17, DateTimeKind.Local).AddTicks(6158),
                            ImgHash = "",
                            Minutes = 0,
                            Second = 10,
                            TargetId = 1
                        },
                        new
                        {
                            Id = 2,
                            Attime = new DateTime(2024, 8, 26, 16, 19, 41, 17, DateTimeKind.Local).AddTicks(6160),
                            ImgHash = "",
                            Minutes = 0,
                            Second = 10,
                            TargetId = 1
                        });
                });

            modelBuilder.Entity("Entity.Models.Target.Target", b =>
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

                    b.Property<int>("TargetPeriodTypeId")
                        .HasColumnType("int");

                    b.Property<int>("TargetPiroityId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TargetPeriodTypeId");

                    b.HasIndex("TargetPiroityId");

                    b.HasIndex("UserId");

                    b.ToTable("Targets");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Count = 1,
                            Description = "My Description",
                            Name = "My Target Test",
                            PeriodLength = 1,
                            PeriodTime = new DateTime(2024, 9, 10, 16, 19, 41, 17, DateTimeKind.Local).AddTicks(6042),
                            TargetPeriodTypeId = 1,
                            TargetPiroityId = 1,
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            Count = 10,
                            Description = "My Description",
                            Name = "My Target Test2",
                            PeriodLength = 2,
                            PeriodTime = new DateTime(2024, 7, 22, 16, 19, 41, 17, DateTimeKind.Local).AddTicks(6063),
                            TargetPeriodTypeId = 2,
                            TargetPiroityId = 1,
                            UserId = 1
                        });
                });

            modelBuilder.Entity("Entity.Models.Target.TargetPeriodType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TargetPeriodTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Day"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Week"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Month"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Year"
                        });
                });

            modelBuilder.Entity("Entity.Models.Target.TargetPiroity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TargetPiroities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "High"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Medium"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Low"
                        });
                });

            modelBuilder.Entity("Entity.Models.User.User", b =>
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

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BirthdayDate = new DateTime(1999, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "admin@admin.com",
                            Name = "admin",
                            Password = "YP50QG5/NT7ZefNQ8vu2ouhpCl+n0bDDKYPR2LP5X2c=",
                            Surname = "admin"
                        });
                });

            modelBuilder.Entity("Entity.Models.User.UserRole", b =>
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

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            Name = "User"
                        });
                });

            modelBuilder.Entity("Entity.Models.User.UserUserRole", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("UserRoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "UserRoleId");

                    b.HasIndex("UserRoleId");

                    b.ToTable("UserUserRoles");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            UserRoleId = 1
                        },
                        new
                        {
                            UserId = 1,
                            UserRoleId = 2
                        });
                });

            modelBuilder.Entity("Entity.Models.Target.Status.TargetStatus", b =>
                {
                    b.HasOne("Entity.Models.Target.Target", "Target")
                        .WithMany("TargetStatuses")
                        .HasForeignKey("TargetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Target");
                });

            modelBuilder.Entity("Entity.Models.Target.Target", b =>
                {
                    b.HasOne("Entity.Models.Target.TargetPeriodType", "TargetPeriodType")
                        .WithMany("Target")
                        .HasForeignKey("TargetPeriodTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entity.Models.Target.TargetPiroity", "TargetPiroity")
                        .WithMany("Target")
                        .HasForeignKey("TargetPiroityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entity.Models.User.User", "User")
                        .WithMany("Target")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TargetPeriodType");

                    b.Navigation("TargetPiroity");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Entity.Models.User.UserUserRole", b =>
                {
                    b.HasOne("Entity.Models.User.User", "User")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entity.Models.User.UserRole", "UserRole")
                        .WithMany("Users")
                        .HasForeignKey("UserRoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");

                    b.Navigation("UserRole");
                });

            modelBuilder.Entity("Entity.Models.Target.Target", b =>
                {
                    b.Navigation("TargetStatuses");
                });

            modelBuilder.Entity("Entity.Models.Target.TargetPeriodType", b =>
                {
                    b.Navigation("Target");
                });

            modelBuilder.Entity("Entity.Models.Target.TargetPiroity", b =>
                {
                    b.Navigation("Target");
                });

            modelBuilder.Entity("Entity.Models.User.User", b =>
                {
                    b.Navigation("Roles");

                    b.Navigation("Target");
                });

            modelBuilder.Entity("Entity.Models.User.UserRole", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
