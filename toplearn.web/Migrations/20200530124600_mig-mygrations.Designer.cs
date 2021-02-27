﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using toplearn.Datalayer.Context;

namespace toplearn.Datalayer.Migrations
{
    [DbContext(typeof(ToplearnContext))]
    [Migration("20200530124600_mig-mygrations")]
    partial class migmygrations
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("toplearn.Datalayer.Entities.User.Role", b =>
                {
                    b.Property<int>("RolID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RolTitle")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("RolID");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("toplearn.Datalayer.Entities.User.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ActiveCode")
                        .HasMaxLength(50);

                    b.Property<string>("Avatar")
                        .HasMaxLength(200);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<bool>("IsActive");

                    b.Property<string>("PassWord")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<DateTime>("RegisterDate");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("UserID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("toplearn.Datalayer.Entities.User.UserRole", b =>
                {
                    b.Property<int>("UR_ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("RolID");

                    b.Property<int>("UserID");

                    b.HasKey("UR_ID");

                    b.HasIndex("RolID");

                    b.HasIndex("UserID");

                    b.ToTable("userRoles");
                });

            modelBuilder.Entity("toplearn.Datalayer.Entities.User.UserRole", b =>
                {
                    b.HasOne("toplearn.Datalayer.Entities.User.Role", "role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RolID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("toplearn.Datalayer.Entities.User.User", "user")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
