﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using portfolio.DataAccess.Data;

#nullable disable

namespace portfolio.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("portfolio.Models.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("GitRepositoryUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("Id");

                    b.ToTable("Projects");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer gravida felis in ultrices molestie.",
                            GitRepositoryUrl = "git",
                            ImageUrl = "images/project-img.png",
                            Name = "Project"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer gravida felis in ultrices molestie.",
                            GitRepositoryUrl = "git",
                            ImageUrl = "images/project-img.png",
                            Name = "Project"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer gravida felis in ultrices molestie.",
                            GitRepositoryUrl = "git",
                            ImageUrl = "images/project-img.png",
                            Name = "Project"
                        });
                });

            modelBuilder.Entity("portfolio.Models.Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()

                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("Id");

                    b.ToTable("Skills");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ImageUrl = "images/csharp.png",
                            Name = "C#"
                        },
                        new
                        {
                            Id = 2,
                            ImageUrl = "images/csharp.png",
                            Name = "C#2"
                        },
                        new
                        {
                            Id = 3,
                            ImageUrl = "images/csharp.png",
                            Name = "C#3"
                        },
                        new
                        {
                            Id = 4,
                            ImageUrl = "images/csharp.png",
                            Name = "C#4"
                        },
                        new
                        {
                            Id = 5,
                            ImageUrl = "images/csharp.png",
                            Name = "C#5"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
