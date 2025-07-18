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
    [Migration("20250610145450_UserAndPostUpdate3")]
    partial class UserAndPostUpdate3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FishModelMapModel", b =>
                {
                    b.Property<string>("FishesName")
                        .HasColumnType("varchar(36)");

                    b.Property<string>("MapsName")
                        .HasColumnType("varchar(36)");

                    b.HasKey("FishesName", "MapsName");

                    b.HasIndex("MapsName");

                    b.ToTable("FishModelMapModel");
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

                    b.Property<string>("RateAmount")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<string>("RateSum")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.HasKey("Username");

                    b.ToTable("AccountModel");
                });

            modelBuilder.Entity("FishSpotter.Server.Models.DataBase.BaitModel", b =>
                {
                    b.Property<string>("Id")
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

                    b.HasKey("Name");

                    b.ToTable("FishModel");
                });

            modelBuilder.Entity("FishSpotter.Server.Models.DataBase.GroundbaitModel", b =>
                {
                    b.Property<string>("GBName")
                        .HasColumnType("varchar(36)");

                    b.HasKey("GBName");

                    b.ToTable("GroundbaitModel");
                });

            modelBuilder.Entity("FishSpotter.Server.Models.DataBase.IngredientModel", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(36)");

                    b.Property<string>("GroundbaitModelGBName")
                        .HasColumnType("varchar(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(36)");

                    b.HasKey("Id");

                    b.HasIndex("GroundbaitModelGBName");

                    b.ToTable("IngredientModel");
                });

            modelBuilder.Entity("FishSpotter.Server.Models.DataBase.MapModel", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("varchar(36)");

                    b.HasKey("Name");

                    b.ToTable("MapModel");
                });

            modelBuilder.Entity("FishSpotter.Server.Models.DataBase.MethodModel", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(36)");

                    b.Property<string>("BaitIds")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BaitModelId")
                        .HasColumnType("varchar(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(36)");

                    b.HasKey("Id");

                    b.HasIndex("BaitModelId");

                    b.ToTable("MethodModel");
                });

            modelBuilder.Entity("FishSpotter.Server.Models.DataBase.PostModel", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(36)");

                    b.Property<string>("AccountModelUsername")
                        .HasColumnType("varchar(32)");

                    b.Property<string>("AdditionalInfo")
                        .IsRequired()
                        .HasColumnType("varchar(80)");

                    b.Property<string>("BaitId")
                        .IsRequired()
                        .HasColumnType("varchar(36)");

                    b.Property<string>("FishModelName")
                        .HasColumnType("varchar(36)");

                    b.Property<string>("FishName")
                        .IsRequired()
                        .HasColumnType("varchar(24)");

                    b.Property<string>("MapName")
                        .IsRequired()
                        .HasColumnType("varchar(24)");

                    b.Property<string>("MethodId")
                        .HasColumnType("varchar(36)");

                    b.Property<string>("MethodName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SpotID")
                        .IsRequired()
                        .HasColumnType("varchar(36)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(36)");

                    b.Property<string>("groundbaitId")
                        .IsRequired()
                        .HasColumnType("varchar(36)");

                    b.Property<string>("rateAmount")
                        .IsRequired()
                        .HasColumnType("varchar(24)");

                    b.Property<string>("rateSum")
                        .IsRequired()
                        .HasColumnType("varchar(24)");

                    b.HasKey("Id");

                    b.HasIndex("AccountModelUsername");

                    b.HasIndex("BaitId");

                    b.HasIndex("FishModelName");

                    b.HasIndex("MethodId");

                    b.HasIndex("SpotID");

                    b.HasIndex("groundbaitId");

                    b.ToTable("PostModel");
                });

            modelBuilder.Entity("FishSpotter.Server.Models.DataBase.SpotModel", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(36)");

                    b.Property<string>("Map")
                        .IsRequired()
                        .HasColumnType("varchar(36)");

                    b.Property<string>("MapModelName")
                        .HasColumnType("varchar(36)");

                    b.Property<string>("XY")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.HasKey("Id");

                    b.HasIndex("MapModelName");

                    b.ToTable("SpotModel");
                });

            modelBuilder.Entity("FishModelMapModel", b =>
                {
                    b.HasOne("FishSpotter.Server.Models.DataBase.FishModel", null)
                        .WithMany()
                        .HasForeignKey("FishesName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FishSpotter.Server.Models.DataBase.MapModel", null)
                        .WithMany()
                        .HasForeignKey("MapsName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FishSpotter.Server.Models.DataBase.IngredientModel", b =>
                {
                    b.HasOne("FishSpotter.Server.Models.DataBase.GroundbaitModel", null)
                        .WithMany("Ingredients")
                        .HasForeignKey("GroundbaitModelGBName");
                });

            modelBuilder.Entity("FishSpotter.Server.Models.DataBase.MethodModel", b =>
                {
                    b.HasOne("FishSpotter.Server.Models.DataBase.BaitModel", null)
                        .WithMany("Methods")
                        .HasForeignKey("BaitModelId");
                });

            modelBuilder.Entity("FishSpotter.Server.Models.DataBase.PostModel", b =>
                {
                    b.HasOne("FishSpotter.Server.Models.DataBase.AccountModel", null)
                        .WithMany("Posts")
                        .HasForeignKey("AccountModelUsername");

                    b.HasOne("FishSpotter.Server.Models.DataBase.BaitModel", "Bait")
                        .WithMany()
                        .HasForeignKey("BaitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FishSpotter.Server.Models.DataBase.FishModel", null)
                        .WithMany("Posts")
                        .HasForeignKey("FishModelName");

                    b.HasOne("FishSpotter.Server.Models.DataBase.MethodModel", "Method")
                        .WithMany()
                        .HasForeignKey("MethodId");

                    b.HasOne("FishSpotter.Server.Models.DataBase.SpotModel", "Spot")
                        .WithMany()
                        .HasForeignKey("SpotID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FishSpotter.Server.Models.DataBase.GroundbaitModel", "groundbait")
                        .WithMany()
                        .HasForeignKey("groundbaitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bait");

                    b.Navigation("Method");

                    b.Navigation("Spot");

                    b.Navigation("groundbait");
                });

            modelBuilder.Entity("FishSpotter.Server.Models.DataBase.SpotModel", b =>
                {
                    b.HasOne("FishSpotter.Server.Models.DataBase.MapModel", null)
                        .WithMany("Spots")
                        .HasForeignKey("MapModelName");
                });

            modelBuilder.Entity("FishSpotter.Server.Models.DataBase.AccountModel", b =>
                {
                    b.Navigation("Posts");
                });

            modelBuilder.Entity("FishSpotter.Server.Models.DataBase.BaitModel", b =>
                {
                    b.Navigation("Methods");
                });

            modelBuilder.Entity("FishSpotter.Server.Models.DataBase.FishModel", b =>
                {
                    b.Navigation("Posts");
                });

            modelBuilder.Entity("FishSpotter.Server.Models.DataBase.GroundbaitModel", b =>
                {
                    b.Navigation("Ingredients");
                });

            modelBuilder.Entity("FishSpotter.Server.Models.DataBase.MapModel", b =>
                {
                    b.Navigation("Spots");
                });
#pragma warning restore 612, 618
        }
    }
}
