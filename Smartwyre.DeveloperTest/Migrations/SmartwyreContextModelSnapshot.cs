﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Smartwyre.DeveloperTest.Data;

#nullable disable

namespace Smartwyre.DeveloperTest.Migrations
{
    [DbContext(typeof(SmartwyreContext))]
    partial class SmartwyreContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Smartwyre.DeveloperTest.Types.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Identifier")
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<int>("SupportedIncentives")
                        .HasColumnType("integer");

                    b.Property<string>("Uom")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Smartwyre.DeveloperTest.Types.Entities.Rebate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric");

                    b.Property<string>("Identifier")
                        .HasColumnType("text");

                    b.Property<int>("Incentive")
                        .HasColumnType("integer");

                    b.Property<decimal>("Percentage")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("Rebates");
                });

            modelBuilder.Entity("Smartwyre.DeveloperTest.Types.RebateCalculation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric");

                    b.Property<string>("Identifier")
                        .HasColumnType("text");

                    b.Property<int>("IncentiveType")
                        .HasColumnType("integer");

                    b.Property<string>("RebateIdentifier")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("RebateCalculations");
                });
#pragma warning restore 612, 618
        }
    }
}
