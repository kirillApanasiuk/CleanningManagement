// <auto-generated />
using System;
using CleanningManagement.Infrastructure.Data.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CleanningManagement.Infrastructure.Data.Migrations
{
    [DbContext(typeof(CleanningManagementDbContext))]
    [Migration("20220322081031_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CleaningManagement.Domain.Entities.CleanningPlan", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.ToTable("CleanningPlans");

                    b.HasData(
                        new
                        {
                            Id = new Guid("183eef1f-e4eb-489d-bd3d-720443bce7c2"),
                            CreatedAt = new DateTime(2022, 3, 22, 11, 10, 30, 941, DateTimeKind.Local).AddTicks(8577),
                            CustomerId = 1,
                            Description = "Simple cleanning plan",
                            Title = "Simple"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
