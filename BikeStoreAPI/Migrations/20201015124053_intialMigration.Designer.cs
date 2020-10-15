﻿// <auto-generated />
using System;
using BikeStoreAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BikeStoreAPI.Migrations
{
    [DbContext(typeof(BikeStoresContext))]
    [Migration("20201015124053_intialMigration")]
    partial class intialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BikeStoreAPI.Models.Brands", b =>
                {
                    b.Property<int>("BrandId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("brand_id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BrandName")
                        .IsRequired()
                        .HasColumnName("brand_name")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.HasKey("BrandId")
                        .HasName("PK__brands__5E5A8E27ED4D7F76");

                    b.ToTable("brands","production");
                });

            modelBuilder.Entity("BikeStoreAPI.Models.Categories", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("category_id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnName("category_name")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.HasKey("CategoryId")
                        .HasName("PK__categori__D54EE9B48FB67C9E");

                    b.ToTable("categories","production");
                });

            modelBuilder.Entity("BikeStoreAPI.Models.Customers", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("customer_id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasColumnName("city")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("email")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnName("first_name")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnName("last_name")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<string>("Phone")
                        .HasColumnName("phone")
                        .HasColumnType("varchar(25)")
                        .HasMaxLength(25)
                        .IsUnicode(false);

                    b.Property<string>("State")
                        .HasColumnName("state")
                        .HasColumnType("varchar(25)")
                        .HasMaxLength(25)
                        .IsUnicode(false);

                    b.Property<string>("Street")
                        .HasColumnName("street")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<string>("ZipCode")
                        .HasColumnName("zip_code")
                        .HasColumnType("varchar(5)")
                        .HasMaxLength(5)
                        .IsUnicode(false);

                    b.HasKey("CustomerId")
                        .HasName("PK__customer__CD65CB85684947EC");

                    b.ToTable("customers","sales");
                });

            modelBuilder.Entity("BikeStoreAPI.Models.OrderItems", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnName("order_id")
                        .HasColumnType("int");

                    b.Property<int>("ItemId")
                        .HasColumnName("item_id")
                        .HasColumnType("int");

                    b.Property<decimal>("Discount")
                        .HasColumnName("discount")
                        .HasColumnType("decimal(4, 2)");

                    b.Property<decimal>("ListPrice")
                        .HasColumnName("list_price")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<int>("ProductId")
                        .HasColumnName("product_id")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnName("quantity")
                        .HasColumnType("int");

                    b.HasKey("OrderId", "ItemId")
                        .HasName("PK__order_it__837942D4BC6CBFA9");

                    b.HasIndex("ProductId");

                    b.ToTable("order_items","sales");
                });

            modelBuilder.Entity("BikeStoreAPI.Models.Orders", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("order_id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CustomerId")
                        .HasColumnName("customer_id")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnName("order_date")
                        .HasColumnType("date");

                    b.Property<byte>("OrderStatus")
                        .HasColumnName("order_status")
                        .HasColumnType("tinyint");

                    b.Property<DateTime>("RequiredDate")
                        .HasColumnName("required_date")
                        .HasColumnType("date");

                    b.Property<DateTime?>("ShippedDate")
                        .HasColumnName("shipped_date")
                        .HasColumnType("date");

                    b.Property<int>("StaffId")
                        .HasColumnName("staff_id")
                        .HasColumnType("int");

                    b.Property<int>("StoreId")
                        .HasColumnName("store_id")
                        .HasColumnType("int");

                    b.HasKey("OrderId")
                        .HasName("PK__orders__465962299EA003CF");

                    b.HasIndex("CustomerId");

                    b.HasIndex("StaffId");

                    b.HasIndex("StoreId");

                    b.ToTable("orders","sales");
                });

            modelBuilder.Entity("BikeStoreAPI.Models.Products", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("product_id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BrandId")
                        .HasColumnName("brand_id")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnName("category_id")
                        .HasColumnType("int");

                    b.Property<decimal>("ListPrice")
                        .HasColumnName("list_price")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<short>("ModelYear")
                        .HasColumnName("model_year")
                        .HasColumnType("smallint");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnName("product_name")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.HasKey("ProductId")
                        .HasName("PK__products__47027DF516749898");

                    b.HasIndex("BrandId");

                    b.HasIndex("CategoryId");

                    b.ToTable("products","production");
                });

            modelBuilder.Entity("BikeStoreAPI.Models.Staffs", b =>
                {
                    b.Property<int>("StaffId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("staff_id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte>("Active")
                        .HasColumnName("active")
                        .HasColumnType("tinyint");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("email")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnName("first_name")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnName("last_name")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<int?>("ManagerId")
                        .HasColumnName("manager_id")
                        .HasColumnType("int");

                    b.Property<string>("Phone")
                        .HasColumnName("phone")
                        .HasColumnType("varchar(25)")
                        .HasMaxLength(25)
                        .IsUnicode(false);

                    b.Property<int>("StoreId")
                        .HasColumnName("store_id")
                        .HasColumnType("int");

                    b.HasKey("StaffId")
                        .HasName("PK__staffs__1963DD9CE2630114");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasName("UQ__staffs__AB6E6164D2C06805");

                    b.HasIndex("ManagerId");

                    b.HasIndex("StoreId");

                    b.ToTable("staffs","sales");
                });

            modelBuilder.Entity("BikeStoreAPI.Models.Stocks", b =>
                {
                    b.Property<int>("StoreId")
                        .HasColumnName("store_id")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnName("product_id")
                        .HasColumnType("int");

                    b.Property<int?>("Quantity")
                        .HasColumnName("quantity")
                        .HasColumnType("int");

                    b.HasKey("StoreId", "ProductId")
                        .HasName("PK__stocks__E68284D39408DB47");

                    b.HasIndex("ProductId");

                    b.ToTable("stocks","production");
                });

            modelBuilder.Entity("BikeStoreAPI.Models.Stores", b =>
                {
                    b.Property<int>("StoreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("store_id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasColumnName("city")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<string>("Email")
                        .HasColumnName("email")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<string>("Phone")
                        .HasColumnName("phone")
                        .HasColumnType("varchar(25)")
                        .HasMaxLength(25)
                        .IsUnicode(false);

                    b.Property<string>("State")
                        .HasColumnName("state")
                        .HasColumnType("varchar(10)")
                        .HasMaxLength(10)
                        .IsUnicode(false);

                    b.Property<string>("StoreName")
                        .IsRequired()
                        .HasColumnName("store_name")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<string>("Street")
                        .HasColumnName("street")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<string>("ZipCode")
                        .HasColumnName("zip_code")
                        .HasColumnType("varchar(5)")
                        .HasMaxLength(5)
                        .IsUnicode(false);

                    b.HasKey("StoreId")
                        .HasName("PK__stores__A2F2A30CFF586CDA");

                    b.ToTable("stores","sales");
                });

            modelBuilder.Entity("BikeStoreAPI.Models.OrderItems", b =>
                {
                    b.HasOne("BikeStoreAPI.Models.Orders", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .HasConstraintName("FK__order_ite__order__398D8EEE")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BikeStoreAPI.Models.Products", "Product")
                        .WithMany("OrderItems")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("FK__order_ite__produ__3A81B327")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BikeStoreAPI.Models.Orders", b =>
                {
                    b.HasOne("BikeStoreAPI.Models.Customers", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .HasConstraintName("FK__orders__customer__33D4B598")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BikeStoreAPI.Models.Staffs", "Staff")
                        .WithMany("Orders")
                        .HasForeignKey("StaffId")
                        .HasConstraintName("FK__orders__staff_id__35BCFE0A")
                        .IsRequired();

                    b.HasOne("BikeStoreAPI.Models.Stores", "Store")
                        .WithMany("Orders")
                        .HasForeignKey("StoreId")
                        .HasConstraintName("FK__orders__store_id__34C8D9D1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BikeStoreAPI.Models.Products", b =>
                {
                    b.HasOne("BikeStoreAPI.Models.Brands", "Brand")
                        .WithMany("Products")
                        .HasForeignKey("BrandId")
                        .HasConstraintName("FK__products__brand___286302EC")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BikeStoreAPI.Models.Categories", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("FK__products__catego__276EDEB3")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BikeStoreAPI.Models.Staffs", b =>
                {
                    b.HasOne("BikeStoreAPI.Models.Staffs", "Manager")
                        .WithMany("InverseManager")
                        .HasForeignKey("ManagerId")
                        .HasConstraintName("FK__staffs__manager___30F848ED");

                    b.HasOne("BikeStoreAPI.Models.Stores", "Store")
                        .WithMany("Staffs")
                        .HasForeignKey("StoreId")
                        .HasConstraintName("FK__staffs__store_id__300424B4")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BikeStoreAPI.Models.Stocks", b =>
                {
                    b.HasOne("BikeStoreAPI.Models.Products", "Product")
                        .WithMany("Stocks")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("FK__stocks__product___3E52440B")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BikeStoreAPI.Models.Stores", "Store")
                        .WithMany("Stocks")
                        .HasForeignKey("StoreId")
                        .HasConstraintName("FK__stocks__store_id__3D5E1FD2")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
