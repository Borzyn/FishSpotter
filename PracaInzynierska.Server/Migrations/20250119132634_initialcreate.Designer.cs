﻿// <auto-generated />
using FishSpotter.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FishSpotter.Server.Migrations
{
    [DbContext(typeof(FishSpotterServerContext))]
    [Migration("20250119132634_initialcreate")]
    partial class initialcreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BaitModelMethodModel", b =>
                {
                    b.Property<string>("BaitId")
                        .HasColumnType("varchar(36)");

                    b.Property<string>("MethodsName")
                        .HasColumnType("varchar(36)");

                    b.HasKey("BaitId", "MethodsName");

                    b.HasIndex("MethodsName");

                    b.ToTable("BaitModelMethodModel");
                });

            modelBuilder.Entity("FishSpotter.Server.Models.DataBase.AccountModel", b =>
                {
                    b.Property<string>("Username")
                        .HasColumnType("varchar(32)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(32)");

                    b.Property<string>("PostsCount")
                        .IsRequired()
                        .HasColumnType("varchar(8)");

                    b.Property<string>("Score")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.HasKey("Username");

                    b.ToTable("AccountModel");
                });

            modelBuilder.Entity("FishSpotter.Server.Models.DataBase.BaitModel", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(36)");

                    b.Property<string>("Size")
                        .IsRequired()
                        .HasColumnType("varchar(4)");

                    b.HasKey("Id");

                    b.ToTable("BaitModel");
                });

            modelBuilder.Entity("FishSpotter.Server.Models.DataBase.FishModel", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("varchar(36)");

                    b.Property<string>("MethodModelName")
                        .HasColumnType("varchar(36)");

                    b.HasKey("Name");

                    b.HasIndex("MethodModelName");

                    b.ToTable("FishModel");
                });

            modelBuilder.Entity("FishSpotter.Server.Models.DataBase.GroundbaitModel", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(36)");

                    b.HasKey("Id");

                    b.ToTable("GroundbaitModel");
                });

            modelBuilder.Entity("FishSpotter.Server.Models.DataBase.IngredientModel", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(36)");

                    b.Property<string>("GroundbaitModelId")
                        .HasColumnType("varchar(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(36)");

                    b.HasKey("Id");

                    b.HasIndex("GroundbaitModelId");

                    b.ToTable("IngredientModel");
                });

            modelBuilder.Entity("FishSpotter.Server.Models.DataBase.MapModel", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("varchar(36)");

                    b.Property<string>("FishModelName")
                        .HasColumnType("varchar(36)");

                    b.Property<string>("Fishes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("X")
                        .IsRequired()
                        .HasColumnType("varchar(4)");

                    b.Property<string>("Y")
                        .IsRequired()
                        .HasColumnType("varchar(4)");

                    b.HasKey("Name");

                    b.HasIndex("FishModelName");

                    b.ToTable("MapModel");
                });

            modelBuilder.Entity("FishSpotter.Server.Models.DataBase.MethodModel", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("varchar(36)");

                    b.HasKey("Name");

                    b.ToTable("MethodModel");
                });

            modelBuilder.Entity("FishSpotter.Server.Models.DataBase.PostModel", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(36)");

                    b.Property<string>("AccountModelUsername")
                        .HasColumnType("varchar(32)");

                    b.Property<string>("fishName")
                        .HasColumnType("varchar(36)");

                    b.Property<string>("rate")
                        .IsRequired()
                        .HasColumnType("varchar(8)");

                    b.Property<string>("userID")
                        .IsRequired()
                        .HasColumnType("varchar(36)");

                    b.HasKey("Id");

                    b.HasIndex("AccountModelUsername");

                    b.HasIndex("fishName");

                    b.ToTable("PostModel");
                });

            modelBuilder.Entity("FishSpotter.Server.Models.DataBase.SpotModel", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(36)");

                    b.Property<string>("AdditionalInfo")
                        .IsRequired()
                        .HasColumnType("varchar(4)");

                    b.Property<string>("FishModelName")
                        .HasColumnType("varchar(36)");

                    b.Property<string>("MapName")
                        .HasColumnType("varchar(36)");

                    b.Property<string>("X")
                        .IsRequired()
                        .HasColumnType("varchar(4)");

                    b.Property<string>("Y")
                        .IsRequired()
                        .HasColumnType("varchar(4)");

                    b.HasKey("Id");

                    b.HasIndex("FishModelName");

                    b.HasIndex("MapName");

                    b.ToTable("SpotModel");
                });

            modelBuilder.Entity("GroundbaitModelMethodModel", b =>
                {
                    b.Property<string>("GroundbaitId")
                        .HasColumnType("varchar(36)");

                    b.Property<string>("MethodsName")
                        .HasColumnType("varchar(36)");

                    b.HasKey("GroundbaitId", "MethodsName");

                    b.HasIndex("MethodsName");

                    b.ToTable("GroundbaitModelMethodModel");
                });

            modelBuilder.Entity("BaitModelMethodModel", b =>
                {
                    b.HasOne("FishSpotter.Server.Models.DataBase.BaitModel", null)
                        .WithMany()
                        .HasForeignKey("BaitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FishSpotter.Server.Models.DataBase.MethodModel", null)
                        .WithMany()
                        .HasForeignKey("MethodsName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FishSpotter.Server.Models.DataBase.FishModel", b =>
                {
                    b.HasOne("FishSpotter.Server.Models.DataBase.MethodModel", null)
                        .WithMany("Fish")
                        .HasForeignKey("MethodModelName");
                });

            modelBuilder.Entity("FishSpotter.Server.Models.DataBase.IngredientModel", b =>
                {
                    b.HasOne("FishSpotter.Server.Models.DataBase.GroundbaitModel", null)
                        .WithMany("Ingredients")
                        .HasForeignKey("GroundbaitModelId");
                });

            modelBuilder.Entity("FishSpotter.Server.Models.DataBase.MapModel", b =>
                {
                    b.HasOne("FishSpotter.Server.Models.DataBase.FishModel", null)
                        .WithMany("Maps")
                        .HasForeignKey("FishModelName");
                });

            modelBuilder.Entity("FishSpotter.Server.Models.DataBase.PostModel", b =>
                {
                    b.HasOne("FishSpotter.Server.Models.DataBase.AccountModel", null)
                        .WithMany("Posts")
                        .HasForeignKey("AccountModelUsername");

                    b.HasOne("FishSpotter.Server.Models.DataBase.FishModel", "fish")
                        .WithMany("Posts")
                        .HasForeignKey("fishName");

                    b.Navigation("fish");
                });

            modelBuilder.Entity("FishSpotter.Server.Models.DataBase.SpotModel", b =>
                {
                    b.HasOne("FishSpotter.Server.Models.DataBase.FishModel", null)
                        .WithMany("Spots")
                        .HasForeignKey("FishModelName");

                    b.HasOne("FishSpotter.Server.Models.DataBase.MapModel", "Map")
                        .WithMany("Spots")
                        .HasForeignKey("MapName");

                    b.Navigation("Map");
                });

            modelBuilder.Entity("GroundbaitModelMethodModel", b =>
                {
                    b.HasOne("FishSpotter.Server.Models.DataBase.GroundbaitModel", null)
                        .WithMany()
                        .HasForeignKey("GroundbaitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FishSpotter.Server.Models.DataBase.MethodModel", null)
                        .WithMany()
                        .HasForeignKey("MethodsName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FishSpotter.Server.Models.DataBase.AccountModel", b =>
                {
                    b.Navigation("Posts");
                });

            modelBuilder.Entity("FishSpotter.Server.Models.DataBase.FishModel", b =>
                {
                    b.Navigation("Maps");

                    b.Navigation("Posts");

                    b.Navigation("Spots");
                });

            modelBuilder.Entity("FishSpotter.Server.Models.DataBase.GroundbaitModel", b =>
                {
                    b.Navigation("Ingredients");
                });

            modelBuilder.Entity("FishSpotter.Server.Models.DataBase.MapModel", b =>
                {
                    b.Navigation("Spots");
                });

            modelBuilder.Entity("FishSpotter.Server.Models.DataBase.MethodModel", b =>
                {
                    b.Navigation("Fish");
                });
#pragma warning restore 612, 618
        }
    }
}
