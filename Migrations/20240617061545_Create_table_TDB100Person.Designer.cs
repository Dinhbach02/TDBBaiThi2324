﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace TDBBaiThi2324.Migrations
{
    [DbContext(typeof(PersonData))]
    [Migration("20240617061545_Create_table_TDB100Person")]
    partial class Create_table_TDB100Person
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.6");

            modelBuilder.Entity("TDBBaiThi2324.Models.TDB100Person", b =>
                {
                    b.Property<string>("PersonID")
                        .HasColumnType("TEXT");

                    b.Property<int>("Age")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(21)
                        .HasColumnType("TEXT");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("PersonID");

                    b.ToTable("TDB100Person");

                    b.HasDiscriminator<string>("Discriminator").HasValue("TDB100Person");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("TDBBaiThi2324.Models.TDB100Emmployee", b =>
                {
                    b.HasBaseType("TDBBaiThi2324.Models.TDB100Person");

                    b.ToTable("TDB100Person");

                    b.HasDiscriminator().HasValue("TDB100Emmployee");
                });
#pragma warning restore 612, 618
        }
    }
}
