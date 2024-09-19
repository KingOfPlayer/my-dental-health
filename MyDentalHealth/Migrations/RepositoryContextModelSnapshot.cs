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
                            Description = "Brushing your teeth twice a day with fluoride toothpaste helps remove plaque and bacteria, keeping your teeth and gums healthy.",
                            Name = "Brush Twice Daily"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Flossing once a day removes food particles and plaque from between teeth, areas a toothbrush can't reach, reducing the risk of gum disease and cavities.",
                            Name = "Floss Daily"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Mouthwash can help kill bacteria, freshen breath, and strengthen enamel, especially when using fluoride or antiseptic mouthwashes.",
                            Name = "Use Mouthwash"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Excess sugar in your diet fuels bacteria that produce acid, leading to tooth decay. Avoid sugary snacks and beverages, especially between meals.",
                            Name = "Limit Sugary Foods and Drinks"
                        },
                        new
                        {
                            Id = 5,
                            Description = "Drinking water helps wash away food particles and bacteria, and staying hydrated ensures your mouth produces enough saliva to protect your teeth.",
                            Name = "Stay Hydrated"
                        },
                        new
                        {
                            Id = 6,
                            Description = "Regular dental check-ups and cleanings (every 6 months) allow for early detection of problems and professional plaque removal.",
                            Name = "Visit Your Dentist Regularly"
                        },
                        new
                        {
                            Id = 7,
                            Description = "Smoking and using tobacco can lead to gum disease, tooth decay, and even oral cancer. Avoiding these products is key to long-term oral health.",
                            Name = "Don’t Use Tobacco Products"
                        },
                        new
                        {
                            Id = 8,
                            Description = "A soft-bristle toothbrush is gentle on your gums and enamel, reducing the risk of erosion or irritation. Replace your toothbrush every 3-4 months.",
                            Name = "Use a Soft-Bristle Toothbrush"
                        },
                        new
                        {
                            Id = 9,
                            Description = "Foods rich in calcium, vitamin D, and phosphorus help strengthen teeth and bones, while crunchy fruits and vegetables stimulate saliva production.",
                            Name = "Eat a Balanced Diet"
                        },
                        new
                        {
                            Id = 10,
                            Description = "If you play contact sports, wearing a mouthguard helps protect your teeth from injury or trauma, reducing the risk of chipped or broken teeth.",
                            Name = "Wear a Mouthguard for Sports"
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
                            Attime = new DateTime(2024, 9, 18, 11, 18, 22, 829, DateTimeKind.Local).AddTicks(6885),
                            ImgHash = "",
                            Minutes = 0,
                            Second = 10,
                            TargetId = 1
                        },
                        new
                        {
                            Id = 2,
                            Attime = new DateTime(2024, 9, 4, 11, 18, 22, 829, DateTimeKind.Local).AddTicks(6888),
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
                            PeriodTime = new DateTime(2024, 9, 19, 11, 18, 22, 829, DateTimeKind.Local).AddTicks(6753),
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
                            PeriodTime = new DateTime(2024, 7, 31, 11, 18, 22, 829, DateTimeKind.Local).AddTicks(6772),
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
                            Password = "elZ/nqXsL8E8T1V+9ZPb0bI4HZD0Sc7/ok9DdfxVFjQuGHj+Scya3q9wLXiX+I36",
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

            modelBuilder.Entity("Entity.Models.User.UserSession", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(449)");

                    b.Property<DateTimeOffset?>("AbsoluteExpiration")
                        .HasColumnType("datetimeoffset(7)");

                    b.Property<DateTimeOffset>("ExpiresAtTime")
                        .HasColumnType("datetimeoffset(7)");

                    b.Property<long?>("SlidingExpirationInSeconds")
                        .HasColumnType("bigint");

                    b.Property<byte[]>("Value")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.ToTable("UserSessions");
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
