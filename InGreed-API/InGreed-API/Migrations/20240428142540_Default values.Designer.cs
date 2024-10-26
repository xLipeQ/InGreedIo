﻿// <auto-generated />
using System;
using InGreed_API.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace InGreed_API.Migrations
{
    [DbContext(typeof(InGreedDataContext))]
    [Migration("20240428142540_Default values")]
    partial class Defaultvalues
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("InGreed_API.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("type");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Type = "Category1"
                        },
                        new
                        {
                            Id = 2,
                            Type = "Category2"
                        },
                        new
                        {
                            Id = 3,
                            Type = "Category3"
                        },
                        new
                        {
                            Id = 4,
                            Type = "Category4"
                        },
                        new
                        {
                            Id = 5,
                            Type = "ACategory"
                        },
                        new
                        {
                            Id = 6,
                            Type = "BCategory"
                        });
                });

            modelBuilder.Entity("InGreed_API.Models.FavouriteProduct", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    b.Property<int>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("product_id");

                    b.HasKey("UserId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("FavouriteProducts");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            ProductId = 2
                        });
                });

            modelBuilder.Entity("InGreed_API.Models.Ingredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<byte[]>("Icon")
                        .IsRequired()
                        .HasColumnType("varbinary(max)")
                        .HasColumnName("icon");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("Ingredients");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Icon = new byte[0],
                            Name = "Ingredient1"
                        },
                        new
                        {
                            Id = 2,
                            Icon = new byte[0],
                            Name = "Ingredient2"
                        },
                        new
                        {
                            Id = 3,
                            Icon = new byte[0],
                            Name = "Ingredient3"
                        },
                        new
                        {
                            Id = 4,
                            Icon = new byte[0],
                            Name = "Ingredient4"
                        },
                        new
                        {
                            Id = 5,
                            Icon = new byte[0],
                            Name = "AIngredient"
                        },
                        new
                        {
                            Id = 6,
                            Icon = new byte[0],
                            Name = "BIngredient"
                        });
                });

            modelBuilder.Entity("InGreed_API.Models.Opinion", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("product_id");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("comment");

                    b.Property<int>("Rating")
                        .HasColumnType("int")
                        .HasColumnName("rating");

                    b.HasKey("ProductId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("Opinions");

                    b.HasData(
                        new
                        {
                            ProductId = 2,
                            UserId = 1,
                            Comment = "Useful product",
                            Rating = 5
                        },
                        new
                        {
                            ProductId = 2,
                            UserId = 2,
                            Comment = "Awful product",
                            Rating = 1
                        },
                        new
                        {
                            ProductId = 3,
                            UserId = 1,
                            Comment = "Decent product",
                            Rating = 4
                        });
                });

            modelBuilder.Entity("InGreed_API.Models.Preference", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    b.Property<int>("IngredientId")
                        .HasColumnType("int")
                        .HasColumnName("ingredient_id");

                    b.Property<int>("PreferenceType")
                        .HasColumnType("int")
                        .HasColumnName("preference_type");

                    b.HasKey("UserId", "IngredientId");

                    b.HasIndex("IngredientId");

                    b.ToTable("Preferences");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            IngredientId = 1,
                            PreferenceType = 0
                        },
                        new
                        {
                            UserId = 1,
                            IngredientId = 2,
                            PreferenceType = 1
                        });
                });

            modelBuilder.Entity("InGreed_API.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("product_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("description");

                    b.Property<byte[]>("Image")
                        .IsRequired()
                        .HasColumnType("varbinary(max)")
                        .HasColumnName("image");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("product_name");

                    b.Property<int>("ProducentId")
                        .HasColumnType("int")
                        .HasColumnName("producent_id");

                    b.HasKey("Id");

                    b.HasIndex("ProducentId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Very good shampoo",
                            Image = new byte[0],
                            Name = "Premium Shampoo N1",
                            ProducentId = 3
                        },
                        new
                        {
                            Id = 2,
                            Description = "Very good shampoo",
                            Image = new byte[0],
                            Name = "Premium Shampoo N2",
                            ProducentId = 3
                        },
                        new
                        {
                            Id = 3,
                            Description = "Very good shampoo",
                            Image = new byte[0],
                            Name = "Premium Shampoo N3",
                            ProducentId = 3
                        },
                        new
                        {
                            Id = 4,
                            Description = "Very good shampoo",
                            Image = new byte[0],
                            Name = "Premium Shampoo N4",
                            ProducentId = 3
                        },
                        new
                        {
                            Id = 5,
                            Description = "Very good shampoo",
                            Image = new byte[0],
                            Name = "Premium Shampoo N5",
                            ProducentId = 3
                        },
                        new
                        {
                            Id = 6,
                            Description = "Very good shampoo",
                            Image = new byte[0],
                            Name = "Premium Shampoo N6",
                            ProducentId = 3
                        },
                        new
                        {
                            Id = 7,
                            Description = "Very good shampoo",
                            Image = new byte[0],
                            Name = "Premium Shampoo N7",
                            ProducentId = 3
                        },
                        new
                        {
                            Id = 8,
                            Description = "Very good shampoo",
                            Image = new byte[0],
                            Name = "Premium Shampoo N8",
                            ProducentId = 3
                        },
                        new
                        {
                            Id = 9,
                            Description = "Very good shampoo",
                            Image = new byte[0],
                            Name = "Premium Shampoo N9",
                            ProducentId = 3
                        },
                        new
                        {
                            Id = 10,
                            Description = "Very good shampoo",
                            Image = new byte[0],
                            Name = "Premium Shampoo N10",
                            ProducentId = 3
                        },
                        new
                        {
                            Id = 11,
                            Description = "Very good shampoo",
                            Image = new byte[0],
                            Name = "Premium Shampoo N11",
                            ProducentId = 3
                        },
                        new
                        {
                            Id = 12,
                            Description = "Very good shampoo",
                            Image = new byte[0],
                            Name = "Premium Shampoo N12",
                            ProducentId = 3
                        });
                });

            modelBuilder.Entity("InGreed_API.Models.ProductCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int")
                        .HasColumnName("category_id");

                    b.Property<int>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("product_id");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductCategories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            ProductId = 1
                        });
                });

            modelBuilder.Entity("InGreed_API.Models.ProductIngredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("IngredientId")
                        .HasColumnType("int")
                        .HasColumnName("ingredient_id");

                    b.Property<int>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("product_id");

                    b.HasKey("Id");

                    b.HasIndex("IngredientId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductIngredients");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IngredientId = 1,
                            ProductId = 1
                        },
                        new
                        {
                            Id = 2,
                            IngredientId = 1,
                            ProductId = 2
                        },
                        new
                        {
                            Id = 3,
                            IngredientId = 1,
                            ProductId = 3
                        },
                        new
                        {
                            Id = 4,
                            IngredientId = 1,
                            ProductId = 4
                        },
                        new
                        {
                            Id = 5,
                            IngredientId = 1,
                            ProductId = 5
                        },
                        new
                        {
                            Id = 6,
                            IngredientId = 1,
                            ProductId = 6
                        },
                        new
                        {
                            Id = 7,
                            IngredientId = 1,
                            ProductId = 7
                        },
                        new
                        {
                            Id = 8,
                            IngredientId = 1,
                            ProductId = 8
                        },
                        new
                        {
                            Id = 9,
                            IngredientId = 1,
                            ProductId = 9
                        },
                        new
                        {
                            Id = 10,
                            IngredientId = 1,
                            ProductId = 10
                        },
                        new
                        {
                            Id = 11,
                            IngredientId = 1,
                            ProductId = 11
                        },
                        new
                        {
                            Id = 12,
                            IngredientId = 1,
                            ProductId = 12
                        },
                        new
                        {
                            Id = 13,
                            IngredientId = 2,
                            ProductId = 1
                        });
                });

            modelBuilder.Entity("InGreed_API.Models.Promotion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("End")
                        .HasColumnType("datetime2")
                        .HasColumnName("end");

                    b.Property<int>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("product_id");

                    b.Property<DateTime>("Start")
                        .HasColumnType("datetime2")
                        .HasColumnName("start");

                    b.HasKey("Id");

                    b.HasIndex("ProductId")
                        .IsUnique();

                    b.ToTable("Promotions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            End = new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999),
                            ProductId = 3,
                            Start = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            End = new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999),
                            ProductId = 4,
                            Start = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            End = new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999),
                            ProductId = 5,
                            Start = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("InGreed_API.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("EmailNotifications")
                        .HasColumnType("bit")
                        .HasColumnName("email_notifications");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("mail");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("password_hash");

                    b.Property<int>("Role")
                        .HasColumnType("int")
                        .HasColumnName("role");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("username");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EmailNotifications = true,
                            Mail = "clientingreed@gmail.com",
                            PasswordHash = "AQAAAAIAAYagAAAAECFziXNCSrKgVQUGu4Ius9In7O1dytR+XOgViy8cOrwqdwj6zcjrRJOBS/vPAPJjZg==",
                            Role = 3,
                            Username = "client"
                        },
                        new
                        {
                            Id = 2,
                            EmailNotifications = false,
                            Mail = "clientingreed2@gmail.com",
                            PasswordHash = "AQAAAAIAAYagAAAAEFMl2ibmxljVgSYUvel1WmE+iB7IbRjl8QeWhf1fA0bhaR0TSaGEwETnWj2z/SjbfA==",
                            Role = 3,
                            Username = "client2"
                        },
                        new
                        {
                            Id = 3,
                            EmailNotifications = true,
                            Mail = "producent@gmail.com",
                            PasswordHash = "AQAAAAIAAYagAAAAEMzfRediqiZFTiV6Xpz38DYmSUDq3j5hmqbaaTbBrbLVWThkHKG508Iznr/bca8uWg==",
                            Role = 2,
                            Username = "producent"
                        },
                        new
                        {
                            Id = 4,
                            EmailNotifications = false,
                            Mail = "producentingreed2@gmail.com",
                            PasswordHash = "AQAAAAIAAYagAAAAEIFvpaWPRcE+iakhC6p4hHrmq0EOmt3id7vIPU3iMZjNM7aTuAJVsv3yxtLzgG1KHQ==",
                            Role = 2,
                            Username = "producent2"
                        });
                });

            modelBuilder.Entity("InGreed_API.Models.FavouriteProduct", b =>
                {
                    b.HasOne("InGreed_API.Models.Product", "Product")
                        .WithMany("FavouriteProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InGreed_API.Models.User", "User")
                        .WithMany("FavouriteProducts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("InGreed_API.Models.Opinion", b =>
                {
                    b.HasOne("InGreed_API.Models.Product", "Product")
                        .WithMany("Opinions")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InGreed_API.Models.User", "User")
                        .WithMany("Opinions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("InGreed_API.Models.Preference", b =>
                {
                    b.HasOne("InGreed_API.Models.Ingredient", "Ingredient")
                        .WithMany("Preferenes")
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InGreed_API.Models.User", "User")
                        .WithMany("Preferences")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ingredient");

                    b.Navigation("User");
                });

            modelBuilder.Entity("InGreed_API.Models.Product", b =>
                {
                    b.HasOne("InGreed_API.Models.User", "Producent")
                        .WithMany("Products")
                        .HasForeignKey("ProducentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Producent");
                });

            modelBuilder.Entity("InGreed_API.Models.ProductCategory", b =>
                {
                    b.HasOne("InGreed_API.Models.Category", "Category")
                        .WithMany("ProductCategory")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InGreed_API.Models.Product", "Product")
                        .WithMany("ProductCategory")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("InGreed_API.Models.ProductIngredient", b =>
                {
                    b.HasOne("InGreed_API.Models.Ingredient", "Ingredient")
                        .WithMany("ProductIngredients")
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InGreed_API.Models.Product", "Product")
                        .WithMany("ProductIngredients")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ingredient");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("InGreed_API.Models.Promotion", b =>
                {
                    b.HasOne("InGreed_API.Models.Product", "Product")
                        .WithOne("Promotion")
                        .HasForeignKey("InGreed_API.Models.Promotion", "ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("InGreed_API.Models.Category", b =>
                {
                    b.Navigation("ProductCategory");
                });

            modelBuilder.Entity("InGreed_API.Models.Ingredient", b =>
                {
                    b.Navigation("Preferenes");

                    b.Navigation("ProductIngredients");
                });

            modelBuilder.Entity("InGreed_API.Models.Product", b =>
                {
                    b.Navigation("FavouriteProducts");

                    b.Navigation("Opinions");

                    b.Navigation("ProductCategory");

                    b.Navigation("ProductIngredients");

                    b.Navigation("Promotion")
                        .IsRequired();
                });

            modelBuilder.Entity("InGreed_API.Models.User", b =>
                {
                    b.Navigation("FavouriteProducts");

                    b.Navigation("Opinions");

                    b.Navigation("Preferences");

                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
