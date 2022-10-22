﻿// <auto-generated />
using EntityFrameworkLazyAndStuff.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EntityFrameworkLazyAndStuff.Infrastructure.Migrations
{
    [DbContext(typeof(LocalDbContext))]
    [Migration("20221020181446_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EntityFrameworkLazyAndStuff.Infrastructure.Entities.MaTestModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MaTestModels");
                });

            modelBuilder.Entity("EntityFrameworkLazyAndStuff.Infrastructure.Entities.OtherTestModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("MaTestId")
                        .HasColumnType("int");

                    b.Property<int>("MaTetModelId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MaTestId");

                    b.ToTable("OtherTestModels");
                });

            modelBuilder.Entity("EntityFrameworkLazyAndStuff.Infrastructure.Entities.OtherTestModel", b =>
                {
                    b.HasOne("EntityFrameworkLazyAndStuff.Infrastructure.Entities.MaTestModel", "MaTest")
                        .WithMany()
                        .HasForeignKey("MaTestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MaTest");
                });
#pragma warning restore 612, 618
        }
    }
}
