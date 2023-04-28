﻿// <auto-generated />
using System;
using Ecommerce.Infrastructure.AppContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Ecommerce.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CategoryProduct", b =>
                {
                    b.Property<Guid>("CategoriesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CategoriesId", "ProductsId");

                    b.HasIndex("ProductsId");

                    b.ToTable("CategoryProduct");
                });

            modelBuilder.Entity("Ecommerce.Models.Brand", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Bio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid?>("ModifiedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Brands");

                    b.HasData(
                        new
                        {
                            Id = new Guid("55125622-b1f1-4a04-8e16-ce6d65fbe233"),
                            Bio = "Software House",
                            CreatedBy = new Guid("ab87151b-1fe0-41dc-8927-cc893696afa4"),
                            CreatedDate = new DateTime(2023, 4, 28, 17, 39, 36, 820, DateTimeKind.Local).AddTicks(8484),
                            IsDeleted = false,
                            Name = "LuftBorn"
                        });
                });

            modelBuilder.Entity("Ecommerce.Models.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid?>("ModifiedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = new Guid("ac2c965a-1c65-4df0-bb94-944c67bc7a87"),
                            CreatedBy = new Guid("dd9d4cae-776e-4f1a-960c-3e7d0fcda2cc"),
                            CreatedDate = new DateTime(2023, 4, 28, 17, 39, 36, 821, DateTimeKind.Local).AddTicks(825),
                            IsDeleted = false,
                            Name = "LuftBorn"
                        });
                });

            modelBuilder.Entity("Ecommerce.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValue(new Guid("2742fb05-9de6-47b2-a295-cf89c992dba5"));

                    b.Property<Guid?>("BrandId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2023, 4, 28, 14, 39, 36, 821, DateTimeKind.Utc).AddTicks(3573));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid?>("ModifiedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = new Guid("22f7b1bf-35f9-40ff-a596-7a06e3c07b03"),
                            BrandId = new Guid("55125622-b1f1-4a04-8e16-ce6d65fbe233"),
                            CreatedBy = new Guid("a03b859f-2550-456b-9be9-94eccee2179e"),
                            CreatedDate = new DateTime(2023, 4, 28, 17, 39, 36, 821, DateTimeKind.Local).AddTicks(2854),
                            Description = "Dummy Dummy1",
                            IsDeleted = false,
                            Name = "Dummy1"
                        },
                        new
                        {
                            Id = new Guid("6d43557a-7f38-4744-a4e9-f76de8685243"),
                            BrandId = new Guid("55125622-b1f1-4a04-8e16-ce6d65fbe233"),
                            CreatedBy = new Guid("72a93b35-5595-48f1-b96c-626f3da092e0"),
                            CreatedDate = new DateTime(2023, 4, 28, 17, 39, 36, 821, DateTimeKind.Local).AddTicks(2918),
                            Description = "Dummy Dummy2",
                            IsDeleted = false,
                            Name = "Dummy2"
                        });
                });

            modelBuilder.Entity("CategoryProduct", b =>
                {
                    b.HasOne("Ecommerce.Models.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ecommerce.Models.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Ecommerce.Models.Product", b =>
                {
                    b.HasOne("Ecommerce.Models.Brand", "Brand")
                        .WithMany("Products")
                        .HasForeignKey("BrandId");

                    b.Navigation("Brand");
                });

            modelBuilder.Entity("Ecommerce.Models.Brand", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
