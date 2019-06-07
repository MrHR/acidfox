﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using acidfox_api.Models;

namespace acidfox_api.Migrations
{
    [DbContext(typeof(AcidFoxContext))]
    partial class AcidFoxContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("acidfox_api.Models.Member", b =>
                {
                    b.Property<int>("MemberId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<bool>("Called");

                    b.Property<int>("Called_Count");

                    b.Property<string>("First_Name");

                    b.Property<DateTime?>("Last_Called");

                    b.Property<string>("Last_Name");

                    b.Property<string>("Notes");

                    b.Property<string>("Phone");

                    b.Property<int>("Rating");

                    b.HasKey("MemberId");

                    b.HasIndex("MemberId")
                        .IsUnique()
                        .HasAnnotation("Npgsql:IndexInclude", new[] { "Last_Name" });

                    b.ToTable("Members");
                });
#pragma warning restore 612, 618
        }
    }
}
