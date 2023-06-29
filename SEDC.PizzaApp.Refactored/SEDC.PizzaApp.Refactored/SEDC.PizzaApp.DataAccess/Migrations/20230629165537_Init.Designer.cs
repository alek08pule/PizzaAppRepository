﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SEDC.PizzaApp.DataAccess;

#nullable disable

namespace SEDC.PizzaApp.DataAccess.Migrations
{
    [DbContext(typeof(PizzaAppDbContext))]
    [Migration("20230629165537_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SEDC.PizzaApp.Domain.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Delivered")
                        .HasColumnType("bit");

                    b.Property<int>("PaymentMethod")
                        .HasColumnType("int");

                    b.Property<string>("PizzaStore")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Delivered = true,
                            PaymentMethod = 2,
                            PizzaStore = "Store1",
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            Delivered = false,
                            PaymentMethod = 1,
                            PizzaStore = "Store2",
                            UserId = 2
                        });
                });

            modelBuilder.Entity("SEDC.PizzaApp.Domain.Models.Pizza", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsOnPromotion")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Pizzas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsOnPromotion = true,
                            Name = "Kaprichioza"
                        },
                        new
                        {
                            Id = 2,
                            IsOnPromotion = false,
                            Name = "Pepperoni"
                        },
                        new
                        {
                            Id = 3,
                            IsOnPromotion = false,
                            Name = "Margarita"
                        });
                });

            modelBuilder.Entity("SEDC.PizzaApp.Domain.Models.PizzaOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("NumberOfPizzas")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("PizzaId")
                        .HasColumnType("int");

                    b.Property<int>("PizzaSize")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("PizzaId");

                    b.ToTable("PizzaOrder");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            NumberOfPizzas = 2,
                            OrderId = 1,
                            PizzaId = 1,
                            PizzaSize = 1,
                            Price = 300.0
                        },
                        new
                        {
                            Id = 2,
                            NumberOfPizzas = 3,
                            OrderId = 1,
                            PizzaId = 2,
                            PizzaSize = 1,
                            Price = 350.0
                        },
                        new
                        {
                            Id = 3,
                            NumberOfPizzas = 2,
                            OrderId = 2,
                            PizzaId = 3,
                            PizzaSize = 2,
                            Price = 400.0
                        });
                });

            modelBuilder.Entity("SEDC.PizzaApp.Domain.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Address1",
                            FirstName = "Afrodita",
                            LastName = "Bele"
                        },
                        new
                        {
                            Id = 2,
                            Address = "Address2",
                            FirstName = "Stefan",
                            LastName = "Trajanoski"
                        });
                });

            modelBuilder.Entity("SEDC.PizzaApp.Domain.Models.Order", b =>
                {
                    b.HasOne("SEDC.PizzaApp.Domain.Models.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("SEDC.PizzaApp.Domain.Models.PizzaOrder", b =>
                {
                    b.HasOne("SEDC.PizzaApp.Domain.Models.Order", "Order")
                        .WithMany("PizzaOrders")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SEDC.PizzaApp.Domain.Models.Pizza", "Pizza")
                        .WithMany("PizzaOrders")
                        .HasForeignKey("PizzaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Pizza");
                });

            modelBuilder.Entity("SEDC.PizzaApp.Domain.Models.Order", b =>
                {
                    b.Navigation("PizzaOrders");
                });

            modelBuilder.Entity("SEDC.PizzaApp.Domain.Models.Pizza", b =>
                {
                    b.Navigation("PizzaOrders");
                });

            modelBuilder.Entity("SEDC.PizzaApp.Domain.Models.User", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
