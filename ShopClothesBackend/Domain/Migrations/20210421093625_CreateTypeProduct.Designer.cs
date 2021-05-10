﻿// <auto-generated />
using System;
using Domain.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Domain.Migrations
{
    [DbContext(typeof(ShopClothesContext))]
    [Migration("20210421093625_CreateTypeProduct")]
    partial class CreateTypeProduct
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Domain.Description", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Descriptions");
                });

            modelBuilder.Entity("Domain.Domain.FileAttachment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Ext")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductImageId")
                        .HasColumnType("int");

                    b.Property<int>("ProductTitleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductImageId");

                    b.HasIndex("ProductTitleId")
                        .IsUnique();

                    b.ToTable("FileAttachments");
                });

            modelBuilder.Entity("Domain.Domain.FileAttachmentData", b =>
                {
                    b.Property<int>("FileId")
                        .HasColumnType("int");

                    b.Property<byte[]>("Data")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("FileId");

                    b.ToTable("FileAttachmentDatas");
                });

            modelBuilder.Entity("Domain.Domain.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProductSizeId")
                        .HasColumnType("int");

                    b.Property<int?>("TypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Domain.Domain.ProductSize", b =>
                {
                    b.Property<int>("SizeId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int?>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("SizeId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductSizes");
                });

            modelBuilder.Entity("Domain.Domain.Size", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Sizes");
                });

            modelBuilder.Entity("Domain.Domain.Type", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("ProductTypes");
                });

            modelBuilder.Entity("Domain.Domain.TypeProduct", b =>
                {
                    b.Property<int>("TypeId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("TypeId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("TypeProduct");
                });

            modelBuilder.Entity("Domain.Domain.Description", b =>
                {
                    b.HasOne("Domain.Domain.Product", "Product")
                        .WithMany("Decriptions")
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("Domain.Domain.FileAttachment", b =>
                {
                    b.HasOne("Domain.Domain.Product", "ProductImage")
                        .WithMany("Images")
                        .HasForeignKey("ProductImageId")
                        .IsRequired();

                    b.HasOne("Domain.Domain.Product", "ProductTitle")
                        .WithOne("TitleImage")
                        .HasForeignKey("Domain.Domain.FileAttachment", "ProductTitleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Domain.FileAttachmentData", b =>
                {
                    b.HasOne("Domain.Domain.FileAttachment", "FileAttachment")
                        .WithOne("FileAttachmentData")
                        .HasForeignKey("Domain.Domain.FileAttachmentData", "FileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Domain.ProductSize", b =>
                {
                    b.HasOne("Domain.Domain.Product", "Product")
                        .WithMany("ProductSizes")
                        .HasForeignKey("ProductId")
                        .IsRequired();

                    b.HasOne("Domain.Domain.Size", "Size")
                        .WithMany("ProductSizes")
                        .HasForeignKey("SizeId")
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Domain.Type", b =>
                {
                    b.HasOne("Domain.Domain.Type", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("Domain.Domain.TypeProduct", b =>
                {
                    b.HasOne("Domain.Domain.Product", "Product")
                        .WithMany("TypeProducts")
                        .HasForeignKey("ProductId")
                        .IsRequired();

                    b.HasOne("Domain.Domain.Type", "Type")
                        .WithMany("TypeProducts")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
