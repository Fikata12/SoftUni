﻿// <auto-generated />
using ForumApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ForumApp.Data.Migrations
{
    [DbContext(typeof(ForumAppDbContext))]
    [Migration("20230601220243_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ForumApp.Data.Models.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(1500)
                        .HasColumnType("nvarchar(1500)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Posts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed ut dictum libero. Nulla facilisi. Integer accumsan ullamcorper magna et tristique.",
                            Title = "Post No.1"
                        },
                        new
                        {
                            Id = 2,
                            Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed ut dictum libero. Nulla facilisi. Integer accumsan ullamcorper magna et tristique.",
                            Title = "Post No.2"
                        },
                        new
                        {
                            Id = 3,
                            Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed ut dictum libero. Nulla facilisi. Integer accumsan ullamcorper magna et tristique.",
                            Title = "Post No.3"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
