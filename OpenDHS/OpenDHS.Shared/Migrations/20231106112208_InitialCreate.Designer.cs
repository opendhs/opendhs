﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Opensalus.Shared;

#nullable disable

namespace Opensalus.Shared.Migrations
{
    [DbContext(typeof(DbContextClass))]
    [Migration("20231106112208_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.13");

            modelBuilder.Entity("Opensalus.Services.MediaEntity", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<byte[]>("FileData")
                        .HasColumnType("BLOB");

                    b.Property<string>("FileName")
                        .HasColumnType("TEXT");

                    b.Property<int>("FileType")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.ToTable("FileDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
