﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using if3250_2022_19_filantropi_backend.Data;

#nullable disable

namespace if3250_2022_19_filantropi_backend.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220330031842_galang_dana_status")]
    partial class galang_dana_status
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("if3250_2022_19_filantropi_backend.Models.Doa", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<long>("GalangDanaId")
                        .HasColumnType("bigint")
                        .HasColumnName("galangdana_id");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_doa");

                    b.HasIndex("GalangDanaId")
                        .HasDatabaseName("ix_doa_galang_dana_id");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_doa_user_id");

                    b.ToTable("doa", (string)null);
                });

            modelBuilder.Entity("if3250_2022_19_filantropi_backend.Models.Donasi", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<int>("Amount")
                        .HasColumnType("integer")
                        .HasColumnName("amount");

                    b.Property<long>("GalangDanaId")
                        .HasColumnType("bigint")
                        .HasColumnName("galangdana_id");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_donasi");

                    b.HasIndex("GalangDanaId")
                        .HasDatabaseName("ix_donasi_galang_dana_id");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_donasi_user_id");

                    b.ToTable("donasi", (string)null);
                });

            modelBuilder.Entity("if3250_2022_19_filantropi_backend.Models.GalanganDana", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("category");

                    b.Property<DateTime>("Deadline")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("deadline");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("EventTitle")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("text")
                        .HasColumnName("image_url");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("status");

                    b.Property<int>("TargetFund")
                        .HasColumnType("integer")
                        .HasColumnName("targetfund");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_galangan_dana");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_galangan_dana_user_id");

                    b.ToTable("galangan_dana", (string)null);
                });

            modelBuilder.Entity("if3250_2022_19_filantropi_backend.Models.TransactionHistory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Date")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("date");

                    b.Property<string>("DonasiId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("donasi_id");

                    b.Property<string>("GalanganDanaId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("galangan_dana_id");

                    b.Property<string>("Nominal")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("nominal");

                    b.HasKey("Id")
                        .HasName("pk_transaction_history");

                    b.ToTable("transaction_history", (string)null);
                });

            modelBuilder.Entity("if3250_2022_19_filantropi_backend.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<int>("DonationAmount")
                        .HasColumnType("integer")
                        .HasColumnName("donation_amount");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("text")
                        .HasColumnName("image_url");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("password");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("role");

                    b.Property<float>("Saldo")
                        .HasColumnType("real")
                        .HasColumnName("saldo");

                    b.HasKey("Id")
                        .HasName("pk_users");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("if3250_2022_19_filantropi_backend.Models.Doa", b =>
                {
                    b.HasOne("if3250_2022_19_filantropi_backend.Models.GalanganDana", "GalanganDana")
                        .WithMany()
                        .HasForeignKey("GalangDanaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_doa_galangan_dana_galang_dana_id");

                    b.HasOne("if3250_2022_19_filantropi_backend.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_doa_users_user_id");

                    b.Navigation("GalanganDana");

                    b.Navigation("User");
                });

            modelBuilder.Entity("if3250_2022_19_filantropi_backend.Models.Donasi", b =>
                {
                    b.HasOne("if3250_2022_19_filantropi_backend.Models.GalanganDana", "GalanganDana")
                        .WithMany()
                        .HasForeignKey("GalangDanaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_donasi_galangan_dana_galang_dana_id");

                    b.HasOne("if3250_2022_19_filantropi_backend.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_donasi_users_user_id");

                    b.Navigation("GalanganDana");

                    b.Navigation("User");
                });

            modelBuilder.Entity("if3250_2022_19_filantropi_backend.Models.GalanganDana", b =>
                {
                    b.HasOne("if3250_2022_19_filantropi_backend.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_galangan_dana_users_user_id");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
