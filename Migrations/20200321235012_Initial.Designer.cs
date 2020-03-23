﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MilesBoxApi.Models;

namespace MilesBoxApi.Migrations
{
    [DbContext(typeof(ModelContext))]
    [Migration("20200321235012_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2");

            modelBuilder.Entity("MilesBoxApi.Models.Box", b =>
                {
                    b.Property<int>("BoxId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("BoxId");

                    b.HasIndex("UserId");

                    b.ToTable("Boxes");
                });

            modelBuilder.Entity("MilesBoxApi.Models.Measurement", b =>
                {
                    b.Property<int>("MeasurementId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BoxId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SensorId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TimeStamp")
                        .HasColumnType("INTEGER");

                    b.Property<float>("Value")
                        .HasColumnType("REAL");

                    b.HasKey("MeasurementId");

                    b.HasIndex("BoxId");

                    b.HasIndex("SensorId");

                    b.ToTable("Measurements");
                });

            modelBuilder.Entity("MilesBoxApi.Models.Sensor", b =>
                {
                    b.Property<int>("SensorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Unit")
                        .HasColumnType("TEXT");

                    b.HasKey("SensorId");

                    b.ToTable("Sensors");
                });

            modelBuilder.Entity("MilesBoxApi.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ApiKey")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MilesBoxApi.Models.Box", b =>
                {
                    b.HasOne("MilesBoxApi.Models.User", "User")
                        .WithMany("Boxes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MilesBoxApi.Models.Measurement", b =>
                {
                    b.HasOne("MilesBoxApi.Models.Box", "Box")
                        .WithMany("Measurements")
                        .HasForeignKey("BoxId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MilesBoxApi.Models.Sensor", "Sensor")
                        .WithMany()
                        .HasForeignKey("SensorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
