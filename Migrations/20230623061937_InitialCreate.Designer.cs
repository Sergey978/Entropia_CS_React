﻿// <auto-generated />
using System;
using Entropia_CS_React.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace SignupVerTutor.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230623061937_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Entropia_CS_React.Domain.Models.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("AcceptTerms")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("PasswordReset")
                        .HasColumnType("datetime2");

                    b.Property<string>("ResetToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ResetTokenExpires")
                        .HasColumnType("datetime2");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("datetime2");

                    b.Property<string>("VerificationToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Verified")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("Entropia_CS_React.Domain.Models.CustomItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<int>("BeginQuantity")
                        .HasColumnType("int");

                    b.Property<decimal>("Markup")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("PurchasePrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<bool>("Selected")
                        .HasColumnType("bit");

                    b.Property<int>("Step")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("CustomItems");
                });

            modelBuilder.Entity("Entropia_CS_React.Domain.Models.StandartItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("StandartItems");
                });

            modelBuilder.Entity("Entropia_CS_React.Domain.Models.UserStandartItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<int>("BeginQuantity")
                        .HasColumnType("int");

                    b.Property<decimal>("Markup")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("PurchasePrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<bool>("Selected")
                        .HasColumnType("bit");

                    b.Property<int>("StandartItemId")
                        .HasColumnType("int");

                    b.Property<int>("Step")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("StandartItemId");

                    b.ToTable("UserStandartItems");
                });

            modelBuilder.Entity("Entropia_CS_React.Domain.Models.Account", b =>
                {
                    b.OwnsMany("Entropia_CS_React.Domain.Models.RefreshToken", "RefreshTokens", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<int>("AccountId")
                                .HasColumnType("int");

                            b1.Property<DateTime>("Created")
                                .HasColumnType("datetime2");

                            b1.Property<string>("CreatedByIp")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<DateTime>("Expires")
                                .HasColumnType("datetime2");

                            b1.Property<string>("ReplacedByToken")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<DateTime?>("Revoked")
                                .HasColumnType("datetime2");

                            b1.Property<string>("RevokedByIp")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Token")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("Id");

                            b1.HasIndex("AccountId");

                            b1.ToTable("RefreshToken");

                            b1.WithOwner("Account")
                                .HasForeignKey("AccountId");

                            b1.Navigation("Account");
                        });

                    b.Navigation("RefreshTokens");
                });

            modelBuilder.Entity("Entropia_CS_React.Domain.Models.CustomItem", b =>
                {
                    b.HasOne("Entropia_CS_React.Domain.Models.Account", null)
                        .WithMany("CustomItems")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Entropia_CS_React.Domain.Models.UserStandartItem", b =>
                {
                    b.HasOne("Entropia_CS_React.Domain.Models.Account", null)
                        .WithMany("StandartItems")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entropia_CS_React.Domain.Models.StandartItem", "StandartItem")
                        .WithMany()
                        .HasForeignKey("StandartItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StandartItem");
                });

            modelBuilder.Entity("Entropia_CS_React.Domain.Models.Account", b =>
                {
                    b.Navigation("CustomItems");

                    b.Navigation("StandartItems");
                });
#pragma warning restore 612, 618
        }
    }
}