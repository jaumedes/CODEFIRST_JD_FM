﻿// <auto-generated />
using System;
using CODEFIRST_JD_FM;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CODEFIRST_JD_FM.Migrations
{
    [DbContext(typeof(CompanyDBContext))]
    [Migration("20240304162656_second")]
    partial class second
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.32")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("CODEFIRST_JD_FM.MODEL.Employees", b =>
                {
                    b.Property<int>("employeeNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT(11)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(50);

                    b.Property<string>("extension")
                        .IsRequired()
                        .HasColumnType("varchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("firstName")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("jobTitle")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("officeCode")
                        .IsRequired()
                        .HasColumnType("varchar(10)")
                        .HasMaxLength(50);

                    b.Property<int?>("reportsTo")
                        .HasColumnType("INT(11)");

                    b.HasKey("employeeNumber");

                    b.HasIndex("officeCode");

                    b.HasIndex("reportsTo");

                    b.ToTable("EMPLOYEES");
                });

            modelBuilder.Entity("CODEFIRST_JD_FM.MODEL.Offices", b =>
                {
                    b.Property<string>("officeCode")
                        .HasColumnType("varchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("addressLine1")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("addressLine2")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("city")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("country")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("phone")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("postalCode")
                        .IsRequired()
                        .HasColumnType("varchar(15)")
                        .HasMaxLength(15);

                    b.Property<string>("state")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("territory")
                        .IsRequired()
                        .HasColumnType("varchar(10)")
                        .HasMaxLength(10);

                    b.HasKey("officeCode");

                    b.ToTable("OFFICES");
                });

            modelBuilder.Entity("CODEFIRST_JD_FM.MODEL.ProductLines", b =>
                {
                    b.Property<string>("productLineName")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("htmlDescription")
                        .HasColumnType("mediumtext");

                    b.Property<byte[]>("image")
                        .HasColumnType("mediumblob");

                    b.Property<string>("textDescription")
                        .IsRequired()
                        .HasColumnType("varchar(4000)")
                        .HasMaxLength(50);

                    b.HasKey("productLineName");

                    b.ToTable("PRODUCTLINES");
                });

            modelBuilder.Entity("CODEFIRST_JD_FM.MODEL.Products", b =>
                {
                    b.Property<string>("productCode")
                        .HasColumnType("varchar(15)")
                        .HasMaxLength(15);

                    b.Property<decimal>("MSRP")
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal>("buyPrice")
                        .HasColumnType("decimal(10,2)");

                    b.Property<string>("productDescription")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("productLine")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("productName")
                        .IsRequired()
                        .HasColumnType("varchar(70)")
                        .HasMaxLength(70);

                    b.Property<string>("productScale")
                        .IsRequired()
                        .HasColumnType("varchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("productVendor")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<short>("quantityStock")
                        .HasColumnType("smallint(6)");

                    b.HasKey("productCode");

                    b.HasIndex("productLine");

                    b.ToTable("PRODUCTS");
                });

            modelBuilder.Entity("CODEFIRST_JD_FM.MODEL.Employees", b =>
                {
                    b.HasOne("CODEFIRST_JD_FM.MODEL.Offices", "Offices")
                        .WithMany("Employees")
                        .HasForeignKey("officeCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CODEFIRST_JD_FM.MODEL.Employees", "employeesToReport")
                        .WithMany()
                        .HasForeignKey("reportsTo");
                });

            modelBuilder.Entity("CODEFIRST_JD_FM.MODEL.Products", b =>
                {
                    b.HasOne("CODEFIRST_JD_FM.MODEL.ProductLines", "productLines")
                        .WithMany("Products")
                        .HasForeignKey("productLine")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
