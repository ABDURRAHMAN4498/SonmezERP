﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SonmezERP.Data;

#nullable disable

namespace SonmezERP.Migrations
{
    [DbContext(typeof(SonmezERPContext))]
    [Migration("20240327082117_UnitsOfMeasurementNametoUnitsOfMeasurement")]
    partial class UnitsOfMeasurementNametoUnitsOfMeasurement
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SonmezERP.Models.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BrandName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descraption")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("SonmezERP.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categoreis");
                });

            modelBuilder.Entity("SonmezERP.Models.Color", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ColorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Colors");
                });

            modelBuilder.Entity("SonmezERP.Models.DashboardSettings", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ActionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ControllerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IconePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DashboardSettingsItems");
                });

            modelBuilder.Entity("SonmezERP.Models.Kdv", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<float>("KdvName")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Kdv");
                });

            modelBuilder.Entity("SonmezERP.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Barcode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BrandId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CeateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ColorId")
                        .HasColumnType("int");

                    b.Property<int>("KdvId")
                        .HasColumnType("int");

                    b.Property<float>("PriceTl")
                        .HasColumnType("real");

                    b.Property<float>("PriceUSD")
                        .HasColumnType("real");

                    b.Property<string>("ProductCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductDetailsId")
                        .HasColumnType("int");

                    b.Property<string>("ProductNameEn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductNameTr")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UnitsOfMeasurementId")
                        .HasColumnType("int");

                    b.Property<bool>("Visiblity")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ColorId");

                    b.HasIndex("KdvId");

                    b.HasIndex("ProductDetailsId");

                    b.HasIndex("UnitsOfMeasurementId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("SonmezERP.Models.ProductDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Container")
                        .HasColumnType("int");

                    b.Property<string>("Coordinate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("CubicMeter")
                        .HasColumnType("real");

                    b.Property<string>("Descreption")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PackageHight")
                        .HasColumnType("int");

                    b.Property<int>("PackagePices")
                        .HasColumnType("int");

                    b.Property<int>("PackageSize")
                        .HasColumnType("int");

                    b.Property<int>("PackageWidth")
                        .HasColumnType("int");

                    b.Property<int>("ProductHight")
                        .HasColumnType("int");

                    b.Property<int>("ProductSize")
                        .HasColumnType("int");

                    b.Property<float>("ProductWeight")
                        .HasColumnType("real");

                    b.Property<int>("ProductWidth")
                        .HasColumnType("int");

                    b.Property<int>("Tir")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ProductDetails");
                });

            modelBuilder.Entity("SonmezERP.Models.ProductLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("ActionDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Input")
                        .HasColumnType("int");

                    b.Property<bool>("LogType")
                        .HasColumnType("bit");

                    b.Property<int>("Output")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductLogs");
                });

            modelBuilder.Entity("SonmezERP.Models.UnitsOfMeasurement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("UnitsOfMeasurementName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UnitsOfMeasurements");
                });

            modelBuilder.Entity("SonmezERP.Models.Product", b =>
                {
                    b.HasOne("SonmezERP.Models.Brand", "Brand")
                        .WithMany("Products")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SonmezERP.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SonmezERP.Models.Color", "Color")
                        .WithMany("Products")
                        .HasForeignKey("ColorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SonmezERP.Models.Kdv", "Kdv")
                        .WithMany("Products")
                        .HasForeignKey("KdvId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SonmezERP.Models.ProductDetails", "ProductDetails")
                        .WithMany("Products")
                        .HasForeignKey("ProductDetailsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SonmezERP.Models.UnitsOfMeasurement", "UnitsOfMeasurementName")
                        .WithMany("Products")
                        .HasForeignKey("UnitsOfMeasurementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");

                    b.Navigation("Category");

                    b.Navigation("Color");

                    b.Navigation("Kdv");

                    b.Navigation("ProductDetails");

                    b.Navigation("UnitsOfMeasurementName");
                });

            modelBuilder.Entity("SonmezERP.Models.ProductLog", b =>
                {
                    b.HasOne("SonmezERP.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("SonmezERP.Models.Brand", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("SonmezERP.Models.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("SonmezERP.Models.Color", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("SonmezERP.Models.Kdv", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("SonmezERP.Models.ProductDetails", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("SonmezERP.Models.UnitsOfMeasurement", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
