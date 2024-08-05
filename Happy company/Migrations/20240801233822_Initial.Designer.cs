﻿// <auto-generated />
using System;
using Happy_company.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Happy_company.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240801233822_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.8");

            modelBuilder.Entity("Happy_company.Model.Domain.Items", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("CostPrice")
                        .HasColumnType("TEXT");

                    b.Property<decimal?>("MSRPPrice")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("QTY")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SKUCode")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("WarehouseId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("WarehouseId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("Happy_company.Model.Domain.Lookup.Country", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            Id = new Guid("f5c3e4b7-6d3b-4c7a-9c79-59c0c73c1d50"),
                            Code = "PS",
                            Name = "Palestine"
                        },
                        new
                        {
                            Id = new Guid("f5a3e4b7-6d3b-4a7a-9c79-59a0c73c1d50"),
                            Code = "JO",
                            Name = "Jordan"
                        },
                        new
                        {
                            Id = new Guid("5d3b9e2e-7423-4cb7-a3e5-d73a67e39d29"),
                            Code = "EG",
                            Name = "Egypt"
                        },
                        new
                        {
                            Id = new Guid("7e3c6f56-963b-4f43-a08c-d6c52c9b37d4"),
                            Code = "SA",
                            Name = "Saudi Arabia"
                        },
                        new
                        {
                            Id = new Guid("f2f59b45-885c-4a0b-a76e-5b9146d88f26"),
                            Code = "SY",
                            Name = "Syria"
                        });
                });

            modelBuilder.Entity("Happy_company.Model.Domain.Lookup.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("8f8d1d70-f81d-4e65-9c3d-1b7f1b7e5c1a"),
                            Type = "Admin"
                        },
                        new
                        {
                            Id = new Guid("d9b1e9d8-7d58-4a6f-9ef5-ccbd7eab16a7"),
                            Type = "Management"
                        },
                        new
                        {
                            Id = new Guid("e4e0b1c4-9624-4e27-8c1b-2d9a9e8e54a0"),
                            Type = "Auditor"
                        });
                });

            modelBuilder.Entity("Happy_company.Model.Domain.RequestLog", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Method")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("QueryString")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("RequestLogs", (string)null);
                });

            modelBuilder.Entity("Happy_company.Model.Domain.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<bool>("Active")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasDefaultValue(false);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("RoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("3d748d79-cd2d-4d67-9d4e-c0ea6e66e44e"),
                            Active = true,
                            Email = "admin@happywarehouse.com",
                            Name = "admin",
                            Password = "P@ssw0rd",
                            RoleId = new Guid("8f8d1d70-f81d-4e65-9c3d-1b7f1b7e5c1a")
                        });
                });

            modelBuilder.Entity("Happy_company.Model.Domain.Warehouse", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CountryID")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CountryID");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Warehouses");
                });

            modelBuilder.Entity("Happy_company.Model.Domain.Items", b =>
                {
                    b.HasOne("Happy_company.Model.Domain.Warehouse", null)
                        .WithMany()
                        .HasForeignKey("WarehouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Happy_company.Model.Domain.User", b =>
                {
                    b.HasOne("Happy_company.Model.Domain.Lookup.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Happy_company.Model.Domain.Warehouse", b =>
                {
                    b.HasOne("Happy_company.Model.Domain.Lookup.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });
#pragma warning restore 612, 618
        }
    }
}
