﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using pdf_sorter.Data;

#nullable disable

namespace pdf_sorter.Migrations
{
    [DbContext(typeof(ProcessingMetadataContext))]
    [Migration("20230227012402_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.3");

            modelBuilder.Entity("pdf_sorter.Data.ProcessEvent", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("CompleteTime")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ProcessEvents");
                });

            modelBuilder.Entity("pdf_sorter.Data.ProcessedFile", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PONumber")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ProcessedDateTime")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ProcessedZipId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ProcessedZipId");

                    b.ToTable("ProcessedFiles");
                });

            modelBuilder.Entity("pdf_sorter.Data.ProcessedZip", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastUpdateDateTime")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ProcessEventId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ProcessEventId");

                    b.ToTable("ProcessedZips");
                });

            modelBuilder.Entity("pdf_sorter.Data.ProcessedFile", b =>
                {
                    b.HasOne("pdf_sorter.Data.ProcessedZip", "ProcessedZip")
                        .WithMany("ProcessedFiles")
                        .HasForeignKey("ProcessedZipId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProcessedZip");
                });

            modelBuilder.Entity("pdf_sorter.Data.ProcessedZip", b =>
                {
                    b.HasOne("pdf_sorter.Data.ProcessEvent", "ProcessEvent")
                        .WithMany("ProcessedZips")
                        .HasForeignKey("ProcessEventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProcessEvent");
                });

            modelBuilder.Entity("pdf_sorter.Data.ProcessEvent", b =>
                {
                    b.Navigation("ProcessedZips");
                });

            modelBuilder.Entity("pdf_sorter.Data.ProcessedZip", b =>
                {
                    b.Navigation("ProcessedFiles");
                });
#pragma warning restore 612, 618
        }
    }
}
