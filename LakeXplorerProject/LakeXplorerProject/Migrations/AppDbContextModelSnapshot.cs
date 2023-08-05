﻿// <auto-generated />
using LakeXplorerProject.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LakeXplorerProject.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LakeXplorerProject.Models.Lake", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("ImageData")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Lakes");
                });

            modelBuilder.Entity("LakeXplorerProject.Models.LakeSighting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LakeId")
                        .HasColumnType("int");

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<double>("Longitude")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("LakeId");

                    b.ToTable("LakeSightings");
                });

            modelBuilder.Entity("LakeXplorerProject.Models.Like", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("LakeSightingId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LakeSightingId");

                    b.ToTable("Likes");
                });

            modelBuilder.Entity("LakeXplorerProject.Models.LakeSighting", b =>
                {
                    b.HasOne("LakeXplorerProject.Models.Lake", "Lake")
                        .WithMany("LakeSightings")
                        .HasForeignKey("LakeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lake");
                });

            modelBuilder.Entity("LakeXplorerProject.Models.Like", b =>
                {
                    b.HasOne("LakeXplorerProject.Models.LakeSighting", "LakeSightings")
                        .WithMany()
                        .HasForeignKey("LakeSightingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LakeSightings");
                });

            modelBuilder.Entity("LakeXplorerProject.Models.Lake", b =>
                {
                    b.Navigation("LakeSightings");
                });
#pragma warning restore 612, 618
        }
    }
}
