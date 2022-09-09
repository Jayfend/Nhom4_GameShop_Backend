﻿// <auto-generated />
using System;
using GameShop.Data.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GameShop.Data.Migrations
{
    [DbContext(typeof(GameShopDbContext))]
    partial class GameShopDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.27")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GameShop.Data.Entities.AppRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                            ConcurrencyStamp = "7a977f36-4578-468c-ab6e-2a0102449de4",
                            Description = "Administrator role",
                            Name = "admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = new Guid("52503f03-bdea-4bf8-8a1a-d21ae2646483"),
                            ConcurrencyStamp = "c3876901-b7b0-46ee-93bf-ebef30a4860c",
                            Description = "User role",
                            Name = "User",
                            NormalizedName = "USER"
                        });
                });

            modelBuilder.Entity("GameShop.Data.Entities.AppUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Dob")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasData(
                        new
                        {
                            Id = new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "1fa89999-9b68-4c1b-8d8e-91998dbe38e9",
                            Dob = new DateTime(2001, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "leenguyen1721@gmail.com",
                            EmailConfirmed = true,
                            FirstName = "Luan",
                            LastName = "Nguyen Phung Le",
                            LockoutEnabled = false,
                            NormalizedEmail = "LEENGUYEN1721@gmail.com",
                            NormalizedUserName = "JAYFEND",
                            PasswordHash = "AQAAAAEAACcQAAAAEM4QNqslvPr7QEDPYn4J3xcfRajA3YExW7vjPVr7wvraPDsmZ+GccF1lMkM/q7KY7Q==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "",
                            TwoFactorEnabled = false,
                            UserName = "Jayfend"
                        });
                });

            modelBuilder.Entity("GameShop.Data.Entities.Cart", b =>
                {
                    b.Property<int>("CartID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BaseEntityID")
                        .HasColumnType("int");

                    b.Property<int>("CheckoutID")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CartID");

                    b.HasIndex("UserID");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("GameShop.Data.Entities.Checkout", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CartID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Purchasedate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("CartID")
                        .IsUnique();

                    b.ToTable("Checkouts");
                });

            modelBuilder.Entity("GameShop.Data.Entities.Game", b =>
                {
                    b.Property<int>("GameID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BaseEntityID")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Discount")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<string>("GameName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gameplay")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("GameID");

                    b.ToTable("Games");

                    b.HasData(
                        new
                        {
                            GameID = 1,
                            BaseEntityID = 0,
                            CreatedDate = new DateTime(2022, 9, 9, 15, 47, 41, 639, DateTimeKind.Local).AddTicks(4080),
                            Description = "The best game in the world",
                            Discount = 0,
                            GameName = "Grand Theft Auto V",
                            Gameplay = "Destroy the city",
                            Price = 250000m,
                            Status = 1,
                            UpdatedDate = new DateTime(2022, 9, 9, 15, 47, 41, 640, DateTimeKind.Local).AddTicks(1204)
                        },
                        new
                        {
                            GameID = 2,
                            BaseEntityID = 0,
                            CreatedDate = new DateTime(2022, 9, 9, 15, 47, 41, 640, DateTimeKind.Local).AddTicks(1683),
                            Description = "Back to the cowboy town",
                            Discount = 20,
                            GameName = "Red Dead Redemption 2",
                            Gameplay = "Discover the cowboy world",
                            Price = 250000m,
                            Status = 1,
                            UpdatedDate = new DateTime(2022, 9, 9, 15, 47, 41, 640, DateTimeKind.Local).AddTicks(1719)
                        });
                });

            modelBuilder.Entity("GameShop.Data.Entities.GameImage", b =>
                {
                    b.Property<int>("ImageID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Caption")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("Filesize")
                        .HasColumnType("bigint");

                    b.Property<int>("GameID")
                        .HasColumnType("int");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SortOrder")
                        .HasColumnType("int");

                    b.Property<bool>("isDefault")
                        .HasColumnType("bit");

                    b.HasKey("ImageID");

                    b.HasIndex("GameID");

                    b.ToTable("GameImages");
                });

            modelBuilder.Entity("GameShop.Data.Entities.GameinGenre", b =>
                {
                    b.Property<int>("GenreID")
                        .HasColumnType("int");

                    b.Property<int>("GameID")
                        .HasColumnType("int");

                    b.HasKey("GenreID", "GameID");

                    b.HasIndex("GameID");

                    b.ToTable("GameinGenre");

                    b.HasData(
                        new
                        {
                            GenreID = 1,
                            GameID = 1
                        },
                        new
                        {
                            GenreID = 2,
                            GameID = 1
                        },
                        new
                        {
                            GenreID = 3,
                            GameID = 2
                        },
                        new
                        {
                            GenreID = 2,
                            GameID = 2
                        });
                });

            modelBuilder.Entity("GameShop.Data.Entities.Genre", b =>
                {
                    b.Property<int>("GenreID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GenreName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GenreID");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            GenreID = 1,
                            GenreName = "Action"
                        },
                        new
                        {
                            GenreID = 2,
                            GenreName = "Open-World"
                        },
                        new
                        {
                            GenreID = 3,
                            GenreName = "Multiplayer"
                        },
                        new
                        {
                            GenreID = 4,
                            GenreName = "Action RPG"
                        },
                        new
                        {
                            GenreID = 5,
                            GenreName = "Simulation"
                        },
                        new
                        {
                            GenreID = 6,
                            GenreName = "Horror"
                        },
                        new
                        {
                            GenreID = 7,
                            GenreName = "Sports & Racing"
                        },
                        new
                        {
                            GenreID = 8,
                            GenreName = "Role-Playing"
                        },
                        new
                        {
                            GenreID = 9,
                            GenreName = "Visual Novel"
                        });
                });

            modelBuilder.Entity("GameShop.Data.Entities.OrderedGame", b =>
                {
                    b.Property<int>("OrderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CartID")
                        .HasColumnType("int");

                    b.Property<int>("GameID")
                        .HasColumnType("int");

                    b.HasKey("OrderID");

                    b.HasIndex("CartID");

                    b.HasIndex("GameID");

                    b.ToTable("OrderedGames");
                });

            modelBuilder.Entity("GameShop.Data.Entities.SystemRequirementMin", b =>
                {
                    b.Property<int>("SRMID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AdditionalNotes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GameID")
                        .HasColumnType("int");

                    b.Property<string>("Graphics")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Memory")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OS")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Processor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Soundcard")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Storage")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SRMID");

                    b.HasIndex("GameID")
                        .IsUnique();

                    b.ToTable("SystemRequirementMin");

                    b.HasData(
                        new
                        {
                            SRMID = 1,
                            AdditionalNotes = "",
                            GameID = 1,
                            Graphics = "NVIDIA 9800 GT 1GB / AMD HD 4870 1GB (DX 10, 10.1, 11)",
                            Memory = "4 GB RAM",
                            OS = "Windows 10 64 Bit, Windows 8.1 64 Bit, Windows 8 64 Bit, Windows 7 64 Bit Service Pack 1",
                            Processor = "Intel Core 2 Quad CPU Q6600 @ 2.40GHz (4 CPUs) / AMD Phenom 9850 Quad-Core Processor (4 CPUs) @ 2.5GHz",
                            Soundcard = "100% DirectX 10 compatible",
                            Storage = "72 GB available space"
                        },
                        new
                        {
                            SRMID = 2,
                            AdditionalNotes = "",
                            GameID = 2,
                            Graphics = "NVIDIA 9800 GT 1GB / AMD HD 4870 1GB (DX 10, 10.1, 11)",
                            Memory = "4 GB RAM",
                            OS = "Windows 10 64 Bit, Windows 8.1 64 Bit, Windows 8 64 Bit, Windows 7 64 Bit Service Pack 1",
                            Processor = "Intel Core 2 Quad CPU Q6600 @ 2.40GHz (4 CPUs) / AMD Phenom 9850 Quad-Core Processor (4 CPUs) @ 2.5GHz",
                            Soundcard = "100% DirectX 10 compatible",
                            Storage = "72 GB available space"
                        });
                });

            modelBuilder.Entity("GameShop.Data.Entities.SystemRequirementRecommended", b =>
                {
                    b.Property<int>("SRRID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AdditionalNotes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GameID")
                        .HasColumnType("int");

                    b.Property<string>("Graphics")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Memory")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OS")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Processor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Soundcard")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Storage")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SRRID");

                    b.HasIndex("GameID")
                        .IsUnique();

                    b.ToTable("SystemRequirementRecommended");

                    b.HasData(
                        new
                        {
                            SRRID = 1,
                            AdditionalNotes = "",
                            GameID = 1,
                            Graphics = "NVIDIA GTX 660 2GB / AMD HD 7870 2GB",
                            Memory = "8 GB RAM",
                            OS = "Windows 10 64 Bit, Windows 8.1 64 Bit, Windows 8 64 Bit, Windows 7 64 Bit Service Pack 1",
                            Processor = " Intel Core i5 3470 @ 3.2GHz (4 CPUs) / AMD X8 FX-8350 @ 4GHz (8 CPUs)",
                            Soundcard = "100% DirectX 10 compatible",
                            Storage = "72 GB available space"
                        },
                        new
                        {
                            SRRID = 2,
                            AdditionalNotes = "",
                            GameID = 2,
                            Graphics = "NVIDIA GTX 660 2GB / AMD HD 7870 2GB",
                            Memory = "8 GB RAM",
                            OS = "Windows 10 64 Bit, Windows 8.1 64 Bit, Windows 8 64 Bit, Windows 7 64 Bit Service Pack 1",
                            Processor = " Intel Core i5 3470 @ 3.2GHz (4 CPUs) / AMD X8 FX-8350 @ 4GHz (8 CPUs)",
                            Soundcard = "100% DirectX 10 compatible",
                            Storage = "72 GB available space"
                        });
                });

            modelBuilder.Entity("GameShop.Data.Entities.WishesGame", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("GameID")
                        .HasColumnType("int");

                    b.Property<int>("WishID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("GameID");

                    b.HasIndex("WishID");

                    b.ToTable("WishesGames");
                });

            modelBuilder.Entity("GameShop.Data.Entities.Wishlist", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid>("UserID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.HasIndex("UserID")
                        .IsUnique();

                    b.ToTable("Wishlists");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");

                    b.HasData(
                        new
                        {
                            UserId = new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                            RoleId = new Guid("8d04dce2-969a-435d-bba4-df3f325983dc")
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("GameShop.Data.Entities.Cart", b =>
                {
                    b.HasOne("GameShop.Data.Entities.AppUser", "AppUser")
                        .WithMany("Carts")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GameShop.Data.Entities.Checkout", b =>
                {
                    b.HasOne("GameShop.Data.Entities.Cart", "Cart")
                        .WithOne("Checkout")
                        .HasForeignKey("GameShop.Data.Entities.Checkout", "CartID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GameShop.Data.Entities.GameImage", b =>
                {
                    b.HasOne("GameShop.Data.Entities.Game", "Game")
                        .WithMany("GameImages")
                        .HasForeignKey("GameID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GameShop.Data.Entities.GameinGenre", b =>
                {
                    b.HasOne("GameShop.Data.Entities.Game", "Game")
                        .WithMany("GameInGenres")
                        .HasForeignKey("GameID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GameShop.Data.Entities.Genre", "Genre")
                        .WithMany("GameInGenres")
                        .HasForeignKey("GenreID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GameShop.Data.Entities.OrderedGame", b =>
                {
                    b.HasOne("GameShop.Data.Entities.Cart", "Cart")
                        .WithMany("OrderedGames")
                        .HasForeignKey("CartID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GameShop.Data.Entities.Game", "Game")
                        .WithMany("OrderedGames")
                        .HasForeignKey("GameID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GameShop.Data.Entities.SystemRequirementMin", b =>
                {
                    b.HasOne("GameShop.Data.Entities.Game", "Game")
                        .WithOne("SystemRequirementMin")
                        .HasForeignKey("GameShop.Data.Entities.SystemRequirementMin", "GameID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GameShop.Data.Entities.SystemRequirementRecommended", b =>
                {
                    b.HasOne("GameShop.Data.Entities.Game", "Game")
                        .WithOne("SystemRequirementRecommended")
                        .HasForeignKey("GameShop.Data.Entities.SystemRequirementRecommended", "GameID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GameShop.Data.Entities.WishesGame", b =>
                {
                    b.HasOne("GameShop.Data.Entities.Game", "Game")
                        .WithMany("WishesGames")
                        .HasForeignKey("GameID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GameShop.Data.Entities.Wishlist", "Wishlist")
                        .WithMany("WishesGame")
                        .HasForeignKey("WishID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GameShop.Data.Entities.Wishlist", b =>
                {
                    b.HasOne("GameShop.Data.Entities.AppUser", "AppUser")
                        .WithOne("Wishlist")
                        .HasForeignKey("GameShop.Data.Entities.Wishlist", "UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("GameShop.Data.Entities.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("GameShop.Data.Entities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("GameShop.Data.Entities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("GameShop.Data.Entities.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GameShop.Data.Entities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("GameShop.Data.Entities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
