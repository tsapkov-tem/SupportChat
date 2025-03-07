﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SupportChat.Core.Data.Entities;

#nullable disable

namespace SupportChat.Core.Data.Entities.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    [Migration("20250223181915_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.2");

            modelBuilder.Entity("SupportChat.Core.Data.Entities.Models.Problem", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("ProblemEvaluation")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProblemStatus")
                        .HasColumnType("INTEGER");

                    b.Property<string>("StartMessage")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Problems");
                });

            modelBuilder.Entity("SupportChat.Core.Data.Entities.Models.ProblemLog", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ProblemId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SupportId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ProblemId");

                    b.HasIndex("SupportId");

                    b.ToTable("ProblemLogs");
                });

            modelBuilder.Entity("SupportChat.Core.Data.Entities.Models.Support", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("SupportProfileId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("SupportType")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("SupportProfileId")
                        .IsUnique();

                    b.ToTable("Supports");
                });

            modelBuilder.Entity("SupportChat.Core.Data.Entities.Models.SupportProfile", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("SupportProfiles");
                });

            modelBuilder.Entity("SupportChat.Core.Data.Entities.Models.ProblemLog", b =>
                {
                    b.HasOne("SupportChat.Core.Data.Entities.Models.Problem", "Problem")
                        .WithMany("ProblemLogs")
                        .HasForeignKey("ProblemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SupportChat.Core.Data.Entities.Models.Support", "Support")
                        .WithMany("ProblemLogs")
                        .HasForeignKey("SupportId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Problem");

                    b.Navigation("Support");
                });

            modelBuilder.Entity("SupportChat.Core.Data.Entities.Models.Support", b =>
                {
                    b.HasOne("SupportChat.Core.Data.Entities.Models.SupportProfile", "SupportProfile")
                        .WithOne("Support")
                        .HasForeignKey("SupportChat.Core.Data.Entities.Models.Support", "SupportProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SupportProfile");
                });

            modelBuilder.Entity("SupportChat.Core.Data.Entities.Models.Problem", b =>
                {
                    b.Navigation("ProblemLogs");
                });

            modelBuilder.Entity("SupportChat.Core.Data.Entities.Models.Support", b =>
                {
                    b.Navigation("ProblemLogs");
                });

            modelBuilder.Entity("SupportChat.Core.Data.Entities.Models.SupportProfile", b =>
                {
                    b.Navigation("Support");
                });
#pragma warning restore 612, 618
        }
    }
}
