﻿// <auto-generated />
using Covid19.Stats.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Covid19.Stats.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.13");

            modelBuilder.Entity("Covid19.Stats.Data.CovidStat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Active")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Confirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("CountryRegion")
                        .HasColumnType("TEXT");

                    b.Property<int>("Deaths")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ProvinceState")
                        .HasColumnType("TEXT");

                    b.Property<int>("Recovered")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Stats");
                });
#pragma warning restore 612, 618
        }
    }
}
