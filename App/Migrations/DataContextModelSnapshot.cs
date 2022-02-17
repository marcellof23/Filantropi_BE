// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using if3250_2022_19_filantropi_backend.Data;

namespace if3250_2022_19_filantropi_backend.Migrations
{
  [DbContext(typeof(DataContext))]
  partial class VehicleQuotesContextModelSnapshot : ModelSnapshot
  {
    protected override void BuildModel(ModelBuilder modelBuilder)
    {
#pragma warning disable 612, 618
      modelBuilder
               .HasAnnotation("ProductVersion", "6.0.2")
               .HasAnnotation("Relational:MaxIdentifierLength", 63);

      NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

      modelBuilder.Entity("if3250_2022_35_cakrawala_backend.Models.User", b =>
          {

            b.Property<long>("Id")
              .ValueGeneratedOnAdd()
              .HasColumnType("bigint")
              .HasColumnName("id");

            b.Property<string>("UserName")
              .HasColumnType("text")
              .HasColumnName("username");

            b.Property<long>("Balance")
              .HasColumnType("bigint")
              .HasColumnName("balance");

            b.Property<string>("DisplayName")
              .IsRequired()
              .HasColumnType("text")
              .HasColumnName("display_name");

            b.Property<string>("Email")
              .IsRequired()
              .HasColumnType("text")
              .HasColumnName("email");

            b.Property<string>("EncryptedPassword")
              .IsRequired()
              .HasColumnType("text")
              .HasColumnName("encrypted_password");

            b.Property<long>("Exp")
              .HasColumnType("bigint")
              .HasColumnName("exp");

            NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

            b.HasKey("Email");

            b.HasIndex("Email")
                      .IsUnique();

            b.ToTable("users", (string)null);
          });

#pragma warning restore 612, 618
    }
  }
}