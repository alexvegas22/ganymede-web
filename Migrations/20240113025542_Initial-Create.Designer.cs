﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ganymede_web.Data;

#nullable disable

namespace ganymede_web.Migrations
{
    [DbContext(typeof(ganymede_webContext))]
    [Migration("20240113025542_Initial-Create")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.0");

            modelBuilder.Entity("ganymede_web.Models.Benevole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Age")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LibreFinDeSemaine")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LibreJourFeries")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nom")
                        .HasColumnType("TEXT");

                    b.Property<string>("NomEtablissement")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .HasColumnType("TEXT");

                    b.Property<bool>("RecuFormationPremierSoins")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("rolePreferee")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Benevole");
                });

            modelBuilder.Entity("ganymede_web.Models.Horaire", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BenevoleID")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Role")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("BenevoleID");

                    b.ToTable("Horaire");
                });

            modelBuilder.Entity("ganymede_web.Models.Horaire", b =>
                {
                    b.HasOne("ganymede_web.Models.Benevole", "Benevole")
                        .WithMany()
                        .HasForeignKey("BenevoleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Benevole");
                });
#pragma warning restore 612, 618
        }
    }
}
