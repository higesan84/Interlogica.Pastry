﻿// <auto-generated />
using System;
using Interlogica.Pastry.BackEnd.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Interlogica.Pastry.BackEnd.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20211014081657_Refactor")]
    partial class Refactor
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.11");

            modelBuilder.Entity("Interlogica.Pastry.BackEnd.Data.Confectionery", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("BakingDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("Confectioneries");
                });

            modelBuilder.Entity("Interlogica.Pastry.BackEnd.Data.ConfectioneryIngredient", b =>
                {
                    b.Property<int>("ConfectoneryId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IngredientId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ConfectioneryId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ConfectoneryId", "IngredientId");

                    b.HasIndex("ConfectioneryId");

                    b.HasIndex("IngredientId");

                    b.ToTable("ConfectioneryIngredient");
                });

            modelBuilder.Entity("Interlogica.Pastry.BackEnd.Data.Ingredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("MeasureUnit")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<double>("Quantity")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("Interlogica.Pastry.BackEnd.Data.ConfectioneryIngredient", b =>
                {
                    b.HasOne("Interlogica.Pastry.BackEnd.Data.Confectionery", "Confectionery")
                        .WithMany("ConfectioneryIngredients")
                        .HasForeignKey("ConfectioneryId");

                    b.HasOne("Interlogica.Pastry.BackEnd.Data.Ingredient", "Ingredient")
                        .WithMany()
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Confectionery");

                    b.Navigation("Ingredient");
                });

            modelBuilder.Entity("Interlogica.Pastry.BackEnd.Data.Confectionery", b =>
                {
                    b.Navigation("ConfectioneryIngredients");
                });
#pragma warning restore 612, 618
        }
    }
}
