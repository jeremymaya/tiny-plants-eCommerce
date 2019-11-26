﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using dotnet_ECommerce.Data;

namespace dotnet_ECommerce.Migrations
{
    [DbContext(typeof(StoreDbContext))]
    partial class StoreDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("dotnet_ECommerce.Models.Product", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsFeatured")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Sku")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Product");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Description = "A combination of multiple small cactuses",
                            Image = "/images/cactus_atlantic.jpg",
                            IsFeatured = true,
                            Name = "Atlantic",
                            Price = 12m,
                            Sku = "CAC001"
                        },
                        new
                        {
                            ID = 2,
                            Description = "A hot pink little cactus to bright up your room",
                            Image = "/images/cactus_rosette.jpg",
                            IsFeatured = true,
                            Name = "Rosette",
                            Price = 9m,
                            Sku = "CAC002"
                        },
                        new
                        {
                            ID = 3,
                            Description = "This cactus with elegant-looking glass is perfect for your desk",
                            Image = "/images/cactus_pastel.jpg",
                            IsFeatured = false,
                            Name = "Pastel",
                            Price = 7m,
                            Sku = "CAC003"
                        },
                        new
                        {
                            ID = 4,
                            Description = "This cute little coral will definitely lighten up your mood",
                            Image = "/images/cactus_coral.jpg",
                            IsFeatured = true,
                            Name = "Coral",
                            Price = 10m,
                            Sku = "CAC004"
                        },
                        new
                        {
                            ID = 5,
                            Description = "The unique looking little parakeet is one of the tiny plants that you must have",
                            Image = "/images/cactus_parakeet.jpg",
                            IsFeatured = false,
                            Name = "Parakeet",
                            Price = 18m,
                            Sku = "CAC005"
                        },
                        new
                        {
                            ID = 6,
                            Description = "This spiky and layered looking cactus is defenitely a rare found",
                            Image = "/images/cactus_crimson.jpg",
                            IsFeatured = false,
                            Name = "Crimson",
                            Price = 17m,
                            Sku = "CAC006"
                        },
                        new
                        {
                            ID = 7,
                            Description = "A blue orchid is one of the best indoor plants that you can have",
                            Image = "/images/flower_arctic.jpg",
                            IsFeatured = false,
                            Name = "Arctic",
                            Price = 24m,
                            Sku = "FLW001"
                        },
                        new
                        {
                            ID = 8,
                            Description = "This ornamental plant comes with violet flowers and kokedama that adds more style to your plant",
                            Image = "/images/flower_kokedama.jpg",
                            IsFeatured = false,
                            Name = "Violet Kokedama",
                            Price = 29m,
                            Sku = "FLW002"
                        },
                        new
                        {
                            ID = 9,
                            Description = "Bamboo is easy to take care of and it grows fast",
                            Image = "/images/plant_bamboo.jpg",
                            IsFeatured = false,
                            Name = "Bamboo",
                            Price = 26m,
                            Sku = "PLN001"
                        },
                        new
                        {
                            ID = 10,
                            Description = "This plant can live in water and it makes a great indoor plant",
                            Image = "/images/plant_hyacinth.jpg",
                            IsFeatured = false,
                            Name = "Hyacinth",
                            Price = 22m,
                            Sku = "PLN002"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
