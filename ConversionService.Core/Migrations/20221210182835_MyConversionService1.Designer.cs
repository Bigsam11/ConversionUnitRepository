﻿// <auto-generated />
using System;
using ConversionService.Core.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ConversionService.Core.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20221210182835_MyConversionService1")]
    partial class MyConversionService1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ConversionService.Core.Entities.Audit", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("API")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("RequestObject")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ResponseObject")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("AUDIT");
                });

            modelBuilder.Entity("ConversionService.Core.Entities.ConversionAction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsActive")
                        .HasMaxLength(200)
                        .HasColumnType("boolean");

                    b.Property<int>("UnitCategory")
                        .HasColumnType("integer");

                    b.Property<string>("UnitNameOfDestination")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<string>("UnitNameOfOrigin")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<float>("ValuePerUnit")
                        .HasColumnType("real");

                    b.Property<float>("ValueResult")
                        .HasColumnType("real");

                    b.Property<float>("valueToConvert")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("CONVERSIONACTION");
                });

            modelBuilder.Entity("ConversionService.Core.Entities.ConversionUnit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsActive")
                        .HasMaxLength(200)
                        .HasColumnType("boolean");

                    b.Property<int>("UnitCategory")
                        .HasColumnType("integer");

                    b.Property<string>("UnitNameOfDestination")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<string>("UnitNameOfOrigin")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<float>("ValuePerUnit")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("CONVERSIONUNIT");
                });

            modelBuilder.Entity("ConversionService.Core.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<bool>("IsActive")
                        .HasMaxLength(200)
                        .HasColumnType("boolean");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.HasKey("Id");

                    b.ToTable("user");
                });

            modelBuilder.Entity("ConversionService.Core.Entities.ConversionAction", b =>
                {
                    b.HasOne("ConversionService.Core.Entities.User", null)
                        .WithMany("ConversionActions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ConversionService.Core.Entities.ConversionUnit", b =>
                {
                    b.HasOne("ConversionService.Core.Entities.User", null)
                        .WithMany("ConversionUnits")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ConversionService.Core.Entities.User", b =>
                {
                    b.Navigation("ConversionActions");

                    b.Navigation("ConversionUnits");
                });
#pragma warning restore 612, 618
        }
    }
}
