﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using POS_ApiServer.Data;

#nullable disable

namespace POS_ApiServer.Migrations
{
    [DbContext(typeof(DBContext))]
    [Migration("20231102185729_add isDeleted in Product Entity")]
    partial class addisDeletedinProductEntity
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("POS_ApiServer.Models.Address", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("city")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("personid")
                        .HasColumnType("int");

                    b.Property<string>("street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("streetNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("zipCode")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("personid");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("POS_ApiServer.Models.Person", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("dni")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Persons");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Person");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("POS_ApiServer.Models.Product", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<decimal>("currentPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("currentStock")
                        .HasColumnType("int");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("productCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("supplierid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("supplierid");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("POS_ApiServer.Models.Sale", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<decimal>("amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("customerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("dateTime")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("discount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("ticketNumber")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("customerId");

                    b.ToTable("Sales");
                });

            modelBuilder.Entity("POS_ApiServer.Models.SaleDetail", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("productId")
                        .HasColumnType("int");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.Property<int>("saleId")
                        .HasColumnType("int");

                    b.Property<decimal>("unitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("id");

                    b.HasIndex("productId");

                    b.HasIndex("saleId");

                    b.ToTable("SalesDetail");
                });

            modelBuilder.Entity("POS_ApiServer.Models.Customer", b =>
                {
                    b.HasBaseType("POS_ApiServer.Models.Person");

                    b.Property<int>("tieredType")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Customer");
                });

            modelBuilder.Entity("POS_ApiServer.Models.Supplier", b =>
                {
                    b.HasBaseType("POS_ApiServer.Models.Person");

                    b.Property<string>("tradeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("web")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Supplier");
                });

            modelBuilder.Entity("POS_ApiServer.Models.Address", b =>
                {
                    b.HasOne("POS_ApiServer.Models.Person", "person")
                        .WithMany("addresses")
                        .HasForeignKey("personid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("person");
                });

            modelBuilder.Entity("POS_ApiServer.Models.Product", b =>
                {
                    b.HasOne("POS_ApiServer.Models.Supplier", "supplier")
                        .WithMany("products")
                        .HasForeignKey("supplierid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("supplier");
                });

            modelBuilder.Entity("POS_ApiServer.Models.Sale", b =>
                {
                    b.HasOne("POS_ApiServer.Models.Customer", "customer")
                        .WithMany("sales")
                        .HasForeignKey("customerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("customer");
                });

            modelBuilder.Entity("POS_ApiServer.Models.SaleDetail", b =>
                {
                    b.HasOne("POS_ApiServer.Models.Product", "product")
                        .WithMany("saleDetails")
                        .HasForeignKey("productId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("POS_ApiServer.Models.Sale", "sale")
                        .WithMany("saleDetails")
                        .HasForeignKey("saleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("product");

                    b.Navigation("sale");
                });

            modelBuilder.Entity("POS_ApiServer.Models.Person", b =>
                {
                    b.Navigation("addresses");
                });

            modelBuilder.Entity("POS_ApiServer.Models.Product", b =>
                {
                    b.Navigation("saleDetails");
                });

            modelBuilder.Entity("POS_ApiServer.Models.Sale", b =>
                {
                    b.Navigation("saleDetails");
                });

            modelBuilder.Entity("POS_ApiServer.Models.Customer", b =>
                {
                    b.Navigation("sales");
                });

            modelBuilder.Entity("POS_ApiServer.Models.Supplier", b =>
                {
                    b.Navigation("products");
                });
#pragma warning restore 612, 618
        }
    }
}
