﻿// <auto-generated />
using System;
using Covid19.Stats.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Covid19.Stats.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220714073854_RemoveOldFields")]
    partial class RemoveOldFields
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<float>("Case_Fatality_Ratio")
                        .HasColumnType("REAL");

                    b.Property<string>("Combined_key")
                        .HasColumnType("TEXT");

                    b.Property<int>("Confirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Country_Region")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<int>("Death")
                        .HasColumnType("INTEGER");

                    b.Property<float>("Incident_Rate")
                        .HasColumnType("REAL");

                    b.Property<DateTime>("Last_Update")
                        .HasColumnType("TEXT");

                    b.Property<float>("Lat")
                        .HasColumnType("REAL");

                    b.Property<float>("Long")
                        .HasColumnType("REAL");

                    b.Property<string>("Province_State")
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